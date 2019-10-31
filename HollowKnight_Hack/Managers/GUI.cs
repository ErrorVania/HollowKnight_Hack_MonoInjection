using UnityEngine;

namespace HollowKnight_Hack
{
    class hGUI : MonoBehaviour
    {

        public static bool GUIisenabled;
        private string prev;
        private bool wasReset;
        public void Start()
        {
            GUIisenabled = true;
            wasReset = false;
        }
        void Awake()
        {
            wasReset = false;
        }
        void LateUpdate()
        {
            if (GUIisenabled)
            {
                if (!wasReset)
                {
                    FindObjectOfType<CanvasText>().reset();
                    wasReset = true;
                }

                string ui = "";
                ui += "Enemies: " + FindObjectsOfType<HealthManager>().Length + "\n";
                if (PlayerData.instance.invinciTest)
                    ui += string.Format("[{0}] Godmode ON", Main.keybinds["Godmode"]) + "\n";
                else
                    ui += string.Format("[{0}] Godmode OFF", Main.keybinds["Godmode"]) + "\n";

                if (Godmode.soulstate)
                    ui += string.Format("[{0}] Unlimited Soul ON", Main.keybinds["Infinite Soul"]) + "\n";
                else
                    ui += string.Format("[{0}] Unlimited Soul OFF", Main.keybinds["Infinite Soul"]) + "\n";

                if (HatchlingHack.state)
                    ui += string.Format("[{0}] HatchlingHack ON", Main.keybinds["HatchlingTest"]) + "\n";
                else
                    ui += string.Format("[{0}] HatchlingHack OFF", Main.keybinds["HatchlingTest"]) + "\n";


                if (ui == prev)
                {
                    FindObjectOfType<CanvasText>().updateText(ui);
                }
                prev = ui;
            }

        }
    }
}
