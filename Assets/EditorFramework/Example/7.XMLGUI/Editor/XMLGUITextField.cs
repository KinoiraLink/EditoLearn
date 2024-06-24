using UnityEngine;

namespace EditorFramework
{
    public class XMLGUITextField : GUIBase
    {
        public string Text;
        public XMLGUITextField(string text)
        {
            Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.TextField(Text);
        }

        protected override void OnDispose()
        {
        }
    }
}