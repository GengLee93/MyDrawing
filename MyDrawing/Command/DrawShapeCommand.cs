using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing.Command
{
    class DrawShapeCommand : BaseCommand
    {
        private readonly string _shapeName;
        private readonly string _text;
        private readonly int _x;
        private readonly int _y;
        private readonly int _width;
        private readonly int _height;

        private int _index;

        public DrawShapeCommand(Model model, string shapeName, string text, int x, int y, int width, int height)
            : base(model)
        {
            _shapeName = shapeName;
            _text = text;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }


        public override void Execute()
        {
           _model.AddShape(_shapeName, _text, _x, _y, _width, _height);
           _index = _model.ShapeList.Count() - 1;
        }
        public override void UnExcute()
        {
            _model.RemoveShape(_index);
        }
    }
}