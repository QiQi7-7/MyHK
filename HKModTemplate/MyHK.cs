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
    public override string GetVersion() => "1.2.0.1";

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

    public static Settings mySettings = new();
    public bool ToggleButtonInsideMenu => true;
    public void OnLoadGlobal(Settings settings) => mySettings = settings;
    public Settings OnSaveGlobal() => mySettings;

    public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates)
    {
        return ModMenu.CreateMenu(modListMenu, toggleDelegates).GetMenuScreen(modListMenu);
    }

    public void Unload()
    {
        foreach(Module module in Module.modules)
        {
            module.Unload();
        }
    }
}
