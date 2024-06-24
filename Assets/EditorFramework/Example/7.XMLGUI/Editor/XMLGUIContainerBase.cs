using System.Xml;

namespace EditorFramework
{
    public abstract class XMLGUIContainerBase : XMLGUIBase
    {
        protected XMLGUI mXmlgui = new XMLGUI();

        public XMLGUI XMLGUI
        {
            get { return mXmlgui; }
        }

        public override void ParseXML(XmlElement xmlElement,XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement,rootXMLGUI);
            mXmlgui.ChildElementsToGUIBase(xmlElement,rootXMLGUI);
        }
        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}