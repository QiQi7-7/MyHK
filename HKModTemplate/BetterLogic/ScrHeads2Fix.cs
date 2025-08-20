using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;
using UnityEngine.PlayerLoop;

namespace MyHK.BetterLogic
{
    public class ScrHeads2Fix : Module
    {
        public override void Load()
        {
            On.PlayMakerFSM.Start += PlayMakerFSM_Start;
            On.HeroController.FlipSprite += HeroController_FlipSprite;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.Start -= PlayMakerFSM_Start;
            On.HeroController.FlipSprite -= HeroController_FlipSprite;
        }

        private void PlayMakerFSM_Start(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "Scr Heads 2" && self.FsmName == "FSM")
            {
                self.InsertCustomAction("Destroy", () =>
                {
                    self.gameObject.transform.localScale = new Vector3(2.5203f, 2.5203f, 2.5203f);
                }, 0);
            }
            orig(self);
        }

        private void HeroController_FlipSprite(On.HeroController.orig_FlipSprite orig, HeroController self)
        {
            orig(self);
            GameObject scr = self.gameObject.Find("Spells").Find("Scr Heads 2");
            if (scr.activeInHierarchy == true)
            {
                scr.transform.localScale = new Vector3(scr.transform.localScale.x * -1, 2.5203f, 2.5203f);
            }
        }
    }
}
