using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutHorizontal : XMLGUIContainerBase
    {
        

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.BeginHorizontal();
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