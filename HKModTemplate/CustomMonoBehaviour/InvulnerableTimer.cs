using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyHK.CustomMonoBehaviour
{
    public class InvulnerableTimer : MonoBehaviour
    {
        public float timer;
        public bool flag;
        private HeroControllerStates state;
        private InvulnerablePulse invPulse;

        private void Start()
        {
            timer = -1f;
            flag = false;
            HeroController heroController = gameObject.GetComponent<HeroController>();
            state = heroController.cState;
            Type selfType = heroController.GetType();
            FieldInfo invPulseInfo = selfType.GetField("invPulse", BindingFlags.Instance | BindingFlags.NonPublic);
            invPulse = (InvulnerablePulse)invPulseInfo.GetValue(heroController);
        }

        private void Update()
        {
            if (timer > 0f && flag)
            {
                timer -= Time.deltaTime;
            }
            else if (timer <= 0f && flag)
            {
                invPulse.stopInvulnerablePulse();
                state.recoiling = false;
                state.invulnerable = false;
                flag = false;
            }
        }
    }
}
