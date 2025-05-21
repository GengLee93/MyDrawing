using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. 四種流程圖元件（Start, Terminator, Process, Decision）。
//        當新增元件時，簡單工廠 (simple factory) 模式來創建不同元件的 Instance。
//     2. 工廠模式目的是為了讓 Shape 的多型實現不需要使用 switch case 邏輯判斷創建的圖形。
////////////////////////////////////////////////////////////////////////////////////

namespace MyDrawing
{
    public class ShapesFactory
    {
        public Shape CreatShape(string shapeName, string text, int x, int y, int width, int height)
        {
            switch (shapeName) {
                case "Start": return new Start(text, x, y, width, height);
                case "Terminator": return new Terminator(text, x, y, width, height);
                case "Process": return new Process(text, x, y, width, height);
                case "Decision": return new Decision(text, x, y, width, height);
                default: throw new ArgumentException($"Invalid shape type: {shapeName}");
            }
        }
    }
}
