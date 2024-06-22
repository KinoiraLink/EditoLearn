using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class DragAndDropTool 
{
    public class DragInfo
    {
       public bool enterArea;
       public bool complete;
       public bool dragging;

       public Object[] ObjectReferences => DragAndDrop.objectReferences;
       public string[] Paths => DragAndDrop.paths;
       public DragAndDropVisualMode VisualMode => DragAndDrop.visualMode;
       public int ActiveControllID => DragAndDrop.activeControlID;
    }
    public static DragInfo Drag(Event e,Rect rect,DragAndDropVisualMode mode = DragAndDropVisualMode.Generic)
    {
        
        DragInfo dragInfo = new();

        if (e.type == EventType.DragUpdated)
        {
            dragInfo.complete = false;
            dragInfo.dragging = true;
            dragInfo.enterArea = rect.Contains(e.mousePosition);
            if (dragInfo.enterArea)
            {
                DragAndDrop.visualMode = mode;
                e.Use();
            }
        }
        else if (e.type == EventType.DragPerform)
        {
            dragInfo.complete = true;
            dragInfo.dragging = false;
            dragInfo.enterArea = rect.Contains(e.mousePosition);
            DragAndDrop.AcceptDrag();
            e.Use();

        }
        else if(e.type == EventType.DragExited)
        {
            dragInfo.complete = true;
            dragInfo.dragging = false;

            dragInfo.enterArea = rect.Contains(e.mousePosition);

        }
        else
        {
            dragInfo.dragging = false;
            dragInfo.complete = false;
            dragInfo.enterArea = rect.Contains(e.mousePosition);
        }
        
        dragInfo.complete = dragInfo.complete && e.type == EventType.Used;


        return dragInfo;
    }
}
