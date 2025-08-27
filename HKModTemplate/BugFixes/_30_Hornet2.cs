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
    public class _30_Hornet2 : Module
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
            if (self.gameObject.name == "Hornet Boss 2" && self.FsmName == "Control")
            {
                //低空斜冲
                self.InsertCustomAction("ADash Antic", () =>
                {
                    self.FsmVariables.FindFsmFloat("Air Dash Pause").Value = 999f;
                }, 0);

                //斜冲卡墙
                self.AddAction("A Dash", new CheckMagnitude
                {
                    gameObject = self.gameObject,
                    magnitude = self.FsmVariables.FindFsmFloat("A Dash Speed").Value,
                    fsmEvent = FsmEvent.Finished
                });
                self.AddState("Check Wall");
                self.AddTransition("A Dash", "FINISHED", "Check Wall");
                self.AddTransition("Check Wall", "ROOF", "Hit Roof");
                self.AddTransition("Check Wall", "LAND", "Land Y");
                self.AddTransition("Check Wall", "WALL L", "Wall L");
                self.AddTransition("Check Wall", "WALL R", "Wall R");
                GetPosition getPosition = Utils.CopyGetPosition(self.GetAction<GetPosition>("A Dash", 2));
                FloatCompare floatCompare_T = Utils.CopyFloatCompare(self.GetAction<FloatCompare>("A Dash", 4));
                floatCompare_T.tolerance = 1f;
                FloatCompare floatCompare_B = Utils.CopyFloatCompare(self.GetAction<FloatCompare>("A Dash", 5));
                floatCompare_B.tolerance = 0f;
                FloatCompare floatCompare_L = Utils.CopyFloatCompare(self.GetAction<FloatCompare>("A Dash", 6));
                floatCompare_L.tolerance = 5f;
                FloatCompare floatCompare_R = Utils.CopyFloatCompare(self.GetAction<FloatCompare>("A Dash", 7));
                floatCompare_R.tolerance = 5f;
                self.AddAction("Check Wall", getPosition);
                self.AddAction("Check Wall", floatCompare_T);
                self.AddAction("Check Wall", floatCompare_B);
                self.AddAction("Check Wall", floatCompare_L);
                self.AddAction("Check Wall", floatCompare_R);
                self.RemoveAction("Wall L", 4);
                self.RemoveAction("Wall R", 4);

                //无前摇
                self.RemoveTransition("GDash Antic", "FINISHED");
                self.AddTransition("GDash Antic", "GG BOSS", "G Dash");
                self.GetAction<Tk2dPlayAnimationWithEvents>("GDash Antic", 1).animationCompleteEvent = FsmEvent.GetFsmEvent("GG BOSS");
            }
            orig(self);
        }
    }
}