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
using Satchel.Futils;

namespace MyHK.BugFixes
{
    public class _16_Marmu : Module
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
            if (self.gameObject.name == "Ghost Warrior Marmu" && self.FsmName == "Control")
            {
                //反弹霸体
                self.gameObject.AddComponent<FsmObjectBounce>();

                ObjectBounce objectBounce = self.gameObject.GetComponent<ObjectBounce>();
                FsmObjectBounce fsmObjectBounce = self.gameObject.GetComponent<FsmObjectBounce>();
                fsmObjectBounce.bounceFactor = objectBounce.bounceFactor;
                fsmObjectBounce.clips = objectBounce.clips;
                fsmObjectBounce.pitchMax = objectBounce.pitchMax;
                fsmObjectBounce.pitchMin = objectBounce.pitchMin;

                self.gameObject.RemoveComponent<ObjectBounce>();

                self.AddVariable<FsmVector2>("bounceVelocity");
                self.AddState("Hit Bounce");
                self.AddTransition("Chase", "BOUNCE", "Hit Bounce");
                self.AddTransition("Hit Bounce", "FINISHED", "Chase");
                self.AddCustomAction("Hit Bounce", () =>
                {
                    self.gameObject.GetComponent<Rigidbody2D>().velocity = self.FsmVariables.FindFsmVector2("bounceVelocity").Value;
                });

                Wait wait = new Wait
                {
                    time = 0.03f,
                    finishEvent = FsmEvent.Finished
                };
                self.GetAction<SetVelocity2d>("Hit Up", 0).everyFrame = true;
                self.AddAction("Hit Up", wait);
                self.GetAction<SetVelocity2d>("Hit Down", 0).everyFrame = true;
                self.AddAction("Hit Down", wait);
                self.GetAction<SetVelocity2d>("Hit Left", 0).everyFrame = true;
                self.AddAction("Hit Left", wait);
                self.GetAction<SetVelocity2d>("Hit Right", 0).everyFrame = true;
                self.AddAction("Hit Right", wait);

                //急停霸体
                self.AddState("Hit Up Unroll");
                self.AddTransition("Unroll", "HIT UP", "Hit Up Unroll");
                self.AddState("Hit Down Unroll");
                self.AddTransition("Unroll", "HIT DOWN", "Hit Down Unroll");
                self.AddState("Hit Left Unroll");
                self.AddTransition("Unroll", "HIT LEFT", "Hit Left Unroll");
                self.AddState("Hit Right Unroll");
                self.AddTransition("Unroll", "HIT RIGHT", "Hit Right Unroll");
                self.AddState("Hit Voice Unroll");
                self.AddTransition("Hit Up Unroll", "FINISHED", "Hit Voice Unroll");
                self.AddTransition("Hit Down Unroll", "FINISHED", "Hit Voice Unroll");
                self.AddTransition("Hit Left Unroll", "FINISHED", "Hit Voice Unroll");
                self.AddTransition("Hit Right Unroll", "FINISHED", "Hit Voice Unroll");
                self.AddTransition("Hit Voice Unroll", "FINISHED", "Unroll");

                FsmFloat[] fsmFloats = new FsmFloat[self.FsmVariables.FloatVariables.Length + 1];
                for (int i = 0; i < fsmFloats.Length - 1; i++)
                {
                    fsmFloats[i] = self.FsmVariables.FloatVariables[i];
                }
                fsmFloats[fsmFloats.Length - 1] = new FsmFloat("Unroll Timer");
                self.FsmVariables.FloatVariables = fsmFloats;
                FsmBool[] fsmBools = new FsmBool[self.FsmVariables.BoolVariables.Length + 1];
                for (int i = 0; i < fsmBools.Length - 1; i++)
                {
                    fsmBools[i] = self.FsmVariables.BoolVariables[i];
                }
                fsmBools[fsmBools.Length - 1] = new FsmBool("Attacked");
                self.FsmVariables.BoolVariables = fsmBools;

                self.RemoveAction("Unroll", 2);
                self.AddAction("Unroll", new FloatAdd()
                {
                    floatVariable = self.FsmVariables.GetFsmFloat("Unroll Timer"),
                    add = -1f,
                    everyFrame = true,
                    perSecond = true
                });
                self.AddAction("Unroll", new FloatCompare()
                {
                    float1 = self.FsmVariables.GetFsmFloat("Unroll Timer"),
                    float2 = new FsmFloat(0f),
                    tolerance = 0f,
                    equal = FsmEvent.Finished,
                    lessThan = FsmEvent.Finished,
                    greaterThan = null,
                    everyFrame = true
                });
                self.AddAction("Hit Voice Unroll", new AudioStop()
                {
                    gameObject = self.GetAction<AudioStop>("Hit Voice", 0).gameObject
                });
                self.AddAction("Hit Voice Unroll", Utils.CopyAudioPlayerOneShot(self.GetAction<AudioPlayerOneShot>("Hit Voice", 1)));
                self.InsertCustomAction("Antic", () =>
                {
                    self.FsmVariables.GetFsmFloat("Unroll Timer").Value = 0.75f;
                    self.FsmVariables.GetFsmBool("Attacked").Value = false;
                }, 0);

                self.AddCustomAction("Hit Up Unroll", () =>
                {
                    if (self.FsmVariables.GetFsmBool("Attacked").Value == true)
                    {
                        self.SendEvent("FINISHED");
                    }
                    else
                    {
                        self.FsmVariables.GetFsmBool("Attacked").Value = true;
                    }
                });
                self.AddCustomAction("Hit Down Unroll", () =>
                {
                    if (self.FsmVariables.GetFsmBool("Attacked").Value == true)
                    {
                        self.SendEvent("FINISHED");
                    }
                    else
                    {
                        self.FsmVariables.GetFsmBool("Attacked").Value = true;
                    }
                });
                self.AddCustomAction("Hit Left Unroll", () =>
                {
                    if (self.FsmVariables.GetFsmBool("Attacked").Value == true)
                    {
                        self.SendEvent("FINISHED");
                    }
                    else
                    {
                        self.FsmVariables.GetFsmBool("Attacked").Value = true;
                    }
                });
                self.AddCustomAction("Hit Right Unroll", () =>
                {
                    if (self.FsmVariables.GetFsmBool("Attacked").Value == true)
                    {
                        self.SendEvent("FINISHED");
                    }
                    else
                    {
                        self.FsmVariables.GetFsmBool("Attacked").Value = true;
                    }
                });
                Rigidbody2D rb = self.gameObject.GetComponent<Rigidbody2D>();
                self.AddCustomAction("Hit Up Unroll", () =>
                {
                    rb.velocity = new Vector2(0f, 20f);
                });
                self.AddAction("Hit Up Unroll", wait);
                self.AddCustomAction("Hit Down Unroll", () =>
                {
                    rb.velocity = new Vector2(0f, -16f);
                });
                self.AddAction("Hit Down Unroll", wait);
                self.AddCustomAction("Hit Left Unroll", () =>
                {
                    rb.velocity = new Vector2(-16f, 6f);
                });
                self.AddAction("Hit Left Unroll", wait);
                self.AddCustomAction("Hit Right Unroll", () =>
                {
                    rb.velocity = new Vector2(16f, 6f);
                });
                self.AddAction("Hit Right Unroll", wait);
            }
            orig(self);
        }
    }
}