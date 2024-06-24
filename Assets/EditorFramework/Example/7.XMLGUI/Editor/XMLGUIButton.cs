using System;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUIButton : XMLGUIBase
    {
        public string Label;

        public XMLGUIButton(string label)
        {
            Label = label;
        }

        public event Action OnClick;

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            if (GUI.Button(position,Label))
            {
                OnClick?.Invoke();
            }
        }

        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}