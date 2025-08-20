using HutongGames.PlayMaker;
//using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using On.HutongGames.PlayMaker.Actions;

namespace MyHK.BugFixes
{
    public class PersonalObjectPoolFix : Module
    {
        private GameManager gm = GameManager.instance;

        public override void Load()
        {
            On.PersonalObjectPool.OnEnable += PersonalObjectPool_OnEnable;
            On.PersonalObjectPool.DestroyMyPooledObjects += PersonalObjectPool_DestroyMyPooledObjects;
        }

        public override void Unload()
        {
            On.PersonalObjectPool.OnEnable -= PersonalObjectPool_OnEnable;
            On.PersonalObjectPool.DestroyMyPooledObjects -= PersonalObjectPool_DestroyMyPooledObjects;
        }

        private void PersonalObjectPool_OnEnable(On.PersonalObjectPool.orig_OnEnable orig, PersonalObjectPool self)
        {
            orig(self);
            gm.OnFinishedSceneTransition += self.DestroyMyPooledObjects;
            gm.OnFinishedSceneTransition += self.DestroyMyPooledObjects;
        }

        private void PersonalObjectPool_DestroyMyPooledObjects(On.PersonalObjectPool.orig_DestroyMyPooledObjects orig, PersonalObjectPool self)
        {
            orig(self);
            gm.OnFinishedSceneTransition -= self.DestroyMyPooledObjects;
        }
    }
}
