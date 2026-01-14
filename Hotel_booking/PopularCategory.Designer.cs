namespace Hotel_booking
{
    partial class PopularCategory
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
            this.labelnobooking = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_category = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelnobooking
            // 
            this.labelnobooking.AutoSize = true;
            this.labelnobooking.Location = new System.Drawing.Point(396, 231);
            this.labelnobooking.Name = "labelnobooking";
            this.labelnobooking.Size = new System.Drawing.Size(0, 16);
            this.labelnobooking.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(381, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Найпопулярніша категорія номерів";
            // 
            // listView_category
            // 
            this.listView_category.FullRowSelect = true;
            this.listView_category.GridLines = true;
            this.listView_category.HideSelection = false;
            this.listView_category.Location = new System.Drawing.Point(177, 162);
            this.listView_category.MultiSelect = false;
            this.listView_category.Name = "listView_category";
            this.listView_category.Size = new System.Drawing.Size(639, 378);
            this.listView_category.TabIndex = 3;
            this.listView_category.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PopularCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 953);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelnobooking);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView_category);
            this.Name = "PopularCategory";
            this.Text = "Найпопулярніша категорія";
            this.Load += new System.EventHandler(this.PopularCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelnobooking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_category;
        private System.Windows.Forms.Button button1;
    }
}