using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        [MenuItem("EditorFramework/Open %#e")]
        static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        private void OnEnable()
        {
            var editorWindowType = typeof(EditorWindow);
            var m_Parent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);

            var editorWindowTypes =AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assemble => assemble.GetTypes())
                .Where(type => type.IsSubclassOf(editorWindowType));

            foreach (var windowType in editorWindowTypes)
            {
                Debug.Log(windowType.Name);
            }

        }
    }
}

