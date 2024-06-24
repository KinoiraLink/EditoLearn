using UnityEngine;

namespace EditorFramework
{
    public abstract class XMLGUIBase : GUIBase
    {
        public string Id { get; set; }


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