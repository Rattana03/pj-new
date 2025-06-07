namespace pj_new
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.g_login = new System.Windows.Forms.GroupBox();
            this.but_re = new System.Windows.Forms.Button();
            this.but_log = new System.Windows.Forms.Button();
            this.tb_pw = new System.Windows.Forms.TextBox();
            this.tb_us = new System.Windows.Forms.TextBox();
            this.la_pass = new System.Windows.Forms.Label();
            this.la_user = new System.Windows.Forms.Label();
            this.back_L = new System.Windows.Forms.PictureBox();
            this.g_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).BeginInit();
            this.SuspendLayout();
            // 
            // g_login
            // 
            this.g_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.g_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(204)))), ((int)(((byte)(246)))));
            this.g_login.Controls.Add(this.but_re);
            this.g_login.Controls.Add(this.but_log);
            this.g_login.Controls.Add(this.tb_pw);
            this.g_login.Controls.Add(this.tb_us);
            this.g_login.Controls.Add(this.la_pass);
            this.g_login.Controls.Add(this.la_user);
            this.g_login.Font = new System.Drawing.Font("Prompt", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.g_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.g_login.Location = new System.Drawing.Point(234, 85);
            this.g_login.Name = "g_login";
            this.g_login.Size = new System.Drawing.Size(534, 500);
            this.g_login.TabIndex = 0;
            this.g_login.TabStop = false;
            this.g_login.Text = "WELCOME TO Pimpri Bingsu!";
            this.g_login.Enter += new System.EventHandler(this.g_login_Enter);
            // 
            // but_re
            // 
            this.but_re.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(26)))), ((int)(((byte)(22)))));
            this.but_re.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_re.ForeColor = System.Drawing.Color.White;
            this.but_re.Location = new System.Drawing.Point(325, 414);
            this.but_re.Name = "but_re";
            this.but_re.Size = new System.Drawing.Size(128, 46);
            this.but_re.TabIndex = 5;
            this.but_re.Text = "Register";
            this.but_re.UseVisualStyleBackColor = false;
            this.but_re.Click += new System.EventHandler(this.but_re_Click);
            // 
            // but_log
            // 
            this.but_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(26)))), ((int)(((byte)(22)))));
            this.but_log.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.but_log.ForeColor = System.Drawing.Color.White;
            this.but_log.Location = new System.Drawing.Point(92, 414);
            this.but_log.Name = "but_log";
            this.but_log.Size = new System.Drawing.Size(115, 46);
            this.but_log.TabIndex = 4;
            this.but_log.Text = "Login";
            this.but_log.UseVisualStyleBackColor = false;
            this.but_log.Click += new System.EventHandler(this.but_log_Click);
            // 
            // tb_pw
            // 
            this.tb_pw.Font = new System.Drawing.Font("Prompt", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pw.Location = new System.Drawing.Point(187, 258);
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.PasswordChar = '*';
            this.tb_pw.Size = new System.Drawing.Size(236, 57);
            this.tb_pw.TabIndex = 3;
            this.tb_pw.TextChanged += new System.EventHandler(this.tb_pw_TextChanged);
            // 
            // tb_us
            // 
            this.tb_us.Font = new System.Drawing.Font("Prompt", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_us.Location = new System.Drawing.Point(187, 157);
            this.tb_us.Name = "tb_us";
            this.tb_us.Size = new System.Drawing.Size(236, 57);
            this.tb_us.TabIndex = 2;
            this.tb_us.TextChanged += new System.EventHandler(this.tb_us_TextChanged);
            // 
            // la_pass
            // 
            this.la_pass.AutoSize = true;
            this.la_pass.Font = new System.Drawing.Font("Myanmar Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_pass.Location = new System.Drawing.Point(18, 264);
            this.la_pass.Name = "la_pass";
            this.la_pass.Size = new System.Drawing.Size(179, 50);
            this.la_pass.TabIndex = 1;
            this.la_pass.Text = "PASSWORD";
            this.la_pass.Click += new System.EventHandler(this.la_pass_Click);
            // 
            // la_user
            // 
            this.la_user.AutoSize = true;
            this.la_user.Font = new System.Drawing.Font("Myanmar Text", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.la_user.Location = new System.Drawing.Point(6, 157);
            this.la_user.Name = "la_user";
            this.la_user.Size = new System.Drawing.Size(175, 50);
            this.la_user.TabIndex = 0;
            this.la_user.Text = "USERNAME";
            this.la_user.Click += new System.EventHandler(this.label1_Click);
            // 
            // back_L
            // 
            this.back_L.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_L.BackgroundImage")));
            this.back_L.Image = ((System.Drawing.Image)(resources.GetObject("back_L.Image")));
            this.back_L.Location = new System.Drawing.Point(27, 578);
            this.back_L.Name = "back_L";
            this.back_L.Size = new System.Drawing.Size(41, 43);
            this.back_L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back_L.TabIndex = 1;
            this.back_L.TabStop = false;
            this.back_L.Click += new System.EventHandler(this.back_L_Click);
            // 
            // login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 633);
            this.Controls.Add(this.back_L);
            this.Controls.Add(this.g_login);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.login_Load);
            this.g_login.ResumeLayout(false);
            this.g_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox g_login;
        private System.Windows.Forms.Label la_user;
        private System.Windows.Forms.Label la_pass;
        private System.Windows.Forms.Button but_log;
        private System.Windows.Forms.TextBox tb_pw;
        private System.Windows.Forms.TextBox tb_us;
        private System.Windows.Forms.Button but_re;
        private System.Windows.Forms.PictureBox back_L;
    }
}