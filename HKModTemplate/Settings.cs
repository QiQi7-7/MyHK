using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHK.BetterLogic;
using MyHK.BugFixes;
using MyHK.CustomMonoBehaviour;
using MyHK.ExtraTools;

namespace MyHK
{
    [Serializable]
    public class Settings
    {
        //逻辑优化
        private static HealthManagerFix healthManagerFix = new HealthManagerFix();
        private static ScrHeadsFix scrHeadsFix = new ScrHeadsFix();
        private static ScrHeads2Fix scrHeads2Fix = new ScrHeads2Fix();
        private static DoubleJumpFix doubleJumpFix = new DoubleJumpFix();
        private static WarpFix warpFix = new WarpFix();
        private static DetectFix detectFix = new DetectFix();
        private static _21_HiveKnight _21_hiveKnight = new _21_HiveKnight();
        private static _29_Sly _29_sly = new _29_Sly();

        //辅助工具
        private static RemoveFreezeMoment removeFreezeMoment = new RemoveFreezeMoment();
        private static ShowStunInfo showStunInfo = new ShowStunInfo();
        private static ShowMovementTarget showMovementTarget = new ShowMovementTarget();
        private static TwoHitKills twoHitKills = new TwoHitKills();
        private static RemoveForeground removeForeground = new RemoveForeground();

        //bug修复
        private static CheckCollisionSideFix checkCollisionSideFix = new CheckCollisionSideFix();
        private static MultiHitFix multiHitFix = new MultiHitFix();
        private static RoarFix roarFix = new RoarFix();
        private static StuckFix stuckFix = new StuckFix();
        private static StunFix stunFix = new StunFix();
        private static Tk2dPlayAnimationWithEventsFix tk2dPlayAnimationWithEventsFix = new Tk2dPlayAnimationWithEventsFix();
        private static SendRandomEventV3Fix sendRandomEventV3Fix = new SendRandomEventV3Fix();
        private static PersonalObjectPoolFix personalObjectPoolFix = new PersonalObjectPoolFix();
        private static HeroBoxFix heroBoxFix = new HeroBoxFix();
        private static _3_FalseKnight _3_falseKnight = new _3_FalseKnight();
        private static _4_MossCharger _4_mossCharger = new _4_MossCharger();
        private static _5_Hornet1 _5_hornet1 = new _5_Hornet1();
        private static _7_DungDefender _7_dungDefender = new _7_DungDefender();
        private static _10_OroAndMato _10_oroAndMato = new _10_OroAndMato();
        private static _14_Oblobbles _14_oblobbles = new _14_Oblobbles();
        private static _15_MantisLord _15_mantisLord = new _15_MantisLord();
        private static _16_Marmu _16_marmu = new _16_Marmu();
        private static _17_FlukeMother _17_flukeMother = new _17_FlukeMother();
        private static _23_Collector _23_collector = new _23_Collector();
        private static _28_HornetNosk _28_hornetNosk = new _28_HornetNosk();
        private static _30_Hornet2 _30_hornet2 = new _30_Hornet2();
        private static _35_WhiteDefender _35_whiteDefender = new _35_WhiteDefender();
        private static _41_PureVessel _41_pureVessel = new _41_PureVessel();
        private static _42_Radiance _42_radiance = new _42_Radiance();

        //逻辑优化
        public int opt_HealthManagerFix
        {
            get
            {
                return healthManagerFix.Setting;
            }
            set
            {
                healthManagerFix.Setting = value;
            }
        }
        public int opt_ScrHeadsFix
        {
            get
            {
                return scrHeadsFix.Setting;
            }
            set
            {
                scrHeadsFix.Setting = value;
            }
        }
        public int opt_ScrHeads2Fix
        {
            get
            {
                return scrHeads2Fix.Setting;
            }
            set
            {
                scrHeads2Fix.Setting = value;
            }
        }
        public int opt_DoubleJumpFix
        {
            get
            {
                return doubleJumpFix.Setting;
            }
            set
            {
                doubleJumpFix.Setting = value;
            }
        }
        public int opt_WarpFix
        {
            get
            {
                return warpFix.Setting;
            }
            set
            {
                warpFix.Setting = value;
            }
        }
        public int opt_DetectFix
        {
            get
            {
                return detectFix.Setting;
            }
            set
            {
                detectFix.Setting = value;
            }
        }
        public int opt_21_HiveKnight
        {
            get
            {
                return _21_hiveKnight.Setting;
            }
            set
            {
                _21_hiveKnight.Setting = value;
            }
        }
        public int opt_29_Sly
        {
            get
            {
                return _29_sly.Setting;
            }
            set
            {
                _29_sly.Setting = value;
            }
        }

        //辅助工具
        public int opt_RemoveFreezeMoment
        {
            get
            {
                return removeFreezeMoment.Setting;
            }
            set
            {
                removeFreezeMoment.Setting = value;
            }
        }
        public int opt_ShowStunInfo
        {
            get
            {
                return showStunInfo.Setting;
            }
            set
            {
                showStunInfo.Setting = value;
            }
        }
        public int opt_ShowMovementTarget
        {
            get
            {
                return showMovementTarget.Setting;
            }
            set
            {
                showMovementTarget.Setting = value;
            }
        }
        public int opt_TwoHitKills
        {
            get
            {
                return twoHitKills.Setting;
            }
            set
            {
                twoHitKills.Setting = value;
            }
        }
        public int opt_RemoveForeground
        {
            get
            {
                return removeForeground.Setting;
            }
            set
            {
                removeForeground.Setting = value;
            }
        }

        //bug修复
        public int opt_CheckCollisionSideFix
        {
            get
            {
                return checkCollisionSideFix.Setting;
            }
            set
            {
                checkCollisionSideFix.Setting = value;
            }
        }
        public int opt_MultiHitFix
        {
            get
            {
                return multiHitFix.Setting;
            }
            set
            {
                multiHitFix.Setting = value;
            }
        }
        public int opt_RoarFix
        {
            get
            {
                return roarFix.Setting;
            }
            set
            {
                roarFix.Setting = value;
            }
        }
        public int opt_StuckFix
        {
            get
            {
                return stuckFix.Setting;
            }
            set
            {
                stuckFix.Setting = value;
            }
        }
        public int opt_StunFix
        {
            get
            {
                return stunFix.Setting;
            }
            set
            {
                stunFix.Setting = value;
            }
        }
        public int opt_Tk2dPlayAnimationWithEventsFix
        {
            get
            {
                return tk2dPlayAnimationWithEventsFix.Setting;
            }
            set
            {
                tk2dPlayAnimationWithEventsFix.Setting = value;
            }
        }
        public int opt_SendRandomEventV3Fix
        {
            get
            {
                return sendRandomEventV3Fix.Setting;
            }
            set
            {
                sendRandomEventV3Fix.Setting = value;
            }
        }
        public int opt_PersonalObjectPoolFix
        {
            get
            {
                return personalObjectPoolFix.Setting;
            }
            set
            {
                personalObjectPoolFix.Setting = value;
            }
        }
        public int opt_HeroBoxFix
        {
            get
            {
                return heroBoxFix.Setting;
            }
            set
            {
                heroBoxFix.Setting = value;
            }
        }
        public int opt_3_FalseKnight
        {
            get
            {
                return _3_falseKnight.Setting;
            }
            set
            {
                _3_falseKnight.Setting = value;
            }
        }
        public int opt_4_MossCharger
        {
            get
            {
                return _4_mossCharger.Setting;
            }
            set
            {
                _4_mossCharger.Setting = value;
            }
        }
        public int opt_5_Hornet1
        {
            get
            {
                return _5_hornet1.Setting;
            }
            set
            {
                _5_hornet1.Setting = value;
            }
        }
        public int opt_7_DungDefender
        {
            get
            {
                return _7_dungDefender.Setting;
            }
            set
            {
                _7_dungDefender.Setting = value;
            }
        }
        public int opt_10_OroAndMato
        {
            get
            {
                return _10_oroAndMato.Setting;
            }
            set
            {
                _10_oroAndMato.Setting = value;
            }
        }
        public int opt_14_Oblobbles
        {
            get
            {
                return _14_oblobbles.Setting;
            }
            set
            {
                _14_oblobbles.Setting = value;
            }
        }
        public int opt_15_MantisLord
        {
            get
            {
                return _15_mantisLord.Setting;
            }
            set
            {
                _15_mantisLord.Setting = value;
            }
        }
        public int opt_16_Marmu
        {
            get
            {
                return _16_marmu.Setting;
            }
            set
            {
                _16_marmu.Setting = value;
            }
        }
        public int opt_17_FlukeMother
        {
            get
            {
                return _17_flukeMother.Setting;
            }
            set
            {
                _17_flukeMother.Setting = value;
            }
        }
        public int opt_23_Collector
        {
            get
            {
                return _23_collector.Setting;
            }
            set
            {
                _23_collector.Setting = value;
            }
        }
        public int opt_28_HornetNosk
        {
            get
            {
                return _28_hornetNosk.Setting;
            }
            set
            {
                _28_hornetNosk.Setting = value;
            }
        }
        public int opt_30_Hornet2
        {
            get
            {
                return _30_hornet2.Setting;
            }
            set
            {
                _30_hornet2.Setting = value;
            }
        }
        public int opt_35_WhiteDefender
        {
            get
            {
                return _35_whiteDefender.Setting;
            }
            set
            {
                _35_whiteDefender.Setting = value;
            }
        }
        public int opt_41_PureVessel
        {
            get
            {
                return _41_pureVessel.Setting;
            }
            set
            {
                _41_pureVessel.Setting = value;
            }
        }
        public int opt_42_Radiance
        {
            get
            {
                return _42_radiance.Setting;
            }
            set
            {
                _42_radiance.Setting = value;
            }
        }
    }
}
