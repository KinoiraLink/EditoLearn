using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(9)]
    public class SearchablePopExample : EditorWindow
    {
        private DayOfWeek mValue;
        private void OnGUI()
        {
            EditorGUILayout.EnumPopup("DayOfWeek", mValue);
            var rect = GUILayoutUtility.GetRect(200, 200);
            if (GUI.Button(rect, "Change\nthe\nDayOfWeek"))
            {

                SearchablePopup.Show(rect,Enum.GetNames(typeof(DayOfWeek)),(int)mValue,OnValueChange);
            }
        }

        private void OnValueChange(int arg1, string arg2)
        {
            mValue = (DayOfWeek)arg1;
            Repaint();
        }
    }
}