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
    public class RoarFix : Module
    {
        public override void Load()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
            On.HeroController.RegainControl += HeroController_RegainControl;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
            On.HeroController.RegainControl -= HeroController_RegainControl;
        }

        private void HeroController_RegainControl(On.HeroController.orig_RegainControl orig, HeroController self)
        {
            if (self.controlReqlinquished && !self.cState.dead)
            {
                if (self.gameObject.LocateMyFSM("Roar Lock").ActiveStateName != "Regain Control")
                {
                    self.gameObject.LocateMyFSM("Roar Lock").SetState("Regain Control");
                }
            }
            orig(self);
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "Jar Collector" && self.FsmName == "Control")
            {
                self.AddAction("Stun Start", new SendEventByName
                {
                    eventTarget = self.GetAction<SendEventByName>("Roar End", 0).eventTarget,
                    sendEvent = self.GetAction<SendEventByName>("Roar End", 0).sendEvent,
                    delay = self.GetAction<SendEventByName>("Roar End", 0).delay,
                    everyFrame = self.GetAction<SendEventByName>("Roar End", 0).everyFrame
                });
                self.AddAction("Stun Start", new SendEventByName
                {
                    eventTarget = self.GetAction<SendEventByName>("Roar End", 1).eventTarget,
                    sendEvent = self.GetAction<SendEventByName>("Roar End", 1).sendEvent,
                    delay = self.GetAction<SendEventByName>("Roar End", 1).delay,
                    everyFrame = self.GetAction<SendEventByName>("Roar End", 1).everyFrame
                });
            }
            orig(self);
        }
    }
}