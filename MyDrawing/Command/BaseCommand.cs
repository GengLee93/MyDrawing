using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public abstract class BaseCommand : ICommand
    {
        protected readonly Model _model;
        protected BaseCommand(Model model)
        {
            _model = model;
        }
        public abstract void Execute();
        public abstract void UnExcute();
    }
}
