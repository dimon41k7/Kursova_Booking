namespace Hotel_booking
{
    partial class EditBookingForm
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
            this.rbSelf = new System.Windows.Forms.RadioButton();
            this.rbOtherClient = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rbSelf
            // 
            this.rbSelf.AutoSize = true;
            this.rbSelf.Location = new System.Drawing.Point(383, 327);
            this.rbSelf.Name = "rbSelf";
            this.rbSelf.Size = new System.Drawing.Size(163, 20);
            this.rbSelf.TabIndex = 6;
            this.rbSelf.TabStop = true;
            this.rbSelf.Text = "Бронювання на себе";
            this.rbSelf.UseVisualStyleBackColor = true;
            this.rbSelf.CheckedChanged += new System.EventHandler(this.rbSelf_CheckedChanged);
            // 
            // rbOtherClient
            // 
            this.rbOtherClient.AutoSize = true;
            this.rbOtherClient.Location = new System.Drawing.Point(383, 365);
            this.rbOtherClient.Name = "rbOtherClient";
            this.rbOtherClient.Size = new System.Drawing.Size(226, 20);
            this.rbOtherClient.TabIndex = 7;
            this.rbOtherClient.TabStop = true;
            this.rbOtherClient.Text = "Бронювання на іншого клієнта";
            this.rbOtherClient.UseVisualStyleBackColor = true;
            this.rbOtherClient.CheckedChanged += new System.EventHandler(this.rbOtherClient_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 37);
            this.button1.TabIndex = 15;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(383, 631);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 46);
            this.button2.TabIndex = 16;
            this.button2.Text = "Зберегти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(149, 136);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(627, 111);
            this.textBox1.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Примітки";
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.ItemHeight = 16;
            this.listBoxClients.Location = new System.Drawing.Point(247, 471);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(463, 132);
            this.listBoxClients.TabIndex = 80;
            this.listBoxClients.DoubleClick += new System.EventHandler(this.listBoxClients_DoubleClick);
            // 
            // textBoxClient
            // 
            this.textBoxClient.Location = new System.Drawing.Point(384, 428);
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.Size = new System.Drawing.Size(199, 22);
            this.textBoxClient.TabIndex = 79;
            this.textBoxClient.TextChanged += new System.EventHandler(this.textBoxClient_TextChanged);
            this.textBoxClient.Enter += new System.EventHandler(this.textBoxClient_Enter);
            // 
            // EditBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.textBoxClient);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbOtherClient);
            this.Controls.Add(this.rbSelf);
            this.Name = "EditBookingForm";
            this.Text = "Форма редагування бронювання";
            this.Load += new System.EventHandler(this.EditBookingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbSelf;
        private System.Windows.Forms.RadioButton rbOtherClient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.TextBox textBoxClient;
    }
}