using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;

namespace MyHK.CustomAction
{
    internal class WaitForAnimaition : FsmStateAction
    {
        public override void Reset()
        {
            this.time = 1f;
            this.finishEvent = null;
            this.realTime = false;
        }

        public override void OnEnter()
        {
            if (this.time.Value <= 0f)
            {
                base.Fsm.Event(this.finishEvent);
                base.Finish();
                return;
            }
            this.startTime = FsmTime.RealtimeSinceStartup;
            this.timer = 0f;
        }

        public override void OnUpdate()
        {
            if (this.realTime)
            {
                this.timer = FsmTime.RealtimeSinceStartup - this.startTime;
            }
            else
            {
                this.timer += Time.deltaTime;
            }
            if (this.timer >= this.time.Value)
            {
                if(_sprite.CurrentClip.name != clipName.Value)
                {
                    base.Finish();
                    if (this.finishEvent != null)
                    {
                        base.Fsm.Event(this.finishEvent);
                        _sprite.AnimationCompleted = null;
                    }
                }
            }
        }

        [RequiredField]
        public FsmFloat time;
        public FsmEvent finishEvent;
        public bool realTime;
        private float startTime;
        private float timer;
        public FsmString clipName;
        public tk2dSpriteAnimator _sprite;
    }
}
