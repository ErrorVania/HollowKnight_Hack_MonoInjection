using System;
using UnityEngine;

namespace HollowKnight_Hack
{
    class ColorCalculatorEnemySelector
    {
        
        public static Color calcColor(float percent)
        {
            return Color.Lerp(Color.red, Color.green, percent / 100f);
        }
    }
}
