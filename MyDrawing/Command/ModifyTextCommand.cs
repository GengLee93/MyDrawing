using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class ModifyTextCommand : BaseCommand
    {
        private readonly Shape _shape;
        private readonly string _originalText;
        private readonly string _newText;

        public ModifyTextCommand(Model model, Shape shape, string newText) : base(model)
        {
            _shape = shape;
            _originalText = shape.Text;
            _newText = newText;
        }


        public override void Execute()
        {
            _shape.Text = _newText;
            _model.NotifyModelChanged();
        }

        public override void UnExcute()
        {
            _shape.Text = _originalText;
            _model.NotifyModelChanged();
        }
    }
}