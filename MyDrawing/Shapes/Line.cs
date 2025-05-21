using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Shapes
{
    public class Line : Shape
    {
        public Shape StartShape { get; private set; }
        public Shape EndShape { get; private set; }
        public (int x, int y) StartPoint { get; private set; }
        public (int x, int y) EndPoint { get; private set; }

        public Line(Shape startShape, (int x, int y) startPoint, Shape endShape, (int x, int y) endPoint, string text = "")
        : base(text, startPoint.x, startPoint.y, Math.Abs(endPoint.x - startPoint.x), Math.Abs(endPoint.y - startPoint.y))
        {
            StartShape = startShape;
            EndShape = endShape;
            StartPoint = startPoint;
            EndPoint = endPoint;

            // 訂閱起始和結束圖形的位置變化
            if (StartShape is INotifyPropertyChanged startNotify)
            {
                startNotify.PropertyChanged += (s, e) => UpdatePosition();
            }
            if (EndShape is INotifyPropertyChanged endNotify)
            {
                endNotify.PropertyChanged += (s, e) => UpdatePosition();
            }
        }
        public override string GetShapeName() => "Line";
        public override void Draw(IGraphics graphics)
        {
            UpdatePosition();
            graphics.DrawLine(StartPoint.x, StartPoint.y, EndPoint.x, EndPoint.y);
        }

        private void UpdatePosition()
        {
            // 當相連的圖形移動時，更新連接點的位置
            if (StartShape != null)
            {
                StartPoint = FindNearestPoint(StartShape.GetConnectionPoints(), StartPoint);
            }
            if (EndShape != null)
            {
                EndPoint = FindNearestPoint(EndShape.GetConnectionPoints(), EndPoint);
            }
        }
        private static (int x, int y) FindNearestPoint(List<(int x, int y)> points, (int x, int y) target)
        {
            return points.OrderBy(p =>
                Math.Sqrt(Math.Pow(p.x - target.x, 2) + Math.Pow(p.y - target.y, 2))).First();
        }
    }
}
