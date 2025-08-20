using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;

namespace MyHK.BetterLogic
{
    public class _21_HiveKnight : Module
    {
        private static List<GameObject> droppers = new List<GameObject>();

        public override void Load()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
            On.PlayMakerFSM.OnDestroy += PlayMakerFSM_OnDestroy;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
            On.PlayMakerFSM.OnDestroy -= PlayMakerFSM_OnDestroy;
            droppers.Clear();
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if(self.gameObject.name.Contains("Bee Dropper") && self.FsmName == "Control")
            {
                droppers.Add(self.gameObject);
                self.AddGlobalTransition("SPELL", "Spell Death");
            }
            orig(self);
        }

        private void PlayMakerFSM_OnDestroy(On.PlayMakerFSM.orig_OnDestroy orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "Hive Knight" && self.FsmName == "Control")
            {
                foreach (GameObject dropper in droppers)
                {
                    dropper.LocateMyFSM("Control").SendEvent("SPELL");
                }
                droppers.Clear();
            }
            orig(self);
        }
    }
}

