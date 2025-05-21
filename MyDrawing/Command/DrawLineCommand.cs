using MyDrawing.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing.Command
{
    public class DrawLineCommand : BaseCommand
    {
        private readonly Line _line;
        private int _index;

        public DrawLineCommand(Model model, Line line)
        : base(model)
        {
            _line = line;
        }


        public override void Execute()
        {
            _model.AddLine(_line);
            _index = _model.ShapeList.Count() - 1;
        }

        public override void UnExcute()
        {
            _model.RemoveShape(_index);
        }
    }
}
