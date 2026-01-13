using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.ExtraFeatures
{
    public class AdjustBackground : Module
    {
        public AdjustBackground()
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
            if (self.gameObject.name == "Boss Control" && self.FsmName == "Control")
            {
                if (self.gameObject.scene.name == "GG_Radiance")
                {
                    GameObject.Destroy(GameObject.Find("GG_gods_ray (2)"));
                    GameObject.Destroy(GameObject.Find("GG_gods_ray (3)"));
                    GameObject.Destroy(GameObject.Find("BlurPlane"));
                    GameObject.Destroy(GameObject.Find("haze2"));
                    GameObject.Destroy(GameObject.Find("haze2 (1)"));
                }
            }
            orig(self);
        }
    }
}
