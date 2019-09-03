using UnityEngine;

namespace HollowKnight_Hack
{
    class Godmode : MonoBehaviour
    {
        private PlayerData p;
        private HeroController h;

        public static bool godstate;
        public static bool soulstate;
        private static bool UsedOnce;

        public void Start()
        {
            p = PlayerData.instance;
            h = HeroController.instance;


            UsedOnce = false;
            godstate = false;
            soulstate = false;
        }



        public void Update()
        {
            if (UsedOnce)
            {
                p.invinciTest = godstate;
                if (soulstate)
                    h.SetMPCharge(99);
            }
        }


        public static void GodStateSetter(bool a)
        {
            UsedOnce = true;
            godstate = a;
        }
        public static void SoulStateSetter(bool a)
        {
            UsedOnce = true;
            soulstate = a;
        }
    }
}
