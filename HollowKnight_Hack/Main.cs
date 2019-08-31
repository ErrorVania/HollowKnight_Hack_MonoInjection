using UnityEngine;
using System.Collections.Generic;
namespace HollowKnight_Hack
{

    class Main : MonoBehaviour
    {

        private HeroController h;
        private PlayerData p;
        private GameManager g;

        public static Dictionary<string, KeyCode> keybinds;


        public void Start()
        {
            h = HeroController.instance;
            p = PlayerData.instance;
            g = GameManager.instance;
            keybinds = new Dictionary<string, KeyCode>();



            keybinds.Add("Unload Lib",KeyCode.Delete);
            keybinds.Add("Godmode", KeyCode.U);
            keybinds.Add("Infinite Soul", KeyCode.Q);
            keybinds.Add("Full Heal", KeyCode.G);
            keybinds.Add("Add Warp", KeyCode.W);
            keybinds.Add("Increase WarpSelector", KeyCode.R);
            keybinds.Add("Decrease WarpSelector", KeyCode.T);
            keybinds.Add("Warp", KeyCode.P);
            keybinds.Add("Add Blue Health", KeyCode.K);
            keybinds.Add("HatchlingTest", KeyCode.H);
        }
        public void Update()
        {
            if (Input.GetKeyDown(keybinds["Unload Lib"]))
                HK_Hack.Loader.Unload();


            if (Input.GetKeyDown(keybinds["Infinite Soul"]))
                Godmode.soulstate = !Godmode.soulstate;

            if (Input.GetKeyDown(keybinds["Godmode"]))
                Godmode.godstate = !Godmode.godstate;

            if (Input.GetKeyDown(keybinds["Full Heal"]))
                h.AddHealth(p.maxHealth - p.health);

            if (Input.GetKeyDown(keybinds["Add Warp"]))
                warp.addWarpPoint();

            if (Input.GetKeyDown(keybinds["Increase WarpSelector"]))
                warp.WarpSelector++;

            if (Input.GetKeyDown(keybinds["Decrease WarpSelector"]))
                warp.WarpSelector--;

            if (Input.GetKeyDown(keybinds["Warp"]))
                //warp.tp();
                g.LoadScene("GG_Atrium");

            if (Input.GetKeyDown(keybinds["Add Blue Health"]))
                EventRegister.SendEvent("ADD BLUE HEALTH");

            if (Input.GetKeyDown(keybinds["HatchlingTest"]))
                HatchlingHack.state = !HatchlingHack.state;

            
        }
     
    }
}