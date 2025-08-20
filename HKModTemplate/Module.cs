using System.Collections;
using System.Reflection;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Modding;
using MonoMod.RuntimeDetour;
using Satchel;
using UnityEngine;
using static GamepadVibrationMixer.GamepadVibrationEmission;

namespace MyHK
{
    public class Module
    {
        private int setting = 1;
        public static List<Module> modules = new List<Module>();

        public int Setting
        {
            get
            {
                return setting;
            }
            set
            {
                setting = value;
                Unload();
                if (value != 0)
                {
                    Load();
                }
            }
        }

        public Module()
        {
            Load();
            modules.Add(this);
        }

        public virtual void Load()
        {
        }

        public virtual void Unload()
        {
        }

        public void Refresh()
        {
            Unload();
            if (setting != 0)
            {
                Load();
            }
        }
    }
}
