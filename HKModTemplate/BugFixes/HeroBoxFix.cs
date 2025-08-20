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
    public class HeroBoxFix : Module
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
            if(self.gameObject.name == "Knight" && self.FsmName == "Surface Water")
            {
                self.AddGlobalTransition("LEVEL LOADED", "Cancel All");
            }
            if(self.gameObject.name == "Knight" && self.FsmName == "Dream Nail")
            {
                self.RemoveAction("Warp Effect", 5);
                self.InsertCustomAction("Warp Effect", () =>
                {
                    HeroBox.inactive = true;
                }, 5);
            }
            if (self.gameObject.name == "Knight" && self.FsmName == "Dream Return")
            {
                self.AddGlobalTransition("LEVEL LOADED", "Wait until after");
                self.RemoveAction("Regain Control", 3);
                self.InsertCustomAction("Regain Control", () =>
                {
                    HeroBox.inactive = false;
                }, 3);
            }
            orig(self);
        }

    }
}

