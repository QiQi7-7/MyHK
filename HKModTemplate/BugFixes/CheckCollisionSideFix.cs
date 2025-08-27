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
            CheckCollisionSide.OnEnter += CheckCollisionSide_OnEnter;
            CheckCollisionSide.OnExit += CheckCollisionSide_OnExit;
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
        }

        public override void Unload()
        {
            CheckCollisionSide.OnEnter -= CheckCollisionSide_OnEnter;
            CheckCollisionSide.OnExit -= CheckCollisionSide_OnExit;
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
        }

        private void CheckCollisionSide_OnEnter(CheckCollisionSide.orig_OnEnter orig, HutongGames.PlayMaker.Actions.CheckCollisionSide self)
        {
            self.topHit.Value = false;
            self.bottomHit.Value = false;
            self.leftHit.Value = false;
            self.rightHit.Value = false;
            orig(self);
        }

        private void CheckCollisionSide_OnExit(CheckCollisionSide.orig_OnExit orig, HutongGames.PlayMaker.Actions.CheckCollisionSide self)
        {
            orig(self);
            self.topHit.Value = false;
            self.bottomHit.Value = false;
            self.leftHit.Value = false;
            self.rightHit.Value = false;
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if(self.gameObject.name == "Mimic Spider" && self.FsmName == "Climb")
            {
                self.InsertCustomAction("Climbing", () =>
                {
                    self.FsmVariables.FindFsmBool("Wall L").Value = true;
                    self.FsmVariables.FindFsmBool("Wall R").Value = true;
                }, 2);
            }
            orig(self);
        }
    }
}
