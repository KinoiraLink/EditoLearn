using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUI
    {
        private List<XMLGUIBase> mGUIBases = new List<XMLGUIBase>();
        private Dictionary<string, XMLGUIBase> mGUIBaseForId = new Dictionary<string, XMLGUIBase>();

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            XMLGUIBase t = default;
            if (mGUIBaseForId.TryGetValue(id,out t))
            {
                return t as T;
            }
            else
            {
                return default;
            }
        }
        public void ReadXML(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNode rootNode = doc.SelectSingleNode("GUI");
            string id = string.Empty;
            XMLGUIBase guibase = default;
            if (rootNode != null)
            {
                foreach (var rootNodeChildNode in rootNode.ChildNodes)
                {
                    if (rootNodeChildNode is XmlElement xmlElement)
                    {
                        if (xmlElement.Name == "Label")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            
                           

                            guibase = new XMLGUILabel(xmlElement.InnerText);
                            guibase.Id = id;
                            
                            var positionString = xmlElement.Attributes["position"].Value;
                            Rect position = StringToRectPosition(positionString);
                            guibase.SetPosition(position);
                            AddGUIBase(guibase);

                    
                        }
                        else if (xmlElement.Name == "TextField")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            guibase = new XMLGUITextField(xmlElement.InnerText);
                            guibase.Id = id;
                            
                            var positionString = xmlElement.Attributes["position"].Value;
                            Rect position = StringToRectPosition(positionString);
                            guibase.SetPosition(position);
                            AddGUIBase(guibase);

                        }
                        else if (xmlElement.Name == "TextArea")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            guibase = new XMLGUITextArea(xmlElement.InnerText);
                            guibase.Id = id;
                            
                            var positionString = xmlElement.Attributes["position"].Value;
                            Rect position = StringToRectPosition(positionString);
                            guibase.SetPosition(position);
                            AddGUIBase(guibase);


                        }
                        else if (xmlElement.Name == "Button")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            guibase = new XMLGUIButton(xmlElement.InnerText);
                            guibase.Id = id;
                            
                            var positionString = xmlElement.Attributes["position"].Value;
                            Rect position = StringToRectPosition(positionString);
                            guibase.SetPosition(position);
                            AddGUIBase(guibase);
                        }
                    }
                
            
                }
            }
        }

        private void  AddGUIBase(XMLGUIBase xmlguiBase)
        {
            mGUIBases.Add(xmlguiBase);
            if (!string.IsNullOrEmpty(xmlguiBase.Id))
            {
                mGUIBaseForId.Add(xmlguiBase.Id,xmlguiBase);
            }
        }

        public void Draw()
        {
            foreach (XMLGUIBase xmlguiBase in mGUIBases)
            {
                xmlguiBase.Draw();
            }
        }

        public Rect StringToRectPosition(string positionString)
        {
            var positionChars  = positionString.Split(',');
            Rect position = new Rect()
            {
                x = int.Parse(positionChars[0]),
                y = int.Parse(positionChars[1]),
                width = int.Parse(positionChars[2]),
                height = int.Parse(positionChars[3])
            };

            return position;
        }
        
    }
}