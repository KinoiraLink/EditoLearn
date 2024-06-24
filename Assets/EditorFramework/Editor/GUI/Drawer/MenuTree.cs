using System;
using System.Collections.Generic;

namespace EditorFramework
{
    public class MenuTree : GUIBase
    {

        public event Action<string> onCurrentChange;
        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }

        public void ReadTree(List<string> list)
        {
            throw new NotImplementedException();
        }
    }
}