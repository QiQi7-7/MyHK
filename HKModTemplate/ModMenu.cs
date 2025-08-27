using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Modding;
using Satchel;
using Satchel.BetterMenus;
using Newtonsoft.Json;

namespace MyHK
{
    internal static class ModMenu
    {
        private static bool zh;
        private static Menu MenuRef;
        private static Menu BetterLogicMenu;
        private static Menu ExtraToolsMenu;
        private static Menu BugFixesMenu;
        private static Dictionary<string, string> zhTexts;
        private static Dictionary<string, string> enTexts;


        static ModMenu()
        {
            zh = Language.Language.CurrentLanguage().ToString().ToLower().Equals("zh");
            zhTexts = JsonConvert.DeserializeObject<Dictionary<string, string>>(Utils.ReadEmbeddedResource("MyHK.Resources.zh.json"));
            enTexts = JsonConvert.DeserializeObject<Dictionary<string, string>>(Utils.ReadEmbeddedResource("MyHK.Resources.en.json"));
        }

        private static string GetText(string s)
        {
            if(zh)
            {
                return zhTexts[s];
            }
            else
            {
                return enTexts[s];
            }
        }

        internal static Menu CreateMenu(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates)
        {
            BetterLogicMenu = new Menu(
                name: GetText("BetterLogic"),
                elements: new Element[]
                {
                    new HorizontalOption(
                        name: GetText("HealthManagerFix"),
                        description: GetText("HealthManagerFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_HealthManagerFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_HealthManagerFix),//受击优化
                    new TextPanel(
                        name: GetText("ReloadTip"),
	                    fontSize: 30),
                    new HorizontalOption(
                        name: GetText("ScrHeads2Fix"),
                        description: GetText("ScrHeads2Fix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_ScrHeads2Fix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_ScrHeads2Fix),//黑吼优化
                    new TextPanel(
                        name: GetText("ReloadTip"),
                        fontSize: 30),
                    new HorizontalOption(
                        name: GetText("ScrHeadsFix"),
                        description: GetText("ScrHeadsFix/Description"),
                        values: new [] {GetText("Off"), GetText("ScrHeadsFix/Setting/1"), GetText("ScrHeadsFix/Setting/2") },
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_ScrHeadsFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_ScrHeadsFix),//白吼优化
                    new TextPanel(
                        name: GetText("ReloadTip"),
                        fontSize: 30),
                    new HorizontalOption(
                        name: GetText("DoubleJumpFix"),
                        description: GetText("DoubleJumpFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_DoubleJumpFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_DoubleJumpFix),//二段跳优化
                    new HorizontalOption(
                        name: GetText("WarpFix"),
                        description: GetText("WarpFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_WarpFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_WarpFix),//闪现优化
                    new HorizontalOption(
                        name: GetText("DetectionFix"),
                        description: GetText("DetectionFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_DetectionFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_DetectionFix),//检测优化
                    new HorizontalOption(
                        name: GetText("_21_HiveKnight"),
                        description: GetText("_21_HiveKnight/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_21_HiveKnight = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_21_HiveKnight),//蜂骑优化
                    new HorizontalOption(
                        name: GetText("_29_Sly"),
                        description: GetText("_29_Sly/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_29_Sly = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_29_Sly),//斯莱优化
                }
            );

            ExtraToolsMenu = new Menu(
                name: GetText("ExtraFeatures"),
                elements: new Element[]
                {
                    new HorizontalOption(
                        name: GetText("RemoveFreezeMoment"),
                        description: GetText("RemoveFreezeMoment/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_RemoveFreezeMoment = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_RemoveFreezeMoment),//移除冻结帧
                    new HorizontalOption(
                        name: GetText("ShowStunInfo"),
                        description: GetText("ShowStunInfo/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_ShowStunInfo = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_ShowStunInfo),//显示硬直信息
                    new HorizontalOption(
                        name: GetText("ShowDestination"),
                        description: GetText("ShowDestination/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_ShowDestination = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_ShowDestination),//显示移动目标
                    new HorizontalOption(
                        name: GetText("TwoHitKills"),
                        description: GetText("TwoHitKills/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_TwoHitKills = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_TwoHitKills),//两击必杀
                    new HorizontalOption(
                        name: GetText("RemoveForeground"),
                        description: GetText("RemoveForeground/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_RemoveForeground = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_RemoveForeground),//移除前景
                }
            );

            BugFixesMenu = new Menu(
                name: GetText("BugFixes"),
                elements: new Element[]
                {
                    new HorizontalOption(
                        name: GetText("CheckCollisionSideFix"),
                        description: GetText("CheckCollisionSideFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_CheckCollisionSideFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_CheckCollisionSideFix),//碰撞修复
                    new HorizontalOption(
                        name: GetText("MultiHitFix"),
                        description: GetText("MultiHitFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_MultiHitFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_MultiHitFix),//多判修复
                    new HorizontalOption(
                        name: GetText("RoarFix"),
                        description: GetText("RoarFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_RoarFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_RoarFix),//战吼修复
                    new HorizontalOption(
                        name: GetText("StuckFix"),
                        description: GetText("StuckFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_StuckFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_StuckFix),//卡墙修复
                    new HorizontalOption(
                        name: GetText("StunFix"),
                        description: GetText("StunFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_StunFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_StunFix),//硬直修复
                    new HorizontalOption(
                        name: GetText("Tk2dPlayAnimationWithEventsFix"),
                        description: GetText("Tk2dPlayAnimationWithEventsFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_Tk2dPlayAnimationWithEventsFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_Tk2dPlayAnimationWithEventsFix),//动画修复
                    new TextPanel(
                        name: GetText("ReloadTip"),
                        fontSize: 30),
                    new HorizontalOption(
                        name: GetText("SendRandomEventV3Fix"),
                        description: GetText("SendRandomEventV3Fix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_SendRandomEventV3Fix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_SendRandomEventV3Fix),//随机选择修复
                    new HorizontalOption(
                        name: GetText("PersonalObjectPoolFix"),
                        description: GetText("PersonalObjectPoolFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_PersonalObjectPoolFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_PersonalObjectPoolFix),//物品回收修复
                    new HorizontalOption(
                        name: GetText("HeroBoxFix"),
                        description: GetText("HeroBoxFix/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_HeroBoxFix = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_HeroBoxFix),//无敌状态修复
                    new TextPanel(
                        name: GetText("ReloadTip"),
                        fontSize: 30),
                    new HorizontalOption(
                        name: GetText("_3_FalseKnight"),
                        description: GetText("_3_FalseKnight/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_3_FalseKnight = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_3_FalseKnight),//假骑士修复
                    new HorizontalOption(
                        name: GetText("_4_MossCharger"),
                        description: GetText("_4_MossCharger/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_4_MossCharger = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_4_MossCharger),//草团子修复
                    new HorizontalOption(
                        name: GetText("_5_Hornet1"),
                        description: GetText("_5_Hornet1/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_5_Hornet1 = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_5_Hornet1),//一见修复
                    new HorizontalOption(
                        name: GetText("_7_DungDefender"),
                        description: GetText("_7_DungDefender/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_7_DungDefender = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_7_DungDefender),//芬达哥修复
                    new HorizontalOption(
                        name: GetText("_10_OroAndMato"),
                        description: GetText("_10_OroAndMato/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_10_OroAndMato = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_10_OroAndMato),//双师傅修复
                    new HorizontalOption(
                        name: GetText("_14_Oblobbles"),
                        description: GetText("_14_Oblobbles/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_14_Oblobbles = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_14_Oblobbles),//波波修复
                    new HorizontalOption(
                        name: GetText("_15_MantisLord"),
                        description: GetText("_15_MantisLord/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_15_MantisLord = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_15_MantisLord),//三螳螂修复
                    new HorizontalOption(
                        name: GetText("_16_Marmu"),
                        description: GetText("_16_Marmu/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_16_Marmu = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_16_Marmu),//马尔穆修复
                    new HorizontalOption(
                        name: GetText("_17_FlukeMother"),
                        description: GetText("_17_FlukeMother/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_17_FlukeMother = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_17_FlukeMother),//虫母修复
                    new HorizontalOption(
                        name: GetText("_23_Collector"),
                        description: GetText("_23_Collector/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_23_Collector = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_23_Collector),//收藏家修复
                    new HorizontalOption(
                        name: GetText("_28_HornetNosk"),
                        description: GetText("_28_HornetNosk/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_28_HornetNosk = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_28_HornetNosk),//有翼诺斯克修复
                    new HorizontalOption(
                        name: GetText("_30_Hornet2"),
                        description: GetText("_30_Hornet2/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_30_Hornet2 = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_30_Hornet2),//二见修复
                    new HorizontalOption(
                        name: GetText("_35_WhiteDefender"),
                        description: GetText("_35_WhiteDefender/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_35_WhiteDefender = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_35_WhiteDefender),//白芬达修复
                    new HorizontalOption(
                        name: GetText("_41_PureVessel"),
                        description: GetText("_41_PureVessel/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_41_PureVessel = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_41_PureVessel),//前辈修复
                    new HorizontalOption(
                        name: GetText("_42_Radiance"),
                        description: GetText("_42_Radiance/Description"),
                        values: new [] {GetText("Off"), GetText("On")},
                        applySetting: index =>
                        {
                            MyHK.mySettings.opt_42_Radiance = index;
                        },
                        loadSetting: ()=>MyHK.mySettings.opt_42_Radiance),//辐光修复
                }
            );

            MenuRef ??= new Menu(
                name: "MyHK",
                elements: new Element[]
                {
                    Blueprints.CreateToggle(
                        toggleDelegates: toggleDelegates.Value,
                        name: GetText("Toggle"),
                        description: GetText("Toggle/Description")),
                    Blueprints.NavigateToMenu(
                        name: GetText("BetterLogic"),
                        description: GetText("BetterLogic/Description"),
                        getScreen: () => BetterLogicMenu.GetMenuScreen(MenuRef.menuScreen)),
                    Blueprints.NavigateToMenu(
                        name: GetText("ExtraFeatures"),
                        description: GetText("ExtraFeatures/Description"),
                        getScreen: () => ExtraToolsMenu.GetMenuScreen(MenuRef.menuScreen)),
                    Blueprints.NavigateToMenu(
                        name: GetText("BugFixes"),
                        description: GetText("BugFixes/Description"),
                        getScreen: () => BugFixesMenu.GetMenuScreen(MenuRef.menuScreen))
                }
            );
            return MenuRef;
        }
    }
}
