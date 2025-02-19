﻿using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILabel : XMLGUIBase
    {
        public string Text;

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUI.Label(position,Text);
        }
        public override void ParseXML(XmlElement xmlElement,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);
            Text = xmlElement.InnerText;
        }

        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}