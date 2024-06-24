using System.Collections.Generic;
using System.Xml;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUI
    {
        private List<XMLGUIBase> mGUIBases = new List<XMLGUIBase>();
        private Dictionary<string, XMLGUIBase> mGUIBaseForId = new Dictionary<string, XMLGUIBase>();
        //抽象工厂模式
        private Dictionary<string, Func<XMLGUIBase>> mFactoriesForGUIBaseNames = new()
        {
            {"Label",()=> new XMLGUILabel()},
            {"TextField",()=>new XMLGUITextField()},
            {"TextArea",()=> new XMLGUITextArea()},
            {"Button",() => new XMLGUIButton()}
        };

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
                        if (mFactoriesForGUIBaseNames.TryGetValue(xmlElement.Name,out Func<XMLGUIBase> xmlGUIBaseFactory))
                        {
                            guibase = xmlGUIBaseFactory.Invoke();
                            guibase.ParseXML(xmlElement);
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