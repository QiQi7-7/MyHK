using System.Collections;
using System.Reflection;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using MonoMod.RuntimeDetour;
using Satchel;
using UnityEngine;

namespace MyHK.CustomAction
{
    internal class ChasePath_Hammer : FsmStateAction
    {
        private List<GameObject> points;
        public ChaseObjectGround cog;
        private GameObject target;
        private Rigidbody2D rbTarget;
        private Rigidbody2D rbSelf;
        private float speedMax;
        private float acceleration;
        private int accuracy = 50;
        private Vector2 positionSelf;
        private Vector2 positionTarget;
        private Vector2 velocity;

        public override void Reset()
        {
            //points = new List<GameObject>();
            //point = GameObject.Find("Knight").LocateMyFSM("Spell Control").
            //    GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
            //if (point == null )
            //{
            //    return;
            //}
            //for (int i = 0; i < accuracy; i++)
            //{
            //    GameObject gameObject = GameObject.Instantiate(point);
            //    gameObject.RemoveComponent<PlayMakerFSM>();
            //    gameObject.SetScale((float)(accuracy - i) / (accuracy * scale), (float)(accuracy - i) / (accuracy * scale));
            //    points.Add(gameObject);
            //}
        }

        public override void OnEnter()
        {
            if (cog == null)
            {
                //base.Finish();
                return;
            }
            else
            {
                target = cog.target.Value;
                speedMax = cog.speedMax.Value;
                acceleration = cog.acceleration.Value;
                rbTarget = target.GetComponent<Rigidbody2D>();
                rbSelf = this.Fsm.GameObject.GetComponent<Rigidbody2D>();
            }

            points = ExtraFeatures.ShowChasePath.instance.GetPoints();
            for (int i = 0; i < accuracy; i++)
            {
                points[i].SetActive(true);
            }
            ShowChasePath();
        }

        public override void OnUpdate()
        {
            ShowChasePath();
        }

        private void ShowChasePath()
        {
            positionSelf = rbSelf.transform.position;
            positionTarget = rbTarget.transform.position;
            velocity = rbSelf.velocity;
            for(int i = 0; i < accuracy; i++)
            {
                velocity.y -= 1;
                if(positionSelf.x < positionTarget.x)
                {
                    velocity.x += acceleration;
                    if(velocity.x > speedMax)
                    {
                        velocity.x = speedMax;
                    }
                    positionSelf.x += velocity.x * Time.fixedDeltaTime;
                    positionSelf.y += velocity.y * Time.fixedDeltaTime;
                    points[i].transform.position = positionSelf;
                }
                else
                {
                    velocity.x -= acceleration;
                    if (velocity.x < -speedMax)
                    {
                        velocity.x = -speedMax;
                    }
                    positionSelf.x += velocity.x * Time.fixedDeltaTime;
                    positionSelf.y += velocity.y * Time.fixedDeltaTime;
                    points[i].transform.position = positionSelf;
                }
            }
        }

        public override void OnExit()
        {
            ExtraFeatures.ShowChasePath.instance.RecyclePoints(points);
            //for (int i = 0; i < accuracy; i++)
            //{
            //    points[i].SetActive(false);
            //}
        }
    }
}
