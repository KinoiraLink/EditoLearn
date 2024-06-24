using UnityEngine;

namespace EditorFramework
{
    public class XMLGUITextArea : XMLGUIBase
    {
        public string Text;

        public XMLGUITextArea(string text)
        {
            Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            Text = GUI.TextArea(position,Text);
        }

        protected override void OnDispose()
        {
        }
    }
}