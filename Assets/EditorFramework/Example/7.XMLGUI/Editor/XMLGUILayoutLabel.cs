﻿using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILayoutLabel : XMLGUIBase
    {
        public string Text { get; set; }

        public override void ParseXML(XmlElement xmlElement)
        {
            base.ParseXML(xmlElement);
            Text = xmlElement.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            GUILayout.Label(Text);
        }

        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}