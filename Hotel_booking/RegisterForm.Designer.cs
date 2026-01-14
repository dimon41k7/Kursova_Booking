namespace Hotel_booking
{
    partial class RegisterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_passf = new System.Windows.Forms.TextBox();
            this.textBox_passs = new System.Windows.Forms.TextBox();
            this.button_next = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hotel_bookingDataSet = new Hotel_booking.hotel_bookingDataSet();
            this.clientTableAdapter = new Hotel_booking.hotel_bookingDataSetTableAdapters.ClientTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotel_bookingDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Реєстрація";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пошта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Підтвердіть пароль";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(426, 248);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(147, 22);
            this.textBox_email.TabIndex = 7;
            // 
            // textBox_passf
            // 
            this.textBox_passf.Location = new System.Drawing.Point(426, 311);
            this.textBox_passf.Name = "textBox_passf";
            this.textBox_passf.Size = new System.Drawing.Size(147, 22);
            this.textBox_passf.TabIndex = 8;
            // 
            // textBox_passs
            // 
            this.textBox_passs.Location = new System.Drawing.Point(426, 369);
            this.textBox_passs.Name = "textBox_passs";
            this.textBox_passs.Size = new System.Drawing.Size(147, 22);
            this.textBox_passs.TabIndex = 9;
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(403, 475);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(180, 43);
            this.button_next.TabIndex = 10;
            this.button_next.Text = "Далі";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Client";
            this.bindingSource1.DataSource = this.hotel_bookingDataSet;
            // 
            // hotel_bookingDataSet
            // 
            this.hotel_bookingDataSet.DataSetName = "hotel_bookingDataSet";
            this.hotel_bookingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 45);
            this.button1.TabIndex = 11;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.textBox_passs);
            this.Controls.Add(this.textBox_passf);
            this.Controls.Add(this.textBox_email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "Форма реєстрації";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotel_bookingDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_passf;
        private System.Windows.Forms.TextBox textBox_passs;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.BindingSource bindingSource1;
        private hotel_bookingDataSet hotel_bookingDataSet;
        private hotel_bookingDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}