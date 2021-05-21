
namespace SkillerAgent
{
    partial class SettingsForm
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
            this.xVarTextBox = new System.Windows.Forms.TextBox();
            this.yVarTextBox = new System.Windows.Forms.TextBox();
            this.timeVarTextBox = new System.Windows.Forms.TextBox();
            this.xVarLabel = new System.Windows.Forms.Label();
            this.yVarLabel = new System.Windows.Forms.Label();
            this.timeVarLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // xVarTextBox
            // 
            this.xVarTextBox.Location = new System.Drawing.Point(96, 12);
            this.xVarTextBox.Name = "xVarTextBox";
            this.xVarTextBox.Size = new System.Drawing.Size(100, 20);
            this.xVarTextBox.TabIndex = 0;
            // 
            // yVarTextBox
            // 
            this.yVarTextBox.Location = new System.Drawing.Point(96, 45);
            this.yVarTextBox.Name = "yVarTextBox";
            this.yVarTextBox.Size = new System.Drawing.Size(100, 20);
            this.yVarTextBox.TabIndex = 1;
            // 
            // timeVarTextBox
            // 
            this.timeVarTextBox.Location = new System.Drawing.Point(96, 78);
            this.timeVarTextBox.Name = "timeVarTextBox";
            this.timeVarTextBox.Size = new System.Drawing.Size(100, 20);
            this.timeVarTextBox.TabIndex = 2;
            // 
            // xVarLabel
            // 
            this.xVarLabel.AutoSize = true;
            this.xVarLabel.Location = new System.Drawing.Point(14, 15);
            this.xVarLabel.Name = "xVarLabel";
            this.xVarLabel.Size = new System.Drawing.Size(62, 13);
            this.xVarLabel.TabIndex = 3;
            this.xVarLabel.Text = "X Variance:";
            // 
            // yVarLabel
            // 
            this.yVarLabel.AutoSize = true;
            this.yVarLabel.Location = new System.Drawing.Point(14, 48);
            this.yVarLabel.Name = "yVarLabel";
            this.yVarLabel.Size = new System.Drawing.Size(62, 13);
            this.yVarLabel.TabIndex = 4;
            this.yVarLabel.Text = "Y Variance:";
            // 
            // timeVarLabel
            // 
            this.timeVarLabel.AutoSize = true;
            this.timeVarLabel.Location = new System.Drawing.Point(14, 81);
            this.timeVarLabel.Name = "timeVarLabel";
            this.timeVarLabel.Size = new System.Drawing.Size(78, 13);
            this.timeVarLabel.TabIndex = 5;
            this.timeVarLabel.Text = "Time Variance:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(17, 113);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(179, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 149);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.timeVarLabel);
            this.Controls.Add(this.yVarLabel);
            this.Controls.Add(this.xVarLabel);
            this.Controls.Add(this.timeVarTextBox);
            this.Controls.Add(this.yVarTextBox);
            this.Controls.Add(this.xVarTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xVarTextBox;
        private System.Windows.Forms.TextBox yVarTextBox;
        private System.Windows.Forms.TextBox timeVarTextBox;
        private System.Windows.Forms.Label xVarLabel;
        private System.Windows.Forms.Label yVarLabel;
        private System.Windows.Forms.Label timeVarLabel;
        private System.Windows.Forms.Button saveButton;
    }
}