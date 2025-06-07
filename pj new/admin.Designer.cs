namespace pj_new
{
    partial class admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin));
            this.datastock = new System.Windows.Forms.DataGridView();
            this.name_bs = new System.Windows.Forms.Label();
            this.price_bs = new System.Windows.Forms.Label();
            this.gb_admin = new System.Windows.Forms.GroupBox();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_ad = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delet = new System.Windows.Forms.Button();
            this.back_admin = new System.Windows.Forms.PictureBox();
            this.ch_pic = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datastock)).BeginInit();
            this.gb_admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back_admin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // datastock
            // 
            this.datastock.AllowUserToAddRows = false;
            this.datastock.AllowUserToDeleteRows = false;
            this.datastock.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datastock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datastock.Location = new System.Drawing.Point(548, 99);
            this.datastock.Name = "datastock";
            this.datastock.ReadOnly = true;
            this.datastock.RowHeadersWidth = 51;
            this.datastock.RowTemplate.Height = 24;
            this.datastock.Size = new System.Drawing.Size(431, 508);
            this.datastock.TabIndex = 0;
            this.datastock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datastock_CellClick);
            this.datastock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datastock_CellContentClick);
            // 
            // name_bs
            // 
            this.name_bs.AutoSize = true;
            this.name_bs.Font = new System.Drawing.Font("Prompt", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_bs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.name_bs.Location = new System.Drawing.Point(15, 41);
            this.name_bs.Name = "name_bs";
            this.name_bs.Size = new System.Drawing.Size(116, 46);
            this.name_bs.TabIndex = 1;
            this.name_bs.Text = "รายการ";
            this.name_bs.Click += new System.EventHandler(this.name_bs_Click);
            // 
            // price_bs
            // 
            this.price_bs.AutoSize = true;
            this.price_bs.Font = new System.Drawing.Font("Prompt", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_bs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.price_bs.Location = new System.Drawing.Point(15, 110);
            this.price_bs.Name = "price_bs";
            this.price_bs.Size = new System.Drawing.Size(80, 46);
            this.price_bs.TabIndex = 2;
            this.price_bs.Text = "ราคา";
            this.price_bs.Click += new System.EventHandler(this.price_bs_Click);
            // 
            // gb_admin
            // 
            this.gb_admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(204)))), ((int)(((byte)(246)))));
            this.gb_admin.Controls.Add(this.tb_price);
            this.gb_admin.Controls.Add(this.tb_name);
            this.gb_admin.Controls.Add(this.name_bs);
            this.gb_admin.Controls.Add(this.price_bs);
            this.gb_admin.Location = new System.Drawing.Point(12, 112);
            this.gb_admin.Name = "gb_admin";
            this.gb_admin.Size = new System.Drawing.Size(479, 185);
            this.gb_admin.TabIndex = 3;
            this.gb_admin.TabStop = false;
            this.gb_admin.Enter += new System.EventHandler(this.gb_admin_Enter);
            // 
            // tb_price
            // 
            this.tb_price.Location = new System.Drawing.Point(170, 110);
            this.tb_price.Multiline = true;
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(170, 45);
            this.tb_price.TabIndex = 4;
            this.tb_price.TextChanged += new System.EventHandler(this.tb_price_TextChanged);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(170, 34);
            this.tb_name.Multiline = true;
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(170, 44);
            this.tb_name.TabIndex = 3;
            this.tb_name.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // btn_ad
            // 
            this.btn_ad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(176)))), ((int)(((byte)(241)))));
            this.btn_ad.Font = new System.Drawing.Font("Microsoft PhagsPa", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ad.Location = new System.Drawing.Point(121, 543);
            this.btn_ad.Name = "btn_ad";
            this.btn_ad.Size = new System.Drawing.Size(94, 64);
            this.btn_ad.TabIndex = 4;
            this.btn_ad.Text = "เพิ่ม";
            this.btn_ad.UseVisualStyleBackColor = false;
            this.btn_ad.Click += new System.EventHandler(this.btn_ad_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(176)))), ((int)(((byte)(241)))));
            this.btn_edit.Font = new System.Drawing.Font("Microsoft PhagsPa", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(354, 543);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(94, 64);
            this.btn_edit.TabIndex = 5;
            this.btn_edit.Text = "แก้ไข";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click_1);
            // 
            // btn_delet
            // 
            this.btn_delet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(176)))), ((int)(((byte)(241)))));
            this.btn_delet.Font = new System.Drawing.Font("Microsoft PhagsPa", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delet.Location = new System.Drawing.Point(232, 543);
            this.btn_delet.Name = "btn_delet";
            this.btn_delet.Size = new System.Drawing.Size(94, 64);
            this.btn_delet.TabIndex = 6;
            this.btn_delet.Text = "ลบ";
            this.btn_delet.UseVisualStyleBackColor = false;
            this.btn_delet.Click += new System.EventHandler(this.btn_delet_Click);
            // 
            // back_admin
            // 
            this.back_admin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_admin.BackgroundImage")));
            this.back_admin.Image = ((System.Drawing.Image)(resources.GetObject("back_admin.Image")));
            this.back_admin.Location = new System.Drawing.Point(6, 565);
            this.back_admin.Name = "back_admin";
            this.back_admin.Size = new System.Drawing.Size(81, 80);
            this.back_admin.TabIndex = 7;
            this.back_admin.TabStop = false;
            this.back_admin.Click += new System.EventHandler(this.back_admin_Click);
            // 
            // ch_pic
            // 
            this.ch_pic.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ch_pic.Font = new System.Drawing.Font("Microsoft PhagsPa", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_pic.Location = new System.Drawing.Point(182, 477);
            this.ch_pic.Name = "ch_pic";
            this.ch_pic.Size = new System.Drawing.Size(119, 42);
            this.ch_pic.TabIndex = 8;
            this.ch_pic.Text = "เลือกรูปภาพ";
            this.ch_pic.UseVisualStyleBackColor = false;
            this.ch_pic.Click += new System.EventHandler(this.ch_pic_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(139, 303);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 156);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // admin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1030, 633);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ch_pic);
            this.Controls.Add(this.back_admin);
            this.Controls.Add(this.btn_delet);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_ad);
            this.Controls.Add(this.gb_admin);
            this.Controls.Add(this.datastock);
            this.Name = "admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admin";
            this.Load += new System.EventHandler(this.admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datastock)).EndInit();
            this.gb_admin.ResumeLayout(false);
            this.gb_admin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back_admin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datastock;
        private System.Windows.Forms.Label name_bs;
        private System.Windows.Forms.Label price_bs;
        private System.Windows.Forms.GroupBox gb_admin;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button btn_ad;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delet;
        private System.Windows.Forms.PictureBox back_admin;
        private System.Windows.Forms.Button ch_pic;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}