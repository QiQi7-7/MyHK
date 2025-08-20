using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.ExtraTools
{
    public class ShowStunInfo : Module
    {
        public ShowStunInfo()
        {
            this.Setting = 0;
        }

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
            if(self.FsmName == "Stun Control" || self.FsmName == "Stun")
            {
                StunInfo StunInfo = self.gameObject.AddComponent<StunInfo>();
                StunInfo.fsm = self;
                self.AddCustomAction("Stop", () =>
                {
                    StunInfo.stop = true;
                });
                self.AddCustomAction("Reset Counter", () =>
                {
                    StunInfo.stop = false;
                });
                self.AddCustomAction("In Combo", () =>
                {
                    StunInfo.InCombo();
                });

                if (self.gameObject.name == "Hornet Boss 1")
                {
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "Hornet Boss 2")
                {
                    StunInfo.color = Color.red;
                }
                if (self.gameObject.name == "Dung Defender")
                {
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "Mage Lord" || self.gameObject.name == "Dream Mage Lord")
                {
                    StunInfo.off = 4f;
                    StunInfo.color = Color.yellow;
                }
                if (self.gameObject.name == "Infected Knight" || self.gameObject.name == "Lost Kin")
                {
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "Sheo Boss")
                {
                    StunInfo.off = 3.5f;
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "Hive Knight")
                {
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "Jar Collector")
                {
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "Grimm Boss" || self.gameObject.name == "Nightmare Grimm Boss")
                {
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "Sly Boss")
                {
                    StunInfo.off = 2.5f;
                    StunInfo.color = Color.red;
                }
                if (self.gameObject.name == "Grey Prince")
                {
                    self.gameObject.LocateMyFSM("Control").InsertCustomAction("Dormant", () =>
                    {
                        StunInfo.UpdateStunInfo();
                    }, 0);
                    StunInfo.off = 2f;
                    StunInfo.color = Color.cyan;
                }
                if (self.gameObject.name == "HK Prime")
                {
                    StunInfo.color = Color.red;
                }
            }
            orig(self);
        }
    }
}
