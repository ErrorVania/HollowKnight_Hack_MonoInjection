using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace HollowKnight_Hack
{
    


    

    class Enemy_hDisplay : MonoBehaviour
    {
        public static int enemy_count = -1;
        private List<GameObject> enemies;
        private Camera mCam;
        GUIStyle style;



        void Start()
        {
            enemies = new List<GameObject>();
            mCam = Camera.main;
            style = new GUIStyle();
            style.normal.textColor = Color.green;
            style.fontSize = 30;
            
            
        }

        void Update()
        {
            enemies.Clear();
            GameObject[] gObjects = FindObjectsOfType<GameObject>();
            
            for (int i = 0; i < gObjects.Length; i++)
                if (gObjects[i].GetComponent<HealthManager>() != null)
                    enemies.Add(gObjects[i]);
            
            enemy_count = enemies.Count;

        }

        void OnGUI()
        {
            foreach (GameObject a in enemies)
            {
                BoxCollider2D bcollider = a.GetComponent<UnityEngine.BoxCollider2D>();
                Bounds bounds2 = bcollider.bounds;


                #region notmycodebyanextend
                float width = Math.Abs(bounds2.max.x - bounds2.min.x);
                float height = Math.Abs(bounds2.max.y - bounds2.min.y);

                Vector2 pos = Camera.main.WorldToScreenPoint(a.transform.position + new Vector3(bcollider.offset.x, bcollider.offset.y, 0f));
                Vector2 size = Camera.main.WorldToScreenPoint(bcollider.transform.position + new Vector3(width, height, 0));
                Vector2 pivot = Camera.main.WorldToScreenPoint(bcollider.transform.position);
                Vector2 pointA = Camera.main.WorldToScreenPoint((Vector2)bcollider.transform.position + bcollider.offset);
                size = size - pos;

                
                pointA.x -= size.x / 2f;
                pointA.y -= size.y / 2f;
                Vector2 pointB = pointA + size;

                pointA = (Vector2)(bcollider.transform.rotation * (pointA - pivot)) + pivot;
                pointB = (Vector2)(bcollider.transform.rotation * (pointB - pivot)) + pivot;

                pos = new Vector2(
                    pointA.x < pointB.x ? pointA.x : pointB.x, 
                    pointA.y > pointB.y ? pointA.y : pointB.y
                    );
                size = new Vector2(Math.Abs(pointA.x - pointB.x), Math.Abs(pointA.y - pointB.y));

                size.x *= 1920f / Screen.width;
                size.y *= 1080f / Screen.height;

                pos.x *= 1920f / Screen.width;
                pos.y *= 1080f / Screen.height;
                pos.y = 1080f - pos.y;
                #endregion




                HealthManager healthManager = a.GetComponent<HealthManager>();
                GUI.Label(new Rect(pos, size),string.Format("{0}",healthManager.hp),style);
            }
        }


        




        
    }
}
