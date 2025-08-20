using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HKMirror.Reflection;
using HutongGames.PlayMaker;
using Modding;
using UnityEngine;
using UnityEngine.Audio;
using Satchel;

namespace MyHK.CustomMonoBehaviour
{
    public class FixedUpdateForHealthManager : MonoBehaviour
    {
        private int count;
        private bool counting;
        private HealthManager healthManager;
        private FieldInfo fieldInfo;

        public void Start()
        {
            count = 0;
            counting = false;
            healthManager = this.gameObject.GetComponent<HealthManager>();
            Type healthType = healthManager.GetType();
            fieldInfo = healthType.GetField("evasionByHitRemaining", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public void FixedUpdate()
        {
            if (counting)
            {
                count++;
                if (count == 10)
                {
                    fieldInfo.SetValue(healthManager, -1f);
                    counting = false;
                }
            }
        }

        public void StartCount()
        {
            count = 0;
            counting = true;
        }

        public void StartCountFromInvincible()
        {
            count = 3;
            counting = true;
        }

        public void SpecialDeath()
        {
            fieldInfo.SetValue(healthManager, -1f);
            count = 0;
            counting = false;
        }
    }
}
