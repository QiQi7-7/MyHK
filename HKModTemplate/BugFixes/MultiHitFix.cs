using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.BugFixes
{
    public class MultiHitFix : Module
    {
        private FieldInfo fieldInfo;

        public MultiHitFix()
        {
            Type selfType = typeof(HeroController);
            fieldInfo = selfType.GetField("invPulse", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public override void Load()
        {
            On.HeroController.Start += HeroController_Start;
            On.HeroController.Invulnerable += HeroController_Invulnerable;
        }

        public override void Unload()
        {
            On.HeroController.Start -= HeroController_Start;
            On.HeroController.Invulnerable -= HeroController_Invulnerable;
        }

        private void HeroController_Start(On.HeroController.orig_Start orig, HeroController self)
        {
            self.gameObject.AddComponent<InvulnerableTimer>();
            orig(self);
        }

        private System.Collections.IEnumerator HeroController_Invulnerable(On.HeroController.orig_Invulnerable orig, HeroController self, float duration)
        {
            self.cState.invulnerable = true;
            InvulnerablePulse invPulse = (InvulnerablePulse)fieldInfo.GetValue(self);
            yield return new WaitForSeconds(0.001f);
            invPulse.startInvulnerablePulse();
            InvulnerableTimer invulnerableTimer = self.gameObject.GetComponent<InvulnerableTimer>();
            invulnerableTimer.timer = duration;
            invulnerableTimer.flag = true;
            yield break;
        }
    }
}