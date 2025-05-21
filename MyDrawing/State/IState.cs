using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.State
{
    public interface IState
    {
        void Initialize(Model m);
        void OnPaint(Model m, IGraphics g);
        void MouseDown(Model m, int x, int y);
        void MouseDoubleClick(Model m, int x, int y);
        void MouseMove(Model m, int x, int y);
        void MouseUp(Model m);
        void KeyDown(Model m, int keyValue);
        void KeyUp(Model m, int keyValue);
    }
}
