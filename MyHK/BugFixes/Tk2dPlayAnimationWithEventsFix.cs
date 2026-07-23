using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using On.HutongGames.PlayMaker.Actions;
using MyHK.CustomAction;

namespace MyHK.BugFixes
{
    public class Tk2dPlayAnimationWithEventsFix : Module
    {
        private FieldInfo fieldInfo;

        public Tk2dPlayAnimationWithEventsFix()
        {
            Type type = typeof(HutongGames.PlayMaker.Actions.Tk2dPlayAnimationWithEvents);
            fieldInfo = type.GetField("_sprite", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public override void Load()
        {
            On.HutongGames.PlayMaker.Actions.Tk2dPlayAnimationWithEvents.OnEnter += Tk2dPlayAnimationWithEvents_OnEnter;
        }

        public override void Unload()
        {
            On.HutongGames.PlayMaker.Actions.Tk2dPlayAnimationWithEvents.OnEnter -= Tk2dPlayAnimationWithEvents_OnEnter;
        }

        private void Tk2dPlayAnimationWithEvents_OnEnter(On.HutongGames.PlayMaker.Actions.Tk2dPlayAnimationWithEvents.orig_OnEnter orig, HutongGames.PlayMaker.Actions.Tk2dPlayAnimationWithEvents self)
        {
            orig(self);
            GameObject go = self.Fsm.GetOwnerDefaultTarget(self.gameObject);
            tk2dSpriteAnimator _sprite;
            if (go != null)
            {
                _sprite = go.GetComponent<tk2dSpriteAnimator>();
            }
            else
            {
                return;
            }
            if (_sprite == null)
            {
                return;
            }

            float duration = _sprite.GetClipByName(self.clipName.Value).Duration + 0.01f;
            int index = self.State.Actions.Length - 1;

            if (self.State.GetAction(index).ToString() != "MyHK.CustomAction.WaitForAnimaition")
            {
                WaitForAnimaition wait = new WaitForAnimaition
                {
                    time = duration,
                    finishEvent = self.animationCompleteEvent,
                    _sprite = _sprite,
                    clipName = self.clipName,
                };
                self.State.AddAction(wait);
            }
        }
    }
}
