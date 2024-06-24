using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUITextField : XMLGUIBase
    {
        public string Text;

        public override void ParseXML(XmlElement xmlElement)
        {
            base.ParseXML(xmlElement);
            Text = xmlElement.InnerText;
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