using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutVertical : XMLGUIContainerBase
    {
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.BeginVertical();
            {
                mXmlgui.Draw();
            }
            GUILayout.EndHorizontal();
        }
        
        protected override void OnDispose()
        {
        }
    }
}