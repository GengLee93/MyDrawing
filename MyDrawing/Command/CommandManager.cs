using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing.Command
{
    public class CommandManager
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command); // 將執行過的命令放入 _undoStack Stack
            _redoStack.Clear();       // 清空 redo Stack
        }
        public void Undo()
        {
            if (_undoStack.Count <= 0) throw new Exception("Cannot Undo exception\n");
            ICommand command = _undoStack.Pop();
            _redoStack.Push(command);
            command.UnExcute();
        }
        public void Redo()
        {
            if (_redoStack.Count <= 0) throw new Exception("Cannot Redo exception\n");
            ICommand command = _redoStack.Pop();
            _undoStack.Push(command);
            command.Execute();
        }
        public bool IsRedoEnabled() => _redoStack.Count != 0;
        public bool IsUndoEnabled() => _undoStack.Count != 0;
    }
}
