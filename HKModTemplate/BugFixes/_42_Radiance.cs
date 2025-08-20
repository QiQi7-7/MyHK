using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using System.Data;

namespace MyHK.BugFixes
{
    public class _42_Radiance : Module
    {
        private static List<GameObject> orbs = new List<GameObject>();

        public override void Load()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
            On.PlayMakerFSM.OnDestroy += PlayMakerFSM_OnDestroy;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
            On.PlayMakerFSM.OnDestroy -= PlayMakerFSM_OnDestroy;
            orbs.Clear();
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "Absolute Radiance" && self.FsmName == "Control")
            {
                self.GetAction<SendEventByName>("Stun1 Start", 6).everyFrame = true;
            }
            if (self.gameObject.name == "Absolute Radiance" && self.FsmName == "Phase Control")
            {
                self.AddCustomAction("Set Phase 3", () =>
                {
                    self.gameObject.LocateMyFSM("Control").FsmVariables.FindFsmBool("Please Cast").Value = false;
                });
            }
            if (self.gameObject.name == "Absolute Radiance" && self.FsmName == "Attack Commands")
            {
                self.AddCustomAction("Final Hit", () =>
                {
                    foreach (GameObject orb in orbs)
                    {
                        orb.LocateMyFSM("Orb Control").SendEvent("RECYCLE");
                    }
                });
            }
            if (self.gameObject.name == "Radiant Orb(Clone)" && self.FsmName == "Orb Control")
            {
                orbs.Add(self.gameObject);
                self.GetAction<SetDamageHeroAmount>("Dissipate", 3).damageDealt = 0;
                self.AddGlobalTransition("RECYCLE", "Recycle");
            }
            orig(self);
        }

        private void PlayMakerFSM_OnDestroy(On.PlayMakerFSM.orig_OnDestroy orig, PlayMakerFSM self)
        {
            if(self.gameObject.name == "Absolute Radiance" && self.FsmName == "Attack Commands")
            {
                orbs.Clear();
            }
            if(self.gameObject.name == "Radiant Orb(Clone)" && self.FsmName == "Orb Control")
            {
                orbs.Remove(self.gameObject);
            }
            orig(self);
        }
    }
}