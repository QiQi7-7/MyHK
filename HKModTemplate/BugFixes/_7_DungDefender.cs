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
    public class _7_DungDefender : Module
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
            if (self.gameObject.name == "Dung Defender" && self.FsmName == "Dung Defender")
            {
                self.AddCustomAction("Stun Land", () =>
                {
                    self.FsmVariables.FindFsmInt("Rages").Value = 0;
                });

                self.AddState("Update Scene");
                self.ChangeTransition("Wake", "FINISHED", "Update Scene");
                self.AddTransition("Update Scene", "FINISHED", "Underground");
                self.AddCustomAction("Update Scene", () =>
                {
                    GameObject chunk1 = GameObject.Find("Chunk 0 1");
                    GameObject chunk2 = GameObject.Find("Chunk 0 2");
                    if (chunk1 != null && chunk2 != null)
                    {
                        EdgeCollider2D edge1 = chunk1.GetComponent<EdgeCollider2D>();
                        EdgeCollider2D edge2 = chunk2.GetComponent<EdgeCollider2D>();

                        if(self.gameObject.scene.name == "Waterways_05_boss")
                        {
                            if(edge1.pointCount == 12 && edge1.points[2] == new Vector2(32, 0) && edge1.points[3] == new Vector2(32, 6))
                            {
                                if (edge2.pointCount == 6 && edge2.points[2] == new Vector2(32, 0) && edge2.points[3] == new Vector2(32, 6))
                                {
                                    edge1.points = new Vector2[]
                                    {
                                        new Vector2(0, 1),
                                        new Vector2(0, 0),
                                        new Vector2(28, 0),
                                        new Vector2(28, 10),
                                        new Vector2(11, 10),
                                        new Vector2(11, 11),
                                        new Vector2(6, 11),
                                        new Vector2(6 ,10),
                                        new Vector2(0 ,10),
                                        new Vector2(0, 10)
                                    };
                                    edge2.points = new Vector2[]
                                    {
                                        new Vector2(-4, 1),
                                        new Vector2(-4, 0),
                                        new Vector2(32, 0),
                                        new Vector2(32, 6),
                                        new Vector2(-4 ,6),
                                        new Vector2(-4 ,1)
                                    };
                                }
                            }
                        }
                        else if(self.gameObject.scene.name == "GG_Dung_Defender")
                        {
                            if (edge1.pointCount == 10 && edge1.points[2] == new Vector2(32, 0) && edge1.points[3] == new Vector2(32, 6))
                            {
                                if (edge2.pointCount == 10 && edge2.points[2] == new Vector2(32, 0) && edge2.points[3] == new Vector2(32, 32))
                                {
                                    edge1.points = new Vector2[]
                                    {
                                        new Vector2(0, 1),
                                        new Vector2(0, 0),
                                        new Vector2(28, 0),
                                        new Vector2(28, 6),
                                        new Vector2(28, 21),
                                        new Vector2(32, 21),
                                        new Vector2(32, 32),
                                        new Vector2(0 ,32),
                                        new Vector2(0 ,1)
                                    };
                                    edge2.points = new Vector2[]
                                    {
                                        new Vector2(-4, 1),
                                        new Vector2(-4, 0),
                                        new Vector2(32, 0),
                                        new Vector2(32, 32),
                                        new Vector2(0, 32),
                                        new Vector2(0, 21),
                                        new Vector2(28, 21),
                                        new Vector2(28, 6),
                                        new Vector2(-4 ,6),
                                        new Vector2(-4 ,1)
                                    };
                                }
                            }
                        }
                    }
                });
            }
            orig(self);
        }
    }
}

