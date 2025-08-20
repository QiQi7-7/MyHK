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
    public class _15_MantisLord : Module
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
            if (self.gameObject.scene.name == "GG_Mantis_Lords_V" && self.gameObject.name == "Battle Sub" && self.FsmName == "Start")
            {
                //死亡刷新攻击
                self.AddState("Wait To P2");
                self.AddState("Idle?");
                self.ChangeTransition("Reset Sub 2", "FINISHED", "Wait To P2");
                self.ChangeTransition("Reset Sub 2", "NULL", "Wait To P2");
                self.AddTransition("Wait To P2", "FINISHED", "Idle?");
                self.AddTransition("Idle?", "FINISHED", "Choose Move Double");
                self.AddTransition("Idle?", "CANCEL", "Wait To P2");

                self.AddAction("Wait To P2", new Wait()
                {
                    time = 0.1f,
                    finishEvent = FsmEvent.Finished
                });
                self.AddCustomAction("Idle?", () =>
                {
                    if (self.FsmVariables.GetFsmGameObject("Sub 1").Value.LocateMyFSM("Mantis Lord").ActiveStateName == "Sub Idle"
                    && self.FsmVariables.GetFsmGameObject("Sub 2").Value.LocateMyFSM("Mantis Lord").ActiveStateName == "Sub Idle")
                    {
                        self.SendEvent("FINISHED");
                    }
                    else
                    {
                        self.SendEvent("CANCEL");
                    }
                });
            }

            if ((self.gameObject.scene.name == "Fungus2_15_boss" || self.gameObject.scene.name == "GG_Mantis_Lords") && self.gameObject.name == "Battle Sub" && self.FsmName == "Start")
            {
                self.FsmVariables.FindFsmFloat("Centre X").Value = 30.3f;
            }
            orig(self);
        }
    }
}