
namespace Lab4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.MyName = new System.Windows.Forms.Label();
            this.Start_Num_Label = new System.Windows.Forms.Label();
            this.Range_Label = new System.Windows.Forms.Label();
            this.Int_Warning = new System.Windows.Forms.Label();
            this.Start_Num = new System.Windows.Forms.TextBox();
            this.Select_Range = new System.Windows.Forms.TextBox();
            this.P_List = new System.Windows.Forms.ListBox();
            this.Generate_Btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Title.Location = new System.Drawing.Point(300, 70);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(613, 55);
            this.Title.TabIndex = 0;
            this.Title.Text = "Find Numeric Palindromes";
            // 
            // MyName
            // 
            this.MyName.AutoSize = true;
            this.MyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MyName.Location = new System.Drawing.Point(535, 158);
            this.MyName.Name = "MyName";
            this.MyName.Size = new System.Drawing.Size(175, 29);
            this.MyName.TabIndex = 1;
            this.MyName.Text = "by Ivan Isakov";
            // 
            // Start_Num_Label
            // 
            this.Start_Num_Label.AutoSize = true;
            this.Start_Num_Label.Location = new System.Drawing.Point(220, 292);
            this.Start_Num_Label.Name = "Start_Num_Label";
            this.Start_Num_Label.Size = new System.Drawing.Size(313, 20);
            this.Start_Num_Label.TabIndex = 2;
            this.Start_Num_Label.Text = "Enter a starting integer (1 - 1,000,000,000):";
            // 
            // Range_Label
            // 
            this.Range_Label.AutoSize = true;
            this.Range_Label.Location = new System.Drawing.Point(739, 292);
            this.Range_Label.Name = "Range_Label";
            this.Range_Label.Size = new System.Drawing.Size(159, 20);
            this.Range_Label.TabIndex = 3;
            this.Range_Label.Text = "Enter count (1 - 100):";
            // 
            // Int_Warning
            // 
            this.Int_Warning.AutoSize = true;
            this.Int_Warning.Location = new System.Drawing.Point(457, 614);
            this.Int_Warning.Name = "Int_Warning";
            this.Int_Warning.Size = new System.Drawing.Size(314, 20);
            this.Int_Warning.TabIndex = 4;
            this.Int_Warning.Text = "Please enter a positive integer within range.";
            this.Int_Warning.Visible = false;
            // 
            // Start_Num
            // 
            this.Start_Num.Location = new System.Drawing.Point(539, 289);
            this.Start_Num.Name = "Start_Num";
            this.Start_Num.Size = new System.Drawing.Size(142, 26);
            this.Start_Num.TabIndex = 5;
            // 
            // Select_Range
            // 
            this.Select_Range.Location = new System.Drawing.Point(904, 289);
            this.Select_Range.Name = "Select_Range";
            this.Select_Range.Size = new System.Drawing.Size(100, 26);
            this.Select_Range.TabIndex = 6;
            // 
            // P_List
            // 
            this.P_List.FormattingEnabled = true;
            this.P_List.ItemHeight = 20;
            this.P_List.Location = new System.Drawing.Point(527, 407);
            this.P_List.Name = "P_List";
            this.P_List.Size = new System.Drawing.Size(170, 204);
            this.P_List.TabIndex = 7;
            // 
            // Generate_Btn
            // 
            this.Generate_Btn.Location = new System.Drawing.Point(549, 353);
            this.Generate_Btn.Name = "Generate_Btn";
            this.Generate_Btn.Size = new System.Drawing.Size(123, 34);
            this.Generate_Btn.TabIndex = 8;
            this.Generate_Btn.Text = "Generate";
            this.Generate_Btn.UseVisualStyleBackColor = true;
            this.Generate_Btn.Click += new System.EventHandler(this.Generate_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.Generate_Btn);
            this.Controls.Add(this.P_List);
            this.Controls.Add(this.Select_Range);
            this.Controls.Add(this.Start_Num);
            this.Controls.Add(this.Int_Warning);
            this.Controls.Add(this.Range_Label);
            this.Controls.Add(this.Start_Num_Label);
            this.Controls.Add(this.MyName);
            this.Controls.Add(this.Title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label MyName;
        private System.Windows.Forms.Label Start_Num_Label;
        private System.Windows.Forms.Label Range_Label;
        private System.Windows.Forms.Label Int_Warning;
        private System.Windows.Forms.TextBox Start_Num;
        private System.Windows.Forms.TextBox Select_Range;
        private System.Windows.Forms.ListBox P_List;
        private System.Windows.Forms.Button Generate_Btn;
    }
}

