using System.Collections;
using System.ComponentModel;
using System.Reflection;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using MonoMod.RuntimeDetour;
using Satchel;
using UnityEngine;
using UnityEngine.SceneManagement;
using MyHK.ExtraFeatures;

namespace MyHK.CustomAction
{
    public class ChasePath_coV2 : FsmStateAction
    {
        private List<GameObject> points;
        public ChaseObjectV2 coV2;
        private GameObject target;
        private Rigidbody2D rbTarget;
        private Rigidbody2D rbSelf;
        private float mass;
        private float speedMax;
        private float accelerationForce;
        private float offsetX;
        private float offsetY;
        private int accuracy = 50;
        private Vector2 positionSelf;
        private Vector2 positionTarget;
        private Vector2 velocity;

        public override void Reset()
        {
            //points = new List<GameObject>();
            //point = GameObject.Find("Knight").LocateMyFSM("Spell Control").
            //    GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value;
            //if (point == null)
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
            if (coV2 == null)
            {
                //base.Finish();
                return;
            }
            else
            {
                target = coV2.target.Value;
                speedMax = coV2.speedMax.Value;
                accelerationForce = coV2.accelerationForce.Value;
                offsetX = coV2.offsetX.Value;
                offsetY = coV2.offsetY.Value;
                rbTarget = target.GetComponent<Rigidbody2D>();
                rbSelf = this.Fsm.GameObject.GetComponent<Rigidbody2D>();
                mass = rbSelf.mass;
            }

            points = ExtraFeatures.ShowChasePath.instance.GetPoints();
            foreach (GameObject point in points)
            {
                point.SetActive(true);
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
            //if (flag)
            //{
            //    return;
            //}
            //else
            //{
            //    flag = true;
            //}
            for (int i = 0; i < accuracy; i++)
            {
                Vector2 vector = new Vector2(positionTarget.x + offsetX - positionSelf.x, 
                    positionTarget.y + offsetY - positionSelf.y);
                vector = Vector2.ClampMagnitude(vector, 1f);
                velocity.x += vector.x * accelerationForce / mass * Time.fixedDeltaTime; 
                velocity.y += vector.y * accelerationForce / mass * Time.fixedDeltaTime;
                //Utils.Log("X轴：" + vector.x * accelerationForce + "  Y轴：" + vector.y * accelerationForce);
                Vector2 vector2 = velocity;
                vector2 = Vector2.ClampMagnitude(vector2, speedMax);
                velocity = vector2;
                positionSelf.x += velocity.x * Time.fixedDeltaTime;
                positionSelf.y += velocity.y * Time.fixedDeltaTime;
                points[i].transform.position = positionSelf;
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
