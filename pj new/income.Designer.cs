namespace pj_new
{
    partial class income
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
            this.dataincome = new System.Windows.Forms.DataGridView();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxyear = new System.Windows.Forms.TextBox();
            this.textBoxmonth = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxusername = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataincome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataincome
            // 
            this.dataincome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataincome.Location = new System.Drawing.Point(24, 280);
            this.dataincome.Name = "dataincome";
            this.dataincome.RowHeadersWidth = 51;
            this.dataincome.RowTemplate.Height = 24;
            this.dataincome.Size = new System.Drawing.Size(604, 350);
            this.dataincome.TabIndex = 1;
            this.dataincome.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataincome_CellContentClick);
            // 
            // txtdate
            // 
            this.txtdate.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.Location = new System.Drawing.Point(43, 200);
            this.txtdate.Multiline = true;
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(102, 42);
            this.txtdate.TabIndex = 2;
            this.txtdate.TextChanged += new System.EventHandler(this.textBoxdate_TextChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(486, 200);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(90, 36);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "ค้นหา";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxyear
            // 
            this.textBoxyear.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxyear.Location = new System.Drawing.Point(341, 203);
            this.textBoxyear.Multiline = true;
            this.textBoxyear.Name = "textBoxyear";
            this.textBoxyear.Size = new System.Drawing.Size(85, 39);
            this.textBoxyear.TabIndex = 4;
            // 
            // textBoxmonth
            // 
            this.textBoxmonth.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxmonth.Location = new System.Drawing.Point(191, 200);
            this.textBoxmonth.Multiline = true;
            this.textBoxmonth.Name = "textBoxmonth";
            this.textBoxmonth.Size = new System.Drawing.Size(97, 42);
            this.textBoxmonth.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "USERNAME",
            "DAY",
            "MOUNT",
            "YEAR"});
            this.comboBox1.Location = new System.Drawing.Point(24, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxusername
            // 
            this.textBoxusername.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxusername.Location = new System.Drawing.Point(241, 113);
            this.textBoxusername.Multiline = true;
            this.textBoxusername.Name = "textBoxusername";
            this.textBoxusername.Size = new System.Drawing.Size(146, 42);
            this.textBoxusername.TabIndex = 7;
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(505, 122);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(100, 22);
            this.txttotal.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(667, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 250);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // income
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::pj_new.Properties.Resources.รายได้1;
            this.ClientSize = new System.Drawing.Size(1001, 671);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.textBoxusername);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxmonth);
            this.Controls.Add(this.textBoxyear);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.dataincome);
            this.Name = "income";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "income";
            this.Load += new System.EventHandler(this.income_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataincome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataincome;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxyear;
        private System.Windows.Forms.TextBox textBoxmonth;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxusername;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}