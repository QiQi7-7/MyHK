using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.BugFixes
{
    public class StunFix : Module
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
            //连击硬直丢失
            if (self.gameObject.name == "Dung Defender" && self.FsmName == "Dung Defender")
            {
                self.RemoveAction("Set Rage", 0);
            }

            //硬直滑行
            if(self.gameObject.name == "Infected Knight" && self.FsmName == "IK Control")
            {
                self.GetAction<SetVelocity2d>("Stunned",0).everyFrame = true;
            }

            if (self.gameObject.name == "Lost Kin" && self.FsmName == "IK Control")
            {
                self.GetAction<SetVelocity2d>("Stunned", 0).everyFrame = true;
            }

            //硬直滑行，取消硬直
            if (self.gameObject.name == "Sheo Boss" && self.FsmName == "nailmaster_sheo")
            {
                self.InsertCustomAction("Idle", () =>
                {
                    self.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                }, 0);

                self.RemoveTransition("Stun Land", "END");
                self.GetAction<Wait>("Stun Land", 4).finishEvent = FsmEvent.GetFsmEvent("BOW");
                self.AddTransition("Stun Land", "BOW", "Stun Recover");
            }

            //取消硬直
            if (self.gameObject.name == "Sly Boss" && self.FsmName == "Control")
            {
                self.RemoveTransition("Stun", "END");
                self.AddTransition("Stun", "FINAL", "Stun Leave");
                self.GetAction<Wait>("Stun", 0).finishEvent = FsmEvent.GetFsmEvent("FINAL");
            }

            //飞天大草，硬直星爆
            if (self.gameObject.name == "HK Prime" && self.FsmName == "Control")
            {
                self.AddState("Stun In Air");
                self.ChangeTransition("Stun Start", "FINISHED", "Stun In Air");
                self.AddTransition("Stun In Air", "FINISHED", "Stun Air");

                self.AddCustomAction("Stun In Air", () =>
                {
                    if (self.gameObject.transform.GetPositionY() > self.FsmVariables.FindFsmFloat("Stun Land Y").Value)
                    {
                        if (self.gameObject.transform.GetPositionX() < GameObject.Find("Knight").transform.GetPositionX())
                        {
                            self.transform.SetScaleX(1);
                            self.GetComponent<Rigidbody2D>().velocity = new Vector2(-12f, 40f);
                        }
                        else
                        {
                            self.transform.SetScaleX(-1);
                            self.GetComponent<Rigidbody2D>().velocity = new Vector2(12f, 40f);
                        }
                    }
                });

                self.InsertCustomAction("Stun Tele?", () =>
                {
                    self.FsmVariables.FindFsmString("Tele Event").Value = "";
                }, 0);
            }
            orig(self);
        }
    }
}