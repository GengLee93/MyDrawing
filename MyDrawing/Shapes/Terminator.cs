using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public class Terminator : Shape
    {
        public Terminator(string text, int x, int y, int width, int height) : base(text, x, y, width, height) { }


        public override string GetShapeName() => "Terminator";
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(X, Y, Width, Height);
            graphics.DrawText(TextX, TextY, Text);
        }
        public override void DrawShapeBoundingBox(IGraphics graphics)
        {
            graphics.DrawShapeBoundingBox(X, Y, Width + Height, Height);
        }
        public override void DrawTextBoundingBox(IGraphics graphics)
        {
            graphics.DrawTextBoundingBox(TextX, TextY, Text);
        }

        public override void DrawConnectionPoints(IGraphics graphics)
        {
            graphics.DrawConnectionPoint(X + (Width + Height)/2, Y - CONNECTION_POINT_SIZE/2, CONNECTION_POINT_SIZE);       // Top center
            graphics.DrawConnectionPoint(X + (Width + Height)/2, Y + Height - CONNECTION_POINT_SIZE/2, CONNECTION_POINT_SIZE);// Bottom center
            graphics.DrawConnectionPoint(X - CONNECTION_POINT_SIZE/2, Y + Height/2, CONNECTION_POINT_SIZE);                 // Left center
            graphics.DrawConnectionPoint(X + Width + Height - CONNECTION_POINT_SIZE/2, Y + Height/2, CONNECTION_POINT_SIZE);// Right center
        }

        public override List<(int x, int y)> GetConnectionPoints()
        {
            return new List<(int x, int y)> {
                (X + (Width + Height)/2, Y),          // Top center
                (X + (Width + Height)/2, Y + Height), // Bottom center
                (X, Y + Height/2),                    // Left center
                (X + Width + Height, Y + Height/2)    // Right center
            };
        }
    }
}
