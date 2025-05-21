using MyDrawing.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
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
    public class PresentationModel
    {
        public event PresentationModelChangedEventHandler PMChanged;
        public delegate void PresentationModelChangedEventHandler();

        private readonly Model _model;
        private readonly Control _canvas;

        public PresentationModel(Model model, Control canvas)
        {
            _canvas = canvas;
            _model = model;
        }

        //
        // ToolStripButton特徵
        //
        public bool IsStartChecked { get; private set; }
        public bool IsTerminatorChecked { get; private set; }
        public bool IsDecisionChecked { get; private set; }
        public bool IsProcessChecked { get; private set; }
        public bool IsLineChecked { get; private set; }
        public bool IsPointerChecked { get; private set; }
        public bool IsUndoEnabled => _model.IsUndoEnabled();
        public bool IsRedoEnabled => _model.IsRedoEnabled();
        //
        // dataGridView上Lable特徵
        //
        public bool IsAddButtonEnabled { get; private set; }
        public string XLabelColor { get; private set; }
        public string YLabelColor { get; private set; }
        public string HeightLabelColor { get; private set; }
        public string WidthLabelColor { get; private set; }
        //
        // 圖形參數輸入 textBoxs
        //
        public string XText { get; set; }
        public string YText { get; set; }
        public string WidthText { get; set; }
        public string HeightText { get; set; }
        public string ShapesComboBoxText { get; set; }

        public void Draw(Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用 
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作 
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new GraphicsAdapter(graphics));
        }
        public void UpdateCursor(Cursor cursor)
        {
            _canvas.Cursor = cursor;
        }
        public void SetCheckedButton(string shapeName)
        {
            ClearAllCheckedButtons();
            switch (shapeName)
            {
                case "Start": IsStartChecked = true; break;
                case "Terminator": IsTerminatorChecked = true; break;
                case "Decision": IsDecisionChecked = true; break;
                case "Process": IsProcessChecked = true; break;
                case "Line": IsLineChecked = true; break;
                case "": IsPointerChecked = true; break;
                default: break;
            }
            NotifyPMChanged();
        }
        public void ClearAllCheckedButtons()
        {
            IsStartChecked = false;
            IsTerminatorChecked = false;
            IsDecisionChecked = false;
            IsProcessChecked = false;
            IsLineChecked = false;
            IsPointerChecked = false;
            NotifyPMChanged();
        }
        public void ValidateForm()
        {
            IsAddButtonEnabled = int.TryParse(XText, out int x) && x > 0 &&
                                 int.TryParse(YText, out int y) && y > 0 &&
                                 int.TryParse(WidthText, out int width) && width > 0 &&
                                 int.TryParse(HeightText, out int height) && height > 0 &&
                                 !string.IsNullOrEmpty(ShapesComboBoxText);

            XLabelColor = int.TryParse(XText, out x) && x > 0 ? "Black" : "Red"; 
            YLabelColor = int.TryParse(YText, out y) && y > 0 ? "Black" : "Red"; 
            WidthLabelColor = int.TryParse(WidthText, out width) && width > 0 ? "Black" : "Red"; 
            HeightLabelColor = int.TryParse(HeightText, out height) && height > 0 ? "Black" : "Red";
            NotifyPMChanged();
        }
        protected virtual void NotifyPMChanged()
        {
            PMChanged?.Invoke();
        }    
    }
}