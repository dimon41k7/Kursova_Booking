namespace Hotel_booking
{
    partial class ListBookings
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
            this.listView_bookings = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTime_check_out = new System.Windows.Forms.DateTimePicker();
            this.dateTime_check_in = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_no_booking = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_bookings
            // 
            this.listView_bookings.FullRowSelect = true;
            this.listView_bookings.GridLines = true;
            this.listView_bookings.HideSelection = false;
            this.listView_bookings.Location = new System.Drawing.Point(75, 250);
            this.listView_bookings.MultiSelect = false;
            this.listView_bookings.Name = "listView_bookings";
            this.listView_bookings.Size = new System.Drawing.Size(818, 325);
            this.listView_bookings.TabIndex = 2;
            this.listView_bookings.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вільні номери за період";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 57);
            this.button1.TabIndex = 14;
            this.button1.Text = "Знайти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTime_check_out
            // 
            this.dateTime_check_out.Location = new System.Drawing.Point(557, 111);
            this.dateTime_check_out.Name = "dateTime_check_out";
            this.dateTime_check_out.Size = new System.Drawing.Size(200, 22);
            this.dateTime_check_out.TabIndex = 12;
            // 
            // dateTime_check_in
            // 
            this.dateTime_check_in.Location = new System.Drawing.Point(260, 112);
            this.dateTime_check_in.Name = "dateTime_check_in";
            this.dateTime_check_in.Size = new System.Drawing.Size(200, 22);
            this.dateTime_check_in.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Дата виїзду";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Дата заїзду";
            // 
            // label_no_booking
            // 
            this.label_no_booking.AutoSize = true;
            this.label_no_booking.Location = new System.Drawing.Point(365, 377);
            this.label_no_booking.Name = "label_no_booking";
            this.label_no_booking.Size = new System.Drawing.Size(0, 16);
            this.label_no_booking.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Ок";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ListBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 614);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_no_booking);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTime_check_out);
            this.Controls.Add(this.dateTime_check_in);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_bookings);
            this.Name = "ListBookings";
            this.Text = "Список бронювань за період";
            this.Load += new System.EventHandler(this.ListBookings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_bookings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTime_check_out;
        private System.Windows.Forms.DateTimePicker dateTime_check_in;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_no_booking;
        private System.Windows.Forms.Button button2;
    }
}