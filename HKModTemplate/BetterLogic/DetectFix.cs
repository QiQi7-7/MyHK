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
    public class DetectFix : Module
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
            //二见刺球刷脸
            if (self.gameObject.name.Contains("Barb Region") && self.FsmName == "Spawn Barbs")
            {
                GameObject hero = GameObject.Find("Knight");
                if (hero != null)
                {
                    self.AddState("Redo 1");
                    self.AddTransition("Spawn 1", "REDO", "Redo 1");
                    self.AddTransition("Redo 1", "FINISHED", "Spawn 1");

                    self.InsertCustomAction("Spawn 1", () =>
                    {
                        if(Vector3.Distance(hero.transform.position, self.FsmVariables.FindFsmVector3("Spawn Pos").Value) < 3f)
                        {
                            self.SendEvent("REDO");
                        }
                    }, 3);
                    self.InsertCustomAction("Spawn 2", () =>
                    {
                        if (Vector3.Distance(hero.transform.position, self.FsmVariables.FindFsmVector3("Spawn Pos").Value) < 3f)
                        {
                            self.SendEvent("REDO");
                        }
                    }, 3);
                    self.InsertCustomAction("Spawn 3", () =>
                    {
                        if (Vector3.Distance(hero.transform.position, self.FsmVariables.FindFsmVector3("Spawn Pos").Value) < 3f)
                        {
                            self.SendEvent("REDO");
                        }
                    }, 3);
                }
            }

            //光球刷脸
            if(self.gameObject.name == "Absolute Radiance" && self.FsmName == "Attack Commands")
            {
                GameObject hero = GameObject.Find("Knight");
                if (hero != null)
                {
                    self.InsertCustomAction("Orb Pos", () =>
                    {
                        if (Vector3.Distance(hero.transform.position, self.FsmVariables.FindFsmVector3("Fireball Pos").Value) < 3f)
                        {
                            self.SendEvent("RESET");
                        }
                    }, 3);
                }
            }
            orig(self);
        }
    }
}

