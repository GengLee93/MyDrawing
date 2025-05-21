using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public class Process : Shape
    {
        public Process(string text, int x, int y, int width, int height) : base(text, x, y, width, height) { }

        public override string GetShapeName() => "Process";
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X, Y, Width, Height);
            graphics.DrawText(TextX, TextY, Text);
        }
    }
}
