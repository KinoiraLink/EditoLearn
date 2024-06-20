using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        [MenuItem("EditorFramework/Open %#e")]
        static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        private IEnumerable<Type> mEditorWindowTypes;

        private void OnEnable()
        {
            //var m_Parent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);
            mEditorWindowTypes =
                typeof(EditorWindow).
                       GetSubTypesWithClassAttributeInAssemblies<CustomEditorWindowAttribute>();
        }

        private void OnGUI()
        {
            foreach (var editorWindowType in mEditorWindowTypes)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(editorWindowType.Name);
                    if (GUILayout.Button("Open", GUILayout.Width(80)))
                    {
                        GetWindow(editorWindowType).Show();
                    }
                }
                GUILayout.EndHorizontal();
            }
            
        }
    }
}

