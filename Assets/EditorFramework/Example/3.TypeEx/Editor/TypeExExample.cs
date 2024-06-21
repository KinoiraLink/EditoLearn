using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(3)]
    public class TypeExExample  : EditorWindow
    {
        
        public class DescriptionBase
        {
            public virtual string Description { get; set; } = "描述";

        }
        
        public class MyDescAttribute : Attribute
        {
            public string Type;

            public MyDescAttribute(string type = "")
            {
                Type = type;
            }
        }
        
        public class MyDescription: DescriptionBase
        {
            public override string Description { get; set; } = "A";
        }
        [MyDesc("TypeB")]
        public class MyDescriptionB: DescriptionBase
        {
            public override string Description { get; set; } = "B";
        }

        private IEnumerable<Type> mDescriptionTypes;
        private IEnumerable<Type> mDescriptionTypesWithAttribute;
        private void OnEnable()
        {
            mDescriptionTypes =  typeof(DescriptionBase).GetSubTypesInAssemblies();
            mDescriptionTypesWithAttribute =
                typeof(DescriptionBase).GetSubTypesWithClassAttributeInAssemblies<MyDescAttribute>();
        }

        private void OnGUI()
        {
            GUILayout.Label("Types");
            foreach (var descriptionType in mDescriptionTypes)
            {
                GUILayout.Label(descriptionType.Name);
            }
            
            GUILayout.Label("With Attribute");
            foreach (var descriptionType in mDescriptionTypesWithAttribute)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(descriptionType.Name);
                    GUILayout.Label(descriptionType.GetCustomAttribute<MyDescAttribute>().Type);   
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}