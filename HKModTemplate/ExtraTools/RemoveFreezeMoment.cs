using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;

namespace MyHK.ExtraTools
{
    public class RemoveFreezeMoment : Module
    {
        public RemoveFreezeMoment()
        {
            this.Setting = 0;
        }

        public override void Load()
        {
            On.GameManager.FreezeMoment_int += GameManager_FreezeMoment_int;
        }

        public override void Unload()
        {
            On.GameManager.FreezeMoment_int -= GameManager_FreezeMoment_int;
        }

        private void GameManager_FreezeMoment_int(On.GameManager.orig_FreezeMoment_int orig, GameManager self, int type)
        {
        }
    }
}
