﻿using UnityEngine;

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
            /*var width = rect.width + pixel;
            var height = rect.height + pixel;

            if (anchorType == AnchorType.MiddleCenter)
            {
                rect.x -= (width - rect.width) * 0.5f;
                rect.y -= (height - rect.height) * 0.5f;
            }
            rect.height = height;
            rect.width = width;
      
            return rect;*/
            return Zoom(rect,anchorType,new Vector2(pixel,pixel));
        }

        public static Rect Zoom(this Rect rect, AnchorType type, Vector2 pixelOffset)
        {
            float tempW = rect.width + pixelOffset.x;
            float tempH = rect.height + pixelOffset.y;

            switch (type)
            {
                case AnchorType.UpperLeft:
                    break;
                case AnchorType.UpperCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    break;
                case AnchorType.UpperRight:
                    rect.x -= tempW - rect.width;
                        break;
                case AnchorType.MiddleLeft:
                    rect.y -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    rect.y -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleRight:
                    rect.y -= (tempH - rect.height) / 2;
                    rect.x -= tempW - rect.width;
                    break;
                case AnchorType.LowerLeft:
                    rect.y -= tempH - rect.height;
                    break;
                case AnchorType.LowerCenter:
                    rect.y -= tempH - rect.height;
                    rect.x -= (tempW - rect.width) / 2;
                    break;
                case AnchorType.LowerRight:
                    rect.y -= tempH - rect.height;
                    rect.x -= tempW - rect.width;
                    break;
            }

            rect.width = tempW;
            rect.height = tempH;
            return rect;
        }

        public static Rect MoveDown(this Rect r, float pixels = 1)
        {
            r.y += pixels;
            return r;
        }

        public static Rect MoveUp(this Rect r, float pixels = 1)
        {
            return r.MoveDown(-pixels);
        }

        public static Rect MoveRight(this Rect r, float pixels = 1)
        {
            r.x += pixels;
            return r;
        }

        public static Rect[] Split(this Rect self,SplitType splitType, float offset, float padding = 0, bool justMid = true)
        {
            /*if (splitType == SplitType.Vertical)
            {
                return VerticalSplit(self, size, padding, justMid);
            }
            else
            {
                return HorizontalSplit(self, size, padding, justMid);
            }*/

            switch (splitType)
            {
                case SplitType.Vertical:
                    return self.VerticalSplit(offset, padding, justMid);
                case SplitType.Horizontal:
                    return self.HorizontalSplit(offset, padding, justMid);
                default:
                    return default(Rect[]);
            }
        }
        public static Rect SplitRect(this Rect self, SplitType splitType, float size, float padding = 0)
        {
            switch (splitType)
            {
                case SplitType.Vertical:
                    return VerticalSplitRect(self, size, padding);
                case SplitType.Horizontal:
                    return HorizontalSplitRect(self, size, padding);
                default:
                    return default(Rect);
                    
            }
            
        }
        public static Rect[] VerticalSplit(this Rect r, float width, float padding = 0, bool justMid = true)
        {
            if (justMid)
            {
                return new Rect[2]
                {
                    r.CutRight((int)(r.width - width)).CutRight(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                    r.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.FloorToInt(padding/2f)),
                };
            }

            return new Rect[2]
            {
                r.CutRight((int)(r.width - width)).Cut(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                r.CutLeft(width).Cut(padding).CutLeft(-Mathf.FloorToInt(padding/2f)),
            };
        }
        
        public static Rect[] HorizontalSplit(this Rect r, float height, float padding = 0, bool justMid = true)
        {
            if (justMid)
            {
                return new Rect[2]
                {
                    
                    r.CutBottom((int)(r.height - height)).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding/2f)),
                    r.CutTop(height).CutTop(padding).CutTop(-Mathf.FloorToInt(padding/2f)),
                };
            }

            return new Rect[2]
            {
                r.CutBottom((int)(r.height - height)).Cut(padding).CutBottom(-Mathf.CeilToInt(padding/2f)),
                r.CutTop(height).Cut(padding).CutTop(-Mathf.FloorToInt(padding/2f)),
            };
        }



        public static Rect VerticalSplitRect(this Rect r, float width, float padding = 0)
        {
            var rect = r.CutRight((int)(r.width - width)).CutRight(padding).CutRight(-Mathf.CeilToInt(padding/2f));

            rect.x += rect.width;
            rect.width = padding;
            return rect;
        }
        
        public static Rect HorizontalSplitRect(this Rect r, float height, float padding = 0)
        {
            Rect rect = r.CutBottom((int)(r.height - height)).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding/2f));
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
            self.yMax += pixels;
            return self;
        }
        public static Rect CutBottom(this Rect self, float pixels)
        {
            self.yMax -= pixels;
            return self;
        }

        public static Rect Cut(this Rect r, float pixels)
        {
            return r.Margin(-pixels);
        }

        public static Rect Margin(this Rect r, float pixels)
        {
            r.xMax += pixels;
            r.xMin -= pixels;
            r.yMax += pixels;
            r.yMin -= pixels;
            return r;
        }


        public static Vector2 TopLeft(this Rect r)
        {
            return new Vector2(r.x, r.y);
        }
        public static Vector2 TopRight(this Rect r)
        {
            return new Vector2(r.xMax, r.y);
        }
        public static Vector2 BottomRight(this Rect r)
        {
            return new Vector2(r.xMax, r.yMax);
        }
        
        public static Vector2 BottomLeft(this Rect r)
        {
            return new Vector2(r.x, r.yMax);
        }

        public static Rect Set(this Rect self, Vector2 position, Vector2 size)
        {
            self.Set(position.x, position.y, size.x, size.y);
            return self;
        }
    }
    
}