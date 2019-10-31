using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace HollowKnight_Hack
{
    class CanvasText : MonoBehaviour
    {
        private GameObject CanvasCarrier;
        private Font curFont;
        public Text tObject;

        void Start()
        {
            reset();
        }
        public void reset()
        {
            curFont = Font.CreateDynamicFontFromOSFont("Arial", 1);

            Canvas canvas;
            CanvasCarrier = new GameObject("CanvasCarrier");
            CanvasCarrier.AddComponent<Canvas>();

            canvas = CanvasCarrier.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasCarrier.AddComponent<CanvasScaler>();
            CanvasCarrier.AddComponent<GraphicRaycaster>();



            GameObject textcontainer = new GameObject();
            textcontainer.transform.parent = CanvasCarrier.transform;
            tObject = textcontainer.AddComponent<Text>();
            tObject.font = curFont;
            RectTransform pos = tObject.GetComponent<RectTransform>();
            pos.localPosition = Vector3.zero;
            pos.sizeDelta = new Vector2(400, 200);







        }
        public void updateText(string text)
        {
            tObject.text = text;

            /*GameObject textcontainer = new GameObject();
            textcontainer.transform.parent = CanvasCarrier.transform;
            Text t = textcontainer.AddComponent<Text>();
            t.font = curFont;
            t.text = text;
            RectTransform pos = t.GetComponent<RectTransform>();
            pos.localPosition = loc;
            pos.sizeDelta = sizeDelta;
            t.color = c;
            tCarrier.Add(t);*/
        }


    }
}
