
using System.IO;
using UnityEditor;
using UnityEngine;


namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private string mPath = "Assets";
        private void OnGUI()
        {
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            var rects = rect.VerticalSplit(rect.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];
            

         
            if (GUI.Button(rightRect, GUIContents.Folder))
            {
                var path = EditorUtility.OpenFolderPanel("打开文件", Application.dataPath, "default Name");

                var assetsFullPath = Path.GetFullPath(Application.dataPath);
                mPath = "Assets" + Path.GetFullPath(path).
                    Substring(assetsFullPath.Length)
                    .Replace("\\","/");
                Debug.Log(mPath);
            }
            var currentGUIEnable = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(leftRect,mPath);
            GUI.enabled = currentGUIEnable;
            var dragInfo = DragAndDropTool.Drag(Event.current, leftRect);

            if (dragInfo.enterArea && dragInfo.complete && !dragInfo.dragging)
            {
                mPath = dragInfo.Paths[0];
            }
        }
    }
    
    
}
