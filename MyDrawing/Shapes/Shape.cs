using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. 這是一個抽象類別，表示圖形的基本形狀。
////////////////////////////////////////////////////////////////////////////////////

namespace MyDrawing
{
    public abstract class Shape
    {
        public string Text { get; set; }
        public int TextX { get; set; }
        public int TextY { get; set; }
        public int TextWidth { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        // 新增相關連接點
        protected const int CONNECTION_POINT_SIZE = 10;
        public bool IsShowingConnectionPoints { get; set; }


        protected Shape(string text, int x, int y, int width, int height)
        {
            Text = text;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            TextWidth = text.Length * 7;

            InitializeTextPosition();
        }
        public virtual void InitializeTextPosition()
        {
            TextX = X + Width / 3;
            TextY = Y + Height / 2;
        }
        public abstract string GetShapeName();          // 方法用於獲取圖形的型別
        public abstract void Draw(IGraphics graphics);  // 方法用於繪製圖形和圖形內文字
        public virtual void DrawShapeBoundingBox(IGraphics graphics) // PointerMdode用於繪製選圖行選取框
        {
            graphics.DrawShapeBoundingBox(X, Y, Width, Height);
        }
        public virtual void DrawTextBoundingBox(IGraphics graphics) // PointerMdode用於繪製文字選取框
        {
            graphics.DrawTextBoundingBox(TextX, TextY, Text); 
        }
        public virtual void DrawConnectionPoints(IGraphics graphics) // DrawingLineMode用於繪製連接點
        {
            graphics.DrawConnectionPoint(X + Width / 2, Y - CONNECTION_POINT_SIZE/2, CONNECTION_POINT_SIZE);            // Top center
            graphics.DrawConnectionPoint(X + Width / 2, Y + Height - CONNECTION_POINT_SIZE / 2, CONNECTION_POINT_SIZE); // Bottom center            // Bottom center
            graphics.DrawConnectionPoint(X - CONNECTION_POINT_SIZE/2, Y + Height / 2, CONNECTION_POINT_SIZE);           // Left center
            graphics.DrawConnectionPoint(X + Width - CONNECTION_POINT_SIZE / 2, Y + Height / 2, CONNECTION_POINT_SIZE); // Right center                // Right center
        }
        public virtual List<(int x, int y)> GetConnectionPoints()
        {
            return new List<(int x, int y)> {
                (X + Width / 2, Y),             // Top center
                (X + Width / 2, Y + Height),    // Bottom center
                (X, Y + Height / 2),            // Left center
                (X + Width, Y + Height / 2)     // Right center
            };
        }
    }
}