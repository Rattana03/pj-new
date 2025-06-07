namespace pj_new
{
    partial class income2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(income2));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dtgincome = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.textBoxdate = new System.Windows.Forms.TextBox();
            this.textBoxmount = new System.Windows.Forms.TextBox();
            this.textBoxyear = new System.Windows.Forms.TextBox();
            this.textBoxtotal = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridViewbest = new System.Windows.Forms.DataGridView();
            this.back_L = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgincome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(978, 162);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(61, 30);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "ค้นหา";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dtgincome
            // 
            this.dtgincome.BackgroundColor = System.Drawing.Color.MintCream;
            this.dtgincome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgincome.Location = new System.Drawing.Point(521, 413);
            this.dtgincome.Name = "dtgincome";
            this.dtgincome.RowHeadersWidth = 51;
            this.dtgincome.RowTemplate.Height = 24;
            this.dtgincome.Size = new System.Drawing.Size(530, 246);
            this.dtgincome.TabIndex = 10;
            this.dtgincome.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgincome_CellContentClick);
            this.dtgincome.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgincome_DataError);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(96, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Username",
            "Date",
            "Mount",
            "Year"});
            this.comboBox.Location = new System.Drawing.Point(620, 159);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(130, 34);
            this.comboBox.TabIndex = 19;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // textBoxdate
            // 
            this.textBoxdate.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdate.Location = new System.Drawing.Point(808, 162);
            this.textBoxdate.Multiline = true;
            this.textBoxdate.Name = "textBoxdate";
            this.textBoxdate.Size = new System.Drawing.Size(38, 22);
            this.textBoxdate.TabIndex = 21;
            this.textBoxdate.TextChanged += new System.EventHandler(this.textBoxdate_TextChanged);
            // 
            // textBoxmount
            // 
            this.textBoxmount.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxmount.Location = new System.Drawing.Point(852, 162);
            this.textBoxmount.Multiline = true;
            this.textBoxmount.Name = "textBoxmount";
            this.textBoxmount.Size = new System.Drawing.Size(36, 22);
            this.textBoxmount.TabIndex = 22;
            this.textBoxmount.TextChanged += new System.EventHandler(this.textBoxmount_TextChanged);
            // 
            // textBoxyear
            // 
            this.textBoxyear.Font = new System.Drawing.Font("Prompt", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxyear.Location = new System.Drawing.Point(894, 162);
            this.textBoxyear.Multiline = true;
            this.textBoxyear.Name = "textBoxyear";
            this.textBoxyear.Size = new System.Drawing.Size(47, 22);
            this.textBoxyear.TabIndex = 23;
            this.textBoxyear.TextChanged += new System.EventHandler(this.textBoxtyear_TextChanged);
            // 
            // textBoxtotal
            // 
            this.textBoxtotal.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxtotal.Location = new System.Drawing.Point(807, 264);
            this.textBoxtotal.Name = "textBoxtotal";
            this.textBoxtotal.Size = new System.Drawing.Size(134, 38);
            this.textBoxtotal.TabIndex = 24;
            this.textBoxtotal.TextChanged += new System.EventHandler(this.textBoxtotal_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(790, 161);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 34);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(142, 363);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 33);
            this.textBox2.TabIndex = 28;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dataGridViewbest
            // 
            this.dataGridViewbest.BackgroundColor = System.Drawing.Color.MintCream;
            this.dataGridViewbest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewbest.Location = new System.Drawing.Point(49, 435);
            this.dataGridViewbest.Name = "dataGridViewbest";
            this.dataGridViewbest.RowHeadersWidth = 51;
            this.dataGridViewbest.RowTemplate.Height = 24;
            this.dataGridViewbest.Size = new System.Drawing.Size(394, 172);
            this.dataGridViewbest.TabIndex = 29;
            this.dataGridViewbest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewbest_CellContentClick);
            // 
            // back_L
            // 
            this.back_L.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_L.BackgroundImage")));
            this.back_L.Image = ((System.Drawing.Image)(resources.GetObject("back_L.Image")));
            this.back_L.Location = new System.Drawing.Point(12, 628);
            this.back_L.Name = "back_L";
            this.back_L.Size = new System.Drawing.Size(41, 43);
            this.back_L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.back_L.TabIndex = 30;
            this.back_L.TabStop = false;
            this.back_L.Click += new System.EventHandler(this.back_L_Click);
            // 
            // income2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::pj_new.Properties.Resources.bgincome1;
            this.ClientSize = new System.Drawing.Size(1072, 683);
            this.Controls.Add(this.back_L);
            this.Controls.Add(this.dataGridViewbest);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxtotal);
            this.Controls.Add(this.textBoxyear);
            this.Controls.Add(this.textBoxmount);
            this.Controls.Add(this.textBoxdate);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dtgincome);
            this.Name = "income2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.income2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgincome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewbest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dtgincome;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox textBoxdate;
        private System.Windows.Forms.TextBox textBoxmount;
        private System.Windows.Forms.TextBox textBoxyear;
        private System.Windows.Forms.TextBox textBoxtotal;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridViewbest;
        private System.Windows.Forms.PictureBox back_L;
    }
}