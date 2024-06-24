using System.Collections.Generic;
using System.Xml;

namespace EditorFramework
{
    public class XMLGUI
    {
        public List<XMLGUIBase> GUIBases = new List<XMLGUIBase>();
        public Dictionary<string, XMLGUIBase> GUIBaseForId = new Dictionary<string, XMLGUIBase>();

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            XMLGUIBase t = default;
            if (GUIBaseForId.TryGetValue(id,out t))
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
            if (rootNode != null)
            {
                foreach (var rootNodeChildNode in rootNode.ChildNodes)
                {
                    string id = string.Empty;
                    if (rootNodeChildNode is XmlElement xmlElement)
                    {
                        if (xmlElement.Name == "Label")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            var guibase = new XMLGUILabel(xmlElement.InnerText);
                            guibase.Id = id;
                            GUIBases.Add(guibase);
                            if (!string.IsNullOrEmpty(id))
                            {
                                GUIBaseForId.Add(id,guibase);
                            }
                    
                        }
                        else if (xmlElement.Name == "TextField")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            var guibase = new XMLGUITextField(xmlElement.InnerText);
                            guibase.Id = id;
                            GUIBases.Add(guibase);
                            if (!string.IsNullOrEmpty(id))
                            {
                                GUIBaseForId.Add(id,guibase);
                            }
                        }
                        else if (xmlElement.Name == "TextArea")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            var guibase = new XMLGUITextArea(xmlElement.InnerText);
                            guibase.Id = id;
                            GUIBases.Add(guibase);
                            if (!string.IsNullOrEmpty(id))
                            {
                                GUIBaseForId.Add(id,guibase);
                            }

                        }
                        else if (xmlElement.Name == "Button")
                        {
                            id = xmlElement.Attributes["id"].Value;
                            var guibase = new XMLGUIButton(xmlElement.InnerText);
                            guibase.Id = id;
                            GUIBases.Add(guibase);
                            if (!string.IsNullOrEmpty(id))
                            {
                                GUIBaseForId.Add(id,guibase);
                            }
                        }
                    }
                
            
                }
            }
        }
    }
}