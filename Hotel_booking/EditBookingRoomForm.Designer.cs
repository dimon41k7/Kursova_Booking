namespace Hotel_booking
{
    partial class EditBookingRoomForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_guests_count = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_check_out_date = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_check_in_date = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 37);
            this.button1.TabIndex = 22;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_guests_count
            // 
            this.textBox_guests_count.Location = new System.Drawing.Point(409, 234);
            this.textBox_guests_count.Name = "textBox_guests_count";
            this.textBox_guests_count.Size = new System.Drawing.Size(200, 22);
            this.textBox_guests_count.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(246, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Кількість гостей";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Дата виїзду";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Дата заїзду";
            // 
            // dateTimePicker_check_out_date
            // 
            this.dateTimePicker_check_out_date.Location = new System.Drawing.Point(409, 153);
            this.dateTimePicker_check_out_date.Name = "dateTimePicker_check_out_date";
            this.dateTimePicker_check_out_date.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_check_out_date.TabIndex = 17;
            // 
            // dateTimePicker_check_in_date
            // 
            this.dateTimePicker_check_in_date.Location = new System.Drawing.Point(409, 82);
            this.dateTimePicker_check_in_date.Name = "dateTimePicker_check_in_date";
            this.dateTimePicker_check_in_date.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_check_in_date.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(409, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 46);
            this.button2.TabIndex = 23;
            this.button2.Text = "Зберегти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditBookingRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_guests_count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_check_out_date);
            this.Controls.Add(this.dateTimePicker_check_in_date);
            this.Name = "EditBookingRoomForm";
            this.Text = "Форма редагування бронювання кімнати";
            this.Load += new System.EventHandler(this.EditBookingRoomForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_guests_count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_check_out_date;
        private System.Windows.Forms.DateTimePicker dateTimePicker_check_in_date;
        private System.Windows.Forms.Button button2;
    }
}