using System;
using UnityEngine;


namespace HollowKnight_Hack
{

    



    class Enemy_Extension : MonoBehaviour
    {
        public int maxHealth;
        private Camera mCam;
        private GUIStyle style;
        private BoxCollider2D bcollider;
        private HealthManager healthManager;

        void Start()
        {
            healthManager = GetComponent<HealthManager>();
            bcollider = GetComponent<BoxCollider2D>();
            maxHealth = healthManager.hp;
            mCam = Camera.main;

            style = new GUIStyle();
            style.normal.textColor = Color.grey;
            style.fontSize = 20;
        }






        void OnGUI()
        {
            //Bounds bounds2 = bcollider.bounds;

            Vector2 pos = mCam.WorldToScreenPoint(this.transform.position);

            pos.y = 1080f - pos.y;
            pos.y -= 220f;

            Vector3 size = new Vector3(1, 1, 0);

            HealthManager healthManager = GetComponent<HealthManager>();
            Enemy_Extension maxHealthObj = GetComponent<Enemy_Extension>();

            float percent = healthManager.hp * 100 / maxHealthObj.maxHealth;

            style.normal.textColor = Color.Lerp(Color.red, Color.green, percent / 100f);

            GUI.Label(new Rect(pos, size), percent.ToString("F") + "%", style);
        }
    }
}
