namespace pj_new
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.b_menu = new System.Windows.Forms.Button();
            this.Developer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_menu
            // 
            this.b_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(200)))), ((int)(((byte)(115)))));
            this.b_menu.Font = new System.Drawing.Font("Verdana", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_menu.ForeColor = System.Drawing.Color.White;
            this.b_menu.Location = new System.Drawing.Point(31, 621);
            this.b_menu.Name = "b_menu";
            this.b_menu.Size = new System.Drawing.Size(246, 91);
            this.b_menu.TabIndex = 1;
            this.b_menu.Text = "เข้าสู่ระบบ";
            this.b_menu.UseVisualStyleBackColor = false;
            this.b_menu.Click += new System.EventHandler(this.button1_Click);
            // 
            // Developer
            // 
            this.Developer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.Developer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Developer.BackgroundImage")));
            this.Developer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Developer.FlatAppearance.BorderSize = 0;
            this.Developer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Developer.Location = new System.Drawing.Point(903, 12);
            this.Developer.Name = "Developer";
            this.Developer.Size = new System.Drawing.Size(59, 61);
            this.Developer.TabIndex = 2;
            this.Developer.UseVisualStyleBackColor = false;
            this.Developer.Click += new System.EventHandler(this.Developer_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.Developer);
            this.Controls.Add(this.b_menu);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button b_menu;
        private System.Windows.Forms.Button Developer;
    }
}

