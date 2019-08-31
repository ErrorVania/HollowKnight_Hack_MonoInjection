using UnityEngine;
namespace HK_Hack
{
    public class Loader
    {
        public static GameObject _Load;
        //private GameObject _gameObject;
        public static void Init()
        {
            _Load = new GameObject();
            _Load.AddComponent<HollowKnight_Hack.Main>();
            _Load.AddComponent<HollowKnight_Hack.hGUI>();
            _Load.AddComponent<HollowKnight_Hack.HatchlingHack>();
            _Load.AddComponent<HollowKnight_Hack.Godmode>();
            
            _Load.AddComponent<HollowKnight_Hack.warp>();
            _Load.AddComponent<HollowKnight_Hack.EnemyFinder>();
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
