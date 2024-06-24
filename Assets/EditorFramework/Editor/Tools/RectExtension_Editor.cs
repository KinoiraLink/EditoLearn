using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public static class RectExtension_Editor
    {
        public static void Drawoutline(this Rect rect, Color color)
        {
            Handles.color = color;
            Handles.DrawAAPolyLine(2,
                new Vector3(rect.x,rect.y,0),
                new Vector3(rect.x,rect.yMax,0),
                new Vector3(rect.xMax,rect.yMax,0),
                new Vector3(rect.xMax,rect.y,0),
                new Vector3(rect.x,rect.y,0)

                );
            Handles.color = Color.white;
        }
    }
}