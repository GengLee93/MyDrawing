using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


/////////////////////////////////////////////////////////////////////////////////////
// Note:                                                                 
//     1. GraphicsAdapter，實作 IGraphics 介面，作為 Adapter 將 Graphics 類別的
//        功能適配到 IGraphics 介面。
//     2. GraphicsAdapter 類別屬於 "類別調適"，Graphics 在 Adapter pattern 中扮演
//        "被適配者(Adaptee)"的角色。    
////////////////////////////////////////////////////////////////////////////////////

namespace MyDrawing
{
    public class GraphicsAdapter : IGraphics
    {
        private readonly Graphics _graphics;
        private readonly Pen _pen = new Pen(Color.Black, 3);
        private readonly Font font = new Font("Arial", 7);

        public GraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        // 流程圖元件實作: Start 
        public void DrawCircle(int x, int y, int width, int height)
        {
            _graphics.DrawEllipse(_pen, x, y, width, height);
        }

        // 流程圖元件實作: Process
        public void DrawRectangle(int x, int y, int width, int height)
        {
            _graphics.DrawRectangle(_pen, x, y, width, height);
        }

        // 流程圖元件實作: Terminator
        public void DrawEllipse(int x, int y, int width, int height)
        {
            // 必免高度為0或是負值，拋出 System.ArgumentException: '參數無效。'
            if (height <= 0)
            {
                _graphics.DrawLine(_pen, x, y, x + width, y);
                return;
            }

            // 繪製左半圓
            _graphics.DrawArc(_pen, x, y, height, height, 90, 180);
            // 繪製右半圓
            _graphics.DrawArc(_pen, x + width, y, height, height, 270, 180);
            // 繪製上方直線
            _graphics.DrawLine(_pen, x + height / 2, y, x + width + height / 2, y);
            // 繪製下方直線
            _graphics.DrawLine(_pen, x + height / 2, y + height, x + width + height / 2, y + height);
        }

        // 流程圖元件實作: Decision
        public void DrawDiamond(int x, int y, int width, int height)
        {
            Point[] points = new Point[]
            {
            new Point(x + width/2, y),          // 頂點
            new Point(x + width, y + height/2), // 右點
            new Point(x + width/2, y + height), // 底點
            new Point(x, y + height/2)          // 左點
            };
            _graphics.DrawPolygon(_pen, points);
        }

        // 流程圖元件中心文字
        public void DrawText(int x, int y, string text)
        {
            _graphics.DrawString(text, font, Brushes.Black, x, y);
        }
        public void DrawShapeBoundingBox(int x, int y, int width, int height)
        {
            Pen pen = new Pen(Color.Red, 2)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Custom,
                DashPattern = new float[] { 2, 2 }
            };
            _graphics.DrawRectangle(pen, x, y, width, height);
        }
        public void DrawTextBoundingBox(int x, int y, string text)
        {
            SizeF textSize = _graphics.MeasureString(text, font);


            // 根據文字尺寸創建邊界框
            int textWidth = (int)Math.Ceiling(textSize.Width);
            int textHeight = (int)Math.Ceiling(textSize.Height);

            // 繪製紅色邊界框
            Pen pen = new Pen(Color.Red, 2);
            _graphics.DrawRectangle(pen, x, y, textWidth, textHeight);

            // 添加橘色拖曳點
            Brush brush = new SolidBrush(Color.Orange);
            _graphics.FillEllipse(brush, x + textWidth / 2 - 5, y - 10, 10, 10);
        }
        public void DrawConnectionPoint(int x, int y, int size)
        {
            _graphics.FillEllipse(Brushes.Gray, x, y, size, size);
        }
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            // 繪製直線
            _graphics.DrawLine(Pens.Black, x1, y1, x2, y2);
        }
        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作 
        }
    }
}
