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
    public class _10_OroAndMato : Module
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
            if (self.FsmName == "nailmaster" && self.gameObject.name == "Oro")
            {
                self.AddCustomAction("Call Mato", () =>
                {
                    self.FsmVariables.FindFsmString("Next Move").Value = "";
                });
                self.gameObject.Find("Dash Slash").layer = 22;
            }

            if (self.FsmName == "nailmaster" && self.gameObject.name == "Mato")
            {
                self.AddCustomAction("Cyclone End", () =>
                {
                    self.FsmVariables.FindFsmString("Next Move").Value = "";
                });
                self.AddTransition("Idle", "D SLASH", "D Slash Bro");
                self.AddTransition("Idle", "DO CYCLONE", "Cyclone Bro");
            }
            orig(self);
        }
    }
}