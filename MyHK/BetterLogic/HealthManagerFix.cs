using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.BetterLogic
{
    public class HealthManagerFix : Module
    {
        public override void Load()
        {
            On.HealthManager.Awake += HealthManager_Awake;
            On.HealthManager.Update += HealthManager_Update;
            On.HealthManager.NonFatalHit += HealthManager_NonFatalHit;
            On.HealthManager.Invincible += HealthManager_Invincible;
            On.PlayMakerFSM.Start += PlayMakerFSM_Start;
        }

        public override void Unload()
        {
            On.HealthManager.Awake -= HealthManager_Awake;
            On.HealthManager.Update -= HealthManager_Update;
            On.HealthManager.NonFatalHit -= HealthManager_NonFatalHit;
            On.HealthManager.Invincible -= HealthManager_Invincible;
            On.PlayMakerFSM.Start -= PlayMakerFSM_Start;
        }

        private void PlayMakerFSM_Start(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "Q Mega" && self.FsmName == "Hit Box Control")
            {
                self.AddAction("Activate", new Wait
                {
                    time = 0.18f,
                    finishEvent = FsmEvent.Finished
                });
            }
            orig(self);
        }

        private void HealthManager_Invincible(On.HealthManager.orig_Invincible orig, HealthManager self, HitInstance hitInstance)
        {
            FixedUpdateForHealthManager fixedUpdateForHealthManager = self.gameObject.GetComponent<FixedUpdateForHealthManager>();
            fixedUpdateForHealthManager.StartCountFromInvincible();
            orig(self, hitInstance);
        }

        private void HealthManager_NonFatalHit(On.HealthManager.orig_NonFatalHit orig, HealthManager self, bool ignoreEvasion)
        {
            FixedUpdateForHealthManager fixedUpdateForHealthManager = self.gameObject.GetComponent<FixedUpdateForHealthManager>();
            fixedUpdateForHealthManager.StartCount();
            orig(self, ignoreEvasion);
        }

        private void HealthManager_Update(On.HealthManager.orig_Update orig, HealthManager self)
        {
        }

        private void HealthManager_Awake(On.HealthManager.orig_Awake orig, HealthManager self)
        {
            self.gameObject.AddComponent<FixedUpdateForHealthManager>();
            orig(self);
        }
    }
}
