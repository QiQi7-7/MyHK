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
    internal class CheckMagnitude : FsmStateAction
    {
        public override void OnEnter()
        {
            flag = false;
            rb = gameObject.GetComponent<Rigidbody2D>();
            recoil = gameObject.GetAddComponent<Recoil>();
            fieldInfo = typeof(Recoil).GetField("state", BindingFlags.NonPublic | BindingFlags.Instance);
            Type statesEnumType = typeof(Recoil).GetNestedType("States", BindingFlags.NonPublic);
            recoilingEnumValue = Enum.Parse(statesEnumType, "Recoiling");
            num = magnitude * 0.9f;
        }

        public override void OnFixedUpdate()
        {
            if(recoil != null)
            {
                if(fieldInfo.GetValue(recoil).Equals(recoilingEnumValue))
                {
                    flag = false;
                }
                else
                {
                    if (flag)
                    {
                        x2 = rb.position.x;
                        y2 = rb.position.y;
                        x = x2 - x1;
                        y = y2 - y1;
                        if ((float)Math.Sqrt(x * x + y * y) / Time.fixedDeltaTime < num)
                        {
                            base.Fsm.Event(this.fsmEvent);
                        }
                        x1 = x2;
                        y1 = y2;
                    }
                    else
                    {
                        flag = true;
                        x1 = rb.position.x;
                        y1 = rb.position.y;
                    }
                }
            }
            else
            {
                if (flag)
                {
                    x2 = rb.position.x;
                    y2 = rb.position.y;
                    x = x2 - x1;
                    y = y2 - y1;
                    if ((float)Math.Sqrt(x * x + y * y) / Time.fixedDeltaTime < num)
                    {
                        base.Fsm.Event(this.fsmEvent);
                    }
                    x1 = x2;
                    y1 = y2;
                }
                else
                {
                    flag = true;
                    x1 = rb.position.x;
                    y1 = rb.position.y;
                }
            }
        }

        public GameObject gameObject;
        public float magnitude;
        public FsmEvent fsmEvent;
        private Rigidbody2D rb;
        private Recoil recoil;
        private FieldInfo fieldInfo;
        private object recoilingEnumValue;
        private float num;
        private float x1;
        private float y1;
        private float x2;
        private float y2;
        private float x;
        private float y;
        private bool flag;
    }
}
