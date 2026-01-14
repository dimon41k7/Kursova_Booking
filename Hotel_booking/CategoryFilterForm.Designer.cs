namespace Hotel_booking
{
    partial class CategoryFilterForm
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
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_CapacityMax = new System.Windows.Forms.TextBox();
            this.textBox_CapacityMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.textBox_PriceMin = new System.Windows.Forms.TextBox();
            this.textBox_PriceMax = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(407, 397);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(164, 38);
            this.button_cancel.TabIndex = 27;
            this.button_cancel.Text = "Відмінити";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(199, 397);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(164, 38);
            this.button_ok.TabIndex = 26;
            this.button_ok.Text = "Зберегти";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "до";
            // 
            // textBox_CapacityMax
            // 
            this.textBox_CapacityMax.Location = new System.Drawing.Point(445, 267);
            this.textBox_CapacityMax.Name = "textBox_CapacityMax";
            this.textBox_CapacityMax.Size = new System.Drawing.Size(200, 22);
            this.textBox_CapacityMax.TabIndex = 21;
            // 
            // textBox_CapacityMin
            // 
            this.textBox_CapacityMin.Location = new System.Drawing.Point(173, 273);
            this.textBox_CapacityMin.Name = "textBox_CapacityMin";
            this.textBox_CapacityMin.Size = new System.Drawing.Size(200, 22);
            this.textBox_CapacityMin.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Місткість: від";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "до";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ціна за день: від";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(351, 123);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(59, 16);
            this.label.TabIndex = 14;
            this.label.Text = "Фільтри";
            // 
            // textBox_PriceMin
            // 
            this.textBox_PriceMin.Location = new System.Drawing.Point(173, 187);
            this.textBox_PriceMin.Name = "textBox_PriceMin";
            this.textBox_PriceMin.Size = new System.Drawing.Size(200, 22);
            this.textBox_PriceMin.TabIndex = 28;
            // 
            // textBox_PriceMax
            // 
            this.textBox_PriceMax.Location = new System.Drawing.Point(445, 187);
            this.textBox_PriceMax.Name = "textBox_PriceMax";
            this.textBox_PriceMax.Size = new System.Drawing.Size(200, 22);
            this.textBox_PriceMax.TabIndex = 29;
            // 
            // CategoryFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.textBox_PriceMax);
            this.Controls.Add(this.textBox_PriceMin);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_CapacityMax);
            this.Controls.Add(this.textBox_CapacityMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Name = "CategoryFilterForm";
            this.Text = "Форма фільтрів категорії";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_CapacityMax;
        private System.Windows.Forms.TextBox textBox_CapacityMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox textBox_PriceMin;
        private System.Windows.Forms.TextBox textBox_PriceMax;
    }
}