using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public static class RectStringConverter 
    {
        public static Rect ConVert(string rectString)
        {
            var positionChars  = rectString.Split(',');
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
