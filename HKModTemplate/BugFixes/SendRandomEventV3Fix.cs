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
    public class SendRandomEventV3Fix : Module
    {
        private FieldInfo fieldInfo;

        public SendRandomEventV3Fix()
        {
            Type type = typeof(HutongGames.PlayMaker.Actions.SendRandomEventV3);
            fieldInfo = type.GetField("loops", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public override void Load()
        {
            SendRandomEventV3.OnEnter += SendRandomEventV3_OnEnter;
        }

        public override void Unload()
        {
            SendRandomEventV3.OnEnter -= SendRandomEventV3_OnEnter;
        }

        private void SendRandomEventV3_OnEnter(SendRandomEventV3.orig_OnEnter orig, HutongGames.PlayMaker.Actions.SendRandomEventV3 self)
        {
            fieldInfo.SetValue(self, 0);
            orig(self);
        }
    }
}
