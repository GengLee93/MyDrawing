using MyDrawing.Command;
using MyDrawing.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyDrawing.State
{
    public class DrawingLineState : IState
    {
        protected const int CONNECTION_POINT_SIZE = 10;

        private Shape _startShape = null;
        private Shape _endShape = null;
        private Shape _hoveredShape = null;
        private (int x, int y) _startPoint;
        private (int x, int y) _endPoint;
        private bool _isDrawing = false;

        public void Initialize(Model m) { }

        public void OnPaint(Model m, IGraphics g)
        {
            foreach (Shape shape in m.ShapeList)
            {
                shape.Draw(g);

                // 顯示被hover的圖形的連接點
                // 判斷是否為Line，若是則不顯示連接點 或 判斷是否為起始圖形且正在畫線
                if ((shape == _hoveredShape && shape.GetShapeName() != "Line") || (shape == _startShape && _isDrawing))
                {
                    shape.DrawConnectionPoints(g);
                }
            }
            if (_isDrawing)
            {
                g.DrawLine(_startPoint.x, _startPoint.y, _endPoint.x, _endPoint.y);
            }
        }

        public void MouseDown(Model m, int x, int y)
        {
            if (!_isDrawing)
            {
                var shapeUnderMouse = GetShapeUnderMouse(m, x, y);
                if (shapeUnderMouse != null)
                {
                    _startShape = shapeUnderMouse;
                    _startPoint = GetClosestConnectionPoint(_startShape, x, y);
                    if (IsNearConnectionPoint(_startShape, _startPoint))
                    {
                        _isDrawing = true; // 開始畫線
                    }
                }
            }
        }

        public void MouseDoubleClick(Model m, int x, int y) { }

        public void MouseMove(Model m, int x, int y)
        {
            var shapeUnderMouse = GetShapeUnderMouse(m, x, y);

            // 更新懸停的圖形
            if (shapeUnderMouse != _hoveredShape)
            {
                _hoveredShape = shapeUnderMouse;
                m.NotifyModelChanged();
            }

            if (_isDrawing)
            {
                _endPoint = (x, y);
                m.NotifyModelChanged();
            }
        }

        public void MouseUp(Model m)
        {
            if (_isDrawing)
            {
                if (_hoveredShape != null)
                {
                    _endShape = _hoveredShape;
                    _endPoint = GetClosestConnectionPoint(_endShape, _endPoint.x, _endPoint.y);

                    // 確認是否符合連接條件
                    if (IsNearConnectionPoint(_endShape, _endPoint) &&
                        !(_startShape == _endShape && _startPoint == _endPoint))
                    {
                        Line newLine = new Line(_startShape, _startPoint, _endShape, _endPoint);

                        // DrawLineCommand
                        var command = new DrawLineCommand(m, newLine);
                        m.CommandManager.ExecuteCommand(command);
                    }
                }
                // 重置狀態
                _isDrawing = false;
                _startShape = null;
                _endShape = null;
                m.EnterPointerState();
                m.NotifyModelChanged();
            }
        }

        public void KeyDown(Model m, int keyValue) { }

        public void KeyUp(Model m, int keyValue) { }

        private static Shape GetShapeUnderMouse(Model m, int x, int y)
        {
            return m.ShapeList.FirstOrDefault(shape =>
            {
                switch (shape.GetShapeName())
                {
                    case "Terminator":
                        return x >= shape.X && x <= shape.X + shape.Height + shape.Width &&
                               y >= shape.Y && y <= shape.Y + shape.Height;
                    default:
                        return x >= shape.X && x <= shape.X + shape.Width &&
                               y >= shape.Y && y <= shape.Y + shape.Height;
                }
            });
        }
        private static (int x, int y) GetClosestConnectionPoint(Shape shape, int x, int y)
        {
            return shape.GetConnectionPoints()
                        .OrderBy(p => Math.Sqrt(Math.Pow(p.x - x, 2) + Math.Pow(p.y - y, 2)))
                        .First();
        }
        private static bool IsNearConnectionPoint(Shape shape, (int x, int y) point)
        {
            if (shape.GetShapeName() == "Terminator")
            {
                return shape.GetConnectionPoints().Any(p =>
                    Math.Sqrt(Math.Pow(p.x - point.x, 2) + Math.Pow(p.y - point.y, 2)) <= CONNECTION_POINT_SIZE / 2);
            }
            return shape.GetConnectionPoints().Any(p =>
                Math.Sqrt(Math.Pow(p.x - point.x, 2) + Math.Pow(p.y - point.y, 2)) <= CONNECTION_POINT_SIZE / 2);
        }
    }
}