namespace Hotel_booking
{
    partial class FinishBookingCreateForm
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
            this.rbOtherClient = new System.Windows.Forms.RadioButton();
            this.rbSelf = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_customer = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label_total_amount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rbOtherClient
            // 
            this.rbOtherClient.AutoSize = true;
            this.rbOtherClient.Location = new System.Drawing.Point(403, 475);
            this.rbOtherClient.Name = "rbOtherClient";
            this.rbOtherClient.Size = new System.Drawing.Size(226, 20);
            this.rbOtherClient.TabIndex = 67;
            this.rbOtherClient.TabStop = true;
            this.rbOtherClient.Text = "Бронювання на іншого клієнта";
            this.rbOtherClient.UseVisualStyleBackColor = true;
            this.rbOtherClient.CheckedChanged += new System.EventHandler(this.rbOtherClient_CheckedChanged);
            // 
            // rbSelf
            // 
            this.rbSelf.AutoSize = true;
            this.rbSelf.Location = new System.Drawing.Point(403, 437);
            this.rbSelf.Name = "rbSelf";
            this.rbSelf.Size = new System.Drawing.Size(163, 20);
            this.rbSelf.TabIndex = 66;
            this.rbSelf.TabStop = true;
            this.rbSelf.Text = "Бронювання на себе";
            this.rbSelf.UseVisualStyleBackColor = true;
            this.rbSelf.CheckedChanged += new System.EventHandler(this.rbSelf_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(204, 210);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(627, 111);
            this.textBox1.TabIndex = 65;
            // 
            // label_customer
            // 
            this.label_customer.AutoSize = true;
            this.label_customer.Location = new System.Drawing.Point(399, 111);
            this.label_customer.Name = "label_customer";
            this.label_customer.Size = new System.Drawing.Size(0, 16);
            this.label_customer.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(680, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 62;
            // 
            // label_total_amount
            // 
            this.label_total_amount.AutoSize = true;
            this.label_total_amount.Location = new System.Drawing.Point(550, 126);
            this.label_total_amount.Name = "label_total_amount";
            this.label_total_amount.Size = new System.Drawing.Size(44, 16);
            this.label_total_amount.TabIndex = 61;
            this.label_total_amount.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Примітки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 59;
            this.label3.Text = "Остаточна сума";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 720);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 62);
            this.button1.TabIndex = 75;
            this.button1.Text = "Створити бронювання";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 43);
            this.button2.TabIndex = 76;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxClient
            // 
            this.textBoxClient.Location = new System.Drawing.Point(419, 530);
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.Size = new System.Drawing.Size(199, 22);
            this.textBoxClient.TabIndex = 77;
            this.textBoxClient.TextChanged += new System.EventHandler(this.textBoxClient_TextChanged);
            this.textBoxClient.Enter += new System.EventHandler(this.textBoxClient_Enter);
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.ItemHeight = 16;
            this.listBoxClients.Location = new System.Drawing.Point(282, 573);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(463, 132);
            this.listBoxClients.TabIndex = 78;
            this.listBoxClients.DoubleClick += new System.EventHandler(this.listBoxClients_DoubleClick);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(432, 865);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(151, 42);
            this.button_cancel.TabIndex = 107;
            this.button_cancel.Text = "Скасувати бронювання";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(365, 806);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(279, 20);
            this.checkBox1.TabIndex = 108;
            this.checkBox1.Text = "Отримати підтвердження бронювання";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FinishBookingCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.textBoxClient);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbOtherClient);
            this.Controls.Add(this.rbSelf);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_customer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_total_amount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "FinishBookingCreateForm";
            this.Text = "Форма завершення бронювання";
            this.Load += new System.EventHandler(this.FinishBookingCreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbOtherClient;
        private System.Windows.Forms.RadioButton rbSelf;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_customer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label_total_amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxClient;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}