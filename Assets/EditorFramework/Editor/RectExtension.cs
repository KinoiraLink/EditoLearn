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

    public enum SplitType
    {
        Vertical,Horizontal
    }
    public static class RectExtension
    {
        public static Rect Zoom(this Rect rect,AnchorType anchorType, float pixel)
        {
            var width = rect.width + pixel;
            var height = rect.height + pixel;

            if (anchorType == AnchorType.MiddleCenter)
            {
                rect.x -= (width - rect.width) * 0.5f;
                rect.y -= (height - rect.height) * 0.5f;
            }
            rect.height = height;
            rect.width = width;
      
            return rect;
        }

        public static Rect[] Split(this Rect self,SplitType splitType, float size, float padding = 0, bool justMid = true)
        {
            if (splitType == SplitType.Vertical)
            {
                return VerticalSplit(self, size, padding, justMid);
            }
            else
            {
                return HorizontalSplit(self, size, padding, justMid);
            }
        }
        public static Rect[] VerticalSplit(this Rect self, float width, float padding = 0, bool justMid = true)
        {
            if (justMid)
            {
                return new Rect[2]
                {
                    
                    self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                    self.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.CeilToInt(padding/2f)),
                };
            }

            return new Rect[2]
            {
                new Rect(0, 0, 0, 0),
                new Rect(0, 0, 0, 0),
            };
        }
        
        public static Rect[] HorizontalSplit(this Rect self, float height, float padding = 0, bool justMid = true)
        {
            if (justMid)
            {
                return new Rect[2]
                {
                    
                    self.CutBottom(self.height - height).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding/2f)),
                    self.CutTop(height).CutTop(padding).CutTop(-Mathf.CeilToInt(padding/2f)),
                };
            }

            return new Rect[2]
            {
                new Rect(0, 0, 0, 0),
                new Rect(0, 0, 0, 0),
            };
        }

        public static Rect SplitRect(this Rect self, SplitType splitType, float size, float padding = 0)
        {
            if (splitType == SplitType.Vertical)
            {
                return VerticalSplitRect(self, size, padding);
            }
            else
            {
                return HorizontalSplitRect(self, size, padding);
            }
        }

        public static Rect VerticalSplitRect(this Rect self, float width, float padding = 0)
        {
            var rect = self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2f));
            rect.x += rect.width;
            rect.width = padding;
            return rect;
        }
        
        public static Rect HorizontalSplitRect(this Rect self, float height, float padding = 0)
        {
            var rect = self.CutBottom(self.width - height).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding / 2f));
            rect.y += rect.height;
            rect.height = padding;
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
            self.yMax -= pixels;
            return self;
        }
        public static Rect CutBottom(this Rect self, float pixels)
        {
            self.yMax += pixels;
            return self;
        }
    }
}