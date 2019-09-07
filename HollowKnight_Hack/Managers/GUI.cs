using UnityEngine;

namespace HollowKnight_Hack
{
    class hGUI : MonoBehaviour
    {
        private PlayerData p;
        private HeroController h;
        private GameManager g;

        private GUIStyle _style;
        private GUIStyle _styleON;
        private GUIStyle _styleOFF;

        private float xoffset;
        private float yoffset;

        public static bool GUIisenabled;

        public void Start()
        {
            GUIisenabled = true;
            p = PlayerData.instance;
            h = HeroController.instance;
            g = GameManager.instance;

            _style = new GUIStyle();
            _styleON = new GUIStyle();
            _styleOFF = new GUIStyle();

            _style.normal.textColor = Color.white;
            _styleON.normal.textColor = Color.green;
            _styleOFF.normal.textColor = Color.red;

            xoffset = Screen.width - 200;
            yoffset = Screen.height - 90;



        }

        public void OnGUI()
        {
            if (GUIisenabled)
            {
                GUI.Label(new Rect(xoffset, yoffset - 15, 150f, 50f), "Enemies: " + FindObjectsOfType<HealthManager>().Length, _style);
                GUI.Label(new Rect(xoffset, yoffset, 150f, 50f), g.GetSceneNameString() + " " + h.transform.position, _style);

                if (PlayerData.instance.invinciTest)
                    GUI.Label(new Rect(xoffset, yoffset + 15, 150f, 50f), string.Format("[{0}] Godmode ON", Main.keybinds["Godmode"]), _styleON);
                else
                    GUI.Label(new Rect(xoffset, yoffset + 15, 150f, 50f), string.Format("[{0}] Godmode OFF", Main.keybinds["Godmode"]), _styleOFF);

                if (Godmode.soulstate)
                    GUI.Label(new Rect(xoffset, yoffset + 30, 150f, 50f), string.Format("[{0}] Unlimited Soul ON", Main.keybinds["Infinite Soul"]), _styleON);
                else
                    GUI.Label(new Rect(xoffset, yoffset + 30, 150f, 50f), string.Format("[{0}] Unlimited Soul OFF", Main.keybinds["Infinite Soul"]), _styleOFF);

                if (HatchlingHack.state == true)
                    GUI.Label(new Rect(xoffset, yoffset + 45, 150f, 50f), string.Format("[{0}] HatchlingHack ON", Main.keybinds["HatchlingTest"]), _styleON);
                else
                    GUI.Label(new Rect(xoffset, yoffset + 45, 150f, 50f), string.Format("[{0}] HatchlingHack OFF", Main.keybinds["HatchlingTest"]), _styleOFF);





                int yoffset_N = 15;


                GUI.Label(new Rect(xoffset, yoffset + 60, 150f, 50f), "Warp Selected: " + warp.WarpSelector.ToString(), _style);

                foreach (Vector3 v in warp.warpCoords)
                {
                    if (v == warp.warpCoords[warp.WarpSelector])
                        GUI.Label(new Rect(xoffset, yoffset_N, 150f, 50f), string.Format("[{0}] ", warp.warpCoords.IndexOf(v)) + v.ToString() + " " + warp.warpSceneNames[warp.warpCoords.IndexOf(v)], _styleON);
                    else
                        GUI.Label(new Rect(xoffset, yoffset_N, 150f, 50f), string.Format("[{0}] ", warp.warpCoords.IndexOf(v)) + v.ToString() + " " + warp.warpSceneNames[warp.warpCoords.IndexOf(v)], _style);
                    yoffset_N += 15;
                }





            }


        }
    }
}
