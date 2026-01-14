namespace Hotel_booking
{
    partial class PopularService
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
            this.listView_services = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView_services
            // 
            this.listView_services.FullRowSelect = true;
            this.listView_services.GridLines = true;
            this.listView_services.HideSelection = false;
            this.listView_services.Location = new System.Drawing.Point(12, 256);
            this.listView_services.MultiSelect = false;
            this.listView_services.Name = "listView_services";
            this.listView_services.Size = new System.Drawing.Size(639, 179);
            this.listView_services.TabIndex = 17;
            this.listView_services.UseCompatibleStateImageBehavior = false;
            // 
            // PopularService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 750);
            this.Controls.Add(this.listView_services);
            this.Controls.Add(this.button1);
            this.Name = "PopularService";
            this.Text = "Популярна послуга";
            this.Load += new System.EventHandler(this.PopularService_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView_services;
    }
}