using HutongGames.PlayMaker;
//using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomAction;
using MyHK.CustomMonoBehaviour;
using On.HutongGames.PlayMaker.Actions;

namespace MyHK.BugFixes
{
    public class StuckFix : Module
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
            if (self.gameObject.name == "Hornet Boss 2" && self.FsmName == "Control")
            {
                if (self.gameObject.scene.name == "GG_Hornet_2")
                {
                    EdgeDetector edgeDetector = self.gameObject.AddComponent<EdgeDetector>();
                    edgeDetector.RightEdge = 38.06f;
                    edgeDetector.LeftEdge = 14.98f;
                }
                else if(self.gameObject.scene.name == "Deepnest_East_Hornet_boss")
                {
                    EdgeDetector edgeDetector = self.gameObject.AddComponent<EdgeDetector>();
                    edgeDetector.LeftEdge = GameObject.Find("Wall Collider").GetComponent<BoxCollider2D>().bounds.max.x;
                    edgeDetector.RightEdge = GameObject.Find("Wall Collider 2").GetComponent<BoxCollider2D>().bounds.min.x;
                }
            }

            if(self.gameObject.name == "Dung Defender" && self.FsmName == "Dung Defender")
            {
                if(self.gameObject.scene.name == "GG_Dung_Defender" || self.gameObject.scene.name == "Waterways_05_boss")
                {
                    EdgeDetector edgeDetector = self.gameObject.AddComponent<EdgeDetector>();
                    edgeDetector.BottomEdge = 5f;
                }
            }
            orig(self);
        }
    }
}