using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;
using System.Runtime.InteropServices;

namespace MyHK.ExtraFeatures
{
    public class ShowDestination : Module
    {
        GameObject charge;
        GameObject charge1;
        GameObject charge2;
        GameObject charge3;
        GameObject charge4;
        GameObject charge5;
        GameObject charge6;
        GameObject charge7;
        GameObject charge8;

        public ShowDestination()
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
            //戈布
            if (self.gameObject.name == "Ghost Warrior Slug" && self.FsmName == "Movement")
            {
                charge = GameObject.Find("Knight").LocateMyFSM("Spell Control").GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
                charge1 = GameObject.Instantiate(charge);
                charge1.transform.position = self.FsmVariables.GetFsmVector3("P1").Value;
                charge1.SetActive(true);
                charge1.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge2 = GameObject.Instantiate(charge);
                charge2.transform.position = self.FsmVariables.GetFsmVector3("P2").Value;
                charge2.SetActive(true);
                charge2.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge3 = GameObject.Instantiate(charge);
                charge3.transform.position = self.FsmVariables.GetFsmVector3("P3").Value;
                charge3.SetActive(true);
                charge3.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge4 = GameObject.Instantiate(charge);
                charge4.transform.position = self.FsmVariables.GetFsmVector3("P4").Value;
                charge4.SetActive(true);
                charge4.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge5 = GameObject.Instantiate(charge);
                charge5.transform.position = self.FsmVariables.GetFsmVector3("P5").Value;
                charge5.SetActive(true);
                charge5.GetComponent<MeshRenderer>().sortingOrder = 2;
                charge6 = GameObject.Instantiate(charge);
                charge6.transform.position = self.FsmVariables.GetFsmVector3("P6").Value;
                charge6.SetActive(true);
                charge6.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge7 = GameObject.Instantiate(charge);
                charge7.transform.position = self.FsmVariables.GetFsmVector3("P7").Value;
                charge7.SetActive(true);
                charge7.GetComponent<MeshRenderer>().sortingOrder = 1;

                self.AddCustomAction("Set 1", () =>
                {
                    charge1.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 2", () =>
                {
                    charge2.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 3", () =>
                {
                    charge3.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 4", () =>
                {
                    charge4.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 5", () =>
                {
                    charge5.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 6", () =>
                {
                    charge6.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 7", () =>
                {
                    charge7.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });

                self.InsertCustomAction("Choose Target", () =>
                {
                    Color color = new Color(1, 1, 1, 1);
                    charge1.GetComponent<MeshRenderer>().material.color = color;
                    charge2.GetComponent<MeshRenderer>().material.color = color;
                    charge3.GetComponent<MeshRenderer>().material.color = color;
                    charge4.GetComponent<MeshRenderer>().material.color = color;
                    charge5.GetComponent<MeshRenderer>().material.color = color;
                    charge6.GetComponent<MeshRenderer>().material.color = color;
                    charge7.GetComponent<MeshRenderer>().material.color = color;
                }, 0);
            }
            //泽若
            if (self.gameObject.name == "Ghost Warrior Xero" && self.FsmName == "Movement")
            {
                charge = GameObject.Find("Knight").LocateMyFSM("Spell Control").GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
                charge1 = GameObject.Instantiate(charge);
                charge1.transform.position = self.FsmVariables.GetFsmVector3("P1").Value;
                charge1.SetActive(true);
                charge1.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge2 = GameObject.Instantiate(charge);
                charge2.transform.position = self.FsmVariables.GetFsmVector3("P2").Value;
                charge2.SetActive(true);
                charge2.GetComponent<MeshRenderer>().sortingOrder = 1;

                self.AddCustomAction("Set 1", () =>
                {
                    charge1.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 2", () =>
                {
                    charge2.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });

                self.InsertCustomAction("Choose Target", () =>
                {
                    Color color = new Color(1, 1, 1, 1);
                    charge1.GetComponent<MeshRenderer>().material.color = color;
                    charge2.GetComponent<MeshRenderer>().material.color = color;
                }, 0);
            }
            //加利安
            if (self.gameObject.name == "Ghost Warrior Galien" && self.FsmName == "Movement")
            {
                charge = GameObject.Find("Knight").LocateMyFSM("Spell Control").GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
                charge1 = GameObject.Instantiate(charge);
                charge1.transform.position = self.FsmVariables.GetFsmVector3("P1").Value;
                charge1.SetActive(true);
                charge1.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge2 = GameObject.Instantiate(charge);
                charge2.transform.position = self.FsmVariables.GetFsmVector3("P2").Value;
                charge2.SetActive(true);
                charge2.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge3 = GameObject.Instantiate(charge);
                charge3.transform.position = self.FsmVariables.GetFsmVector3("P3").Value;
                charge3.SetActive(true);
                charge3.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge4 = GameObject.Instantiate(charge);
                charge4.transform.position = self.FsmVariables.GetFsmVector3("P4").Value;
                charge4.SetActive(true);
                charge4.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge5 = GameObject.Instantiate(charge);
                charge5.transform.position = self.FsmVariables.GetFsmVector3("P5").Value;
                charge5.SetActive(true);
                charge5.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge6 = GameObject.Instantiate(charge);
                charge6.transform.position = self.FsmVariables.GetFsmVector3("P6").Value;
                charge6.SetActive(true);
                charge6.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge7 = GameObject.Instantiate(charge);
                charge7.transform.position = self.FsmVariables.GetFsmVector3("P7").Value;
                charge7.SetActive(true);
                charge7.GetComponent<MeshRenderer>().sortingOrder = 1;

                self.AddCustomAction("Set 1", () =>
                {
                    charge1.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 2", () =>
                {
                    charge2.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 3", () =>
                {
                    charge3.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 4", () =>
                {
                    charge4.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 5", () =>
                {
                    charge5.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 6", () =>
                {
                    charge6.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 7", () =>
                {
                    charge7.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });

                self.InsertCustomAction("Choose Target", () =>
                {
                    Color color = new Color(1, 1, 1, 1);
                    charge1.GetComponent<MeshRenderer>().material.color = color;
                    charge2.GetComponent<MeshRenderer>().material.color = color;
                    charge3.GetComponent<MeshRenderer>().material.color = color;
                    charge4.GetComponent<MeshRenderer>().material.color = color;
                    charge5.GetComponent<MeshRenderer>().material.color = color;
                    charge6.GetComponent<MeshRenderer>().material.color = color;
                    charge7.GetComponent<MeshRenderer>().material.color = color;
                }, 0);
            }
            //老胡
            if (self.gameObject.name == "Ghost Warrior Hu" && self.FsmName == "Movement")
            {
                charge = GameObject.Find("Knight").LocateMyFSM("Spell Control").GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
                charge1 = GameObject.Instantiate(charge);
                charge1.transform.position = self.FsmVariables.GetFsmVector3("P1").Value;
                charge1.SetActive(true);
                charge1.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge2 = GameObject.Instantiate(charge);
                charge2.transform.position = self.FsmVariables.GetFsmVector3("P2").Value;
                charge2.SetActive(true);
                charge2.GetComponent<MeshRenderer>().sortingOrder = 1;

                self.AddCustomAction("Set 1", () =>
                {
                    charge1.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 2", () =>
                {
                    charge2.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });

                self.InsertCustomAction("Choose Target", () =>
                {
                    Color color = new Color(1, 1, 1, 1);
                    charge1.GetComponent<MeshRenderer>().material.color = color;
                    charge2.GetComponent<MeshRenderer>().material.color = color;
                }, 0);
            }
            //无眼
            if (self.gameObject.name == "Ghost Warrior No Eyes" && self.FsmName == "Movement")
            {
                charge = GameObject.Find("Knight").LocateMyFSM("Spell Control").GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
                charge1 = GameObject.Instantiate(charge);
                charge1.transform.position = self.FsmVariables.GetFsmVector3("P1").Value;
                charge1.SetActive(true);
                charge1.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge2 = GameObject.Instantiate(charge);
                charge2.transform.position = self.FsmVariables.GetFsmVector3("P2").Value;
                charge2.SetActive(true);
                charge2.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge3 = GameObject.Instantiate(charge);
                charge3.transform.position = self.FsmVariables.GetFsmVector3("P3").Value;
                charge3.SetActive(true);
                charge3.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge4 = GameObject.Instantiate(charge);
                charge4.transform.position = self.FsmVariables.GetFsmVector3("P4").Value;
                charge4.SetActive(true);
                charge4.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge5 = GameObject.Instantiate(charge);
                charge5.transform.position = self.FsmVariables.GetFsmVector3("P5").Value;
                charge5.SetActive(true);
                charge5.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge6 = GameObject.Instantiate(charge);
                charge6.transform.position = self.FsmVariables.GetFsmVector3("P6").Value;
                charge6.SetActive(true);
                charge6.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge7 = GameObject.Instantiate(charge);
                charge7.transform.position = self.FsmVariables.GetFsmVector3("P7").Value;
                charge7.SetActive(true);
                charge7.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge8 = GameObject.Instantiate(charge);
                charge8.transform.position = self.FsmVariables.GetFsmVector3("P8").Value;
                charge8.SetActive(true);
                charge8.GetComponent<MeshRenderer>().sortingOrder = 1;

                self.AddCustomAction("Set 1", () =>
                {
                    charge1.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 2", () =>
                {
                    charge2.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 3", () =>
                {
                    charge3.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 4", () =>
                {
                    charge4.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 5", () =>
                {
                    charge5.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 6", () =>
                {
                    charge6.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 7", () =>
                {
                    charge7.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });
                self.AddCustomAction("Set 8", () =>
                {
                    charge8.GetComponent<MeshRenderer>().material.color = new Color(0, 1, 1, 1);
                });

                self.InsertCustomAction("Choose Target", () =>
                {
                    Color color = new Color(1, 1, 1, 1);
                    charge1.GetComponent<MeshRenderer>().material.color = color;
                    charge2.GetComponent<MeshRenderer>().material.color = color;
                    charge3.GetComponent<MeshRenderer>().material.color = color;
                    charge4.GetComponent<MeshRenderer>().material.color = color;
                    charge5.GetComponent<MeshRenderer>().material.color = color;
                    charge6.GetComponent<MeshRenderer>().material.color = color;
                    charge7.GetComponent<MeshRenderer>().material.color = color;
                    charge8.GetComponent<MeshRenderer>().material.color = color;
                }, 0);
            }
            //马爹
            if ((self.gameObject.scene.name == "GG_Ghost_Markoth" || self.gameObject.scene.name == "GG_Ghost_Markoth_V") && self.gameObject.name == "Ghost Warrior Markoth" && self.FsmName == "Movement")
            {
                charge = GameObject.Find("Knight").LocateMyFSM("Spell Control").GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
                charge1 = GameObject.Instantiate(charge);
                charge1.transform.position = self.FsmVariables.GetFsmVector3("P1").Value;
                charge1.SetActive(true);
                charge1.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge2 = GameObject.Instantiate(charge);
                charge2.transform.position = self.FsmVariables.GetFsmVector3("P2").Value;
                charge2.SetActive(true);
                charge2.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge3 = GameObject.Instantiate(charge);
                charge3.transform.position = self.FsmVariables.GetFsmVector3("P3").Value;
                charge3.SetActive(true);
                charge3.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge4 = GameObject.Instantiate(charge);
                charge4.transform.position = self.FsmVariables.GetFsmVector3("P4").Value;
                charge4.SetActive(true);
                charge4.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge5 = GameObject.Instantiate(charge);
                charge5.transform.position = self.FsmVariables.GetFsmVector3("P5").Value;
                charge5.SetActive(true);
                charge5.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge6 = GameObject.Instantiate(charge);
                charge6.transform.position = self.FsmVariables.GetFsmVector3("P6").Value;
                charge6.SetActive(true);
                charge6.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge7 = GameObject.Instantiate(charge);
                charge7.transform.position = self.FsmVariables.GetFsmVector3("P7").Value;
                charge7.SetActive(true);
                charge7.GetComponent<MeshRenderer>().sortingOrder = 1;
                charge8 = GameObject.Instantiate(charge);
                charge8.transform.position = self.FsmVariables.GetFsmVector3("P8").Value;
                charge8.SetActive(true);
                charge8.GetComponent<MeshRenderer>().sortingOrder = 1;

                self.AddCustomAction("Set 1", () =>
                {
                    charge1.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 2", () =>
                {
                    charge2.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 3", () =>
                {
                    charge3.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 4", () =>
                {
                    charge4.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 5", () =>
                {
                    charge5.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 6", () =>
                {
                    charge6.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 7", () =>
                {
                    charge7.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });
                self.AddCustomAction("Set 8", () =>
                {
                    charge8.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 1, 1);
                });

                self.InsertCustomAction("Choose Target", () =>
                {
                    Color color = new Color(1, 1, 1, 1);
                    charge1.GetComponent<MeshRenderer>().material.color = color;
                    charge2.GetComponent<MeshRenderer>().material.color = color;
                    charge3.GetComponent<MeshRenderer>().material.color = color;
                    charge4.GetComponent<MeshRenderer>().material.color = color;
                    charge5.GetComponent<MeshRenderer>().material.color = color;
                    charge6.GetComponent<MeshRenderer>().material.color = color;
                    charge7.GetComponent<MeshRenderer>().material.color = color;
                    charge8.GetComponent<MeshRenderer>().material.color = color;
                }, 0);
            }
            orig(self);
        }
    }
}
