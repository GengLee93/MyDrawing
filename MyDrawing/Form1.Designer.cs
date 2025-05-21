namespace MyDrawing
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DELColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShapesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.YLabel = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.comboBox1Shapes = new System.Windows.Forms.ComboBox();
            this.newShapebtn = new System.Windows.Forms.Button();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.TextLabel = new System.Windows.Forms.Label();
            this.Xlabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.button3 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripUndoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRedoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripMouseButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripStartButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripTerminatorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDecisionButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripProcessButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLineButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DELColumn,
            this.IDColumn,
            this.ShapesColumn,
            this.TextColumn,
            this.XColumn,
            this.YColumn,
            this.HColumn,
            this.WColumn});
            this.dataGridView1.Location = new System.Drawing.Point(0, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(345, 590);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellContentClick);
            // 
            // DELColumn
            // 
            this.DELColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DELColumn.FillWeight = 80.95067F;
            this.DELColumn.HeaderText = "DELETE";
            this.DELColumn.MinimumWidth = 6;
            this.DELColumn.Name = "DELColumn";
            this.DELColumn.ReadOnly = true;
            this.DELColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DELColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DELColumn.Width = 70;
            // 
            // IDColumn
            // 
            this.IDColumn.FillWeight = 42.78074F;
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.MinimumWidth = 6;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 25;
            // 
            // ShapesColumn
            // 
            this.ShapesColumn.FillWeight = 179.2877F;
            this.ShapesColumn.HeaderText = "Shapes";
            this.ShapesColumn.MinimumWidth = 6;
            this.ShapesColumn.Name = "ShapesColumn";
            this.ShapesColumn.ReadOnly = true;
            this.ShapesColumn.Width = 70;
            // 
            // TextColumn
            // 
            this.TextColumn.FillWeight = 197.8163F;
            this.TextColumn.HeaderText = "Text";
            this.TextColumn.MinimumWidth = 6;
            this.TextColumn.Name = "TextColumn";
            this.TextColumn.ReadOnly = true;
            this.TextColumn.Width = 62;
            // 
            // XColumn
            // 
            this.XColumn.FillWeight = 76.62164F;
            this.XColumn.HeaderText = "X";
            this.XColumn.MinimumWidth = 6;
            this.XColumn.Name = "XColumn";
            this.XColumn.ReadOnly = true;
            this.XColumn.Width = 30;
            // 
            // YColumn
            // 
            this.YColumn.FillWeight = 75.04753F;
            this.YColumn.HeaderText = "Y";
            this.YColumn.MinimumWidth = 6;
            this.YColumn.Name = "YColumn";
            this.YColumn.ReadOnly = true;
            this.YColumn.Width = 30;
            // 
            // HColumn
            // 
            this.HColumn.FillWeight = 74.21966F;
            this.HColumn.HeaderText = "H";
            this.HColumn.MinimumWidth = 6;
            this.HColumn.Name = "HColumn";
            this.HColumn.ReadOnly = true;
            this.HColumn.Width = 30;
            // 
            // WColumn
            // 
            this.WColumn.FillWeight = 73.27568F;
            this.WColumn.HeaderText = "W";
            this.WColumn.MinimumWidth = 6;
            this.WColumn.Name = "WColumn";
            this.WColumn.ReadOnly = true;
            this.WColumn.Width = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxY);
            this.groupBox1.Controls.Add(this.textBoxWidth);
            this.groupBox1.Controls.Add(this.YLabel);
            this.groupBox1.Controls.Add(this.textBoxX);
            this.groupBox1.Controls.Add(this.textBoxHeight);
            this.groupBox1.Controls.Add(this.textBoxText);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.comboBox1Shapes);
            this.groupBox1.Controls.Add(this.newShapebtn);
            this.groupBox1.Controls.Add(this.WidthLabel);
            this.groupBox1.Controls.Add(this.TextLabel);
            this.groupBox1.Controls.Add(this.Xlabel);
            this.groupBox1.Controls.Add(this.HeightLabel);
            this.groupBox1.Location = new System.Drawing.Point(865, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 618);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("標楷體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxY.Location = new System.Drawing.Point(255, 35);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(30, 23);
            this.textBoxY.TabIndex = 17;
            this.textBoxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Font = new System.Drawing.Font("標楷體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxWidth.Location = new System.Drawing.Point(315, 35);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(30, 23);
            this.textBoxWidth.TabIndex = 18;
            this.textBoxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.YLabel.Location = new System.Drawing.Point(259, 17);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(17, 15);
            this.YLabel.TabIndex = 4;
            this.YLabel.Text = "Y";
            // 
            // textBoxX
            // 
            this.textBoxX.Font = new System.Drawing.Font("標楷體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxX.Location = new System.Drawing.Point(224, 35);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(30, 23);
            this.textBoxX.TabIndex = 15;
            this.textBoxX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Font = new System.Drawing.Font("標楷體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxHeight.Location = new System.Drawing.Point(285, 35);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(30, 23);
            this.textBoxHeight.TabIndex = 16;
            this.textBoxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxText
            // 
            this.textBoxText.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBoxText.Location = new System.Drawing.Point(132, 29);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(91, 31);
            this.textBoxText.TabIndex = 8;
            // 
            // comboBox1Shapes
            // 
            this.comboBox1Shapes.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox1Shapes.FormattingEnabled = true;
            this.comboBox1Shapes.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Process",
            "Decision"});
            this.comboBox1Shapes.Location = new System.Drawing.Point(54, 33);
            this.comboBox1Shapes.Name = "comboBox1Shapes";
            this.comboBox1Shapes.Size = new System.Drawing.Size(72, 25);
            this.comboBox1Shapes.TabIndex = 3;
            // 
            // newShapebtn
            // 
            this.newShapebtn.Location = new System.Drawing.Point(0, 29);
            this.newShapebtn.Name = "newShapebtn";
            this.newShapebtn.Size = new System.Drawing.Size(48, 32);
            this.newShapebtn.TabIndex = 3;
            this.newShapebtn.Text = "New";
            this.newShapebtn.UseVisualStyleBackColor = true;
            this.newShapebtn.Click += new System.EventHandler(this.NewShapeButtonClick);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WidthLabel.Location = new System.Drawing.Point(318, 16);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(20, 15);
            this.WidthLabel.TabIndex = 6;
            this.WidthLabel.Text = "W";
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TextLabel.Location = new System.Drawing.Point(162, 11);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(33, 15);
            this.TextLabel.TabIndex = 7;
            this.TextLabel.Text = "Text";
            // 
            // Xlabel
            // 
            this.Xlabel.AutoSize = true;
            this.Xlabel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Xlabel.Location = new System.Drawing.Point(229, 17);
            this.Xlabel.Name = "Xlabel";
            this.Xlabel.Size = new System.Drawing.Size(17, 15);
            this.Xlabel.TabIndex = 3;
            this.Xlabel.Text = "X";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HeightLabel.Location = new System.Drawing.Point(289, 16);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(17, 15);
            this.HeightLabel.TabIndex = 5;
            this.HeightLabel.Text = "H";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1223, 27);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 23);
            this.helpToolStripMenuItem.Text = "說明";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.aboutToolStripMenuItem.Text = "about";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 69);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 155);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 69);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUndoButton,
            this.toolStripRedoButton,
            this.toolStripMouseButton,
            this.toolStripStartButton,
            this.toolStripTerminatorButton,
            this.toolStripDecisionButton,
            this.toolStripProcessButton,
            this.toolStripLineButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1223, 27);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripUndoButton
            // 
            this.toolStripUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripUndoButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUndoButton.Image")));
            this.toolStripUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUndoButton.Name = "toolStripUndoButton";
            this.toolStripUndoButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripUndoButton.Text = "toolStripUndoButton";
            this.toolStripUndoButton.Click += new System.EventHandler(this.ToolStripUndoButtonClick);
            // 
            // toolStripRedoButton
            // 
            this.toolStripRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRedoButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRedoButton.Image")));
            this.toolStripRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRedoButton.Name = "toolStripRedoButton";
            this.toolStripRedoButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripRedoButton.Text = "toolStripRedoButton";
            this.toolStripRedoButton.Click += new System.EventHandler(this.ToolStripRedoButtonClick);
            // 
            // toolStripMouseButton
            // 
            this.toolStripMouseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMouseButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMouseButton.Image")));
            this.toolStripMouseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMouseButton.Name = "toolStripMouseButton";
            this.toolStripMouseButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripMouseButton.Text = "Mouse";
            this.toolStripMouseButton.ToolTipText = "Mouse";
            this.toolStripMouseButton.Click += new System.EventHandler(this.ToolStripMouseButtonClick);
            // 
            // toolStripStartButton
            // 
            this.toolStripStartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStartButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStartButton.Image")));
            this.toolStripStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartButton.Name = "toolStripStartButton";
            this.toolStripStartButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripStartButton.Text = "Start";
            this.toolStripStartButton.ToolTipText = "toolStripButton";
            this.toolStripStartButton.Click += new System.EventHandler(this.ToolStripStartButtonClick);
            // 
            // toolStripTerminatorButton
            // 
            this.toolStripTerminatorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTerminatorButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTerminatorButton.Image")));
            this.toolStripTerminatorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTerminatorButton.Name = "toolStripTerminatorButton";
            this.toolStripTerminatorButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripTerminatorButton.Text = "Terminator";
            this.toolStripTerminatorButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripTerminatorButton.Click += new System.EventHandler(this.ToolStripTerminatorButtonClick);
            // 
            // toolStripDecisionButton
            // 
            this.toolStripDecisionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDecisionButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDecisionButton.Image")));
            this.toolStripDecisionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDecisionButton.Name = "toolStripDecisionButton";
            this.toolStripDecisionButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripDecisionButton.Text = "Decision";
            this.toolStripDecisionButton.Click += new System.EventHandler(this.ToolStripDecisionButtonClick);
            // 
            // toolStripProcessButton
            // 
            this.toolStripProcessButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripProcessButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripProcessButton.Image")));
            this.toolStripProcessButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripProcessButton.Name = "toolStripProcessButton";
            this.toolStripProcessButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripProcessButton.Text = "Process";
            this.toolStripProcessButton.Click += new System.EventHandler(this.ToolStripProcessButtonClick);
            // 
            // toolStripLineButton
            // 
            this.toolStripLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLineButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLineButton.Image")));
            this.toolStripLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLineButton.Name = "toolStripLineButton";
            this.toolStripLineButton.Size = new System.Drawing.Size(29, 24);
            this.toolStripLineButton.Text = "Line";
            this.toolStripLineButton.Click += new System.EventHandler(this.ToolStripLineButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 683);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyDrawing";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button newShapebtn;
        private System.Windows.Forms.ComboBox comboBox1Shapes;
        private System.Windows.Forms.Label Xlabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label TextLabel;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripStartButton;
        private System.Windows.Forms.ToolStripButton toolStripTerminatorButton;
        private System.Windows.Forms.ToolStripButton toolStripDecisionButton;
        private System.Windows.Forms.ToolStripButton toolStripProcessButton;
        private System.Windows.Forms.DataGridViewButtonColumn DELColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShapesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn XColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn YColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WColumn;
        private System.Windows.Forms.ToolStripButton toolStripMouseButton;
        private System.Windows.Forms.ToolStripButton toolStripUndoButton;
        private System.Windows.Forms.ToolStripButton toolStripRedoButton;
        private System.Windows.Forms.ToolStripButton toolStripLineButton;
    }
}

