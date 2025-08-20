using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.BetterLogic
{
    public class WarpFix : Module
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
            if (self.gameObject.name == "Ghost Warrior Slug" && self.FsmName == "Movement")
            {
                Recoil recoil = self.gameObject.GetComponent<Recoil>();
                self.AddCustomAction("Warp", () =>
                {
                    CoroutineRunner.Run(CancelRecoil(recoil));
                });
            }

            if (self.gameObject.name == "Ghost Warrior Hu" && self.FsmName == "Movement")
            {
                Recoil recoil = self.gameObject.GetComponent<Recoil>();
                self.AddCustomAction("Warp", () =>
                {
                    CoroutineRunner.Run(CancelRecoil(recoil));
                });
            }

            if (self.gameObject.name == "Ghost Warrior No Eyes" && self.FsmName == "Movement")
            {
                Recoil recoil = self.gameObject.GetComponent<Recoil>();
                self.AddCustomAction("Warp", () =>
                {
                    CoroutineRunner.Run(CancelRecoil(recoil));
                });
            }

            if (self.gameObject.name == "Mage Knight" && self.FsmName == "Mage Knight")
            {
                Recoil recoil = self.gameObject.GetComponent<Recoil>();
                self.AddCustomAction("Up Tele", () =>
                {
                    CoroutineRunner.Run(CancelRecoil(recoil));
                });
                self.AddCustomAction("Side Tele", () =>
                {
                    CoroutineRunner.Run(CancelRecoil(recoil));
                });
            }
            orig(self);
        }

        private System.Collections.IEnumerator CancelRecoil(Recoil recoil)
        {
            yield return new WaitForFixedUpdate();
            recoil.CancelRecoil();
        }
    }
}
