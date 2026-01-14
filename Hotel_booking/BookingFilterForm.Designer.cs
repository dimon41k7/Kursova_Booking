namespace Hotel_booking
{
    partial class BookingFilterForm
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
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_AmountMin = new System.Windows.Forms.TextBox();
            this.textBox_AmountMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_pending = new System.Windows.Forms.CheckBox();
            this.checkBox_confirmed = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox_completed = new System.Windows.Forms.CheckBox();
            this.checkBox_canceled = new System.Windows.Forms.CheckBox();
            this.checkBox_paid = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(347, 108);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(59, 16);
            this.label.TabIndex = 0;
            this.label.Text = "Фільтри";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Дата створення: від";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "до";
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(169, 170);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 22);
            this.dateFrom.TabIndex = 3;
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(441, 169);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 22);
            this.dateTo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Остаточна ціна: від";
            // 
            // textBox_AmountMin
            // 
            this.textBox_AmountMin.Location = new System.Drawing.Point(169, 258);
            this.textBox_AmountMin.Name = "textBox_AmountMin";
            this.textBox_AmountMin.Size = new System.Drawing.Size(200, 22);
            this.textBox_AmountMin.TabIndex = 6;
            // 
            // textBox_AmountMax
            // 
            this.textBox_AmountMax.Location = new System.Drawing.Point(441, 252);
            this.textBox_AmountMax.Name = "textBox_AmountMax";
            this.textBox_AmountMax.Size = new System.Drawing.Size(200, 22);
            this.textBox_AmountMax.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "до";
            // 
            // checkBox_pending
            // 
            this.checkBox_pending.AutoSize = true;
            this.checkBox_pending.Location = new System.Drawing.Point(364, 331);
            this.checkBox_pending.Name = "checkBox_pending";
            this.checkBox_pending.Size = new System.Drawing.Size(73, 20);
            this.checkBox_pending.TabIndex = 9;
            this.checkBox_pending.Text = "Очікує";
            this.checkBox_pending.UseVisualStyleBackColor = true;
            // 
            // checkBox_confirmed
            // 
            this.checkBox_confirmed.AutoSize = true;
            this.checkBox_confirmed.Location = new System.Drawing.Point(364, 373);
            this.checkBox_confirmed.Name = "checkBox_confirmed";
            this.checkBox_confirmed.Size = new System.Drawing.Size(122, 20);
            this.checkBox_confirmed.TabIndex = 10;
            this.checkBox_confirmed.Text = "Підтверджено";
            this.checkBox_confirmed.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Статус;";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(187, 572);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(164, 38);
            this.button_ok.TabIndex = 12;
            this.button_ok.Text = "Зберегти";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(395, 572);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(164, 38);
            this.button_cancel.TabIndex = 13;
            this.button_cancel.Text = "Відмінити";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox_completed
            // 
            this.checkBox_completed.AutoSize = true;
            this.checkBox_completed.Location = new System.Drawing.Point(364, 510);
            this.checkBox_completed.Name = "checkBox_completed";
            this.checkBox_completed.Size = new System.Drawing.Size(103, 20);
            this.checkBox_completed.TabIndex = 14;
            this.checkBox_completed.Text = "Завершено";
            this.checkBox_completed.UseVisualStyleBackColor = true;
            // 
            // checkBox_canceled
            // 
            this.checkBox_canceled.AutoSize = true;
            this.checkBox_canceled.Location = new System.Drawing.Point(364, 465);
            this.checkBox_canceled.Name = "checkBox_canceled";
            this.checkBox_canceled.Size = new System.Drawing.Size(100, 20);
            this.checkBox_canceled.TabIndex = 15;
            this.checkBox_canceled.Text = "Скасовано";
            this.checkBox_canceled.UseVisualStyleBackColor = true;
            // 
            // checkBox_paid
            // 
            this.checkBox_paid.AutoSize = true;
            this.checkBox_paid.Location = new System.Drawing.Point(364, 422);
            this.checkBox_paid.Name = "checkBox_paid";
            this.checkBox_paid.Size = new System.Drawing.Size(95, 20);
            this.checkBox_paid.TabIndex = 16;
            this.checkBox_paid.Text = "Оплачено";
            this.checkBox_paid.UseVisualStyleBackColor = true;
            // 
            // BookingFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.checkBox_paid);
            this.Controls.Add(this.checkBox_canceled);
            this.Controls.Add(this.checkBox_completed);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_confirmed);
            this.Controls.Add(this.checkBox_pending);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_AmountMax);
            this.Controls.Add(this.textBox_AmountMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Name = "BookingFilterForm";
            this.Text = "Форма фільтрації бронювань";
            this.Load += new System.EventHandler(this.BookingFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_AmountMin;
        private System.Windows.Forms.TextBox textBox_AmountMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_pending;
        private System.Windows.Forms.CheckBox checkBox_confirmed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox_completed;
        private System.Windows.Forms.CheckBox checkBox_canceled;
        private System.Windows.Forms.CheckBox checkBox_paid;
    }
}