namespace SkillerAgent
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PositionsGroupBox = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.PositionsGridView = new System.Windows.Forms.DataGridView();
            this.xColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftOrRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTSleep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SleepTimeTextBox = new System.Windows.Forms.TextBox();
            this.QueuedYPositionTextBox = new System.Windows.Forms.TextBox();
            this.RightClickCheckBox = new System.Windows.Forms.CheckBox();
            this.SleepTimeLabel = new System.Windows.Forms.Label();
            this.AddPositionButton = new System.Windows.Forms.Button();
            this.QueuedXPositionLabel = new System.Windows.Forms.Label();
            this.QueuedYPositionLabel = new System.Windows.Forms.Label();
            this.QueuedXPositionTextBox = new System.Windows.Forms.TextBox();
            this.QueuedPositionsLabel = new System.Windows.Forms.Label();
            this.ListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentPosGroupBox = new System.Windows.Forms.GroupBox();
            this.CopyToAddButton = new System.Windows.Forms.Button();
            this.CurrentYCoordTextBox = new System.Windows.Forms.TextBox();
            this.XCoordLabel = new System.Windows.Forms.Label();
            this.YCoordLabel = new System.Windows.Forms.Label();
            this.CurrentXCoordTextBox = new System.Windows.Forms.TextBox();
            this.StartingOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.IterationLabel = new System.Windows.Forms.Label();
            this.IterationDescLabel = new System.Windows.Forms.Label();
            this.StopClickingButton = new System.Windows.Forms.Button();
            this.StartClickingButton = new System.Windows.Forms.Button();
            this.NumRepeatsTextBox = new System.Windows.Forms.TextBox();
            this.NumRepeatsLabel = new System.Windows.Forms.Label();
            this.CurrentPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PositionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionsGridView)).BeginInit();
            this.ListViewContextMenu.SuspendLayout();
            this.CurrentPosGroupBox.SuspendLayout();
            this.StartingOptionsGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionsGroupBox
            // 
            this.PositionsGroupBox.Controls.Add(this.SaveButton);
            this.PositionsGroupBox.Controls.Add(this.ImportButton);
            this.PositionsGroupBox.Controls.Add(this.PositionsGridView);
            this.PositionsGroupBox.Controls.Add(this.SleepTimeTextBox);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionTextBox);
            this.PositionsGroupBox.Controls.Add(this.RightClickCheckBox);
            this.PositionsGroupBox.Controls.Add(this.SleepTimeLabel);
            this.PositionsGroupBox.Controls.Add(this.AddPositionButton);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionTextBox);
            this.PositionsGroupBox.Controls.Add(this.QueuedPositionsLabel);
            this.PositionsGroupBox.Location = new System.Drawing.Point(285, 38);
            this.PositionsGroupBox.Name = "PositionsGroupBox";
            this.PositionsGroupBox.Size = new System.Drawing.Size(493, 340);
            this.PositionsGroupBox.TabIndex = 0;
            this.PositionsGroupBox.TabStop = false;
            this.PositionsGroupBox.Text = "Cursor Positions";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(401, 305);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(84, 20);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(401, 276);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(85, 21);
            this.ImportButton.TabIndex = 13;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // PositionsGridView
            // 
            this.PositionsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PositionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PositionsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xColumn,
            this.yColumn,
            this.leftOrRight,
            this.tTSleep});
            this.PositionsGridView.Location = new System.Drawing.Point(6, 32);
            this.PositionsGridView.Name = "PositionsGridView";
            this.PositionsGridView.Size = new System.Drawing.Size(481, 237);
            this.PositionsGridView.TabIndex = 12;
            this.PositionsGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PositionsGridView_CellDoubleClick);
            // 
            // xColumn
            // 
            this.xColumn.HeaderText = "X";
            this.xColumn.Name = "xColumn";
            // 
            // yColumn
            // 
            this.yColumn.HeaderText = "Y";
            this.yColumn.Name = "yColumn";
            // 
            // leftOrRight
            // 
            this.leftOrRight.HeaderText = "L/R";
            this.leftOrRight.Name = "leftOrRight";
            // 
            // tTSleep
            // 
            this.tTSleep.HeaderText = "Time to Sleep";
            this.tTSleep.Name = "tTSleep";
            // 
            // SleepTimeTextBox
            // 
            this.SleepTimeTextBox.Location = new System.Drawing.Point(285, 306);
            this.SleepTimeTextBox.Name = "SleepTimeTextBox";
            this.SleepTimeTextBox.Size = new System.Drawing.Size(87, 20);
            this.SleepTimeTextBox.TabIndex = 11;
            this.SleepTimeTextBox.Text = "1000";
            // 
            // QueuedYPositionTextBox
            // 
            this.QueuedYPositionTextBox.Location = new System.Drawing.Point(285, 277);
            this.QueuedYPositionTextBox.Name = "QueuedYPositionTextBox";
            this.QueuedYPositionTextBox.Size = new System.Drawing.Size(87, 20);
            this.QueuedYPositionTextBox.TabIndex = 10;
            // 
            // RightClickCheckBox
            // 
            this.RightClickCheckBox.AutoSize = true;
            this.RightClickCheckBox.Location = new System.Drawing.Point(15, 308);
            this.RightClickCheckBox.Name = "RightClickCheckBox";
            this.RightClickCheckBox.Size = new System.Drawing.Size(83, 17);
            this.RightClickCheckBox.TabIndex = 9;
            this.RightClickCheckBox.Text = "Right Click?";
            this.RightClickCheckBox.UseVisualStyleBackColor = true;
            // 
            // SleepTimeLabel
            // 
            this.SleepTimeLabel.AutoSize = true;
            this.SleepTimeLabel.Location = new System.Drawing.Point(169, 310);
            this.SleepTimeLabel.Name = "SleepTimeLabel";
            this.SleepTimeLabel.Size = new System.Drawing.Size(106, 13);
            this.SleepTimeLabel.TabIndex = 5;
            this.SleepTimeLabel.Text = "Time to Sleep (.ms) - ";
            // 
            // AddPositionButton
            // 
            this.AddPositionButton.Location = new System.Drawing.Point(15, 276);
            this.AddPositionButton.Name = "AddPositionButton";
            this.AddPositionButton.Size = new System.Drawing.Size(131, 21);
            this.AddPositionButton.TabIndex = 4;
            this.AddPositionButton.Text = "Add Position (Shift + F2)";
            this.AddPositionButton.UseVisualStyleBackColor = true;
            this.AddPositionButton.Click += new System.EventHandler(this.AddPositionButton_Click);
            // 
            // QueuedXPositionLabel
            // 
            this.QueuedXPositionLabel.AutoSize = true;
            this.QueuedXPositionLabel.Location = new System.Drawing.Point(152, 280);
            this.QueuedXPositionLabel.Name = "QueuedXPositionLabel";
            this.QueuedXPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.QueuedXPositionLabel.TabIndex = 7;
            this.QueuedXPositionLabel.Text = "X";
            // 
            // QueuedYPositionLabel
            // 
            this.QueuedYPositionLabel.AutoSize = true;
            this.QueuedYPositionLabel.Location = new System.Drawing.Point(265, 280);
            this.QueuedYPositionLabel.Name = "QueuedYPositionLabel";
            this.QueuedYPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.QueuedYPositionLabel.TabIndex = 8;
            this.QueuedYPositionLabel.Text = "Y";
            // 
            // QueuedXPositionTextBox
            // 
            this.QueuedXPositionTextBox.Location = new System.Drawing.Point(172, 277);
            this.QueuedXPositionTextBox.Name = "QueuedXPositionTextBox";
            this.QueuedXPositionTextBox.Size = new System.Drawing.Size(87, 20);
            this.QueuedXPositionTextBox.TabIndex = 8;
            // 
            // QueuedPositionsLabel
            // 
            this.QueuedPositionsLabel.AutoSize = true;
            this.QueuedPositionsLabel.Location = new System.Drawing.Point(3, 16);
            this.QueuedPositionsLabel.Name = "QueuedPositionsLabel";
            this.QueuedPositionsLabel.Size = new System.Drawing.Size(123, 13);
            this.QueuedPositionsLabel.TabIndex = 0;
            this.QueuedPositionsLabel.Text = "Queued Cursor Positions";
            // 
            // ListViewContextMenu
            // 
            this.ListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveAllMenuItem,
            this.RemoveSelectedMenuItem});
            this.ListViewContextMenu.Name = "ListViewContextMenu";
            this.ListViewContextMenu.Size = new System.Drawing.Size(167, 48);
            // 
            // RemoveAllMenuItem
            // 
            this.RemoveAllMenuItem.Name = "RemoveAllMenuItem";
            this.RemoveAllMenuItem.Size = new System.Drawing.Size(166, 22);
            this.RemoveAllMenuItem.Text = "Remove All Items";
            this.RemoveAllMenuItem.Click += new System.EventHandler(this.RemoveAllMenuItem_Click);
            // 
            // RemoveSelectedMenuItem
            // 
            this.RemoveSelectedMenuItem.Name = "RemoveSelectedMenuItem";
            this.RemoveSelectedMenuItem.Size = new System.Drawing.Size(166, 22);
            this.RemoveSelectedMenuItem.Text = "Remove Selected";
            this.RemoveSelectedMenuItem.Click += new System.EventHandler(this.RemoveSelectedMenuItem_Click);
            // 
            // CurrentPosGroupBox
            // 
            this.CurrentPosGroupBox.Controls.Add(this.CopyToAddButton);
            this.CurrentPosGroupBox.Controls.Add(this.CurrentYCoordTextBox);
            this.CurrentPosGroupBox.Controls.Add(this.XCoordLabel);
            this.CurrentPosGroupBox.Controls.Add(this.YCoordLabel);
            this.CurrentPosGroupBox.Controls.Add(this.CurrentXCoordTextBox);
            this.CurrentPosGroupBox.Location = new System.Drawing.Point(12, 38);
            this.CurrentPosGroupBox.Name = "CurrentPosGroupBox";
            this.CurrentPosGroupBox.Size = new System.Drawing.Size(267, 157);
            this.CurrentPosGroupBox.TabIndex = 2;
            this.CurrentPosGroupBox.TabStop = false;
            this.CurrentPosGroupBox.Text = "Current Cursor Position";
            // 
            // CopyToAddButton
            // 
            this.CopyToAddButton.Location = new System.Drawing.Point(6, 112);
            this.CopyToAddButton.Name = "CopyToAddButton";
            this.CopyToAddButton.Size = new System.Drawing.Size(252, 30);
            this.CopyToAddButton.TabIndex = 6;
            this.CopyToAddButton.Text = "Copy to Add Position (Shift + F1)";
            this.CopyToAddButton.UseVisualStyleBackColor = true;
            this.CopyToAddButton.Click += new System.EventHandler(this.CopyToAddButton_Click);
            // 
            // CurrentYCoordTextBox
            // 
            this.CurrentYCoordTextBox.Location = new System.Drawing.Point(47, 75);
            this.CurrentYCoordTextBox.Name = "CurrentYCoordTextBox";
            this.CurrentYCoordTextBox.Size = new System.Drawing.Size(214, 20);
            this.CurrentYCoordTextBox.TabIndex = 5;
            // 
            // XCoordLabel
            // 
            this.XCoordLabel.AutoSize = true;
            this.XCoordLabel.Location = new System.Drawing.Point(6, 36);
            this.XCoordLabel.Name = "XCoordLabel";
            this.XCoordLabel.Size = new System.Drawing.Size(14, 13);
            this.XCoordLabel.TabIndex = 2;
            this.XCoordLabel.Text = "X";
            // 
            // YCoordLabel
            // 
            this.YCoordLabel.AutoSize = true;
            this.YCoordLabel.Location = new System.Drawing.Point(6, 78);
            this.YCoordLabel.Name = "YCoordLabel";
            this.YCoordLabel.Size = new System.Drawing.Size(14, 13);
            this.YCoordLabel.TabIndex = 3;
            this.YCoordLabel.Text = "Y";
            // 
            // CurrentXCoordTextBox
            // 
            this.CurrentXCoordTextBox.Location = new System.Drawing.Point(47, 33);
            this.CurrentXCoordTextBox.Name = "CurrentXCoordTextBox";
            this.CurrentXCoordTextBox.Size = new System.Drawing.Size(214, 20);
            this.CurrentXCoordTextBox.TabIndex = 4;
            // 
            // StartingOptionsGroupBox
            // 
            this.StartingOptionsGroupBox.Controls.Add(this.IterationLabel);
            this.StartingOptionsGroupBox.Controls.Add(this.IterationDescLabel);
            this.StartingOptionsGroupBox.Controls.Add(this.StopClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.StartClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsTextBox);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsLabel);
            this.StartingOptionsGroupBox.Location = new System.Drawing.Point(12, 201);
            this.StartingOptionsGroupBox.Name = "StartingOptionsGroupBox";
            this.StartingOptionsGroupBox.Size = new System.Drawing.Size(267, 177);
            this.StartingOptionsGroupBox.TabIndex = 2;
            this.StartingOptionsGroupBox.TabStop = false;
            this.StartingOptionsGroupBox.Text = "Starting Options";
            // 
            // IterationLabel
            // 
            this.IterationLabel.AutoSize = true;
            this.IterationLabel.Location = new System.Drawing.Point(129, 150);
            this.IterationLabel.Name = "IterationLabel";
            this.IterationLabel.Size = new System.Drawing.Size(0, 13);
            this.IterationLabel.TabIndex = 5;
            // 
            // IterationDescLabel
            // 
            this.IterationDescLabel.AutoSize = true;
            this.IterationDescLabel.Location = new System.Drawing.Point(6, 150);
            this.IterationDescLabel.Name = "IterationDescLabel";
            this.IterationDescLabel.Size = new System.Drawing.Size(117, 13);
            this.IterationDescLabel.TabIndex = 4;
            this.IterationDescLabel.Text = "Currently on Iteration #:";
            // 
            // StopClickingButton
            // 
            this.StopClickingButton.Location = new System.Drawing.Point(6, 99);
            this.StopClickingButton.Name = "StopClickingButton";
            this.StopClickingButton.Size = new System.Drawing.Size(255, 37);
            this.StopClickingButton.TabIndex = 3;
            this.StopClickingButton.Text = "Stop Clicking (Shift + F4)";
            this.StopClickingButton.UseVisualStyleBackColor = true;
            this.StopClickingButton.Click += new System.EventHandler(this.StopClickingButton_Click);
            // 
            // StartClickingButton
            // 
            this.StartClickingButton.Location = new System.Drawing.Point(6, 56);
            this.StartClickingButton.Name = "StartClickingButton";
            this.StartClickingButton.Size = new System.Drawing.Size(255, 37);
            this.StartClickingButton.TabIndex = 2;
            this.StartClickingButton.Text = "Start Clicking Queued Positions (Shift + F3)";
            this.StartClickingButton.UseVisualStyleBackColor = true;
            this.StartClickingButton.Click += new System.EventHandler(this.StartClickingButton_Click);
            // 
            // NumRepeatsTextBox
            // 
            this.NumRepeatsTextBox.Location = new System.Drawing.Point(120, 25);
            this.NumRepeatsTextBox.Name = "NumRepeatsTextBox";
            this.NumRepeatsTextBox.Size = new System.Drawing.Size(141, 20);
            this.NumRepeatsTextBox.TabIndex = 1;
            this.NumRepeatsTextBox.Text = "1";
            // 
            // NumRepeatsLabel
            // 
            this.NumRepeatsLabel.AutoSize = true;
            this.NumRepeatsLabel.Location = new System.Drawing.Point(6, 28);
            this.NumRepeatsLabel.Name = "NumRepeatsLabel";
            this.NumRepeatsLabel.Size = new System.Drawing.Size(108, 13);
            this.NumRepeatsLabel.TabIndex = 0;
            this.NumRepeatsLabel.Text = "Number of Repeats - ";
            // 
            // CurrentPositionTimer
            // 
            this.CurrentPositionTimer.Interval = 1;
            this.CurrentPositionTimer.Tick += new System.EventHandler(this.CurrentPositionTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(790, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 388);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StartingOptionsGroupBox);
            this.Controls.Add(this.CurrentPosGroupBox);
            this.Controls.Add(this.PositionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Skiller Agent";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.PositionsGroupBox.ResumeLayout(false);
            this.PositionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PositionsGridView)).EndInit();
            this.ListViewContextMenu.ResumeLayout(false);
            this.CurrentPosGroupBox.ResumeLayout(false);
            this.CurrentPosGroupBox.PerformLayout();
            this.StartingOptionsGroupBox.ResumeLayout(false);
            this.StartingOptionsGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PositionsGroupBox;
        private System.Windows.Forms.TextBox SleepTimeTextBox;
        private System.Windows.Forms.TextBox QueuedYPositionTextBox;
        private System.Windows.Forms.CheckBox RightClickCheckBox;
        private System.Windows.Forms.Label SleepTimeLabel;
        private System.Windows.Forms.Button AddPositionButton;
        private System.Windows.Forms.Label QueuedXPositionLabel;
        private System.Windows.Forms.Label QueuedYPositionLabel;
        private System.Windows.Forms.TextBox QueuedXPositionTextBox;
        private System.Windows.Forms.Label QueuedPositionsLabel;
        private System.Windows.Forms.GroupBox CurrentPosGroupBox;
        private System.Windows.Forms.Button CopyToAddButton;
        private System.Windows.Forms.TextBox CurrentYCoordTextBox;
        private System.Windows.Forms.Label XCoordLabel;
        private System.Windows.Forms.Label YCoordLabel;
        private System.Windows.Forms.TextBox CurrentXCoordTextBox;
        private System.Windows.Forms.GroupBox StartingOptionsGroupBox;
        private System.Windows.Forms.Button StopClickingButton;
        private System.Windows.Forms.Button StartClickingButton;
        private System.Windows.Forms.TextBox NumRepeatsTextBox;
        private System.Windows.Forms.Label NumRepeatsLabel;
        private System.Windows.Forms.Timer CurrentPositionTimer;
        private System.Windows.Forms.ContextMenuStrip ListViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveSelectedMenuItem;
        private System.Windows.Forms.DataGridView PositionsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn xColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftOrRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTSleep;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Label IterationLabel;
        private System.Windows.Forms.Label IterationDescLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

