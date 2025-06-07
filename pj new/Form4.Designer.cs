namespace pj_new
{
    partial class management
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(management));
            this.stock = new System.Windows.Forms.Button();
            this.income = new System.Windows.Forms.Button();
            this.back_L = new System.Windows.Forms.PictureBox();
            this.customer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).BeginInit();
            this.SuspendLayout();
            // 
            // stock
            // 
            this.stock.BackgroundImage = global::pj_new.Properties.Resources.ปุ่มจัดการสินค้า;
            this.stock.Location = new System.Drawing.Point(58, 191);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(155, 135);
            this.stock.TabIndex = 0;
            this.stock.UseVisualStyleBackColor = true;
            this.stock.Click += new System.EventHandler(this.stock_Click);
            // 
            // income
            // 
            this.income.BackgroundImage = global::pj_new.Properties.Resources.รายได้;
            this.income.Location = new System.Drawing.Point(551, 191);
            this.income.Name = "income";
            this.income.Size = new System.Drawing.Size(155, 135);
            this.income.TabIndex = 2;
            this.income.UseVisualStyleBackColor = true;
            this.income.Click += new System.EventHandler(this.income_Click);
            // 
            // back_L
            // 
            this.back_L.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_L.BackgroundImage")));
            this.back_L.Image = ((System.Drawing.Image)(resources.GetObject("back_L.Image")));
            this.back_L.Location = new System.Drawing.Point(12, 398);
            this.back_L.Name = "back_L";
            this.back_L.Size = new System.Drawing.Size(41, 43);
            this.back_L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back_L.TabIndex = 31;
            this.back_L.TabStop = false;
            this.back_L.Click += new System.EventHandler(this.back_L_Click);
            // 
            // customer
            // 
            this.customer.BackgroundImage = global::pj_new.Properties.Resources.Chonburi;
            this.customer.Location = new System.Drawing.Point(306, 191);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(155, 135);
            this.customer.TabIndex = 32;
            this.customer.UseVisualStyleBackColor = true;
            this.customer.Click += new System.EventHandler(this.customer_Click);
            // 
            // management
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::pj_new.Properties.Resources.การจัดการแอดมิน;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.back_L);
            this.Controls.Add(this.income);
            this.Controls.Add(this.stock);
            this.Name = "management";
            this.Load += new System.EventHandler(this.management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button stock;
        private System.Windows.Forms.Button income;
        private System.Windows.Forms.PictureBox back_L;
        private System.Windows.Forms.Button customer;
    }
}