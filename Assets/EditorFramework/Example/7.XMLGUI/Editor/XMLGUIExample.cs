

using System;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

// ReSharper disable CheckNamespace



// ReSharper disable InconsistentNaming

namespace EditorFramework
{
    [CustomEditorWindow(7)]
    public class XMLGUIExample : EditorWindow
    {
        private const string XMLFilePath = "Assets/EditorFramework/Example/7.XMLGUI/Editor/GUIExample.xml";
        private string mXMLContent;

        public List<GUIBase> XMLGUI;
        private void OnEnable()
        {
            TextAsset xmlFileAsset =  AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            mXMLContent = xmlFileAsset.text;

            XMLGUI = new List<GUIBase>();
            
            var doc = new XmlDocument();
            doc.LoadXml(mXMLContent);
            XmlNode rootNode = doc.SelectSingleNode("GUI");
            if (rootNode != null)
            {
                foreach (var rootNodeChildNode in rootNode.ChildNodes)
                {
                    if (rootNodeChildNode is XmlElement xmlElement)
                    {
                        if (xmlElement.Name == "Label")
                        {
                            XMLGUI.Add(new XMLGUILabel(xmlElement.InnerText));
                    
                        }
                        else if (xmlElement.Name == "TextField")
                        {
                            XMLGUI.Add(new XMLGUITextField(xmlElement.InnerText));
                        }
                    }
                
            
                }
            }
            
            
        }

        private void OnGUI()
        {
           // var selfSize = this.LocalPosition();
            foreach (GUIBase guiBase in XMLGUI)
            {
                //var rect = GUILayoutUtility.GetRect(selfSize.width,selfSize.height);
                guiBase.OnGUI(default);
            }
        }
    }
    
    
}