using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyHK.CustomMonoBehaviour
{
    public class MotionFreeze : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Vector2 speed;
        public bool freezing;

        public void Start()
        {
            rb = this.gameObject.GetComponent<Rigidbody2D>();
            speed = new Vector2(0f, 0f);
            freezing = false;
        }

        public void FixedUpdate()
        {
            if (freezing)
            {
                this.rb.velocity = speed;
            }
        }
    }
}
