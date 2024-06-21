// ReSharper disable CheckNamespace

using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow]
    public class CustomEditorExample : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("自定义窗口");
        }
    }
}