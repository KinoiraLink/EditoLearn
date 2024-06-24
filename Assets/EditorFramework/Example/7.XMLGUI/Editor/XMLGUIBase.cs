using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public abstract class XMLGUIBase : GUIBase
    {
        public string Id { get; set; }

        public virtual void ParseXML(XmlElement xmlElement,XMLGUI rootXMLGUI)
        {
            var id = xmlElement.GetAttribute("id");

            if (!string.IsNullOrEmpty(id))
            {
                Id = id;
            }

            var positionString = xmlElement.GetAttribute("position");

            if (!string.IsNullOrEmpty(positionString))
            {
                mPostition = RectStringConverter.ConVert(positionString);
            }
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