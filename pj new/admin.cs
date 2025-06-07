using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO; // เพิ่ม namespace นี้


namespace pj_new
{
    public partial class admin : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=bingsu;";

            MySqlConnection conn = new MySqlConnection(connectionstring);

            return conn;
        }

        private void showStock()
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT *  FROM stockbingsu";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            datastock.DataSource = ds.Tables[0].DefaultView;

        }

        

        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {

            showStock();
           
        }

        

        private void datastock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datastock_CellClick(object sender, DataGridViewCellEventArgs e) 
        {

            // ตรวจสอบว่าเลือกแถวที่มีข้อมูล
            if (e.RowIndex >= 0 && e.RowIndex < datastock.Rows.Count )
            {
                datastock.CurrentRow.Selected = true;

                // ดึงข้อมูลจากเซลล์แต่ละคอลัมน์ในแถวที่เลือกมาแสดงใน TextBox
                tb_name.Text = datastock.Rows[e.RowIndex].Cells["Menu"].FormattedValue.ToString();
                tb_price.Text = datastock.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();

                // ดึงข้อมูลรูปภาพจากเซลล์ "Picture" ในแถวที่เลือก
                byte[] imageBytes = (byte[])datastock.Rows[e.RowIndex].Cells["Picture"].Value;

                // แปลงข้อมูล byte array เป็นรูปภาพและแสดงใน PictureBox
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // ตั้งค่า PictureBox ให้ปรับขนาดรูปภาพให้เข้ากับขนาดของ PictureBox
                        pictureBox1.Image = Image.FromStream(ms);
                        
                    }
                }
                else
                {
                    // หากไม่มีข้อมูลรูปภาพ กำหนดรูปภาพใน PictureBox เป็น null
                    pictureBox1.SizeMode = PictureBoxSizeMode.Normal; // สลับค่าเป็น Normal หากไม่มีรูปภาพ
                    // หากไม่มีรูปภาพในเซลล์ "Picture" ให้ลบรูปภาพใน PictureBox
                    pictureBox1.Image = null;
                }
            }

        }
        




        private void btn_ad_Click(object sender, EventArgs e) //ปุ่มเพิ่ม
        {
            byte[] image = null;

            // แปลงรูปภาพจาก PictureBox เป็น byte array
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    image = ms.ToArray();
                }
            }


            try
            {
                MySqlConnection conn = databaseConnection();
                

                string sql = "INSERT INTO stockbingsu (Menu, Price, Picture) VALUES (@Menu, @Price, @Picture)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Menu", tb_name.Text);
                cmd.Parameters.AddWithValue("@Price", tb_price.Text);
                cmd.Parameters.AddWithValue("@Picture", image);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("เพิ่มสำเร็จ");

                    // เคลียร์ข้อมูลใน TextBox
                    tb_name.Clear();
                    tb_price.Clear();
                    // เคลียร์รูปใน PictureBox
                    pictureBox1.Image = null;

                    showStock();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเพิ่มข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void btn_delet_Click(object sender, EventArgs e)
        {

            int selectedRow = datastock.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(datastock.Rows[selectedRow].Cells["Id"].Value);

            Console.WriteLine(deleteId);


            try
            {

                MySqlConnection conn = databaseConnection();

                string sql = "DELETE FROM stockbingsu WHERE Id = '" + deleteId + "'";

                MySqlCommand cmd = new MySqlCommand(sql, conn);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("ลบสำเร็จ");
                    showStock();
                    // เคลียร์ข้อมูลใน TextBox
                    tb_name.Clear();
                    tb_price.Clear();
                    // เคลียร์รูปใน PictureBox
                    pictureBox1.Image = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการลบข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_edit_Click_1(object sender, EventArgs e)
        {
            int selectedRow = datastock.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(datastock.Rows[selectedRow].Cells["Id"].Value);

            byte[] image = null;

            // แปลงรูปภาพจาก PictureBox เป็น byte array
            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // ใช้ Bitmap เพื่อหลีกเลี่ยงการล็อกไฟล์ภาพ
                    Bitmap bitmap = new Bitmap(pictureBox1.Image);
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // บันทึกเป็น JPEG หรือรูปแบบที่ต้องการ
                    image = ms.ToArray();
                }
            }

            //Console.WriteLine(editId);
            try
            {
                MySqlConnection conn = databaseConnection();

                // อัปเดตข้อมูลโดยใช้คำสั่ง SQL UPDATE
                string sql = "UPDATE stockbingsu SET Menu = @Menu, Price = @Price, Picture = @Picture WHERE Id = @Id ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // กำหนดค่าพารามิเตอร์
                cmd.Parameters.AddWithValue("@Menu", tb_name.Text);
                cmd.Parameters.AddWithValue("@Price", tb_price.Text);
                cmd.Parameters.AddWithValue("@Picture", image); // สมมติว่าตัวแปร image เก็บรูปภาพที่ต้องการอัปเดต

                // กำหนดค่า Primary Key ของแถวที่ต้องการอัปเดต
                cmd.Parameters.AddWithValue("@Id", editId); // ใส่ค่า Primary Key ของแถวที่ต้องการอัปเดต

                // เปิดการเชื่อมต่อกับฐานข้อมูล
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();

                if (rows > 0)
                {
                    MessageBox.Show("แก้ไขสำเร็จ");
                    showStock();

                    // เคลียร์ข้อมูลใน TextBox
                    tb_name.Clear();
                    tb_price.Clear();
                    // เคลียร์รูปใน PictureBox
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ch_pic_Click_1(object sender, EventArgs e)
        {
            // เปิดหน้าต่างเลือกรูปภาพ
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp) | *.jpg; *.jpeg; *.png; *.bmp";
            openFileDialog1.Title = "เลือกรูปภาพ";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // แสดงรูปภาพที่เลือกใน pictureBox
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // กำหนดให้รูปภาพปรับขนาดให้พอดีกับ PictureBox

            }
        }

        private void gb_admin_Enter(object sender, EventArgs e)
        {

        }

        private void name_bs_Click(object sender, EventArgs e)
        {

        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_bs_Click(object sender, EventArgs e)
        {

        }

        private void tb_price_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_pic_TextChanged(object sender, EventArgs e)
        {

        }

        private void back_admin_Click(object sender, EventArgs e)
        {
            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            management form2 = new management(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

        
    }
}
