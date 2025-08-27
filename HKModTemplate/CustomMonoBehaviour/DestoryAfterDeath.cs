using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyHK.CustomMonoBehaviour
{
    public class DestoryAfterDeath : MonoBehaviour
    {
        public Component component;
        public HealthManager healthManager;

        public void Update()
        {
            if(healthManager == null)
            {
                Component.Destroy(component);
            }
            else if(healthManager.hp <= 0)
            {
                Component.Destroy(component);
            }
        }
    }
}
