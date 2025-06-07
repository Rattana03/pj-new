using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace pj_new
{
    public partial class customers : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=bingsu;";

            MySqlConnection conn = new MySqlConnection(connectionstring);


            return conn;
        }

        private void showUser()
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT *  FROM user";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }

        public customers()
        {
            InitializeComponent();
        }

        private void customers_Load(object sender, EventArgs e)
        {
            showUser();
            //LoadUsernames();
        }

        private void edit_Click(object sender, EventArgs e) //ปุ่มแก้ไข
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["Id"].Value);

            

            //Console.WriteLine(editId);
            try
            {
                MySqlConnection conn = databaseConnection();


                // อัปเดตข้อมูลโดยใช้คำสั่ง SQL UPDATE
                string sql = "UPDATE user SET Name = @Name, Username = @Username, Tel = @Tel, Password = @Password WHERE Id = @Id ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // กำหนดค่าพารามิเตอร์
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Username", tbusername.Text);
                cmd.Parameters.AddWithValue("@Tel", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);


                // กำหนดค่า Primary Key ของแถวที่ต้องการอัปเดต
                cmd.Parameters.AddWithValue("@Id", editId); // ใส่ค่า Primary Key ของแถวที่ต้องการอัปเดต
              

                // เปิดการเชื่อมต่อกับฐานข้อมูล
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                conn.Close();


                if (rows > 0)
                {
                    MessageBox.Show("แก้ไขสำเร็จ");
                    showUser();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            // Console.WriteLine(editId);
            try
            {
                MySqlConnection conn = databaseConnection();
                // อัปเดตข้อมูลในตาราง all order โดยใช้ username และ iduser ที่ถูกแก้ไข
                string sql = "UPDATE `all order` SET username = @Username WHERE IDuser = @Id";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);

                // กำหนดค่าพารามิเตอร์สำหรับการอัปเดตตาราง all order
                cmd1.Parameters.Clear(); // เคลียร์พารามิเตอร์จากคำสั่ง SQL ก่อนหน้า
                cmd1.Parameters.AddWithValue("@Username", tbusername.Text); // ชื่อผู้ใช้ใหม่
                cmd1.Parameters.AddWithValue("@Id", editId); // iduser ที่ตรงกับแถวใน `all order`


                // เปิดการเชื่อมต่อกับฐานข้อมูล
                conn.Open();
                // รันคำสั่ง SQL เพื่ออัปเดตข้อมูลในตาราง all order
                cmd1.ExecuteNonQuery();

                conn.Close();

                // เคลียร์ข้อมูลใน TextBox
                textBox1.Clear();
                textBox2.Clear();
                tbusername.Clear();
                textBox3.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการแก้ไขข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        //เหตุการณ์เมื่อคลิ๊ก
        private void dataEquiment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ตรวจสอบว่าเลือกแถวที่มีข้อมูล
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.CurrentRow.Selected = true;

                // ดึงข้อมูลจากเซลล์แต่ละคอลัมน์ในแถวที่เลือกมาแสดงใน TextBox
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Tel"].FormattedValue.ToString();
                tbusername.Text = dataGridView1.Rows[e.RowIndex].Cells["Username"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Password"].FormattedValue.ToString();


            }
        }

        private void LoadNames() 
        {
            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();
                // Query เพื่อดึงชื่อผู้ใช้ทั้งหมดจากฐานข้อมูล
                MySqlCommand cmd = new MySqlCommand("SELECT Name FROM `user`", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                // เติมข้อมูลใน ComboBox
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("Name"));
                }

                // ตั้งค่า AutoCompleteMode และ AutoCompleteSource ให้กับ ComboBox
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadUsernames()
        {
            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();
                // Query เพื่อดึงชื่อผู้ใช้ทั้งหมดจากฐานข้อมูล
                MySqlCommand cmd = new MySqlCommand("SELECT Username FROM `user`", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                // เติมข้อมูลใน ComboBox
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("Username"));
                }

                // ตั้งค่า AutoCompleteMode และ AutoCompleteSource ให้กับ ComboBox
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

      

        private void LoadTel()
        {
            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();
                // Query เพื่อดึงชื่อผู้ใช้ทั้งหมดจากฐานข้อมูล
                MySqlCommand cmd = new MySqlCommand("SELECT Tel FROM `user`", conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                // เติมข้อมูลใน ComboBox
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("Tel"));
                }

                // ตั้งค่า AutoCompleteMode และ AutoCompleteSource ให้กับ ComboBox
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

       

        private void comboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            tbusername.Clear();
            textBox3.Clear();

            comboBox1.Text = "";

            if (comboBox.SelectedIndex == 0)
            {
                comboBox1.Items.Clear();
                LoadNames();

            }
            else if (comboBox.SelectedIndex == 1)
            {
                comboBox1.Items.Clear();
                LoadUsernames();
            }
            else if (comboBox.SelectedIndex == 2)
            {
                comboBox1.Items.Clear();
                LoadTel();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            tbusername.Clear();
            textBox3.Clear();

        }

        private void button1_Click(object sender, EventArgs e)  //ปุ่มค้นหา
        {
            string searchValue = comboBox1.Text;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("กรุณาเลือกหรือพิมพ์ข้อมูลสำหรับการค้นหา");
                return;
            }

            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();
                // Query เพื่อดึงข้อมูลที่เกี่ยวข้องกับ Username หรือ Tel
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM `user` WHERE `Name` = @searchValue OR `Username` = @searchValue OR `Tel` = @searchValue",
                    conn
                );
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                DataTable dt = new DataTable();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                // ตรวจสอบว่ามีข้อมูลที่แสดงหรือไม่
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ตรงกัน");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            management form2 = new management(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }
    }
}
