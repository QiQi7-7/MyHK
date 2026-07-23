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
    public class _29_Sly : Module
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
            if (self.gameObject.name.Contains("Sly Boss") && self.FsmName == "Control")
            {
                GameObject hero = GameObject.Find("Knight");
                GameObject gs1 = self.gameObject.Find("GS1");

                gs1.GetComponent<PolygonCollider2D>().points = hero.Find("Attacks").Find("Great Slash").GetComponent<PolygonCollider2D>().points;
                gs1.SetScale(2.5f, 2.5f);
            }
            orig(self);
        }
    }
}

