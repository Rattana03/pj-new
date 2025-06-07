namespace pj_new
{
    partial class Menu2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu2));
            this.dg_menu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dg_menu)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_menu
            // 
            this.dg_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_menu.Location = new System.Drawing.Point(12, 98);
            this.dg_menu.Name = "dg_menu";
            this.dg_menu.RowHeadersWidth = 51;
            this.dg_menu.RowTemplate.Height = 24;
            this.dg_menu.Size = new System.Drawing.Size(510, 246);
            this.dg_menu.TabIndex = 0;
            // 
            // Menu2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 633);
            this.Controls.Add(this.dg_menu);
            this.Name = "Menu2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu2";
            this.Load += new System.EventHandler(this.Menu2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_menu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_menu;
    }
}