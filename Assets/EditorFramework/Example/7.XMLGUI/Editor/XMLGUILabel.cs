﻿using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILabel : XMLGUIBase
    {
        public string Text;
        public XMLGUILabel(string text)
        {
            Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.Label(Text);
        }

        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}