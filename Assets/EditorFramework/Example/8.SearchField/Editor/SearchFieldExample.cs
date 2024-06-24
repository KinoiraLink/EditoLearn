using System;
using System.Collections;
using System.Collections.Generic;
using EditorFramework;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
 
    [CustomEditorWindow(8)]
    public class SearchFieldExample : EditorWindow
    {
        private SearchField mSearchField;
        private string mSearchContent = "";

        private string[] mSearchableContents = new[] { "model1", "model2", "model3" };


        private void OnEnable()
        {
            mSearchField = new SearchField(mSearchContent, mSearchableContents, 0);
            mSearchField.OnModeChanged += MSearchFieldOnOnModeChanged;
            mSearchField.OnValueChanged += MSearchFieldOnOnValueChanged;
            mSearchField.OnEndEdit += MSearchFieldOnOnEndEdit;
        }

        private void MSearchFieldOnOnModeChanged(int obj)
        {
            Debug.Log(obj);
        }

        private void MSearchFieldOnOnValueChanged(string obj)
        {
            Debug.Log(obj);
        }


        private void MSearchFieldOnOnEndEdit(string obj)
        {
            Debug.Log(obj);
        }
        

        private void OnGUI()
        {
            GUILayout.Label("SearchField");
            mSearchField.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(20)));
        }
    }   
}
