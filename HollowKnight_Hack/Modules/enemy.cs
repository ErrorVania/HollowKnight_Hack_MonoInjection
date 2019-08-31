using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Windows;

namespace DebugMod
{
    public struct EnemyData
    {
        public int HP;
        public int maxHP;
        public PlayMakerFSM FSM;
        public Component Spr;
        public GameObject gameObject;

        public EnemyData(int hp, PlayMakerFSM fsm, Component spr, GameObject parent = null, GameObject go = null)
        {
            HP = hp;
            maxHP = hp;
            FSM = fsm;
            Spr = spr;
            gameObject = go;
        }

        public void SetHP(int health)
        {
            HP = health;
            FSM.FsmVariables.GetFsmInt("HP").Value = health;
        }
    }
}

namespace HollowKnight_Hack
{
    class ObjectContainer
    {
        public Component[] cList;
        public GameObject obj;
        public ObjectContainer(GameObject o)
        {
            obj = o;
            Component[] a = o.GetComponents(typeof(Component));

            cList = new Component[a.Length];
            for (int i = 0; i < a.Length;i++)
            {
                cList[i] = a[i];
            }

        }
    }
    class EnemyFinder : MonoBehaviour
    {



        private static GameManager _g;
        private static GameObject parent;
        public static List<DebugMod.EnemyData> enemyPool;

        void Start()
        {
            _g = GameManager.instance;
            enemyPool = new List<DebugMod.EnemyData>();

        }
        
        void Update()
        {
            

            GameObject[] objects = FindObjectsOfType<GameObject>();
            List<ObjectContainer> wOC = new List<ObjectContainer>();

            ObjectContainer[] c = new ObjectContainer[objects.Length];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = new ObjectContainer(objects[i]);
            }


            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].obj.GetComponents<HealthManager>().Length > 0)
                {
                    wOC.Add(c[i]);
                }
            }
            


        }

        void Dump()
        {
            tk2dSprite[] objs = FindObjectsOfType<tk2dSprite>();
            GameObject[] gameObjects = FindObjectsOfType<GameObject>();
            PlayMakerFSM[] pmfsms = FindObjectsOfType<PlayMakerFSM>();

            string[] arr_tk2d = new string[objs.Length];
            string[] arr_gmob = new string[gameObjects.Length];
            string[] arr_pmfsm = new string[gameObjects.Length];




            for (int i = 0; i < objs.Length; i++)
            {
                if (/*objs[i].tag != "Untagged"*/true)
                    arr_tk2d[i] = objs[i].tag + "; " + objs[i].transform.position.ToString() + "; " + typeof(tk2dSprite).FullName;
            }
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (/*objs[i].tag != "Untagged"*/true)
                    arr_gmob[i] = gameObjects[i].tag + "; " + gameObjects[i].transform.position.ToString() + "; " + typeof(GameObject).FullName;
            }
            for (int i = 0; i < pmfsms.Length; i++)
            {
                if (/*objs[i].tag != "Untagged"*/true)
                    arr_pmfsm[i] = pmfsms[i].tag + "; " + pmfsms[i].transform.position.ToString() + "; " + pmfsms[i].Fsm.GetFsmInt("HP").Value.ToString() + "; " + typeof(PlayMakerFSM).FullName;
            }
            //arr = arr.Where(x => !string.IsNullOrEmpty(x)).ToArray();



            var cmb = arr_tk2d.Concat(arr_gmob).Concat(arr_pmfsm).ToArray();


            System.IO.File.WriteAllLines("C:\\Users\\Joshua\\Desktop\\debug_PlayMakerFSM.txt", cmb);
        }
    }
}
