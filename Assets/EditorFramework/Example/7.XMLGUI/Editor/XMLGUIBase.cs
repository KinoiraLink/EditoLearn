using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public abstract class XMLGUIBase : GUIBase
    {
        protected T GetAttributeValue<T>(XmlElement xmlElement,string attributeName)
        {
            var attributeValue = xmlElement.GetAttribute(attributeName);
            if (!string.IsNullOrEmpty(attributeValue))
            {
                T result = default;
                if (attributeValue.TryConvert<T>(out result))
                {
                    return result;
                }
            }
            

            return default;

        }
        public string Id { get; set; }

        public virtual void ParseXML(XmlElement xmlElement,XMLGUI rootXMLGUI)
        {
            var id = xmlElement.GetAttribute("id");

            if (!string.IsNullOrEmpty(id))
            {
                Id = id;
            }

            mPostition = GetAttributeValue<Rect>(xmlElement, "position");
        }

        public void SetPosition(Rect position)
        {
            mPostition = position;
        }
        public void Draw()
        {
            OnGUI(mPostition);
        }
        
    }
}