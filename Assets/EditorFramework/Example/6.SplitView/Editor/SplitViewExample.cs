using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(6)]
    public class SplitViewExample : EditorWindow
    {
        private SplitView mSplitView;

        private void OnEnable()
        {
            mSplitView = new SplitView();
            mSplitView.FirstArea += SplitViewFirstArea;
            mSplitView.SecondArea += SplitViewSecondArea;
        }

        private void SplitViewFirstArea(Rect obj)
        {
            obj.Drawoutline(Color.green);
            
            GUI.Box(obj,"First");

        }
        private void SplitViewSecondArea(Rect obj)
        {
            obj.Drawoutline(Color.green);

            GUI.Box(obj,"Second");
        }
        

        private void OnGUI()
        {
            mSplitView.OnGUI( this.LocalPosition().Zoom(AnchorType.MiddleCenter,-10));
        }
    }    
}

