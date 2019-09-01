﻿using UnityEngine;
namespace HK_Hack
{
    public class Loader
    {
        public static GameObject _Load;

        public static void Init()
        {
            _Load = new GameObject();
            _Load.name = "hLoader";
            _Load.AddComponent<HollowKnight_Hack.Main>();
            _Load.AddComponent<HollowKnight_Hack.hGUI>();
            _Load.AddComponent<HollowKnight_Hack.HatchlingHack>();
            _Load.AddComponent<HollowKnight_Hack.Godmode>();
            _Load.AddComponent<HollowKnight_Hack.Dump>();
            _Load.AddComponent<HollowKnight_Hack.warp>();
            _Load.AddComponent<HollowKnight_Hack.Enemy_hDisplay>();
            GameObject.DontDestroyOnLoad(_Load);
        }
        public static void Unload()
        {
            _Unload();
        }
        private static void _Unload()
        {
            GameObject.Destroy(_Load);
        }
        
    }
}
