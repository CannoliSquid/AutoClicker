
namespace SkillerAgent
{
    partial class HelpForm
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
            this.topicListBox = new System.Windows.Forms.ListBox();
            this.contentTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // topicListBox
            // 
            this.topicListBox.FormattingEnabled = true;
            this.topicListBox.Location = new System.Drawing.Point(13, 13);
            this.topicListBox.Name = "topicListBox";
            this.topicListBox.ScrollAlwaysVisible = true;
            this.topicListBox.Size = new System.Drawing.Size(120, 238);
            this.topicListBox.TabIndex = 0;
            this.topicListBox.SelectedIndexChanged += new System.EventHandler(this.topicListBox_SelectedIndexChanged);
            // 
            // contentTextBox
            // 
            this.contentTextBox.Location = new System.Drawing.Point(139, 13);
            this.contentTextBox.Multiline = true;
            this.contentTextBox.Name = "contentTextBox";
            this.contentTextBox.ReadOnly = true;
            this.contentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.contentTextBox.Size = new System.Drawing.Size(421, 238);
            this.contentTextBox.TabIndex = 1;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 264);
            this.Controls.Add(this.contentTextBox);
            this.Controls.Add(this.topicListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.HelpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox topicListBox;
        private System.Windows.Forms.TextBox contentTextBox;
    }
}