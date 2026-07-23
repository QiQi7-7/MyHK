using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using Satchel;
using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using System.Collections;
using MyHK.CustomMonoBehaviour;
using UnityEngine.PlayerLoop;
using GlobalEnums;

namespace MyHK.BetterLogic
{
    public class DoubleJumpFix : Module
    {
        private FieldInfo fieldInfo;

        public DoubleJumpFix()
        {
            fieldInfo = typeof(HeroController).GetField("doubleJumped", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public override void Load()
        {
            On.HeroController.CanDoubleJump += HeroController_CanDoubleJump;
        }

        public override void Unload()
        {
            On.HeroController.CanDoubleJump -= HeroController_CanDoubleJump;
        }

        private bool HeroController_CanDoubleJump(On.HeroController.orig_CanDoubleJump orig, HeroController self)
        {
            return self.playerData.GetBool("hasDoubleJump")
                && !self.controlReqlinquished
                && !(bool)fieldInfo.GetValue(self)
                && !self.inAcid
                && self.hero_state != ActorStates.no_input
                && self.hero_state != ActorStates.hard_landing
                && self.hero_state != ActorStates.dash_landing
                && !self.cState.dashing
                && !self.cState.wallSliding
                && !self.cState.backDashing
                //&& !self.cState.attacking
                && !self.cState.bouncing
                && !self.cState.shroomBouncing
                && !self.cState.onGround;
        }
    }
}
