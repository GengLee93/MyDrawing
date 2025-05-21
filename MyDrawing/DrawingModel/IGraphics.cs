using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. IGraphics.cs - 繪圖介面抽象化（Adapter Pattern）
//     2. IGraphics是中性繪圖介面，定義於Model，與任何View都沒有耦合
////////////////////////////////////////////////////////////////////////////////////

namespace MyDrawing
{
    public interface IGraphics
    {
        // 繪製流程圖元件
        void DrawCircle(int x, int y, int width, int height);
        void DrawRectangle(int x, int y, int width, int height);
        void DrawText(int x, int y, string text);
        void DrawEllipse(int x, int y, int width, int height);
        void DrawDiamond(int x, int y, int width, int height);
        void DrawShapeBoundingBox(int x, int y, int width, int height);
        void DrawTextBoundingBox(int x, int y, string text);
        void DrawConnectionPoint(int x, int y, int size);
        void DrawLine(int x1, int y1, int x2, int y2);
        void ClearAll();
    }
}