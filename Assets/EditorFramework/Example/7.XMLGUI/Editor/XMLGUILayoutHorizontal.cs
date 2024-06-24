using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutHorizontal : XMLGUIContainerBase
    {
        public bool Box { get; set; }
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);
            var boxString = xmlElement.GetAttribute("box");
            if (!string.IsNullOrEmpty(boxString))
            {
                Box = bool.Parse(boxString);
            }
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            if (Box)
            {
                GUILayout.BeginHorizontal("box");

            }
            else
            {
                GUILayout.BeginHorizontal();

            }
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