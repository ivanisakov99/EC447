
namespace Lab6
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxOutlinePenC = new System.Windows.Forms.ListBox();
            this.listBoxFillC = new System.Windows.Forms.ListBox();
            this.listBoxPenWidth = new System.Windows.Forms.ListBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Outline/Pen Colour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "FIll Colour";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pen Width";
            // 
            // listBoxOutlinePenC
            // 
            this.listBoxOutlinePenC.FormattingEnabled = true;
            this.listBoxOutlinePenC.ItemHeight = 20;
            this.listBoxOutlinePenC.Items.AddRange(new object[] {
            "No Outline",
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.listBoxOutlinePenC.Location = new System.Drawing.Point(17, 32);
            this.listBoxOutlinePenC.Name = "listBoxOutlinePenC";
            this.listBoxOutlinePenC.Size = new System.Drawing.Size(120, 104);
            this.listBoxOutlinePenC.TabIndex = 3;
            // 
            // listBoxFillC
            // 
            this.listBoxFillC.FormattingEnabled = true;
            this.listBoxFillC.ItemHeight = 20;
            this.listBoxFillC.Items.AddRange(new object[] {
            "No Fill",
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.listBoxFillC.Location = new System.Drawing.Point(175, 32);
            this.listBoxFillC.Name = "listBoxFillC";
            this.listBoxFillC.Size = new System.Drawing.Size(120, 104);
            this.listBoxFillC.TabIndex = 4;
            // 
            // listBoxPenWidth
            // 
            this.listBoxPenWidth.FormattingEnabled = true;
            this.listBoxPenWidth.ItemHeight = 20;
            this.listBoxPenWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.listBoxPenWidth.Location = new System.Drawing.Point(327, 32);
            this.listBoxPenWidth.Name = "listBoxPenWidth";
            this.listBoxPenWidth.Size = new System.Drawing.Size(120, 204);
            this.listBoxPenWidth.TabIndex = 5;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(175, 261);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(112, 35);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(327, 261);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(112, 35);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 344);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.listBoxPenWidth);
            this.Controls.Add(this.listBoxFillC);
            this.Controls.Add(this.listBoxOutlinePenC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        public System.Windows.Forms.ListBox listBoxOutlinePenC;
        public System.Windows.Forms.ListBox listBoxFillC;
        public System.Windows.Forms.ListBox listBoxPenWidth;
    }
}