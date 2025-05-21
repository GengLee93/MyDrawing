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
        // 流程圖元件
        void DrawCircle(int x, int y, int width, int height);
        void DrawRectangle(int x, int y, int width, int height);
        void DrawText(string text, int x, int y);
        void DrawEllipse(int x, int y, int width, int height);
        void DrawDiamond(int x, int y, int width, int height);
        void ClearAll();
    }
}