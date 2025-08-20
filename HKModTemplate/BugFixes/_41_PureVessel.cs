using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;

namespace MyHK.BugFixes
{
    public class _41_PureVessel : Module
    {
        private FieldInfo damage;
        private MethodInfo DoDamage;
        private MethodInfo Burst;

        public _41_PureVessel()
        {
            damage = typeof(SpellFluke).GetField("damage", BindingFlags.Instance | BindingFlags.NonPublic);
            DoDamage = typeof(SpellFluke).GetMethod("DoDamage", BindingFlags.Instance | BindingFlags.NonPublic);
            Burst = typeof(SpellFluke).GetMethod("Burst", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public override void Load()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
            On.SpellFluke.DoDamage += SpellFluke_DoDamage;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
            On.SpellFluke.DoDamage -= SpellFluke_DoDamage;
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "HK Plume Prime(Clone)" && self.FsmName == "FSM")
            {
                self.AddTransition("Init", "HK STUN", "Auto?");
                self.AddTransition("Outside Arena?", "HK STUN", "Auto?");
                self.AddTransition("Shift Y", "HK STUN", "Auto?");
            }
            orig(self);
        }

        private void SpellFluke_DoDamage(On.SpellFluke.orig_DoDamage orig, SpellFluke self, GameObject obj, int upwardRecursionAmount, bool burst)
        {
            HealthManager component = obj.GetComponent<HealthManager>();
            if (component)
            {
                if (component.IsInvincible && obj.tag != "Spell Vulnerable")
                {
                    return;
                }
                if (!component.isDead)
                {
                    component.hp -= (int)damage.GetValue(self);
                    if (component.hp <= 0)
                    {
                        component.Die(new float?(0f), AttackTypes.Generic, false);
                    }
                }
            }
            SpriteFlash component2 = obj.GetComponent<SpriteFlash>();
            if (component2)
            {
                component2.FlashShadowRecharge();
            }
            FSMUtility.SendEventToGameObject(obj.gameObject, "TOOK DAMAGE", false);
            upwardRecursionAmount--;
            if (upwardRecursionAmount > 0 && obj.transform.parent)
            {
                DoDamage.Invoke(self, new object[] { obj.transform.parent.gameObject, upwardRecursionAmount, false });
            }
            else if (upwardRecursionAmount > -1 && obj.transform.parent)
            {
                if(obj.transform.parent.gameObject.name == "HK Prime")
                {
                    DoDamage.Invoke(self, new object[] { obj.transform.parent.gameObject, upwardRecursionAmount, false });
                }
            }
            if (burst)
            {
                Burst.Invoke(self, null);
            }
        }
    }
}