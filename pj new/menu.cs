using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pj_new
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {

            showStock();

        }

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
            cmd.CommandText = "SELECT * FROM stockbingsu";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            gd_menu.DataSource = ds.Tables[0].DefaultView;



        }

        private void mango_Click(object sender, EventArgs e)
        {
            
        }

        private void gd_menu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // ตรวจสอบว่าเมื่อคลิกเซลล์ในแถวไหนใน DataGridView
                if (e.RowIndex >= 0)
                {
                    // รับ ID ของแถวที่ถูกคลิก
                    int selectedRow = e.RowIndex;
                    // รับ ID ที่จะใช้ในการดึงข้อมูลรูปภาพ
                    int itemId = Convert.ToInt32(gd_menu.Rows[selectedRow].Cells["Id"].Value);

                    // เชื่อมต่อฐานข้อมูล
                    MySqlConnection conn = databaseConnection();
                    conn.Open();

                    // สร้างคำสั่ง SQL เพื่อดึงข้อมูลรูปภาพ
                    string sql = "SELECT Picture FROM stock WHERE Id = @itemId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@itemId", itemId);

                    // อ่านข้อมูลรูปภาพจากฐานข้อมูล
                    byte[] imgData = (byte[])cmd.ExecuteScalar();

                    // แปลงข้อมูลรูปภาพเป็นรูปภาพและแสดงใน PictureBox
                    if (imgData != null)
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imgData))
                        {
                            pictureBox_pic.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // หากไม่พบรูปภาพในฐานข้อมูล
                        MessageBox.Show("ไม่พบรูปภาพสำหรับรายการนี้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

