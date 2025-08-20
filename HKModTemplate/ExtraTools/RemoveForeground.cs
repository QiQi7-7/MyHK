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
    public class RemoveForeground : Module
    {
        public RemoveForeground()
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
            if(self.gameObject.name == "Jar Collector" && self.FsmName == "Control")
            {
                if(self.gameObject.scene.name == "GG_Collector" || self.gameObject.scene.name == "GG_Collector_V")
                {
                    GameObject.Destroy(GameObject.Find("Spawn Jar (12)"));
                    GameObject.Destroy(GameObject.Find("Spawn Jar (15)"));
                    GameObject.Destroy(GameObject.Find("GG_scenery_0008_13 (1)"));
                    GameObject.Destroy(GameObject.Find("GG_scenery_0008_13 (2)"));
                }
            }
            orig(self);
        }
    }
}
