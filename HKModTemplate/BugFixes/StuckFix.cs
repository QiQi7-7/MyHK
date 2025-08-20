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
            SetIsKinematic2d.OnEnter += SetIsKinematic2d_OnEnter;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
            SetIsKinematic2d.OnEnter -= SetIsKinematic2d_OnEnter;
        }

        private void SetIsKinematic2d_OnEnter(SetIsKinematic2d.orig_OnEnter orig, HutongGames.PlayMaker.Actions.SetIsKinematic2d self)
        {
            EdgeDetector edgeDetector = self.Owner.GetComponent<EdgeDetector>();
            if (edgeDetector != null)
            {
                edgeDetector.flag = !self.isKinematic.Value;
            }
            orig(self);
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "Hornet Boss 2" && self.FsmName == "Control")
            {
                if (self.gameObject.scene.name == "GG_Hornet_2")
                {
                    EdgeDetector edgeDetector = self.gameObject.AddComponent<EdgeDetector>();
                    BoxCollider2D[] boxColliders = GameObject.Find("Terrain Saver").GetComponents<BoxCollider2D>();
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
                    edgeDetector.distance = 0.2f;
                    edgeDetector.detectType = EdgeDetector.DetectType.easy;
                }
            }
            orig(self);
        }
    }
}