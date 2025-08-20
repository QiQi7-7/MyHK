using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyHK.CustomMonoBehaviour
{
    public class EdgeDetector : MonoBehaviour
    {
        public void Start()
        {
            stucking_T = false;
            stucking_B = false;
            stucking_L = false;
            stucking_R = false;
            if(rb == null)
            {
                rb = base.gameObject.GetComponent<Rigidbody2D>();
            }
            if(target == null)
            {
                target = base.gameObject.GetComponent<BoxCollider2D>();
            }
        }

        public void FixedUpdate()
        {
            if (flag && doDetect != null)
            {
                if (stucking_T || stucking_B || stucking_L || stucking_R)
                {
                    rb.isKinematic = true;
                }
                else
                {
                    rb.isKinematic = false;
                }
                doDetect(target);
            }
        }

        private void DetectTop(Collider2D collider)
        {
            if(detectType == DetectType.easy)
            {
                if(target.bounds.max.y > topEdge + tolerance)
                {
                    stucking_T = true;
                    base.transform.Translate(0, -distance, 0);
                }
                else
                {
                    stucking_T = false;
                }
            }
            else
            {
                if (target.bounds.max.y > topEdge)
                {
                    stucking_T = true;
                    base.transform.Translate(0, -distance, 0);
                }
                else
                {
                    stucking_T = false;
                }
            }
        }

        private void DetectBottom(Collider2D collider)
        {
            if (detectType == DetectType.easy)
            {
                if (target.bounds.min.y < bottomEdge - tolerance)
                {
                    stucking_B = true;
                    base.transform.Translate(0, distance, 0);
                }
                else
                {
                    stucking_B = false;
                }
            }
            else
            {
                if (target.bounds.min.y < bottomEdge)
                {
                    stucking_B = true;
                    base.transform.Translate(0, distance, 0);
                }
                else
                {
                    stucking_B = false;
                }
            }
        }

        private void DetectLeft(Collider2D collider)
        {
            if (detectType == DetectType.easy)
            {
                if (target.bounds.min.x < leftEdge - tolerance)
                {
                    stucking_L = true;
                    base.transform.Translate(distance, 0, 0);
                }
                else
                {
                    stucking_L = false;
                }
            }
            else
            {
                if (target.bounds.min.x < leftEdge)
                {
                    stucking_L = true;
                    base.transform.Translate(distance, 0, 0);
                }
                else
                {
                    stucking_L = false;
                }
            }
        }

        private void DetectRight(Collider2D collider)
        {
            if (detectType == DetectType.easy)
            {
                if (target.bounds.max.x > rightEdge + tolerance)
                {
                    stucking_R = true;
                    base.transform.Translate(-distance, 0, 0);
                }
                else
                {
                    stucking_R = false;
                }
            }
            else
            {
                if (target.bounds.max.x > rightEdge)
                {
                    stucking_R = true;
                    base.transform.Translate(-distance, 0, 0);
                }
                else
                {
                    stucking_R = false;
                }
            }
        }

        public bool flag = false;
        public enum DetectType
        {
            easy,
            hard
        }
        public DetectType detectType = DetectType.hard;
        public Collider2D target;
        public Rigidbody2D rb;
        public float distance = 0.05f;
        public float tolerance = 1f;
        public float TopEdge
        {
            get
            {
                return topEdge;
            }
            set
            {
                doDetect -= DetectTop;
                topEdge = value;
                doDetect += DetectTop;
            }
        }
        public float BottomEdge
        {
            get
            {
                return bottomEdge;
            }
            set
            {
                doDetect -= DetectBottom;
                bottomEdge = value;
                doDetect += DetectBottom;
            }
        }
        public float LeftEdge
        {
            get
            {
                return leftEdge;
            }
            set
            {
                doDetect -= DetectLeft;
                leftEdge = value;
                doDetect += DetectLeft;
            }
        }
        public float RightEdge
        {
            get
            {
                return rightEdge;
            }
            set
            {
                doDetect -= DetectRight;
                rightEdge = value;
                doDetect += DetectRight;
            }
        }
        private float topEdge;
        private float bottomEdge;
        private float leftEdge;
        private float rightEdge;
        private bool stucking_T;
        private bool stucking_B;
        private bool stucking_L;
        private bool stucking_R;
        private delegate void DoDetect(Collider2D collider);
        private DoDetect doDetect;
    }
}
