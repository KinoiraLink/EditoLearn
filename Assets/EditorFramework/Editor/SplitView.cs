using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class SplitView : GUIBase
    {
        public event Action<Rect> FirstArea, SecondArea;

        public float SplitWidth = 200;
        public float MinSize = 100;

        public bool Dragging = false;
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            
            var rects = position.VerticalSplit(SplitWidth, 4);

            var mid = position.VerticalSplitRect(SplitWidth, 4);
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

            var e = Event.current;

            if (mid.Contains(e.mousePosition))
            {
                EditorGUIUtility.AddCursorRect(mid,MouseCursor.ResizeHorizontal);
            }

            switch (e.type)
            {
                case EventType.MouseDown:
                    if (mid.Contains(e.mousePosition))
                    {
                        Dragging = true;
                    }
                    break;
                case EventType.MouseDrag:
                    if (Dragging)
                    {
                        SplitWidth += e.delta.x;
                        
                        SplitWidth = Mathf.Clamp(SplitWidth, MinSize, position.width -MinSize);
                        
                        e.Use();
                    }
                    break;
                
                case EventType.MouseUp:
                    if (Dragging)
                    {
                        Dragging = false;
                    }
                    break;
            }
        }

        protected override void OnDispose()
        {
            FirstArea = null;
            SecondArea = null;
        }
    }
}