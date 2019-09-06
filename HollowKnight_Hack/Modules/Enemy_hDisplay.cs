using UnityEngine;
using System;
using System.Collections.Generic;

namespace HollowKnight_Hack
{
    class Enemy_hDisplay : MonoBehaviour
    {

        private List<Enemy_Extension> visible_enemies;
        private static bool drawall;

        void Start()
        {
            visible_enemies = new List<Enemy_Extension>();
            drawall = true;
        }

        void Update()
        {
            visible_enemies.Clear();
            //enemies.Clear();
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
                    } else
                    {
                        visible_enemies.Remove(gObjects[i].GetComponent<Enemy_Extension>());
                    }
                }
            }



            /*foreach (Enemy_Extension enemy_Extension in visible_enemies)
            {
                if (visible_enemies.IndexOf(enemy_Extension) != EnemySelector && !drawall)
                {
                    enemy_Extension.drawLine = false;
                } else
                {
                    enemy_Extension.drawLine = true;
                }
            }*/

            /*if (Input.GetKeyDown(KeyCode.R))
            {
                
                EnemySelector++;
            } else if (Input.GetKeyDown(KeyCode.T))
            {
                EnemySelector--;
            }*/
        }
    }
}
