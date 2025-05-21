using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. Model
//     2. 
////////////////////////////////////////////////////////////////////////////////////

namespace MyDrawing
{
    public class Model
    {
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        private double _firstPointX;                        // 鼠標按下時的初始X
        private double _firstPointY;                        // 鼠標按下時的初始Y
        bool _isPressed = false;                            // 鼠標是否按下

        //// Drawing State Management
        //enum Mode
        //{
        //    Pointer,
        //    Drawing
        //}

        ShapesFactory _shapesFactory = new ShapesFactory();
        List<Shape> _shapes = new List<Shape>();
        private readonly Shape _hint = null;

        //Mode mode = Mode.Pointer;           // 繪圖狀態

        // 在繪圖區上
        //public void OnPaint(Graphics g)
        //{
        //    if (mode == Mode.Drawing && _firstPointX > 0)
        //    {
        //        Cursor.Current = Cursors.Cross;
        //    }
        //}

        //// 鼠標移動事件
        //public void MouseMoveHandler(int x, int y)
        //{
        //    _firstPointX = x;
        //    _firstPointY = y;
        //    if (mode == Mode.Drawing)
        //        NotifyModelChanged();
        //}

        //// 繪圖模式
        //public void SetDrawingMode()
        //{
        //    mode = Mode.Drawing;
        //    NotifyModelChanged();
        //}

        //// 鼠標模式
        //public void SetPointerMode()
        //{
        //    mode = Mode.Pointer;
        //    NotifyModelChanged();
        //}

        public void PointerPressed (double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;

                // hint 不知道怎實作
                _isPressed = true;
            }
        }

        public void PointerMoved(double x, double y)
        {
            if (_isPressed)
            {
                // hint 不知道怎實作
                NotifyModelChanged();
            }
        }

        public void PointerReleased(double x, double y)
        {
            if (_isPressed)
            {
                // hint 不知道怎實作
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        public void ClearAll()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (var shape in _shapes) 
            { 
                shape.Draw(graphics);
            }
            if (_isPressed)
            {
                // hint 不知道怎實作
            }
        }

        // 通知觀察者狀態改變
        void NotifyModelChanged()
        {
            if (ModelChanged != null)
                ModelChanged();
        }

        // Shape Management
        public void AddShape(string shapeName, int x, int y, int width, int height)
        {
            if (string.IsNullOrEmpty(shapeName))
                throw new ArgumentNullException(nameof(shapeName));

            if (width <= 0 || height <= 0)
                throw new ArgumentException("Width and height must be positive values");

            Shape newShape = _shapesFactory.CreatShape(shapeName, x, y, width, height);
            _shapes.Add(newShape);
            NotifyModelChanged();
        }

        public void RemoveShape(int index)
        {
            if (index >= 0 && index < _shapes.Count)
            {
                _shapes.RemoveAt(index);
                NotifyModelChanged();
            }
        }

        public List<Shape> GetShapes()
        {
            return new List<Shape>(_shapes);
        }
    }
}
