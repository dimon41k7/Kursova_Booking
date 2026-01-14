namespace Hotel_booking
{
    partial class MyPaymentsForm
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
            this.button_filtr_cancel = new System.Windows.Forms.Button();
            this.button_filter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelnobooking = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_mypayments = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_filtr_cancel
            // 
            this.button_filtr_cancel.Location = new System.Drawing.Point(263, 627);
            this.button_filtr_cancel.Name = "button_filtr_cancel";
            this.button_filtr_cancel.Size = new System.Drawing.Size(151, 42);
            this.button_filtr_cancel.TabIndex = 23;
            this.button_filtr_cancel.Text = "Зняти фільтр";
            this.button_filtr_cancel.UseVisualStyleBackColor = true;
            this.button_filtr_cancel.Click += new System.EventHandler(this.button_filtr_cancel_Click);
            // 
            // button_filter
            // 
            this.button_filter.Location = new System.Drawing.Point(59, 627);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(151, 42);
            this.button_filter.TabIndex = 22;
            this.button_filter.Text = "Накласти фільтр";
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 42);
            this.button1.TabIndex = 21;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelnobooking
            // 
            this.labelnobooking.AutoSize = true;
            this.labelnobooking.Location = new System.Drawing.Point(390, 296);
            this.labelnobooking.Name = "labelnobooking";
            this.labelnobooking.Size = new System.Drawing.Size(0, 16);
            this.labelnobooking.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Мої оплати";
            // 
            // listView_mypayments
            // 
            this.listView_mypayments.FullRowSelect = true;
            this.listView_mypayments.GridLines = true;
            this.listView_mypayments.HideSelection = false;
            this.listView_mypayments.Location = new System.Drawing.Point(59, 216);
            this.listView_mypayments.MultiSelect = false;
            this.listView_mypayments.Name = "listView_mypayments";
            this.listView_mypayments.Size = new System.Drawing.Size(859, 378);
            this.listView_mypayments.TabIndex = 18;
            this.listView_mypayments.UseCompatibleStateImageBehavior = false;
            this.listView_mypayments.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_mypayments_ColumnClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(767, 627);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 42);
            this.button2.TabIndex = 24;
            this.button2.Text = "Отримати квитанцію";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MyPaymentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_filtr_cancel);
            this.Controls.Add(this.button_filter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelnobooking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_mypayments);
            this.Name = "MyPaymentsForm";
            this.Text = "Мої оплати";
            this.Load += new System.EventHandler(this.MyPaymentsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_filtr_cancel;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelnobooking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_mypayments;
        private System.Windows.Forms.Button button2;
    }
}