using UnityEngine;

namespace HollowKnight_Hack
{
    class Godmode : MonoBehaviour
    {
        private PlayerData p;
        private HeroController h;

        public static bool godstate { get; set; }
        public static bool soulstate { get; set; }

        public void Start()
        {
            p = PlayerData.instance;
            h = HeroController.instance;

            p.invinciTest = false;

            godstate = false;
            soulstate = false;
        }



        public void Update()
        {
            p.invinciTest = godstate;
            if (soulstate)
                h.SetMPCharge(99);
        }
    }
}
