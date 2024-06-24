using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class FolderField : GUIBase
    {
        protected string mPath ;
        public string Path => mPath;
        public void SetPath(string path) => mPath = path;
        public string Title;
        public string Folder;
        public string DefaultName;
        public FolderField(string path = "Assets", string folder = "Assets", string title = "Select Folder",
            string defaultName = "")
        {
            mPath = path;
            Title = title;
            Folder = folder;
            DefaultName = defaultName;

        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);
            
            var rects = position.VerticalSplit(position.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];
            

         
            if (GUI.Button(rightRect, GUIContents.Folder))
            {
                var path = EditorUtility.OpenFolderPanel(Title, Folder, DefaultName);

                if (!string.IsNullOrEmpty(path) && path.IsDirectory())
                {
                    mPath = path.ToAssetsPath();
                
                    Debug.Log(mPath);    
                }
                
            }
            var currentGUIEnable = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(leftRect,mPath);
            GUI.enabled = currentGUIEnable;
            var dragInfo = DragAndDropTool.Drag(Event.current, leftRect);

            if (dragInfo.enterArea && dragInfo.complete && !dragInfo.dragging && dragInfo.Paths[0].IsDirectory())
            {
                mPath = dragInfo.Paths[0];
            }
        }

        protected override void OnDispose()
        {
        }
    }
}