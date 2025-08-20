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
    public class _4_MossCharger : Module
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
            if (self.gameObject.name == "Mega Moss Charger" && self.FsmName == "Mossy Control")
            {
                self.AddState("Check Direction");
                self.ChangeTransition("Charge", "SUBMERGE", "Check Direction");
                self.AddTransition("Check Direction", "FINISHED", "Submerge 1");

                FsmGameObject fsmGameObject = new FsmGameObject();
                self.GetAction<Collision2dEventLayer>("Charge", 4).storeCollider = fsmGameObject;
                self.AddCustomAction("Check Direction", () =>
                {
                    if (fsmGameObject.Value.name == "wall collider (1)" && self.FsmVariables.FindFsmFloat("Current Charge Speed").Value > 0)
                    {
                        self.SetState("Charge");
                    }
                    else if (fsmGameObject.Value.name == "wall collider" && self.FsmVariables.FindFsmFloat("Current Charge Speed").Value < 0)
                    {
                        self.SetState("Charge");
                    }
                });
            }
            orig(self);
        }
    }
}