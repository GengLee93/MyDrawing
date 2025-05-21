using MyDrawing.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing.State
{
    public class PointerState : IState
    {
        private int _offestX, _offestY; // 選取圖形，距離圖形左上角的偏移量
        private int _initialX, _initialY;    // 提供圖形原始位置給 MoveShapeCommand
        private int _initialTextX, _initialTextY; // 提供文字原始位置給 MoveTextCommand
        public bool IsDragging { get; private set; }
        public bool IsDraggingText { get; private set; }
        public Shape SelectShape { get; set; }


        public PointerState() { }

        public void Initialize(Model m)
        {
            SelectShape = null;
            IsDraggingText = false;
        }
        public void OnPaint(Model m, IGraphics g)
        {
            // 畫出所有圖形
            foreach (Shape shape in m.ShapeList)
            {
                shape.Draw(g);
            }
            // 畫出選取框
            if (SelectShape != null && SelectShape.GetShapeName() != "Line")
            {
                SelectShape.DrawShapeBoundingBox(g);
                SelectShape.DrawTextBoundingBox(g);
            }
        }
        public void MouseDown(Model m, int x, int y)
        {
            // 檢查是否點擊在橘色拖曳點上
            var shapeWithDragPoint = m.ShapeList.FirstOrDefault(shape => IsOverDragPoint(shape, x, y));
            if (shapeWithDragPoint != null)
            {
                SelectShape = shapeWithDragPoint;
                IsDraggingText = true;
                _offestX = x - SelectShape.TextX;
                _offestY = y - SelectShape.TextY;

                // 記錄初始文字位置給 MoveTextCommand
                _initialTextX = SelectShape.TextX;
                _initialTextY = SelectShape.TextY;
                return;
            }

            // 檢查是否點擊在圖形上
            var shapeUnderMouse = m.ShapeList.FirstOrDefault(shape =>
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

            if (shapeUnderMouse != null)
            {
                SelectShape = shapeUnderMouse;
                IsDragging = true;
                _offestX = x - SelectShape.X;
                _offestY = y - SelectShape.Y;

                // 記錄圖形初始位置給 MoveShapeCommand
                _initialX = SelectShape.X;
                _initialY = SelectShape.Y;
                _initialTextX = SelectShape.TextX;
                _initialTextY = SelectShape.TextY;
            }
            else
            {
                // 如果沒有選中任何圖形，重置選中狀態
                SelectShape = null;
                IsDragging = false;
                IsDraggingText = false;
                m.NotifyModelChanged();
            }
        }
        public void MouseDoubleClick(Model m, int x, int y)
        {
            var shapeWithDragPoint = m.ShapeList.FirstOrDefault(shape => IsOverDragPoint(shape, x, y));
            if (shapeWithDragPoint != null)
            {
                SelectShape = shapeWithDragPoint;
                using (TextChangeDialog dialog = new TextChangeDialog(SelectShape.Text))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var command = new ModifyTextCommand(m, SelectShape, dialog.NewText);
                        m.CommandManager.ExecuteCommand(command);
                        //SelectShape.Text = dialog.NewText;
                        m.NotifyModelChanged();
                    }
                }
            }
        }
        public void MouseMove(Model m, int x, int y)
        {
            if (SelectShape != null)
            {
                if (IsDraggingText)
                {
                    SelectShape.TextX = x - _offestX;
                    SelectShape.TextY = y - _offestY;


                }
                else if (IsDragging)
                {
                    // 計算位移量
                    int deltaX = x - _offestX - SelectShape.X;
                    int deltaY = y - _offestY - SelectShape.Y;

                    // 更新圖形位置
                    SelectShape.X = x - _offestX;
                    SelectShape.Y = y - _offestY;

                    // 文字位置跟著圖形移動
                    SelectShape.TextX += deltaX;
                    SelectShape.TextY += deltaY;
                }
                m.NotifyModelChanged();
                //m.NotifyShapeAdded(); // 未來優化datagridview更新，不然拖動圖形會卡頓
            }
        }
        public void MouseUp(Model m)
        {
                if (IsDraggingText)
                {
                    IsDraggingText = false;
                    var command = new MoveTextCommand(m, SelectShape, _initialTextX,
        _initialTextY, SelectShape.TextX, SelectShape.TextY);
                    m.CommandManager.ExecuteCommand(command);
                }

                if (IsDragging)
                {
                    var command = new MoveShapeCommand(m, SelectShape, _initialX, _initialY, SelectShape.X,
                        SelectShape.Y, _initialTextX, _initialTextY, SelectShape.TextX, SelectShape.TextY);
                    m.CommandManager.ExecuteCommand(command);
                    IsDragging = false;
                }
            IsDragging = false;
            _offestX = 0; _offestY = 0;
        }
        public void KeyDown(Model m, int keyValue) { }
        public void KeyUp(Model m, int keyValue) { }
        public void AddSelectedShape(Shape shape)
        {
            SelectShape = shape;
        }
        private static bool IsOverDragPoint(Shape shape, int x, int y)
        {
            int dragPointX = shape.TextX + shape.TextWidth / 2 - 5; // 中心點
            int dragPointY = shape.TextY - 10;                      // 偏移位置
            bool isOver = (x >= dragPointX - 10 && x <= dragPointX + 15 && y >= dragPointY - 10 && y <= dragPointY + 15);
            return isOver;
        }
    }   
}