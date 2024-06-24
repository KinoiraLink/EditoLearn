using UnityEngine;

namespace EditorFramework
{
    public enum AnchorType
    {
        UpperLeft = 0,
        UpperCenter = 1,
        UpperRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        LowerLeft = 6,
        LowerCenter = 7,
        LowerRight = 8,
    }
    public static class RectExtension
    {
        public static Rect Zoom(this Rect rect,AnchorType anchorType, float pixel)
        {
            var width = rect.width + pixel;
            var height = rect.height + pixel;

            if (anchorType == AnchorType.MiddleCenter)
            {
                rect.x -= pixel * 0.5f;
                rect.y -= pixel * 0.5f;
            }
           
            rect.width = width;
            rect.height = height;
            return rect;
        }
        public static Rect[] VerticalSplit(this Rect self, float width, float padding = 0, bool justMid = true)
        {
            if (justMid)
            {
                return new Rect[2]
                {
                    self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                    self.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.CeilToInt(padding/2f))
                };
            }

            return new Rect[2]
            {
                new Rect(0, 0, 0, 0),
                new Rect(0, 0, 0, 0),
            };
        }

        public static Rect VerticalSplitRect(this Rect self, float width, float padding = 0)
        {
            var rect = self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2f));
            rect.x += rect.width;
            rect.width = padding;
            return rect;
        }

        public static Rect CutRight(this Rect self, float pixels)
        {
            self.xMax -= pixels;
            return self;
        }
        public static Rect CutLeft(this Rect self, float pixels)
        {
            self.xMax += pixels;
            return self;
        }
        public static Rect CutTop(this Rect self, float pixels)
        {
            self.yMax += pixels;
            return self;
        }
        public static Rect CutBottom(this Rect self, float pixels)
        {
            self.yMax -= pixels;
            return self;
        }
    }
}