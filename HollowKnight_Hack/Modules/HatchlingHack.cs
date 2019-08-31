using UnityEngine;
namespace HollowKnight_Hack
{
    class HatchlingHack : MonoBehaviour
    {
        private static KnightHatchling _template { get; set; }
        private static HeroController h;

        public static bool state { get; set; }
        public static int minKH { get; set; }

        public void Start()
        {
            h = HeroController.instance;
            _template = null;
            state = false;
            minKH = 4;
        }

        public void Update()
        {
            if (state)
            {
                KnightHatchling a = FindObjectOfType<KnightHatchling>();
                if (a != null || a == _template)
                {
                    if (a.CurrentState == KnightHatchling.State.Follow)
                        _template = a;
                }
                if (FindObjectsOfType<KnightHatchling>().Length < minKH)
                    spawnHatchling();
            }
        }

        public static void updateTemplate() { _template = null; }

        public static void spawnHatchling()
        {
            if (state && _template != null)
                _template.Spawn(h.transform.position);
        }
    }
}
