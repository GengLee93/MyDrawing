using MyDrawing.Command;
using MyDrawing.Shapes;
using MyDrawing.State;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;


namespace MyDrawing
{
    public class Model
    {
        // 宣告狀態物件
        public readonly IState pointerState;
        readonly IState drawingShapeState;
        readonly IState drawingLineState;

        // 直接使用reference作為狀態變數
        public IState currentState { get; set; }

        // Event
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        public event Action ShapeAdded;

        //model 透過 ShapesFactory 來建立形狀，並管理所有圖形
        readonly ShapesFactory _shapesFactory = new ShapesFactory();
        readonly BindingList<Shape> _shapes = new BindingList<Shape>();
        public string CurrentShapeName { get; set; }

        // CommandManager 完成 Undo/Redo
        public CommandManager CommandManager { get; private set; } = new CommandManager();
        public bool IsRedoEnabled() => CommandManager.IsRedoEnabled();
        public bool IsUndoEnabled() => CommandManager.IsUndoEnabled();


        public Model()
        {
            // 建立pointerState物件，也可以改用Factory替代new
            pointerState = new PointerState();
            // 建立drawingState物件，令DrawingState知道PointerState
            drawingShapeState = new DrawingShapeState((PointerState)pointerState);
            drawingLineState = new DrawingLineState();

            // 預設為PointerState
            EnterPointerState();
        }


        public void Undo()
        {
            CommandManager.Undo();
        }
        public void Redo()
        {
            CommandManager.Redo();
        }

        public void EnterPointerState()
        {
            pointerState.Initialize(this);
            currentState = pointerState;
        }
        public void EnterDrawingShapeState()
        {
            drawingShapeState.Initialize(this);
            currentState = drawingShapeState;
        }
        public void EnterDrawingLineState()
        {
            drawingLineState.Initialize(this);
            currentState = drawingLineState;
        }
        public void PointerPressed(int x, int y)
        {
            currentState.MouseDown(this, x, y);
        }
        public void PointerDoublePressed(int x, int y)
        {
            currentState.MouseDoubleClick(this, x, y);
        }
        public void PointerMoved(int x, int y)
        {
            currentState.MouseMove(this, x, y);
        }
        public void PointerReleased()
        {
            currentState.MouseUp(this);
            NotifyShapeAdded();
            CurrentShapeName = "";    // 釋放滑鼠時，清除選擇的形狀
        }
        public void KeyDown(int keyValue)
        {
            currentState.KeyDown(this, keyValue);
            NotifyModelChanged();
        }
        public void KeyUp(int keyValue)
        {
            currentState.KeyUp(this, keyValue);
            NotifyModelChanged();
        }
        public void Draw(IGraphics graphics)
        {
            // 清理視圖
            graphics.ClearAll();
            currentState.OnPaint(this, graphics);
        }

        // Shape Management
        public void AddShape(string shapeName, string text, int x, int y, int width, int height)
        {
            if (string.IsNullOrEmpty(shapeName))
                throw new ArgumentNullException(nameof(shapeName));

            if (width <= 0 || height <= 0)
                throw new ArgumentException("Width and height must be positive values");

            Shape newShape = _shapesFactory.CreatShape(shapeName, text, x, y, width, height);
            _shapes.Add(newShape);
            ((PointerState)pointerState).AddSelectedShape(newShape); // 新增後設為選中狀態
            NotifyModelChanged();
        }

        public void AddLine(Line line)
        {
            _shapes.Add(line);
            EnterPointerState();
            NotifyModelChanged();
            NotifyShapeAdded();
        }

        public void RemoveShape(int index)
        {
            if (index >= 0 && index < _shapes.Count)
            {
                _shapes.RemoveAt(index);
                EnterPointerState();
                NotifyModelChanged();
                NotifyShapeAdded();
            }
        }

        // 通知觀察者狀態改變
        public void NotifyModelChanged()
        {
            ModelChanged?.Invoke();
        }
        public void NotifyShapeAdded()
        {
            ShapeAdded?.Invoke();
        }
        public IList<Shape> ShapeList
        {
            get { return new List<Shape>(_shapes); }
        }
    }
}