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
    public class ScrHeadsFix : Module
    {
        public override void Load()
        {
            On.PlayMakerFSM.Start += PlayMakerFSM_Start;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.Start -= PlayMakerFSM_Start;
        }

        private void PlayMakerFSM_Start(On.PlayMakerFSM.orig_Start orig, PlayMakerFSM self)
        {
            if (this.Setting == 1)
            {
                if (self.gameObject.name == "Scr Heads" && self.FsmName == "Hit Box Control")
                {
                    self.ChangeTransition("Init", "FINISHED", "Activate");
                }
            }
            else if (this.Setting == 2)
            {
                if (self.gameObject.name == "Scr Heads" && self.FsmName == "Hit Box Control")
                {
                    self.RemoveAction("Init", 6);
                    self.RemoveAction("Init", 4);
                }
                if (self.gameObject.name == "Scr Heads" && self.FsmName == "FSM")
                {
                    self.RemoveAction("Init", 2);
                    self.gameObject.GetComponent<tk2dSpriteAnimator>().GetClipByName("Scream1").frames[1].triggerEvent = false;
                }
            }
            orig(self);
        }
    }
}
