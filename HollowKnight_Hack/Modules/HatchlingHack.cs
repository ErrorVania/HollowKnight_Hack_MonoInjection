using UnityEngine;
using System.Collections.Generic;
namespace HollowKnight_Hack
{
    class HatchlingHack : MonoBehaviour
    {
        private static GameObject _template { get; set; }
        private static HeroController h;

        private List<GameObject> Knight_Hatchlings;

        public static bool state { get; set; }
        public static int minKH { get; set; }

        public void Start()
        {
            h = HeroController.instance;
            _template = null;
            Knight_Hatchlings = new List<GameObject>();
            state = false;
            minKH = 4;
        }

        public void Update()
        {
            Knight_Hatchlings.Clear();
            if (state)
            {
                GameObject[] a = FindObjectsOfType<GameObject>();
                foreach (GameObject b in a)
                {
                    if (b.GetComponent<KnightHatchling>() != null)
                    {
                        Knight_Hatchlings.Add(b);
                    }
                }

                if (Knight_Hatchlings.Count < minKH)
                {
                    GameObject f = GameObject.Instantiate(Knight_Hatchlings[0], GameObject.Find("Knight").transform);
                    f.GetComponent<KnightHatchling>().FsmQuickSpawn();
                }
            }
        }

        public static void updateTemplate() { _template = null; }
    }
}
