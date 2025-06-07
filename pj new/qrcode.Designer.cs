namespace pj_new
{
    partial class qrcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(qrcode));
            this.pay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.back_L = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).BeginInit();
            this.SuspendLayout();
            // 
            // pay
            // 
            this.pay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(98)))), ((int)(((byte)(221)))));
            this.pay.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pay.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pay.Location = new System.Drawing.Point(178, 440);
            this.pay.Name = "pay";
            this.pay.Size = new System.Drawing.Size(99, 39);
            this.pay.TabIndex = 1;
            this.pay.Text = "เสร็จสิ้น";
            this.pay.UseVisualStyleBackColor = false;
            this.pay.Click += new System.EventHandler(this.pay_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Prompt", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(150, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 28);
            this.label2.TabIndex = 2;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pj_new.Properties.Resources.qrcode1;
            this.pictureBox1.Location = new System.Drawing.Point(87, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(281, 316);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(168, 391);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 33);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // back_L
            // 
            this.back_L.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_L.BackgroundImage")));
            this.back_L.Image = ((System.Drawing.Image)(resources.GetObject("back_L.Image")));
            this.back_L.Location = new System.Drawing.Point(12, 436);
            this.back_L.Name = "back_L";
            this.back_L.Size = new System.Drawing.Size(41, 43);
            this.back_L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back_L.TabIndex = 32;
            this.back_L.TabStop = false;
            this.back_L.Click += new System.EventHandler(this.back_L_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Prompt", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(23, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 28);
            this.label1.TabIndex = 33;
            this.label1.Text = "ยอดรวมทั้งสิ้น";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Prompt", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(23, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 28);
            this.label3.TabIndex = 34;
            this.label3.Text = "ชื่อผู้ใช้";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // qrcode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::pj_new.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(475, 487);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back_L);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Name = "qrcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "qrcode";
            this.Load += new System.EventHandler(this.qrcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button pay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox back_L;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}