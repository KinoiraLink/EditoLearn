using UnityEngine;

namespace EditorFramework
{
    public class XMLGUITextField : XMLGUIBase
    {
        public string Text;
        public XMLGUITextField(string text)
        {
            Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            Text = GUI.TextField(position,Text);
        }

        protected override void OnDispose()
        {
        }
    }
}