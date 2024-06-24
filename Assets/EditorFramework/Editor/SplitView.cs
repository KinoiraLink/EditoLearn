using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class SplitView : GUIBase
    {
        public event Action<Rect> FirstArea, SecondArea;
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            
            var rects = position.VerticalSplit(200, 4);

            var mid = position.VerticalSplitRect(200, 4);
            //右区域
            if(SecondArea != null)
            {
                SecondArea(rects[1]);
            }
            //左区域
            if(FirstArea != null)
            {
                FirstArea(rects[0]);
            }
        
            EditorGUI.DrawRect(mid.Zoom(AnchorType.MiddleCenter,-2),Color.green);
        }

        protected override void OnDispose()
        {
            FirstArea = null;
            SecondArea = null;
        }
    }
}