using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomAction;
using MyHK.CustomMonoBehaviour;

namespace MyHK.BugFixes
{
    public class _14_Oblobbles : Module
    {
        public override void Load()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if (self.gameObject.name.Contains("Mega Fat Bee") && self.FsmName == "Fatty Fly Attack")
            {
                MotionFreeze motionFreeze = self.gameObject.AddComponent<MotionFreeze>();
                self.AddCustomAction("Shoot Anim", () =>
                {
                    motionFreeze.freezing = true;
                });
                self.InsertCustomAction("Wait", () =>
                {
                    motionFreeze.freezing = false;
                }, 0);
            }
            orig(self);
        }
    }
}