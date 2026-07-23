using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyHK.CustomMonoBehaviour
{
    public class FsmObjectBounce : MonoBehaviour
    {
        public event ObjectBounce.BounceEvent OnBounce;

        private void Start()
        {
            this.rb = base.GetComponent<Rigidbody2D>();
            this.audio = base.GetComponent<AudioSource>();
            this.animator = base.GetComponent<tk2dSpriteAnimator>();
            this.fsm = base.gameObject.LocateMyFSM("Control");
        }

        private void FixedUpdate()
        {
            if (this.bouncing)
            {
                if (this.stepCounter >= 3)
                {
                    Vector2 a = new Vector2(base.transform.position.x, base.transform.position.y);
                    this.velocity = a - this.lastPos;
                    this.lastPos = a;
                    this.speed = (this.rb ? this.rb.velocity.magnitude : 0f);
                    this.stepCounter = 0;
                    return;
                }
                this.stepCounter++;
            }
        }

        private void Update()
        {
            if (this.animTimer > 0f)
            {
                this.animTimer -= Time.deltaTime;
            }
        }
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!this.rb || this.rb.isKinematic)
            {
                return;
            }
            if (this.bouncing && this.speed > this.speedThreshold)
            {
                Vector3 inNormal = col.GetSafeContact().Normal;
                Vector3 normalized = Vector3.Reflect(this.velocity.normalized, inNormal).normalized;
                var bounceVelocity = new Vector2(normalized.x, normalized.y) * (this.speed * (this.bounceFactor * UnityEngine.Random.Range(0.8f, 1.2f)));
                this.fsm.FsmVariables.FindFsmVector2("bounceVelocity").Value = bounceVelocity;
                this.fsm.SendEvent("BOUNCE");
                if (this.playSound)
                {
                    this.chooser = UnityEngine.Random.Range(1, 100);
                    int num = UnityEngine.Random.Range(0, this.clips.Length - 1);
                    AudioClip clip = this.clips[num];
                    if (this.chooser <= this.chanceToPlay)
                    {
                        float pitch = UnityEngine.Random.Range(this.pitchMin, this.pitchMax);
                        this.audio.pitch = pitch;
                        this.audio.PlayOneShot(clip);
                    }
                }
                if (this.playAnimationOnBounce && this.animTimer <= 0f)
                {
                    this.animator.Play(this.animationName);
                    this.animator.PlayFromFrame(0);
                    this.animTimer = this.animPause;
                }
                if (this.OnBounce != null)
                {
                    this.OnBounce();
                }
            }
        }

        public void StopBounce()
        {
            this.bouncing = false;
        }

        public void StartBounce()
        {
            this.bouncing = true;
        }

        public void SetBounceFactor(float value)
        {
            this.bounceFactor = value;
        }

        public void SetBounceAnimation(bool set)
        {
            this.playAnimationOnBounce = set;
        }

        public FsmObjectBounce()
        {
            this.speedThreshold = 1f;
            this.chanceToPlay = 100;
            this.pitchMin = 1f;
            this.pitchMax = 1f;
            this.animPause = 0.5f;
            this.bouncing = true;
        }

        public float bounceFactor;

        public float speedThreshold;

        public bool playSound;

        public AudioClip[] clips;

        public int chanceToPlay;

        public float pitchMin;

        public float pitchMax;

        public bool playAnimationOnBounce;

        public string animationName;

        public float animPause;

        public bool sendFSMEvent;

        private float speed;

        private float animTimer;

        private tk2dSpriteAnimator animator;

        private PlayMakerFSM fsm;

        private Vector2 velocity;

        private Vector2 lastPos;

        private Rigidbody2D rb;

        private AudioSource audio;

        private int chooser;

        private bool bouncing;

        private int stepCounter;

        public delegate void BounceEvent();
    }
}
