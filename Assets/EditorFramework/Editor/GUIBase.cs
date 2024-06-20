using System;
using UnityEngine;

namespace EditorFramework
{
    public abstract class GUIBase : IDisposable
    {

        public bool mDisposed { get; private set; }
        public Rect mPostition { get; private set; }

        public virtual void OnGUI(Rect position)
        {
            mPostition = position;
        }

        public virtual void Dispose()
        {
            if (mDisposed) return;
            OnDispose();
            mDisposed = true;
        }

        protected abstract void OnDispose();
    }
}