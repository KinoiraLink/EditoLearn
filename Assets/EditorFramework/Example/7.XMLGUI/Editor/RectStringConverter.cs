using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class RectStringConverter : StringConverter<Rect>
    {
        public override bool TryConvert(string self, out Rect result)
        {
            var positionChars  = self.Split(',');
            Rect position = new Rect()
            {
                x = int.Parse(positionChars[0]),
                y = int.Parse(positionChars[1]),
                width = int.Parse(positionChars[2]),
                height = int.Parse(positionChars[3])
            };
            result = position;
            return true;
        }
    }
    
}
