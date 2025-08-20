using System.Collections;
using System.Reflection;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using MonoMod.RuntimeDetour;
using Satchel;
using Satchel.BetterMenus;
using UnityEngine;

namespace MyHK;

public class MyHK : Mod, IGlobalSettings<Settings>, ITogglableMod, ICustomMenuMod
{
    public MyHK() : base("MyHK")
    {
    }
    public override string GetVersion() => "1.2.0.0";

    public override List<(string, string)> GetPreloadNames()
    {
        return [];
    }

    public override void Initialize(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        foreach (Module module in Module.modules)
        {
            module.Refresh();
        }
    }

    private static Settings mySettings = new();
    public bool ToggleButtonInsideMenu => true;
    public void OnLoadGlobal(Settings settings) => mySettings = settings;
    public Settings OnSaveGlobal() => mySettings;

    private Menu MenuRef;
    public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates)
    {
        MenuRef ??= new Menu(
            name: "MyHK",
            elements: new Element[]
            {
                Blueprints.CreateToggle(
                    toggleDelegates: toggleDelegates.Value,
                    name: "MOD开关",
                    description: "开关MOD的所有功能"),
                Blueprints.NavigateToMenu(
                    name: "逻辑优化",
                    description: "该模块相关内容不属于恶性bug，默认全部开启",
                    getScreen: () => BetterLogicMenu.GetMenuScreen(MenuRef.menuScreen)),
                Blueprints.NavigateToMenu(
                    name: "辅助功能",
                    description: "该模块提供部分额外的功能，默认全部关闭",
                    getScreen: () => ExtraToolsMenu.GetMenuScreen(MenuRef.menuScreen)),
                Blueprints.NavigateToMenu(
                    name: "bug修复",
                    description: "该模块相关内容属于恶性bug，默认全部开启",
                    getScreen: () => BugFixesMenu.GetMenuScreen(MenuRef.menuScreen))
            }
        );
        return MenuRef.GetMenuScreen(modListMenu);
    }

    private Menu BetterLogicMenu = new Menu(
        name: "逻辑优化",
        elements: new Element[]
        {
            new HorizontalOption(
                name: "受击优化",
                description: "修复因帧率导致的丢判",
                values: new [] {"禁用", "启用"},
                applySetting: index =>
                {
                    mySettings.opt_HealthManagerFix = index;
                },
                loadSetting: ()=>mySettings.opt_HealthManagerFix),//受击优化
            new HorizontalOption(
                name: "黑吼优化",
                description: "禁止黑吼第四判转向",
                values: new [] {"禁用", "启用"},
                applySetting: index =>
                {
                    mySettings.opt_ScrHeads2Fix = index;
                },
                loadSetting: ()=>mySettings.opt_ScrHeads2Fix),//黑吼优化
            new HorizontalOption(
                name: "白吼优化",
                description: "优化白吼的击退机制",
                values: new [] {"禁用", "左吼排斥右吼吸引", "永远排斥"},
                applySetting: index =>
                {
                    mySettings.opt_ScrHeadsFix = index;
                },
                loadSetting: ()=>mySettings.opt_ScrHeadsFix),//白吼优化
            new HorizontalOption(
                name: "二段跳优化",
                description: "攻击后也能立刻使用二段跳",
                values: new [] {"禁用", "启用"},
                applySetting: index =>
                {
                    mySettings.opt_DoubleJumpFix = index;
                },
                loadSetting: ()=>mySettings.opt_DoubleJumpFix),//二段跳优化
            new HorizontalOption(
                name: "闪现优化",
                description: "使部分BOSS在闪现后停止击退",
                values: new [] {"禁用", "启用"},
                applySetting: index =>
                {
                    mySettings.opt_WarpFix = index;
                },
                loadSetting: ()=>mySettings.opt_WarpFix),//闪现优化
            new HorizontalOption(
                name: "检测优化",
                description: "给部分招式添加或调整检玩家测机制以避免刷脸",
                values: new [] {"禁用", "启用"},
                applySetting: index =>
                {
                    mySettings.opt_DetectFix = index;
                },
                loadSetting: ()=>mySettings.opt_DetectFix),//检测优化
            new HorizontalOption(
                name: "蜂骑优化",
                description: "蜂骑死亡后使全部小蜜蜂死亡",
                values: new [] {"禁用", "启用"},
                applySetting: index =>
                {
                    mySettings.opt_21_HiveKnight = index;
                },
                loadSetting: ()=>mySettings.opt_21_HiveKnight),//蜂骑优化
            new HorizontalOption(
                name: "斯莱优化",
                description: "调整斯莱蓄力斩碰撞箱使之更符合贴图",
                values: new [] {"禁用", "启用"},
                applySetting: index =>
                {
                    mySettings.opt_29_Sly = index;
                },
                loadSetting: ()=>mySettings.opt_29_Sly),//斯莱优化
        }
        );

    private Menu ExtraToolsMenu = new Menu(
        name: "辅助功能",
        elements: new Element[]
        {
            new HorizontalOption(
            name: "移除冻结帧",
            description: "移除玩家受伤以外的所有冻结帧",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_RemoveFreezeMoment = index;
            },
            loadSetting: ()=>mySettings.opt_RemoveFreezeMoment),//移除冻结帧
            new HorizontalOption(
            name: "显示硬直信息",
            description: "显示累计硬直数、连击硬直数、连击计时",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_ShowStunInfo = index;
            },
            loadSetting: ()=>mySettings.opt_ShowStunInfo),//显示硬直信息
            new HorizontalOption(
            name: "显示移动目标",
            description: "显示除马尔穆以外所有梦境战士的移动目标",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_ShowMovementTarget = index;
            },
            loadSetting: ()=>mySettings.opt_ShowMovementTarget),//显示移动目标
            new HorizontalOption(
            name: "两击必杀",
            description: "若一次攻击无法击杀敌人则将血量降为1",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_TwoHitKills = index;
            },
            loadSetting: ()=>mySettings.opt_TwoHitKills),//两击必杀
            new HorizontalOption(
            name: "移除前景",
            description: "移除收藏家场景内的部分前景",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_RemoveForeground = index;
            },
            loadSetting: ()=>mySettings.opt_RemoveForeground),//移除前景
        }
        );

    private Menu BugFixesMenu = new Menu(
        name: "bug修复",
        elements: new Element[]
        {
            new HorizontalOption(
            name: "碰撞",
            description: "修复若干碰撞相关bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_CheckCollisionSideFix = index;
            },
            loadSetting: ()=>mySettings.opt_CheckCollisionSideFix),//碰撞修复
            new HorizontalOption(
            name: "多判修复",
            description: "修复连续受伤导致无敌时间丢失的bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_MultiHitFix = index;
            },
            loadSetting: ()=>mySettings.opt_MultiHitFix),//多判修复
            new HorizontalOption(
            name: "战吼修复",
            description: "可以安全的使用菜单卡战吼",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_RoarFix = index;
            },
            loadSetting: ()=>mySettings.opt_RoarFix),//战吼修复
            new HorizontalOption(
            name: "卡墙修复",
            description: "避免部分BOSS卡到战斗区域之外",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_StuckFix = index;
            },
            loadSetting: ()=>mySettings.opt_StuckFix),//卡墙修复
            new HorizontalOption(
            name: "硬直修复",
            description: "修复部分BOSS的硬直bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_StunFix = index;
            },
            loadSetting: ()=>mySettings.opt_StunFix),//硬直修复
            new HorizontalOption(
            name: "动画修复",
            description: "修复若干动画导致的卡死bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_Tk2dPlayAnimationWithEventsFix = index;
            },
            loadSetting: ()=>mySettings.opt_Tk2dPlayAnimationWithEventsFix),//动画修复
            new HorizontalOption(
            name: "随机选择修复",
            description: "修复战斗时间较长的情况下BOSS出招异常的bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_SendRandomEventV3Fix = index;
            },
            loadSetting: ()=>mySettings.opt_SendRandomEventV3Fix),//随机选择修复
            new HorizontalOption(
            name: "物品回收修复",
            description: "修复切换场景时召唤的物体不能正确回收的bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_PersonalObjectPoolFix = index;
            },
            loadSetting: ()=>mySettings.opt_PersonalObjectPoolFix),//物品回收修复
            new HorizontalOption(
            name: "无敌状态修复",
            description: "修复特定操作可以使小骑士卡上无敌状态的bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_HeroBoxFix = index;
            },
            loadSetting: ()=>mySettings.opt_HeroBoxFix),//无敌状态修复
            new HorizontalOption(
            name: "假骑士修复",
            description: "修复假骑士的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_3_FalseKnight = index;
            },
            loadSetting: ()=>mySettings.opt_3_FalseKnight),//假骑士修复
            new HorizontalOption(
            name: "草团子修复",
            description: "修复草团子的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_4_MossCharger = index;
            },
            loadSetting: ()=>mySettings.opt_4_MossCharger),//草团子修复
            new HorizontalOption(
            name: "一见修复",
            description: "修复一见的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_5_Hornet1 = index;
            },
            loadSetting: ()=>mySettings.opt_5_Hornet1),//一见修复
            new HorizontalOption(
            name: "芬达哥修复",
            description: "修复芬达哥的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_7_DungDefender = index;
            },
            loadSetting: ()=>mySettings.opt_7_DungDefender),//芬达哥修复
            new HorizontalOption(
            name: "双师傅修复",
            description: "修复双师傅的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_10_OroAndMato = index;
            },
            loadSetting: ()=>mySettings.opt_10_OroAndMato),//双师傅修复
            new HorizontalOption(
            name: "波波修复",
            description: "修复波波的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_14_Oblobbles = index;
            },
            loadSetting: ()=>mySettings.opt_14_Oblobbles),//波波修复
            new HorizontalOption(
            name: "三螳螂修复",
            description: "修复三螳螂的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_15_MantisLord = index;
            },
            loadSetting: ()=>mySettings.opt_15_MantisLord),//三螳螂修复
            new HorizontalOption(
            name: "马尔穆修复",
            description: "修复马尔穆的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_16_Marmu = index;
            },
            loadSetting: ()=>mySettings.opt_16_Marmu),//马尔穆修复
            new HorizontalOption(
            name: "虫母修复",
            description: "修复虫母的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_17_FlukeMother = index;
            },
            loadSetting: ()=>mySettings.opt_17_FlukeMother),//虫母修复
            new HorizontalOption(
            name: "收藏家修复",
            description: "修复收藏家的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_23_Collector = index;
            },
            loadSetting: ()=>mySettings.opt_23_Collector),//收藏家修复
            new HorizontalOption(
            name: "有翼诺斯克修复",
            description: "修复有翼诺斯克的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_28_HornetNosk = index;
            },
            loadSetting: ()=>mySettings.opt_28_HornetNosk),//有翼诺斯克修复
            new HorizontalOption(
            name: "二见修复",
            description: "修复二见的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_30_Hornet2 = index;
            },
            loadSetting: ()=>mySettings.opt_30_Hornet2),//二见修复
            new HorizontalOption(
            name: "白芬达修复",
            description: "修复白芬达的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_35_WhiteDefender = index;
            },
            loadSetting: ()=>mySettings.opt_35_WhiteDefender),//白芬达修复
            new HorizontalOption(
            name: "前辈修复",
            description: "修复前辈的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_41_PureVessel = index;
            },
            loadSetting: ()=>mySettings.opt_41_PureVessel),//前辈修复
            new HorizontalOption(
            name: "辐光修复",
            description: "修复辐光的已知bug",
            values: new [] {"禁用", "启用"},
            applySetting: index =>
            {
                mySettings.opt_42_Radiance = index;
            },
            loadSetting: ()=>mySettings.opt_42_Radiance),//辐光修复
        }
        );

    public void Unload()
    {
        foreach(Module module in Module.modules)
        {
            module.Unload();
        }
    }
}
