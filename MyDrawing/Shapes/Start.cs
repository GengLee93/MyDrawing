using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public class Start : Shape
    {
        public Start(string text, int x, int y, int width, int height) : base(text, x, y, width, height) { }

        public override string GetShapeName() => "Start";
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawCircle(X, Y, Width, Height);
            graphics.DrawText(TextX, TextY, Text);
        }
    }
}