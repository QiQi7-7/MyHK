using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Satchel;
using UnityEngine;
using TMPro;

namespace MyHK.CustomMonoBehaviour
{
    public class StunInfo : MonoBehaviour
    {
        public PlayMakerFSM fsm;
        public bool stop;
        public float off = 3f;
        public Color color = Color.white;
        private TMP_Text text;
        private int stunHitMax;
        private int stunCombo;
        private FsmInt hitsTotal;
        private FsmInt comboCounter;
        private int comboTime;
        private float timer;
        private MeshRenderer meshRenderer;
        private GameObject go;
        private Transform _transform;
        private StringBuilder sb;
        private string s1;
        private string s2;

        public void Start()
        {
            if(fsm != null)
            {
                sb = new StringBuilder();
                UpdateStunInfo();

                if(fsm.gameObject.GetComponent<MeshRenderer>() != null)
                {
                    meshRenderer = fsm.gameObject.GetComponent<MeshRenderer>();
                }
                else
                {
                    meshRenderer = null;
                }
                go = new GameObject();
                text = go.AddComponent<TextMeshPro>();
                if(fsm.GetComponent<HealthManager>() != null)
                {
                    DestoryAfterDeath destoryAfterDeath = go.AddComponent<DestoryAfterDeath>();
                    destoryAfterDeath.healthManager = fsm.GetComponent<HealthManager>();
                    destoryAfterDeath.component = text;
                }
                _transform = fsm.gameObject.transform;

                text.fontSize = 5;
                text.color = color;
                text.alignment = TextAlignmentOptions.Center;
                go.GetComponent<MeshRenderer>().sortingOrder = 1;
            }
            else
            {
                this.enabled = false;
            }
        }

        public void FixedUpdate()
        {
            sb.Clear();
            if (meshRenderer != null && meshRenderer.enabled)
            {
                sb.Append("Total:");
                sb.Append(hitsTotal.Value);
                sb.Append(s1);
                if (fsm.ActiveStateName == "In Combo")
                {
                    sb.Append(comboCounter.Value);
                }
                else
                {
                    sb.Append(0);
                }
                sb.Append(s2);
                if (stop)
                {
                    sb.Append("Stop");
                }
                else
                {
                    sb.Append((int)timer / 100);
                    sb.Append(".");
                    sb.Append((int)timer % 100);
                    timer -= 2;
                    if (timer < 0)
                    {
                        timer = 0;
                    }
                }
            }
            text.text = sb.ToString();
        }

        public void Update()
        {
            go.transform.localPosition = new Vector3(_transform.position.x, _transform.position.y + off, _transform.position.z);
        }

        public void InCombo()
        {
            timer = comboTime;
        }

        public void UpdateStunInfo()
        {
            stunHitMax = fsm.FsmVariables.FindFsmInt("Stun Hit Max").Value + 1;
            stunCombo = fsm.FsmVariables.FindFsmInt("Stun Combo").Value;
            hitsTotal = fsm.FsmVariables.FindFsmInt("Hits Total");
            comboCounter = fsm.FsmVariables.FindFsmInt("Combo Counter");
            comboTime = (int)fsm.FsmVariables.FindFsmFloat("Combo Time").Value * 100;
            s1 = string.Format("/{0}\nCombo:", stunHitMax);
            s2 = string.Format("/{0}\nTimer:", stunCombo);
        }
    }
}