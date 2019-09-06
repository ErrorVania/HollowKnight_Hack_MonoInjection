using System;
using UnityEngine;


namespace HollowKnight_Hack
{

    



    class Enemy_Extension : MonoBehaviour
    {
        public int maxHealth;
        private GUIStyle style;
        private HealthManager healthManager;
        private Vector2 pos;
        //private Vector3 playerPos;
        private LineRenderer lr;
        private Color color;
        public bool drawLine;
        public bool isVisible;



        void OnBecameVisible()
        {
            isVisible = true;
        }
        void OnBecameInvisible()
        {
            isVisible = false;
        }


        void Start()
        {
            style = new GUIStyle();
            lr = gameObject.AddComponent<LineRenderer>();
            healthManager = GetComponent<HealthManager>();
            maxHealth = healthManager.hp;

            style.fontSize = 17;
            lr.startWidth = 0.25f;
            lr.endWidth = 0.25f;
            lr.widthMultiplier = 0.1f;
            lr.positionCount = 2;



            drawLine = true;
        }



        void OnGUI()
        {
            useGUILayout = false;
            if (isVisible && drawLine)
            {
                pos = Camera.main.WorldToScreenPoint(this.transform.position);
                //playerPos = Camera.main.WorldToScreenPoint(GameObject.FindGameObjectWithTag("Player").transform.position);

                pos.y = 1080f - pos.y;
                pos.y -= 220f;

                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, FindObjectOfType<HeroController>().transform.position);


                float percent = healthManager.hp * 100 / maxHealth;
                color = Color.Lerp(Color.red, Color.green, percent / 100f);
                lr.material.color = style.normal.textColor = color;

                GUI.Label(new Rect(pos, new Vector3(1, 1, 0)), percent.ToString("F") + "%", style);
            } else
            {
                lr.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
            }
        }
    }
}
