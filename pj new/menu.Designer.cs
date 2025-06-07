namespace pj_new
{
    partial class menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.mango = new System.Windows.Forms.Button();
            this.staw = new System.Windows.Forms.Button();
            this.durian = new System.Windows.Forms.Button();
            this.blueberry = new System.Windows.Forms.Button();
            this.watermelon = new System.Windows.Forms.Button();
            this.melon = new System.Windows.Forms.Button();
            this.mixed = new System.Windows.Forms.Button();
            this.thai = new System.Windows.Forms.Button();
            this.choco = new System.Windows.Forms.Button();
            this.pictureBox_pic = new System.Windows.Forms.PictureBox();
            this.gd_menu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd_menu)).BeginInit();
            this.SuspendLayout();
            // 
            // mango
            // 
            this.mango.Image = ((System.Drawing.Image)(resources.GetObject("mango.Image")));
            this.mango.Location = new System.Drawing.Point(12, 130);
            this.mango.Name = "mango";
            this.mango.Size = new System.Drawing.Size(145, 150);
            this.mango.TabIndex = 0;
            this.mango.UseVisualStyleBackColor = true;
            this.mango.Click += new System.EventHandler(this.mango_Click);
            // 
            // staw
            // 
            this.staw.Image = ((System.Drawing.Image)(resources.GetObject("staw.Image")));
            this.staw.Location = new System.Drawing.Point(172, 130);
            this.staw.Name = "staw";
            this.staw.Size = new System.Drawing.Size(145, 150);
            this.staw.TabIndex = 1;
            this.staw.UseVisualStyleBackColor = true;
            // 
            // durian
            // 
            this.durian.Image = ((System.Drawing.Image)(resources.GetObject("durian.Image")));
            this.durian.Location = new System.Drawing.Point(337, 130);
            this.durian.Name = "durian";
            this.durian.Size = new System.Drawing.Size(145, 150);
            this.durian.TabIndex = 2;
            this.durian.UseVisualStyleBackColor = true;
            // 
            // blueberry
            // 
            this.blueberry.Image = ((System.Drawing.Image)(resources.GetObject("blueberry.Image")));
            this.blueberry.Location = new System.Drawing.Point(172, 306);
            this.blueberry.Name = "blueberry";
            this.blueberry.Size = new System.Drawing.Size(145, 150);
            this.blueberry.TabIndex = 3;
            this.blueberry.UseVisualStyleBackColor = true;
            // 
            // watermelon
            // 
            this.watermelon.Image = ((System.Drawing.Image)(resources.GetObject("watermelon.Image")));
            this.watermelon.Location = new System.Drawing.Point(12, 476);
            this.watermelon.Name = "watermelon";
            this.watermelon.Size = new System.Drawing.Size(145, 150);
            this.watermelon.TabIndex = 4;
            this.watermelon.UseVisualStyleBackColor = true;
            // 
            // melon
            // 
            this.melon.Image = ((System.Drawing.Image)(resources.GetObject("melon.Image")));
            this.melon.Location = new System.Drawing.Point(12, 306);
            this.melon.Name = "melon";
            this.melon.Size = new System.Drawing.Size(145, 150);
            this.melon.TabIndex = 5;
            this.melon.UseVisualStyleBackColor = true;
            // 
            // mixed
            // 
            this.mixed.Image = ((System.Drawing.Image)(resources.GetObject("mixed.Image")));
            this.mixed.Location = new System.Drawing.Point(337, 306);
            this.mixed.Name = "mixed";
            this.mixed.Size = new System.Drawing.Size(145, 150);
            this.mixed.TabIndex = 6;
            this.mixed.UseVisualStyleBackColor = true;
            // 
            // thai
            // 
            this.thai.Image = ((System.Drawing.Image)(resources.GetObject("thai.Image")));
            this.thai.Location = new System.Drawing.Point(172, 476);
            this.thai.Name = "thai";
            this.thai.Size = new System.Drawing.Size(145, 150);
            this.thai.TabIndex = 7;
            this.thai.UseVisualStyleBackColor = true;
            // 
            // choco
            // 
            this.choco.Image = ((System.Drawing.Image)(resources.GetObject("choco.Image")));
            this.choco.Location = new System.Drawing.Point(337, 471);
            this.choco.Name = "choco";
            this.choco.Size = new System.Drawing.Size(145, 150);
            this.choco.TabIndex = 8;
            this.choco.UseVisualStyleBackColor = true;
            // 
            // pictureBox_pic
            // 
            this.pictureBox_pic.Location = new System.Drawing.Point(578, 391);
            this.pictureBox_pic.Name = "pictureBox_pic";
            this.pictureBox_pic.Size = new System.Drawing.Size(330, 230);
            this.pictureBox_pic.TabIndex = 9;
            this.pictureBox_pic.TabStop = false;
            // 
            // gd_menu
            // 
            this.gd_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gd_menu.Location = new System.Drawing.Point(528, 12);
            this.gd_menu.Name = "gd_menu";
            this.gd_menu.RowHeadersWidth = 51;
            this.gd_menu.RowTemplate.Height = 24;
            this.gd_menu.Size = new System.Drawing.Size(442, 217);
            this.gd_menu.TabIndex = 10;
            this.gd_menu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gd_menu_CellClick);
            // 
            // menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 633);
            this.Controls.Add(this.gd_menu);
            this.Controls.Add(this.pictureBox_pic);
            this.Controls.Add(this.choco);
            this.Controls.Add(this.thai);
            this.Controls.Add(this.mixed);
            this.Controls.Add(this.melon);
            this.Controls.Add(this.watermelon);
            this.Controls.Add(this.blueberry);
            this.Controls.Add(this.durian);
            this.Controls.Add(this.staw);
            this.Controls.Add(this.mango);
            this.Name = "menu";
            this.Text = "menu";
            this.Load += new System.EventHandler(this.menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd_menu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mango;
        private System.Windows.Forms.Button staw;
        private System.Windows.Forms.Button durian;
        private System.Windows.Forms.Button blueberry;
        private System.Windows.Forms.Button watermelon;
        private System.Windows.Forms.Button melon;
        private System.Windows.Forms.Button mixed;
        private System.Windows.Forms.Button thai;
        private System.Windows.Forms.Button choco;
        private System.Windows.Forms.PictureBox pictureBox_pic;
        private System.Windows.Forms.DataGridView gd_menu;
    }
}