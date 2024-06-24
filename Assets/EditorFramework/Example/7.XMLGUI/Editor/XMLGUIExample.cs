

using System;
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
        private void OnEnable()
        {
            TextAsset xmlFileAsset =  AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            mXMLContent = xmlFileAsset.text;
        }

        private void OnGUI()
        {
            var doc = new XmlDocument();
            doc.LoadXml(mXMLContent);
            var rootNode = doc.SelectSingleNode("GUI");
            foreach (XmlElement rootNodeChildNode in rootNode.ChildNodes)
            {
                if (rootNodeChildNode.Name == "Label")
                {
                    GUILayout.Label(rootNodeChildNode.InnerText);
                }
            }
        }
    }
    
    
}