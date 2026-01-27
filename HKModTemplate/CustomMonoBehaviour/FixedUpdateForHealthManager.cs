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
        private static readonly FieldInfo evasionByHitRemainingField = typeof(HealthManager).GetField("evasionByHitRemaining", BindingFlags.NonPublic | BindingFlags.Instance);
    
        private int count;
        private bool counting;
        private HealthManager healthManager;
        private FieldInfo fieldInfo;

        public void Start()
        {
            count = 0;
            counting = false;
            healthManager = this.gameObject.GetComponent<HealthManager>();
        }

        public void FixedUpdate()
        {
            if (counting)
            {
                count++;
                if (count == 10)
                {
                    evasionByHitRemainingField.SetValue(healthManager, -1f);
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
            evasionByHitRemainingField.SetValue(healthManager, -1f);
            count = 0;
            counting = false;
        }
    }
}
