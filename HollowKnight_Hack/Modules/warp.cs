using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace HollowKnight_Hack
{

    class warp : MonoBehaviour
    {
        private static GameManager _g;
        private static HeroController _h;
        private static PlayerData _p;

        private static string origDreamGateScene;
        private static Vector2 origDreamGatePos;

        public static List<Vector3> warpCoords;
        public static List<string> warpSceneNames;
        public static int WarpSelector;

        void Start()
        {
            _g = GameManager.instance;
            _h = HeroController.instance;
            _p = PlayerData.instance;

            warpCoords = new List<Vector3>();
            warpSceneNames = new List<string>();

            warpCoords.Clear();
            warpSceneNames.Clear();
            WarpSelector = 0;
            
           
        }
        void Update()
        {
            if (WarpSelector < 0)
            {
                WarpSelector++;
            }
            if (WarpSelector > warpCoords.Count-1)
            {
                WarpSelector--;
            }
        }


        public static void tp()
        {
            /*origDreamGateScene = _p.dreamGateScene;
            origDreamGatePos = new Vector2(_p.dreamGateX, _p.dreamGateY);

            _p.dreamGateScene = warpSceneNames[WarpSelector];





            _p.dreamGateX = warpCoords[WarpSelector].x;
            _p.dreamGateY = warpCoords[WarpSelector].y;
            _g.WarpToDreamGate();

            //GameObject[] b = GameObject.FindGameObjectsWithTag("Player");
            //for (int i = 0; i < b.Length;i++)
                //b[i].transform.position = warpCoords[WarpSelector];


            _p.dreamGateX = origDreamGatePos.x;
            _p.dreamGateY = origDreamGatePos.y;
            _p.dreamGateScene = origDreamGateScene;*/


            //GameManager.instance.ChangeToScene(warpSceneNames[WarpSelector], "", 0);
            
            GameManager.instance.LoadScene(warpSceneNames[WarpSelector]);
            //GameManager.instance.ui.SetState(GlobalEnums.UIState.PLAYING);

        }

        public static void addWarpPoint()
        {
            if (!warpCoords.Contains(_h.transform.position) && !warpSceneNames.Contains(_g.GetSceneNameString())) {
                warpCoords.Add(_h.transform.position);
                warpSceneNames.Add(_g.GetSceneNameString());
            }
        }



       
    }
}
