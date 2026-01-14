namespace Hotel_booking
{
    partial class MyBookingsForm
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
            this.listView_mybookings = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelnobooking = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hotel_bookingDataSet = new Hotel_booking.hotel_bookingDataSet();
            this.clientTableAdapter = new Hotel_booking.hotel_bookingDataSetTableAdapters.ClientTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button_filtr_cancel = new System.Windows.Forms.Button();
            this.button_filter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotel_bookingDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // listView_mybookings
            // 
            this.listView_mybookings.FullRowSelect = true;
            this.listView_mybookings.GridLines = true;
            this.listView_mybookings.HideSelection = false;
            this.listView_mybookings.Location = new System.Drawing.Point(179, 220);
            this.listView_mybookings.MultiSelect = false;
            this.listView_mybookings.Name = "listView_mybookings";
            this.listView_mybookings.Size = new System.Drawing.Size(639, 378);
            this.listView_mybookings.TabIndex = 0;
            this.listView_mybookings.UseCompatibleStateImageBehavior = false;
            this.listView_mybookings.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_mybookings_ColumnClick);
            this.listView_mybookings.DoubleClick += new System.EventHandler(this.listView_mybookings_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Мої бронювання";
            // 
            // labelnobooking
            // 
            this.labelnobooking.AutoSize = true;
            this.labelnobooking.Location = new System.Drawing.Point(398, 289);
            this.labelnobooking.Name = "labelnobooking";
            this.labelnobooking.Size = new System.Drawing.Size(0, 16);
            this.labelnobooking.TabIndex = 2;
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
            this.button1.Size = new System.Drawing.Size(146, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_filtr_cancel
            // 
            this.button_filtr_cancel.Location = new System.Drawing.Point(570, 633);
            this.button_filtr_cancel.Name = "button_filtr_cancel";
            this.button_filtr_cancel.Size = new System.Drawing.Size(151, 42);
            this.button_filtr_cancel.TabIndex = 17;
            this.button_filtr_cancel.Text = "Зняти фільтр";
            this.button_filtr_cancel.UseVisualStyleBackColor = true;
            this.button_filtr_cancel.Click += new System.EventHandler(this.button_filtr_cancel_Click);
            // 
            // button_filter
            // 
            this.button_filter.Location = new System.Drawing.Point(299, 633);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(151, 42);
            this.button_filter.TabIndex = 16;
            this.button_filter.Text = "Накласти фільтр";
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // MyBookingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.button_filtr_cancel);
            this.Controls.Add(this.button_filter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelnobooking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_mybookings);
            this.Name = "MyBookingsForm";
            this.Text = "Мої бронювання";
            this.Load += new System.EventHandler(this.MyBookingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotel_bookingDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_mybookings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private hotel_bookingDataSet hotel_bookingDataSet;
        private hotel_bookingDataSetTableAdapters.ClientTableAdapter clientTableAdapter;
        private System.Windows.Forms.Label labelnobooking;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_filtr_cancel;
        private System.Windows.Forms.Button button_filter;
    }
}