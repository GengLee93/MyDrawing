using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class MoveShapeCommand : BaseCommand
    {
        private readonly Shape _shape;
        private readonly int _originalX;
        private readonly int _originalY;
        private readonly int _newX;
        private readonly int _newY;
        private readonly int _originalTextX;
        private readonly int _originalTextY;
        private readonly int _newTextX;
        private readonly int _newTextY;

        public MoveShapeCommand(Model model, Shape shape, int originalX, int originalY, int newX, 
            int newY, int originalTextX, int originalTextY, int newTextX, int newTextY) 
            : base(model)
        {
            _shape = shape;
            _originalX = originalX;
            _originalY = originalY;
            _newX = newX;
            _newY = newY;
            _originalTextX = originalTextX;
            _originalTextY = originalTextY;
            _newTextX = newTextX;
            _newTextY = newTextY;
        }


        public override void Execute()
        {
            _shape.X = _newX;
            _shape.Y = _newY;
            _shape.TextX = _newTextX;
            _shape.TextY = _newTextY;
            _model.NotifyModelChanged();
        }

        public override void UnExcute()
        {
            _shape.X = _originalX;
            _shape.Y = _originalY;
            _shape.TextX = _originalTextX;
            _shape.TextY = _originalTextY;
            _model.NotifyModelChanged();
        }
    }
}
