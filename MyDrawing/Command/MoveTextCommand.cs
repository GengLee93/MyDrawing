using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class MoveTextCommand : BaseCommand
    {
        private readonly Shape _shape;
        private readonly int _originalTextX;
        private readonly int _originalTextY;
        private readonly int _newTextX;
        private readonly int _newTextY;

        public MoveTextCommand(Model model, Shape shape, int originalTextX, int originalTextY, int newTextX, int newTextY)
            : base(model)
        {
            _shape = shape;
            _originalTextX = originalTextX;
            _originalTextY = originalTextY;
            _newTextX = newTextX;
            _newTextY = newTextY;
        }


        public override void Execute()
        {
            _shape.TextX = _newTextX;
            _shape.TextY = _newTextY;
            _model.NotifyModelChanged();
        }

        public override void UnExcute()
        {
            _shape.TextX = _originalTextX;
            _shape.TextY = _originalTextY;
            _model.NotifyModelChanged();
        }
    }
}