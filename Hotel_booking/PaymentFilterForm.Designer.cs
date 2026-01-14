namespace Hotel_booking
{
    partial class PaymentFilterForm
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
            this.checkBox_card = new System.Windows.Forms.CheckBox();
            this.checkBox_online = new System.Windows.Forms.CheckBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_addpay = new System.Windows.Forms.CheckBox();
            this.checkBox_prepay = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_AmountMax = new System.Windows.Forms.TextBox();
            this.textBox_AmountMin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox_card
            // 
            this.checkBox_card.AutoSize = true;
            this.checkBox_card.Location = new System.Drawing.Point(406, 421);
            this.checkBox_card.Name = "checkBox_card";
            this.checkBox_card.Size = new System.Drawing.Size(149, 20);
            this.checkBox_card.TabIndex = 32;
            this.checkBox_card.Text = "Банківська картка";
            this.checkBox_card.UseVisualStyleBackColor = true;
            // 
            // checkBox_online
            // 
            this.checkBox_online.AutoSize = true;
            this.checkBox_online.Location = new System.Drawing.Point(406, 466);
            this.checkBox_online.Name = "checkBox_online";
            this.checkBox_online.Size = new System.Drawing.Size(125, 20);
            this.checkBox_online.TabIndex = 31;
            this.checkBox_online.Text = "Онлайн платіж";
            this.checkBox_online.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(437, 528);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(164, 38);
            this.button_cancel.TabIndex = 30;
            this.button_cancel.Text = "Відмінити";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(229, 528);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(164, 38);
            this.button_ok.TabIndex = 29;
            this.button_ok.Text = "Зберегти";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Тип оплати";
            // 
            // checkBox_addpay
            // 
            this.checkBox_addpay.AutoSize = true;
            this.checkBox_addpay.Location = new System.Drawing.Point(406, 329);
            this.checkBox_addpay.Name = "checkBox_addpay";
            this.checkBox_addpay.Size = new System.Drawing.Size(85, 20);
            this.checkBox_addpay.TabIndex = 27;
            this.checkBox_addpay.Text = "Доплата";
            this.checkBox_addpay.UseVisualStyleBackColor = true;
            // 
            // checkBox_prepay
            // 
            this.checkBox_prepay.AutoSize = true;
            this.checkBox_prepay.Location = new System.Drawing.Point(406, 287);
            this.checkBox_prepay.Name = "checkBox_prepay";
            this.checkBox_prepay.Size = new System.Drawing.Size(110, 20);
            this.checkBox_prepay.TabIndex = 26;
            this.checkBox_prepay.Text = "Передплата";
            this.checkBox_prepay.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "до";
            // 
            // textBox_AmountMax
            // 
            this.textBox_AmountMax.Location = new System.Drawing.Point(483, 208);
            this.textBox_AmountMax.Name = "textBox_AmountMax";
            this.textBox_AmountMax.Size = new System.Drawing.Size(200, 22);
            this.textBox_AmountMax.TabIndex = 24;
            // 
            // textBox_AmountMin
            // 
            this.textBox_AmountMin.Location = new System.Drawing.Point(211, 214);
            this.textBox_AmountMin.Name = "textBox_AmountMin";
            this.textBox_AmountMin.Size = new System.Drawing.Size(200, 22);
            this.textBox_AmountMin.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Сума оплати: від";
            // 
            // dateTo
            // 
            this.dateTo.Location = new System.Drawing.Point(483, 125);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(200, 22);
            this.dateTo.TabIndex = 21;
            // 
            // dateFrom
            // 
            this.dateFrom.Location = new System.Drawing.Point(211, 126);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(200, 22);
            this.dateFrom.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "до";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Дата оплати: від";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(389, 64);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(59, 16);
            this.label.TabIndex = 17;
            this.label.Text = "Фільтри";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(298, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Спосіб оплати";
            // 
            // PaymentFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 653);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_card);
            this.Controls.Add(this.checkBox_online);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_addpay);
            this.Controls.Add(this.checkBox_prepay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_AmountMax);
            this.Controls.Add(this.textBox_AmountMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Name = "PaymentFilterForm";
            this.Text = "Форма фільтрів оплат";
            this.Load += new System.EventHandler(this.PaymentFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_card;
        private System.Windows.Forms.CheckBox checkBox_online;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_addpay;
        private System.Windows.Forms.CheckBox checkBox_prepay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_AmountMax;
        private System.Windows.Forms.TextBox textBox_AmountMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label6;
    }
}