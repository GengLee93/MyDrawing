using MyDrawing.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyDrawing
{
    public partial class Form1 : Form
    {
        private readonly Model _model;
        private readonly PresentationModel _presentationModel;
        private readonly Panel _canvas = new DoubleBufferedPanel();

        public Form1()
        {
            InitializeComponent();
            //
            // prepare canvas
            //
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.White;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseDoubleClick += HandleCanvasDoublePressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
            //
            // Key Event Handlers
            //
            KeyPreview = true;  // Form1 屬性設置 KeyPreview = true 才可以攔截按鍵事件。
            KeyDown += KeyDownHandler;
            KeyUp += KeyUpHandler;
            //
            // prepare presentation model and model
            //
            _model = new Model();
            _presentationModel = new PresentationModel(_model, _canvas);
            _model.ModelChanged += HandleModelChanged;
            _model.ShapeAdded += RefreshDataGridView;
            _presentationModel.PMChanged += UpdateUIState;
            //
            // DataBinding "newShapebtn" Enabled 屬性
            //
            newShapebtn.DataBindings.Add("Enabled", _presentationModel, "IsAddButtonEnabled");
            textBoxX.TextChanged += (s, e) => { _presentationModel.XText = textBoxX.Text; _presentationModel.ValidateForm(); }; 
            textBoxY.TextChanged += (s, e) => { _presentationModel.YText = textBoxY.Text; _presentationModel.ValidateForm(); }; 
            textBoxWidth.TextChanged += (s, e) => { _presentationModel.WidthText = textBoxWidth.Text; _presentationModel.ValidateForm(); }; 
            textBoxHeight.TextChanged += (s, e) => { _presentationModel.HeightText = textBoxHeight.Text; _presentationModel.ValidateForm(); };
            comboBox1Shapes.SelectedIndexChanged += (s, e) => { _presentationModel.ShapesComboBoxText = comboBox1Shapes.Text; _presentationModel.ValidateForm(); };
            ////
            //// initial bottom status
            ////
            toolStripRedoButton.Enabled = false;
            toolStripUndoButton.Enabled = false;

            // 初始驗證 dataGridView 填寫
            _presentationModel.ValidateForm();
        }

        private void UpdateUIState()
        {
            toolStripStartButton.Checked = _presentationModel.IsStartChecked;
            toolStripTerminatorButton.Checked = _presentationModel.IsTerminatorChecked;
            toolStripDecisionButton.Checked = _presentationModel.IsDecisionChecked;
            toolStripProcessButton.Checked = _presentationModel.IsProcessChecked;
            toolStripMouseButton.Checked = _presentationModel.IsPointerChecked;
            toolStripLineButton.Checked = _presentationModel.IsLineChecked;

            ///////////////////////////////////////////////////////////////////
            toolStripUndoButton.Enabled = _presentationModel.IsUndoEnabled;
            toolStripRedoButton.Enabled = _presentationModel.IsRedoEnabled;
            ///////////////////////////////////////////////////////////////////

            Xlabel.ForeColor = _presentationModel.XLabelColor == "Red" ? Color.Red : Color.Black;
            YLabel.ForeColor = _presentationModel.YLabelColor == "Red" ? Color.Red : Color.Black;
            WidthLabel.ForeColor = _presentationModel.WidthLabelColor == "Red" ? Color.Red : Color.Black;
            HeightLabel.ForeColor = _presentationModel.HeightLabelColor == "Red" ? Color.Red : Color.Black;
            newShapebtn.Enabled = _presentationModel.IsAddButtonEnabled;
        }
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }
        public void HandleCanvasDoublePressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerDoublePressed(e.X, e.Y);
        }
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerReleased();
            _presentationModel.UpdateCursor(Cursors.Default);
            _presentationModel.ClearAllCheckedButtons();
        }
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }
        public void HandleModelChanged()
        {
            // Invalidate(true); 會導致完整的重繪，包括子控制項，造成頻繁重繪，導致掉幀。
            _canvas.Invalidate();
        }
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            // 注意：同一個鍵持續按著不放會自動Auto repeat
            _model.KeyDown(e.KeyValue);
        }
        private void KeyUpHandler(object sender, KeyEventArgs e)
        {
            _model.KeyUp(e.KeyValue);
            UpdateStyles();
        }

        // 按下 textView 的 "Del" 按鈕
        private void DataGridView1CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // "Delete" button column
            {
                //_model.RemoveShape(e.RowIndex);
                var shapeToDel = _model.ShapeList[e.RowIndex];
                var command = new DeleteShapeCommand(_model, shapeToDel);
                _model.CommandManager.ExecuteCommand(command);
                RefreshDataGridView();
                _model.EnterPointerState();
            }
        }

        // This method is called when the user clicks the "New Shape" button
        private void NewShapeButtonClick(object sender, EventArgs e)
        {
            var command = new DrawShapeCommand(
                _model,
                comboBox1Shapes.SelectedItem.ToString(),
                textBoxText.Text,
                int.Parse(textBoxX.Text),
                int.Parse(textBoxY.Text),
                int.Parse(textBoxWidth.Text),
                int.Parse(textBoxHeight.Text)
                );
            _model.CommandManager.ExecuteCommand(command);
            //_model.AddShape(
            //comboBox1Shapes.SelectedItem.ToString(),
            //textBoxText.Text,
            //int.Parse(textBoxX.Text),
            //int.Parse(textBoxY.Text),
            //int.Parse(textBoxWidth.Text),
            //int.Parse(textBoxHeight.Text)
            //);
            UpdateUIState();
            RefreshDataGridView();
        }

        // 更新 textView
        private void RefreshDataGridView()
        {
            // 未來可以利用 DataBingding 做更好的處理
            dataGridView1.Rows.Clear();
            for (int i = 0; i < _model.ShapeList.Count; i++)
            {
                var shape = _model.ShapeList[i];
                dataGridView1.Rows.Add(
                    "Del",                     // 刪除按鈕
                    i + 1,                     // 排序
                    shape.GetShapeName(),      // 形狀名稱
                    shape.Text,                // 顯示文字
                    shape.X,                   // X 座標
                    shape.Y,                   // Y 座標
                    shape.Width,               // 寬度
                    shape.Height               // 高度
                );
            }
        }
        public void HandleToolStripButtonClick(ToolStripButton button, string shapeName)
        {
            _presentationModel.SetCheckedButton(shapeName);
            _model.CurrentShapeName = shapeName;

            if (shapeName != "")
            {
                _presentationModel.UpdateCursor(Cursors.Cross);
                if (shapeName == "Line")
                {
                    _model.EnterDrawingLineState();
                    return;
                }
                _model.EnterDrawingShapeState();
            }
            else
            {
                _presentationModel.UpdateCursor(Cursors.Default);
                _model.EnterPointerState();
            }
        }

        // 按下Line按鈕
        private void ToolStripLineButtonClick(object sender, EventArgs e)
        {
            HandleToolStripButtonClick(toolStripStartButton, "Line");
        }

        // 按下Start按鈕
        private void ToolStripStartButtonClick(object sender, EventArgs e)
        {
            HandleToolStripButtonClick(toolStripStartButton, "Start");
        }

        // 按下Terminator按鈕
        private void ToolStripTerminatorButtonClick(object sender, EventArgs e)
        {
            HandleToolStripButtonClick(toolStripTerminatorButton, "Terminator");
        }

        // 按下Decision按鈕
        private void ToolStripDecisionButtonClick(object sender, EventArgs e)
        {
            HandleToolStripButtonClick(toolStripDecisionButton, "Decision");
        }

        // 按下Process按鈕
        private void ToolStripProcessButtonClick(object sender, EventArgs e)
        {
            HandleToolStripButtonClick(toolStripProcessButton, "Process");
        }

        // 按下Mouse按鈕
        private void ToolStripMouseButtonClick(object sender, EventArgs e)
        {
            HandleToolStripButtonClick(toolStripProcessButton, "");
        }

        // 按下Undo按鈕
        private void ToolStripUndoButtonClick(object sender, EventArgs e)
        {
            _model.Undo();
            UpdateUIState();
            RefreshDataGridView();
        }

        // 按下Redo按鈕
        private void ToolStripRedoButtonClick(object sender, EventArgs e)
        {
            _model.Redo();
            UpdateUIState();
            RefreshDataGridView();
        }
    }
}