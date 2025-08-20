using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.ExtraTools
{
    public class TwoHitKills : Module
    {
        private Type type;
        private FieldInfo ignoreAcid;
        private FieldInfo directionOfLastAttack;
        private FieldInfo sendHitTo;
        private FieldInfo recoil;
        private FieldInfo enemyType;
        private FieldInfo strikeNailPrefab;
        private FieldInfo slashImpactPrefab;
        private FieldInfo fireballHitPrefab;
        private FieldInfo sharpShadowImpactPrefab;
        private FieldInfo effectOrigin;
        private FieldInfo hitEffectReceiver;
        private FieldInfo stunControlFSM;
        private MethodInfo NonFatalHit;

        public TwoHitKills()
        {
            this.Setting = 0;
            type = typeof(HealthManager);
            ignoreAcid = type.GetField("ignoreAcid", BindingFlags.Instance | BindingFlags.NonPublic);
            directionOfLastAttack = type.GetField("directionOfLastAttack", BindingFlags.Instance | BindingFlags.NonPublic);
            sendHitTo = type.GetField("sendHitTo", BindingFlags.Instance | BindingFlags.NonPublic);
            recoil = type.GetField("recoil", BindingFlags.Instance | BindingFlags.NonPublic);
            enemyType = type.GetField("enemyType", BindingFlags.Instance | BindingFlags.NonPublic);
            strikeNailPrefab = type.GetField("strikeNailPrefab", BindingFlags.Instance | BindingFlags.NonPublic);
            slashImpactPrefab = type.GetField("slashImpactPrefab", BindingFlags.Instance | BindingFlags.NonPublic);
            fireballHitPrefab = type.GetField("fireballHitPrefab", BindingFlags.Instance | BindingFlags.NonPublic);
            sharpShadowImpactPrefab = type.GetField("sharpShadowImpactPrefab", BindingFlags.Instance | BindingFlags.NonPublic);
            effectOrigin = type.GetField("effectOrigin", BindingFlags.Instance | BindingFlags.NonPublic);
            hitEffectReceiver = type.GetField("hitEffectReceiver", BindingFlags.Instance | BindingFlags.NonPublic);
            stunControlFSM = type.GetField("stunControlFSM", BindingFlags.Instance | BindingFlags.NonPublic);
            NonFatalHit = type.GetMethod("NonFatalHit", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public override void Load()
        {
            On.HealthManager.TakeDamage += HealthManager_TakeDamage;
        }

        public override void Unload()
        {
            On.HealthManager.TakeDamage -= HealthManager_TakeDamage;
        }

        private void HealthManager_TakeDamage(On.HealthManager.orig_TakeDamage orig, HealthManager self, HitInstance hitInstance)
        {
            if (hitInstance.AttackType == AttackTypes.Acid && (bool)ignoreAcid.GetValue(self))
            {
                return;
            }
            if (CheatManager.IsInstaKillEnabled)
            {
                hitInstance.DamageDealt = 9999;
            }
            int cardinalDirection = DirectionUtils.GetCardinalDirection(hitInstance.GetActualDirection(self.gameObject.transform));
            directionOfLastAttack.SetValue(self, cardinalDirection);
            FSMUtility.SendEventToGameObject(self.gameObject, "HIT", false);
            FSMUtility.SendEventToGameObject(hitInstance.Source, "HIT LANDED", false);
            FSMUtility.SendEventToGameObject(self.gameObject, "TOOK DAMAGE", false);
            if (sendHitTo.GetValue(self) != null)
            {
                FSMUtility.SendEventToGameObject((GameObject)sendHitTo.GetValue(self), "HIT", false);
            }
            if (recoil.GetValue(self) != null)
            {
                ((Recoil)recoil.GetValue(self)).RecoilByDirection(cardinalDirection, hitInstance.MagnitudeMultiplier);
            }
            switch (hitInstance.AttackType)
            {
                case AttackTypes.Nail:
                case AttackTypes.NailBeam:
                    {
                        if (hitInstance.AttackType == AttackTypes.Nail && (int)enemyType.GetValue(self) != 3 && (int)enemyType.GetValue(self) != 6)
                        {
                            HeroController.instance.SoulGain();
                        }
                        Vector3 position = (hitInstance.Source.transform.position + self.gameObject.transform.position) * 0.5f + (Vector3)effectOrigin.GetValue(self);
                        ((GameObject)strikeNailPrefab.GetValue(self)).Spawn(position, Quaternion.identity);
                        GameObject gameObject = ((GameObject)slashImpactPrefab.GetValue(self)).Spawn(position, Quaternion.identity);
                        switch (cardinalDirection)
                        {
                            case 0:
                                gameObject.transform.SetRotation2D((float)UnityEngine.Random.Range(340, 380));
                                gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
                                break;
                            case 1:
                                gameObject.transform.SetRotation2D((float)UnityEngine.Random.Range(70, 110));
                                gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
                                break;
                            case 2:
                                gameObject.transform.SetRotation2D((float)UnityEngine.Random.Range(340, 380));
                                gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
                                break;
                            case 3:
                                gameObject.transform.SetRotation2D((float)UnityEngine.Random.Range(250, 290));
                                gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
                                break;
                        }
                        break;
                    }
                case AttackTypes.Generic:
                    ((GameObject)strikeNailPrefab.GetValue(self)).Spawn(self.gameObject.transform.position + (Vector3)effectOrigin.GetValue(self), Quaternion.identity).transform.SetPositionZ(0.0031f);
                    break;
                case AttackTypes.Spell:
                    ((GameObject)fireballHitPrefab.GetValue(self)).Spawn(self.gameObject.transform.position + (Vector3)effectOrigin.GetValue(self), Quaternion.identity).transform.SetPositionZ(0.0031f);
                    break;
                case AttackTypes.SharpShadow:
                    ((GameObject)sharpShadowImpactPrefab.GetValue(self)).Spawn(self.gameObject.transform.position + (Vector3)effectOrigin.GetValue(self), Quaternion.identity);
                    break;
            }
            if (((IHitEffectReciever)hitEffectReceiver.GetValue(self)) != null && hitInstance.AttackType != AttackTypes.RuinsWater)
            {
                ((IHitEffectReciever)hitEffectReceiver.GetValue(self)).RecieveHitEffect(hitInstance.GetActualDirection(self.gameObject.transform));
            }
            int num = Mathf.RoundToInt((float)hitInstance.DamageDealt * hitInstance.Multiplier);
            if (self.damageOverride)
            {
                num = 1;
            }

            if(self.hp - num <= 0)
            {
                self.hp -= num;
            }
            else if(self.hp > 1)
            {
                self.hp = 1;
            }
            else
            {
                self.hp = 0;
            }

            if (self.hp > 0)
            {
                NonFatalHit.Invoke(self, new object[] { hitInstance.IgnoreInvulnerable });
                if ((PlayMakerFSM)stunControlFSM.GetValue(self))
                {
                    ((PlayMakerFSM)stunControlFSM.GetValue(self)).SendEvent("STUN DAMAGE");
                    return;
                }
            }
            else
            {
                self.Die(new float?(hitInstance.GetActualDirection(self.gameObject.transform)), hitInstance.AttackType, hitInstance.IgnoreInvulnerable);
            }
        }
    }
}
