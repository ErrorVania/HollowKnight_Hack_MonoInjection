﻿using UnityEngine;


namespace HollowKnight_Hack
{
    class Enemy_Extension : MonoBehaviour
    {
        public int maxHealth;
        public bool isVisible, isSmallEnemy;
        private GUIStyle style;
        public HealthManager healthManager;
        //private Vector2 pos;
        private LineRenderer lr;



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
            lr.startWidth = lr.endWidth = 0.15f;
            lr.widthMultiplier = 0.1f;
            lr.positionCount = 2;



            isVisible = true;
            isSmallEnemy = (maxHealth <= PlayerData.instance.nailDamage) ? true : false;

        }



        void OnGUI()
        {
            if (isVisible && !isSmallEnemy)
            {
                //pos = Camera.main.WorldToScreenPoint(this.transform.position);
                //pos.y = 1080f - pos.y - 220f;

                float percent = healthManager.hp * 100 / maxHealth;
                lr.material.color = style.normal.textColor = Color.Lerp(Color.red, Color.green, percent / 100f);


                lr.SetPositions(new Vector3[] {
                    transform.position,
                    FindObjectOfType<HeroController>().transform.position }
                );
            }
            else
            {
                lr.SetPositions(new Vector3[] { Vector3.zero, Vector3.zero });
            }
        }
    }
}
