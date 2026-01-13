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
//using On.HutongGames.PlayMaker.Actions;

namespace MyHK.BugFixes
{
    public class _23_Collector : Module
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
            if (self.gameObject.name == "Colosseum_Armoured_Roller R(Clone)" && self.FsmName == "Roller")
            {
                PlayMakerFSM fsm = self.gameObject.Find("Bouncer").LocateMyFSM("Detect Bounce");
                fsm.AddState("Wait");
                fsm.AddAction("Wait", new NextFrameEvent
                {
                    sendEvent = FsmEvent.Finished
                });
                fsm.AddTransition("Wait", "FINISHED", "Detect");

                fsm.InsertCustomAction("Send", () =>
                {
                    if (fsm.FsmVariables.FindFsmGameObject("Collider").Value.name == "Colosseum_Armoured_Roller R(Clone)")
                    {
                        GameObject parent = fsm.FsmVariables.FindFsmGameObject("Parent").Value;
                        GameObject collider = fsm.FsmVariables.FindFsmGameObject("Collider").Value;
                        collider.Find("Bouncer").LocateMyFSM("Detect Bounce").SetState("Wait");

                        if (parent.transform.GetPositionX() < collider.transform.GetPositionX())
                        {
                            parent.LocateMyFSM("Roller").SetState("Collide Right");
                            collider.LocateMyFSM("Roller").SetState("Collide Left");
                        }
                        else
                        {
                            parent.LocateMyFSM("Roller").SetState("Collide Left");
                            collider.LocateMyFSM("Roller").SetState("Collide Right");
                        }
                        fsm.SetState("Wait");
                    }
                }, 0);
            }

            if (self.gameObject.name == "Colosseum_Armoured_Mosquito R(Clone)" && self.FsmName == "Mozzie2")
            {
                Wait wait = new Wait
                {
                    time = 0.03f,
                    finishEvent = FsmEvent.Finished
                };
                self.AddAction("Hit Right", wait);
                self.AddAction("Hit Left", wait);
                self.AddAction("Hit Up", wait);
                self.AddAction("Hit Down", wait);
                CheckCollisionSide ccs = new CheckCollisionSide();
                ccs.topHit = new FsmBool(false);
                ccs.bottomHit = new FsmBool(false);
                ccs.leftHit = new FsmBool(false);
                ccs.rightHit = new FsmBool(false);
                ccs.topHitEvent = ccs.bottomHitEvent = ccs.leftHitEvent = ccs.rightHitEvent = self.GetAction<Collision2dEvent>("Lunging", 4).sendEvent;
                ccs.otherLayer = false;
                ccs.otherLayerNumber = 0;
                ccs.ignoreTriggers = false;
                self.AddAction("Lunging", ccs);

                //Collision2dEvent collision2DEvent = Utils.CopyCollision2dEvent(self.GetAction<Collision2dEvent>("Lunging", 4));
                //collision2DEvent.collision = Collision2DType.OnCollisionStay2D;
                //self.AddAction("Lunging", collision2DEvent);
                //collision2DEvent.Fsm.HandleCollisionStay2D = true;

                BoxCollider2D boxCollider2D = self.gameObject.GetComponent<BoxCollider2D>();
                Vector2 size = new Vector2(1.4531f, 0.9375f);
                Vector2 offset = new Vector2(0.0391f, 0.0156f);
                self.AddCustomAction("Pull Out", () =>
                {
                    boxCollider2D.size = size;
                    boxCollider2D.offset = offset;
                });

                self.AddAction("Recover", new SetRecoilSpeed
                {
                    target = self.GetAction<SetRecoilSpeed>("Pull Out", 6).target,
                    newRecoilSpeed = 20f
                });
            }
            orig(self);
        }
    }
}