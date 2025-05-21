using MyDrawing.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class DeleteShapeCommand : BaseCommand
    {
        private readonly Shape _shape;
        private readonly int _index;

        public DeleteShapeCommand(Model model, Shape shape) : base(model)
        {
            _shape = shape;
            _index = model.ShapeList.IndexOf(_shape);
        }

        public override void Execute()
        {
            _model.RemoveShape(_index);
        }

        public override void UnExcute()
        {
            if (_shape.GetShapeName() != "Line")
            {
                _model.AddShape(_shape.GetShapeName(), _shape.Text, _shape.X, _shape.Y, _shape.Width, _shape.Height);
                return;
            }

            var line = _shape as Line;
            if (line != null) _model.AddLine(line);
        }
    }
}
