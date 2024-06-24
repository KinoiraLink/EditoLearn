

using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class GUIStyles
    {
        private static Dictionary<string, GUIStyle> mStyles;

        public static GUIStyle Get(string name)
        {
            GUIStyle style;
            if (mStyles == null)
            {
                mStyles = new Dictionary<string, GUIStyle>();
            }

            if (!mStyles.TryGetValue(name, out style))
            {
                style = new GUIStyle(name);
                mStyles.Add(name,style);
                
            }

            return style;
        }

        public static GUIStyle Get(GUIStyle style)
        {
            GUIStyle _style;
            if (mStyles == null)
            {
                mStyles = new Dictionary<string, GUIStyle>();
            }

            if (!mStyles.TryGetValue(style.name, out _style))
            {
                _style = new GUIStyle(style);
                mStyles.Add(style.name,_style);
            }

            return _style;
        }

        public static GUIStyle PreDropDown = Get("PreDropDown");

        public static GUIStyle IN_title = Get("IN Title");

        public static GUIStyle titlestyle = Get("IN BigTitle");

        public static GUIStyle minus = Get("OL Minus");

        public static GUIStyle plus = Get("OL Plus");

        public static GUIStyle BoldLabel = Get("BoldLabel");
        public static GUIStyle entryBackodd = Get("CN EntryBackodd");
        public static GUIStyle entryBackEven = Get("CN EntryBackEven");

        public static GUIStyle header = new GUIStyle("BoldLabel")
        {
            fontSize = 20
        };

        public static GUIStyle toolbarbutton = Get("toolbarbutton");

        public static GUIStyle ToolbarDropDown = Get("ToolbarDropDown");
        
        



    }
}