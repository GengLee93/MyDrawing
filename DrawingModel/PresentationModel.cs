using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/////////////////////////////////////////////////////////////////////////////////////
// Note:
//     1. PresentationModel不含任何controls
//     2. PresentationModel儲存、管理、控制control的狀態
//     3. PresentationModel將事件委派(delegate)給Model負責
////////////////////////////////////////////////////////////////////////////////////

namespace MyDrawing
{
    class PresentationModel
    {
        private readonly Model _model;
        private string _selectedShape;
        public PresentationModel(Model model, Control canvas)
        {
            this._model = model;
            canvas.MouseMove += MouseMoveHandler;
            
        }
        
        public void Draw(Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用 
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作 
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new GraphicsAdapter(graphics));
        }

        // 鼠標移動事件
        public void MouseMoveHandler(int x, int y)
        {
            _model.MouseMoveHandler(x, y);
        }
    }
}