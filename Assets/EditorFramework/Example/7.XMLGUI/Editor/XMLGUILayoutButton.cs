using System;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutButton : XMLGUIBase
    {
        private string Text { get; set; }

        public event Action OnClick;
        public override void ParseXML(XmlElement xmlElement,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);
            Text = xmlElement.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            if (GUILayout.Button(Text))
            {
                OnClick?.Invoke();
            }
        }

        protected override void OnDispose()
        {
        }
    }
}