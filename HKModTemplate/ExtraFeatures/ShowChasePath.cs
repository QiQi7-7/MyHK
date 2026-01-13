using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;
using System.Runtime.InteropServices;
using MyHK.CustomAction;

namespace MyHK.ExtraFeatures
{
    public class ShowChasePath : Module
    {
        private List<List<GameObject>> pool;
        private GameObject point;
        public static ShowChasePath instance;
        public int accuracy = 50;
        private float scale = 2;

        public ShowChasePath()
        {
            this.Setting = 0;
            if (instance == null)
            {
                instance = this;
            }
            pool = new List<List<GameObject>>();
        }

        private List<GameObject> CreatePoints()
        {
            List<GameObject> points = new List<GameObject>();
            for (int i = 0; i < accuracy; i++)
            {
                GameObject gameObject = GameObject.Instantiate(point);
                gameObject.SetScale((float)(accuracy - i) / (accuracy * scale), (float)(accuracy - i) / (accuracy * scale));
                gameObject.SetActive(false);
                GameObject.DontDestroyOnLoad(gameObject);
                points.Add(gameObject);
            }
            return points;
        }

        public List<GameObject> GetPoints()
        {
            List<GameObject> points = new List<GameObject>();
            if(pool.Count > 0)
            {
                points = pool[pool.Count - 1];
                pool.RemoveAt(pool.Count - 1);
            }
            else
            {
                points = CreatePoints();
            }
            return points;
        }

        public void RecyclePoints(List<GameObject> points)
        {
            foreach(GameObject point in points)
            {
                point.SetActive(false);
            }
            pool.Add(points);
        }

        public override void Load()
        {
            On.PlayMakerFSM.OnEnable += PlayMakerFSM_OnEnable;
        }

        public override void Unload()
        {
            On.PlayMakerFSM.OnEnable -= PlayMakerFSM_OnEnable;
        }

        private void PlayMakerFSM_OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            if (self.gameObject.name == "Knight" && self.FsmName == "Spell Control")
            {
                self.AddCustomAction("Init", () =>
                {
                    point = GameObject.Instantiate(self.GetAction<ActivateGameObject>("Quake Antic", 5).gameObject.GameObject.Value);
                    point.RemoveComponent<PlayMakerFSM>();
                    GameObject.DontDestroyOnLoad(point);
                    pool.Add(CreatePoints());
                    pool.Add(CreatePoints());
                });
            }
            if (self.gameObject.name == "Galien Hammer" && self.FsmName == "Attack")
            {
                self.AddAction("Chase", new ChasePath_Hammer()
                {
                    cog = self.GetAction<ChaseObjectGround>("Chase", 3)
                });
            }
            if (self.gameObject.name == "Ghost Warrior Marmu" && self.FsmName == "Control")
            {
                self.AddAction("Chase", new ChasePath_coV2()
                {
                    coV2 = self.GetAction<ChaseObjectV2>("Chase", 0)
                });
            }
            if (self.gameObject.name.Contains("Lil Jellyfish(Clone)") && self.FsmName == "Lil Jelly")
            {
                self.AddAction("Chase", new ChasePath_coV2()
                {
                    coV2 = self.GetAction<ChaseObjectV2>("Chase", 5)
                });
            }
            if (self.gameObject.name.Contains("Radiant Orb(Clone)") && self.FsmName == "Orb Control")
            {
                self.AddAction("Chase Hero", new ChasePath_coV2()
                {
                    coV2 = self.GetAction<ChaseObjectV2>("Chase Hero", 3)
                });
                self.AddAction("Chase Hero 2", new ChasePath_coV2()
                {
                    coV2 = self.GetAction<ChaseObjectV2>("Chase Hero 2", 4)
                });
            }
            orig(self);
        }
    }
}
