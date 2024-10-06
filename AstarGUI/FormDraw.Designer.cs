namespace AstarGUI
{
    partial class FormDraw
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            numericColumns = new NumericUpDown();
            btnReset = new Button();
            checkDiagonal = new CheckBox();
            btnFind = new Button();
            labelResult = new Label();
            numericCurves = new NumericUpDown();
            numericRows = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            labelCurves = new Label();
            labelOpen = new Label();
            labelClose = new Label();
            checkBoxOpen = new CheckBox();
            checkBoxClosed = new CheckBox();
            btnNodes = new Button();
            labelRes = new Label();
            comboBoxDistance = new ComboBox();
            panel = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericColumns).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCurves).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panel).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(776, 535);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(numericColumns, 0, 13);
            tableLayoutPanel2.Controls.Add(btnReset, 0, 14);
            tableLayoutPanel2.Controls.Add(checkDiagonal, 0, 10);
            tableLayoutPanel2.Controls.Add(btnFind, 0, 15);
            tableLayoutPanel2.Controls.Add(labelResult, 0, 16);
            tableLayoutPanel2.Controls.Add(numericCurves, 0, 9);
            tableLayoutPanel2.Controls.Add(numericRows, 0, 12);
            tableLayoutPanel2.Controls.Add(label1, 0, 11);
            tableLayoutPanel2.Controls.Add(label2, 0, 8);
            tableLayoutPanel2.Controls.Add(labelCurves, 0, 0);
            tableLayoutPanel2.Controls.Add(labelOpen, 0, 1);
            tableLayoutPanel2.Controls.Add(labelClose, 0, 2);
            tableLayoutPanel2.Controls.Add(checkBoxOpen, 0, 7);
            tableLayoutPanel2.Controls.Add(checkBoxClosed, 0, 6);
            tableLayoutPanel2.Controls.Add(btnNodes, 0, 5);
            tableLayoutPanel2.Controls.Add(labelRes, 0, 3);
            tableLayoutPanel2.Controls.Add(comboBoxDistance, 0, 4);
            tableLayoutPanel2.Location = new Point(599, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 17;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 14F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 61F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(174, 529);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // numericColumns
            // 
            numericColumns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericColumns.Location = new Point(3, 344);
            numericColumns.Name = "numericColumns";
            numericColumns.Size = new Size(168, 23);
            numericColumns.TabIndex = 1;
            numericColumns.ValueChanged += numericColumns_ValueChanged;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnReset.Location = new Point(3, 374);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(168, 25);
            btnReset.TabIndex = 3;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // checkDiagonal
            // 
            checkDiagonal.AutoSize = true;
            checkDiagonal.Location = new Point(3, 265);
            checkDiagonal.Name = "checkDiagonal";
            checkDiagonal.Size = new Size(133, 19);
            checkDiagonal.TabIndex = 4;
            checkDiagonal.Text = "Allow Diagonal Path";
            checkDiagonal.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            btnFind.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnFind.Location = new Point(3, 405);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(168, 25);
            btnFind.TabIndex = 0;
            btnFind.Text = "Search";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // labelResult
            // 
            labelResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelResult.AutoSize = true;
            labelResult.Location = new Point(3, 433);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(168, 96);
            labelResult.TabIndex = 5;
            labelResult.Text = "click search to start";
            // 
            // numericCurves
            // 
            numericCurves.DecimalPlaces = 2;
            numericCurves.Dock = DockStyle.Left;
            numericCurves.Location = new Point(3, 230);
            numericCurves.Name = "numericCurves";
            numericCurves.Size = new Size(168, 23);
            numericCurves.TabIndex = 6;
            // 
            // numericRows
            // 
            numericRows.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            numericRows.Location = new Point(3, 313);
            numericRows.Name = "numericRows";
            numericRows.Size = new Size(168, 23);
            numericRows.TabIndex = 2;
            numericRows.ValueChanged += numericRows_ValueChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 289);
            label1.Name = "label1";
            label1.Size = new Size(168, 21);
            label1.TabIndex = 7;
            label1.Text = "Grid Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 205);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 8;
            label2.Text = "Turn/Curve Penalty";
            // 
            // labelCurves
            // 
            labelCurves.AutoSize = true;
            labelCurves.Location = new Point(3, 0);
            labelCurves.Name = "labelCurves";
            labelCurves.Size = new Size(0, 15);
            labelCurves.TabIndex = 10;
            // 
            // labelOpen
            // 
            labelOpen.AutoSize = true;
            labelOpen.Location = new Point(3, 20);
            labelOpen.Name = "labelOpen";
            labelOpen.Size = new Size(0, 15);
            labelOpen.TabIndex = 11;
            labelOpen.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelClose
            // 
            labelClose.AutoSize = true;
            labelClose.Location = new Point(3, 40);
            labelClose.Name = "labelClose";
            labelClose.Size = new Size(0, 15);
            labelClose.TabIndex = 12;
            // 
            // checkBoxOpen
            // 
            checkBoxOpen.AutoSize = true;
            checkBoxOpen.Checked = true;
            checkBoxOpen.CheckState = CheckState.Checked;
            checkBoxOpen.Location = new Point(3, 177);
            checkBoxOpen.Name = "checkBoxOpen";
            checkBoxOpen.Size = new Size(120, 19);
            checkBoxOpen.TabIndex = 13;
            checkBoxOpen.Text = "Show open nodes";
            checkBoxOpen.UseVisualStyleBackColor = true;
            // 
            // checkBoxClosed
            // 
            checkBoxClosed.AutoSize = true;
            checkBoxClosed.Checked = true;
            checkBoxClosed.CheckState = CheckState.Checked;
            checkBoxClosed.Location = new Point(3, 149);
            checkBoxClosed.Name = "checkBoxClosed";
            checkBoxClosed.Size = new Size(127, 19);
            checkBoxClosed.TabIndex = 14;
            checkBoxClosed.Text = "Show closed nodes";
            checkBoxClosed.UseVisualStyleBackColor = true;
            // 
            // btnNodes
            // 
            btnNodes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnNodes.Location = new Point(3, 112);
            btnNodes.Name = "btnNodes";
            btnNodes.Size = new Size(168, 31);
            btnNodes.TabIndex = 17;
            btnNodes.Text = "Showing nodes cost";
            btnNodes.UseVisualStyleBackColor = true;
            btnNodes.Click += btnNodes_Click;
            // 
            // labelRes
            // 
            labelRes.AutoSize = true;
            labelRes.Location = new Point(3, 61);
            labelRes.Name = "labelRes";
            labelRes.Size = new Size(0, 14);
            labelRes.TabIndex = 9;
            // 
            // comboBoxDistance
            // 
            comboBoxDistance.FormattingEnabled = true;
            comboBoxDistance.Items.AddRange(new object[] { "Manhattan", "Chebyshev", "Euclidean" });
            comboBoxDistance.Location = new Point(3, 78);
            comboBoxDistance.Name = "comboBoxDistance";
            comboBoxDistance.Size = new Size(168, 23);
            comboBoxDistance.TabIndex = 15;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.Location = new Point(3, 3);
            panel.Name = "panel";
            panel.Size = new Size(590, 529);
            panel.TabIndex = 2;
            panel.TabStop = false;
            panel.SizeChanged += panel_SizeChanged;
            panel.Paint += onPaint;
            panel.MouseMove += panel_MouseMove;
            // 
            // FormDraw
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 559);
            Controls.Add(tableLayoutPanel1);
            Name = "FormDraw";
            Text = " Astar";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericColumns).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCurves).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)panel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnFind;
        private NumericUpDown numericColumns;
        private NumericUpDown numericRows;
        private Button btnReset;
        private PictureBox panel;
        private CheckBox checkDiagonal;
        private Label labelResult;
        private NumericUpDown numericCurves;
        private Label label1;
        private Label label2;
        private Label labelRes;
        private Label labelCurves;
        private Label labelOpen;
        private Label labelClose;
        private CheckBox checkBoxOpen;
        private CheckBox checkBoxClosed;
        private ComboBox comboBoxDistance;
        private Button btnNodes;
    }
}
