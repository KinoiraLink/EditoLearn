﻿

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

        private XMLGUI mXmlgui;

        private void OnEnable()
        {
            
            TextAsset xmlFileAsset =  AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            mXMLContent = xmlFileAsset.text;

            mXmlgui = new XMLGUI();
            mXmlgui.ReadXML(mXMLContent);

            mXmlgui.GetGUIBaseById<XMLGUIButton>("loginButton").OnClick += () =>
            {
                Debug.Log("Clicked");
                mXmlgui.GetGUIBaseById<XMLGUILabel>("label").Text = "1";
            };

        }

        private void OnGUI()
        {
           // var selfSize = this.LocalPosition();
            foreach (GUIBase guiBase in mXmlgui.GUIBases)
            {
                //var rect = GUILayoutUtility.GetRect(selfSize.width,selfSize.height);
                guiBase.OnGUI(default);
            }
        }
    }
    
    
}