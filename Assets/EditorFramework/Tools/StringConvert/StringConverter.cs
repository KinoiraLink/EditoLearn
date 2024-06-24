using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{

    public abstract class StringConverter 
    {
        public static Dictionary<Type, StringConverter> mConverterMap = new()
        {
            {typeof(Rect),new RectStringConverter()},
            {typeof(string),new StringStringConverter()},
            {typeof(bool),new BooleanStringConverter()}
        };

        public static StringConverter<T> Get<T>()
        {
            StringConverter t = default;
            if (mConverterMap.TryGetValue(typeof(T), out t))
            {
                return t as StringConverter<T>;
            }

            return default;
        }
    }
    
    public abstract class StringConverter<T> : StringConverter
    {
        public virtual string ConvertToString(T t)
        {
            return t.ToString();
        }

        public abstract bool TryConvert(string self, out T result);
    }
}