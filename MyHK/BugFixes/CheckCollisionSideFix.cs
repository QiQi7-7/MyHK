using HutongGames.PlayMaker;
//using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using On.HutongGames.PlayMaker.Actions;
using MyHK.CustomAction;

namespace MyHK.BugFixes
{
    public class CheckCollisionSideFix : Module
    {   
        public override void Load()
        {
            CheckCollisionSide.OnExit += CheckCollisionSide_OnExit;
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
        }

        public override void Unload()
        {
            CheckCollisionSide.OnExit -= CheckCollisionSide_OnExit;
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
        }

        private void CheckCollisionSide_OnExit(CheckCollisionSide.orig_OnExit orig, HutongGames.PlayMaker.Actions.CheckCollisionSide self)
        {
            orig(self);
            CoroutineRunner.Run(ResetBool(self));
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if(self.gameObject.name == "Mimic Spider" && self.FsmName == "Climb")
            {
                self.InsertCustomAction("Climbing", () =>
                {
                    self.FsmVariables.FindFsmBool("Wall L").Value = true;
                    self.FsmVariables.FindFsmBool("Wall R").Value = true;
                }, 0);

                self.AddState("Start Climbing 1");
                self.AddAction("Start Climbing 1", new HutongGames.PlayMaker.Actions.NextFrameEvent
                {
                    sendEvent = FsmEvent.Finished
                });
                self.AddState("Start Climbing 2");
                self.AddAction("Start Climbing 2", new HutongGames.PlayMaker.Actions.NextFrameEvent
                {
                    sendEvent = FsmEvent.Finished
                });
                self.ChangeTransition("Not Climbing", "SWAP", "Start Climbing 1");
                self.AddTransition("Start Climbing 1", "FINISHED", "Start Climbing 2");
                self.AddTransition("Start Climbing 2", "FINISHED", "Climbing");

                self.AddState("End Climbing 1");
                self.AddAction("End Climbing 1", new HutongGames.PlayMaker.Actions.NextFrameEvent
                {
                    sendEvent = FsmEvent.Finished
                });
                self.AddState("End Climbing 2");
                self.AddAction("End Climbing 2", new HutongGames.PlayMaker.Actions.NextFrameEvent
                {
                    sendEvent = FsmEvent.Finished
                });
                self.ChangeTransition("Climbing", "SWAP", "End Climbing 1");
                self.AddTransition("End Climbing 1", "FINISHED", "End Climbing 2");
                self.AddTransition("End Climbing 2", "FINISHED", "Not Climbing");
            }
            orig(self);
        }

        private System.Collections.IEnumerator ResetBool(HutongGames.PlayMaker.Actions.CheckCollisionSide self)
        {
            yield return null;
            if(self == null)
            {
                yield break;
            }
            self.topHit.Value = false;
            self.bottomHit.Value = false;
            self.leftHit.Value = false;
            self.rightHit.Value = false;
        }
    }
}
