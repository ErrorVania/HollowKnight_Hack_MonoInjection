using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace HollowKnight_Hack
{
    class Dump : MonoBehaviour
    {
        class ObjectContainer
        {
            public Component[] cList;
            public GameObject obj;

            public ObjectContainer(GameObject o)
            {
                obj = o;
                Component[] temp = obj.GetComponents(typeof(Component));
                cList = temp;
            }
        }

        public static void superdump()
        {
            try
            {

                List<string> content = new List<string>();

                GameObject[] all_gobjects = FindObjectsOfType<GameObject>();
                content.Add(string.Format("Found {0} Objects", all_gobjects.Length));

                ObjectContainer[] advanced_all_gobjects = new ObjectContainer[all_gobjects.Length];

                for (int i = 0; i < advanced_all_gobjects.Length; i++)
                {
                    advanced_all_gobjects[i] = new ObjectContainer(all_gobjects[i]);
                }





                for (int i = 0; i < advanced_all_gobjects.Length; i++)
                {
                    content.Add(string.Format("Object -> Name: \"{0}\"; Layer: {1}", advanced_all_gobjects[i].obj.name, advanced_all_gobjects[i].obj.layer.ToString()));
                    content.Add("-----Pos: " + advanced_all_gobjects[i].obj.transform.position.ToString());

                    if (advanced_all_gobjects[i].obj.tag != "Untagged") { content.Add("-----Tag: " + advanced_all_gobjects[i].obj.tag); }

                    foreach (Component c in advanced_all_gobjects[i].cList)
                    {
                        if (c.tag == "Untagged") { content.Add("----------Component: " + c.GetType().ToString()); }
                        else { content.Add("----------Component: " + c.GetType().ToString() + "; Component Tag: " + c.tag); }
                    }

                }

                TextWriter tw = new StreamWriter("C:\\Users\\" + Environment.UserName + "\\Desktop\\SuperDump.txt");

                foreach (string s in content)
                    tw.WriteLine(s);

                tw.Close();




            }
            catch (Exception e)
            {
                System.IO.File.WriteAllLines(@"C:\Users\Joshua\Desktop\SuperDump.txt", new string[] { e.ToString() });
            }

        }
    }
}
