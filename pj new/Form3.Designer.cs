namespace pj_new
{
    partial class Form3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxdiscount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.textBoxVAT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.datacart = new System.Windows.Forms.DataGridView();
            this.confirm = new System.Windows.Forms.Button();
            this.tb_total = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.Button();
            this.edit_cart = new System.Windows.Forms.Button();
            this.delete_cart = new System.Windows.Forms.Button();
            this.textbox_amount = new System.Windows.Forms.TextBox();
            this.order = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datacart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Controls.Add(this.textBoxdiscount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxSum);
            this.groupBox1.Controls.Add(this.textBoxVAT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.datacart);
            this.groupBox1.Controls.Add(this.confirm);
            this.groupBox1.Controls.Add(this.tb_total);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(698, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 671);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxdiscount
            // 
            this.textBoxdiscount.Font = new System.Drawing.Font("Prompt", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdiscount.Location = new System.Drawing.Point(336, 508);
            this.textBoxdiscount.Multiline = true;
            this.textBoxdiscount.Name = "textBoxdiscount";
            this.textBoxdiscount.Size = new System.Drawing.Size(143, 30);
            this.textBoxdiscount.TabIndex = 16;
            this.textBoxdiscount.TextChanged += new System.EventHandler(this.textBoxdiscount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(27, 508);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 30);
            this.label5.TabIndex = 15;
            this.label5.Text = "ส่วนลด";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Font = new System.Drawing.Font("Prompt", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSum.Location = new System.Drawing.Point(336, 550);
            this.textBoxSum.Multiline = true;
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(143, 30);
            this.textBoxSum.TabIndex = 14;
            this.textBoxSum.TextChanged += new System.EventHandler(this.textBoxSum_TextChanged);
            // 
            // textBoxVAT
            // 
            this.textBoxVAT.Font = new System.Drawing.Font("Prompt", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVAT.Location = new System.Drawing.Point(336, 463);
            this.textBoxVAT.Multiline = true;
            this.textBoxVAT.Name = "textBoxVAT";
            this.textBoxVAT.Size = new System.Drawing.Size(143, 30);
            this.textBoxVAT.TabIndex = 13;
            this.textBoxVAT.TextChanged += new System.EventHandler(this.textBoxVAT_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Snow;
            this.label4.Location = new System.Drawing.Point(27, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 30);
            this.label4.TabIndex = 12;
            this.label4.Text = "ยอดรวมทั้งสิ้น";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(27, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "มูลค่าภาษีเพิ่ม(VAT 7%)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Prompt", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(10, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 46);
            this.label2.TabIndex = 10;
            this.label2.Text = "ชื่อผู้ใช้";
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("Prompt", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(133, 28);
            this.textBox_name.Multiline = true;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(134, 41);
            this.textBox_name.TabIndex = 9;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // datacart
            // 
            this.datacart.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.datacart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datacart.Location = new System.Drawing.Point(18, 77);
            this.datacart.Name = "datacart";
            this.datacart.RowHeadersWidth = 51;
            this.datacart.RowTemplate.Height = 24;
            this.datacart.Size = new System.Drawing.Size(479, 318);
            this.datacart.TabIndex = 8;
            this.datacart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datacart_CellContentClick);
            this.datacart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datacart_CellContentClick_1);
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(200)))), ((int)(((byte)(115)))));
            this.confirm.Font = new System.Drawing.Font("Prompt", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.Location = new System.Drawing.Point(352, 609);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(96, 44);
            this.confirm.TabIndex = 7;
            this.confirm.Text = "ชำระเงิน";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // tb_total
            // 
            this.tb_total.Font = new System.Drawing.Font("Prompt", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_total.Location = new System.Drawing.Point(336, 418);
            this.tb_total.Multiline = true;
            this.tb_total.Name = "tb_total";
            this.tb_total.Size = new System.Drawing.Size(143, 30);
            this.tb_total.TabIndex = 6;
            this.tb_total.TextChanged += new System.EventHandler(this.tb_total_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(27, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "ยอดรวม";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.back.BackgroundImage = global::pj_new.Properties.Resources.back1;
            this.back.Location = new System.Drawing.Point(12, 616);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(50, 50);
            this.back.TabIndex = 11;
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // edit_cart
            // 
            this.edit_cart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(182)))), ((int)(((byte)(241)))));
            this.edit_cart.Font = new System.Drawing.Font("Prompt", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edit_cart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.edit_cart.Location = new System.Drawing.Point(378, 569);
            this.edit_cart.Name = "edit_cart";
            this.edit_cart.Size = new System.Drawing.Size(90, 50);
            this.edit_cart.TabIndex = 10;
            this.edit_cart.Text = "แก้ไข";
            this.edit_cart.UseVisualStyleBackColor = false;
            this.edit_cart.Click += new System.EventHandler(this.edit_cart_Click);
            // 
            // delete_cart
            // 
            this.delete_cart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(182)))), ((int)(((byte)(241)))));
            this.delete_cart.Font = new System.Drawing.Font("Prompt", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_cart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.delete_cart.Location = new System.Drawing.Point(246, 569);
            this.delete_cart.Name = "delete_cart";
            this.delete_cart.Size = new System.Drawing.Size(75, 50);
            this.delete_cart.TabIndex = 9;
            this.delete_cart.Text = "ลบ";
            this.delete_cart.UseVisualStyleBackColor = false;
            this.delete_cart.Click += new System.EventHandler(this.delete_cart_Click);
            // 
            // textbox_amount
            // 
            this.textbox_amount.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_amount.Location = new System.Drawing.Point(246, 503);
            this.textbox_amount.Multiline = true;
            this.textbox_amount.Name = "textbox_amount";
            this.textbox_amount.Size = new System.Drawing.Size(97, 49);
            this.textbox_amount.TabIndex = 3;
            this.textbox_amount.TextChanged += new System.EventHandler(this.textbox_amount_TextChanged);
            // 
            // order
            // 
            this.order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(182)))), ((int)(((byte)(241)))));
            this.order.Font = new System.Drawing.Font("Prompt", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.order.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.order.Location = new System.Drawing.Point(118, 569);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(82, 50);
            this.order.TabIndex = 2;
            this.order.Text = "สั่ง";
            this.order.UseVisualStyleBackColor = false;
            this.order.Click += new System.EventHandler(this.order_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(1, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(691, 439);
            this.panel1.TabIndex = 2;
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Red;
            this.BackgroundImage = global::pj_new.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(1207, 678);
            this.Controls.Add(this.edit_cart);
            this.Controls.Add(this.back);
            this.Controls.Add(this.delete_cart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textbox_amount);
            this.Controls.Add(this.order);
            this.Location = new System.Drawing.Point(50, 60);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datacart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button order;
        private System.Windows.Forms.TextBox textbox_amount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_total;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.DataGridView datacart;
        private System.Windows.Forms.Button delete_cart;
        private System.Windows.Forms.Button edit_cart;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.TextBox textBoxVAT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxdiscount;
    }
}