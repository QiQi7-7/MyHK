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
            if (target == null)
            {
                target = GetComponent<Collider2D>();
            }
            if (rb == null)
            {
                rb = GetComponent<Rigidbody2D>();
            }
        }

        public void FixedUpdate()
        {
            bounds = target.bounds;
            currentPosition = rb.position;
            if (target == null || rb == null)
            {
                return;
            }
            if (rb.isKinematic)
            {
                return;
            }
            CalculatePosition();
        }

        private void CalculatePosition()
        {
            nextPosition = currentPosition;

            if (detectTop && bounds.center.y + bounds.extents.y > topEdge)
            {
                nextPosition.y -= (bounds.center.y + bounds.extents.y - topEdge + extraDistance);
            }
            else if (detectBottom && bounds.center.y - bounds.extents.y < bottomEdge)
            {
                nextPosition.y += (bottomEdge - (bounds.center.y - bounds.extents.y) + extraDistance);
            }

            if (detectLeft && bounds.center.x - bounds.extents.x < leftEdge)
            {
                nextPosition.x += (leftEdge - (bounds.center.x - bounds.extents.x) + extraDistance);
            }
            else if (detectRight && bounds.center.x + bounds.extents.x > rightEdge)
            {
                nextPosition.x -= (bounds.center.x + bounds.extents.x - rightEdge + extraDistance);
            }

            if(nextPosition != currentPosition)
            {
                MoveToNextPosition();
            }
        }

        private void MoveToNextPosition()
        {
            if(Vector2.Distance(currentPosition, nextPosition) > maxDistance)
            {
                nextPosition = Vector2.MoveTowards(currentPosition, nextPosition, maxDistance);
            }
            rb.position = nextPosition;
            Physics2D.SyncTransforms();
        }

        private Vector2 currentPosition;
        private Vector2 nextPosition;
        public Collider2D target;
        public Rigidbody2D rb;
        private float extraDistance = 0.02f;
        private float maxDistance = 0.2f;
        private Bounds bounds;
        public float TopEdge
        {
            get
            {
                return topEdge;
            }
            set
            {
                detectTop = true;
                topEdge = value;
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
                detectBottom = true;
                bottomEdge = value;
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
                detectLeft = true;
                leftEdge = value;
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
                detectRight = true;
                rightEdge = value;
            }
        }
        private float topEdge;
        private float bottomEdge;
        private float leftEdge;
        private float rightEdge;
        private bool detectTop;
        private bool detectBottom;
        private bool detectLeft;
        private bool detectRight;
    }
}
