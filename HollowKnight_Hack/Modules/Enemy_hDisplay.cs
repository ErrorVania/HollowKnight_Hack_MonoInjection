using UnityEngine;

namespace HollowKnight_Hack
{
    class Enemy_hDisplay : MonoBehaviour
    {
        void Update()
        {
            //enemies.Clear();
            GameObject[] gObjects = FindObjectsOfType<GameObject>();

            for (int i = 0; i < gObjects.Length; i++)
            {
                if (gObjects[i].GetComponent<HealthManager>() != null)
                {
                    if (gObjects[i].GetComponent<Enemy_Extension>() == null)
                        gObjects[i].AddComponent<Enemy_Extension>();
                    //enemies.Add(gObjects[i]);
                }
            }
        }
    }
}
