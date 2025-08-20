using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomAction;

namespace MyHK.BugFixes
{
    public class _5_Hornet1 : Module
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
            if (self.gameObject.name == "Hornet Boss 1" && self.FsmName == "Control")
            {
                self.InsertCustomAction("ADash Antic", () =>
                {
                    self.FsmVariables.FindFsmFloat("Air Dash Pause").Value = 999f;
                }, 0);
            }
            orig(self);
        }
    }
}