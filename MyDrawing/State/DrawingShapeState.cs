using MyDrawing.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.State
{
    public class DrawingShapeState : IState
    {
        readonly ShapesFactory _shapesFactory = new ShapesFactory();

        // 繪圖時滑鼠的第一個點
        public int FirstPointX { get; private set; }
        public int FirstPointY { get; private set; }

        // 記錄左上角按了沒
        public bool IsUpperLeftPressed { get; private set; }

        // 記錄正在畫的圖
        public Shape Hint { get; private set; } 
        public string CurrentShapeName { get; private set; }

        // 記錄PointerState
        private readonly PointerState pointerState;

        public DrawingShapeState(PointerState pointerState)
        {
            // ///////////////////////////////////////////////////////
            // 建立DrawingState時，傳入PointerState，
            // 使得DrawingState可以指定PointerState選取剛剛新增的圖形
            //////////////////////////////////////////////////////////
            this.pointerState = pointerState;
        }

        public void Initialize(Model m)
        {
            CurrentShapeName = m.CurrentShapeName;
            IsUpperLeftPressed = false;
            Hint = null;
            FirstPointX = 0;
            FirstPointY = 0;
        }
        public void OnPaint(Model m, IGraphics g)
        {
            // 畫出 Hint
            foreach (Shape shape in m.ShapeList)
            {
                shape.Draw(g);
            }
            if (Hint != null) Hint.Draw(g);
        }
        public void MouseDown(Model m, int x, int y)
        {
            FirstPointX = x;
            FirstPointY = y;
            IsUpperLeftPressed = true;

            // Generate random text for the shape
            string randomText = GenerateRandomText();

            // 確保有選擇形狀
            Hint = _shapesFactory.CreatShape(CurrentShapeName, randomText, x, y, 0, 0);
        }
        public void MouseDoubleClick(Model m, int x, int y) { }
        public void MouseMove(Model m, int x, int y)
        {
            // 增加對 Hint 的空值檢查
            if (IsUpperLeftPressed && Hint != null)
            {
                // 計算寬度和高度
                int width = Math.Abs(x - FirstPointX);
                int height = Math.Abs(y - FirstPointY);

                // 確保起始點是左上角
                int newX = Math.Min(x, FirstPointX);
                int newY = Math.Min(y, FirstPointY);

                Hint.X = newX;
                Hint.Y = newY;
                Hint.Width = width;
                Hint.Height = height;
                m.NotifyModelChanged();
            }
        }
        public void MouseUp(Model m)
        {
            if (IsUpperLeftPressed && Hint != null)
            {
                // 增加了對形狀大小的檢查，確保只有當形狀有實際大小時才添加
                if (Hint.Width > 0 && Hint.Height > 0) 
                {
                    Hint.InitializeTextPosition();
                    //m.AddShape(Hint.GetShapeName(), Hint.Text, Hint.X, Hint.Y, Hint.Width, Hint.Height);

                    var command = new DrawShapeCommand(m, Hint.GetShapeName(),
                        Hint.Text, Hint.X, Hint.Y, Hint.Width, Hint.Height);
                    m.CommandManager.ExecuteCommand(command);
                    m.NotifyShapeAdded();
                }
                IsUpperLeftPressed = false;

                // 等return後，Model才會真正切換到PointerState
                m.EnterPointerState();

                // 指定PointerState選取剛剛新增的圖形，不能與前面那行對調順序
                pointerState.AddSelectedShape(Hint);
            }
        }
        public void KeyDown(Model m, int keyValue) { }
        public void KeyUp(Model m, int keyValue) { }
        private static string GenerateRandomText()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var length = random.Next(3, 7);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}