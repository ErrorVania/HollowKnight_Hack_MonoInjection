using System.Collections.Generic;
using UnityEngine;

namespace HollowKnight_Hack
{
    class Enemy_hDisplay : MonoBehaviour
    {

        private List<Enemy_Extension> visible_enemies;

        void Start()
        {
            visible_enemies = new List<Enemy_Extension>();
        }

        void Update()
        {
            visible_enemies.Clear();
            GameObject[] gObjects = FindObjectsOfType<GameObject>();

            for (int i = 0; i < gObjects.Length; i++)
            {
                if (gObjects[i].GetComponent<HealthManager>() != null)
                {
                    if (gObjects[i].GetComponent<Enemy_Extension>() == null)
                        gObjects[i].AddComponent<Enemy_Extension>();


                    if (gObjects[i].GetComponent<Enemy_Extension>().isVisible)
                    {
                        visible_enemies.Add(gObjects[i].GetComponent<Enemy_Extension>());
                    }
                    else
                    {
                        visible_enemies.Remove(gObjects[i].GetComponent<Enemy_Extension>());
                    }
                }
            }
        }
    }
}
