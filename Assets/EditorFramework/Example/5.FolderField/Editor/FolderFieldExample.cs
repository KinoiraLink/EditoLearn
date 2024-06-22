using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private string mPath = String.Empty;
        private void OnGUI()
        {
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));

            GUI.Label(rect,mPath);
            if (GUI.Button(rect, GUIContents.Folder))
            {
                var path = EditorUtility.OpenFolderPanel("打开文件", Application.dataPath, "default Name");

                mPath = path;
                Debug.Log(path);
            }

            var dragInfo = DragAndDropTool.Drag(Event.current, rect);

            if (dragInfo.enterArea && dragInfo.complete && !dragInfo.dragging)
            {
                mPath = dragInfo.Paths[0];
            }
        }
    }
    
    
}
