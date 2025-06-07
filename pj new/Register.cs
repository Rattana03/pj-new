using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace pj_new
{
    public partial class Register : Form
    {
        


        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=Bingsu;";

            MySqlConnection conn = new MySqlConnection(connectionstring);

            return conn;
        }

        public Register()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }



        private void Register_Load(object sender, EventArgs e)
        {
           


        }


        private void btnsave_Click_1(object sender, EventArgs e) //ปุ่ม register
        {
            // ตรวจสอบความถูกต้องของข้อมูลที่ผู้ใช้กรอกเข้ามา
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(tb_us.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบทุกช่อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(textBox2.Text, out _))
            {
                MessageBox.Show("เบอร์โทรศัพท์ต้องเป็นตัวเลขเท่านั้น", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!textBox2.Text.StartsWith("0") || textBox2.Text.Length != 10)
            {
                MessageBox.Show("เบอร์โทรต้องขึ้นต้นด้วย 0 และต้องมีความยาว 10 ตัว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBox1.Text.Length < 6)
            {
                MessageBox.Show("รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();

                // ตรวจสอบว่า Username ซ้ำหรือไม่
                string checkUsernameSql = "SELECT COUNT(*) FROM user WHERE Username = @Username";
                MySqlCommand checkUsernameCmd = new MySqlCommand(checkUsernameSql, conn);
                checkUsernameCmd.Parameters.AddWithValue("@Username", tb_us.Text);

                if (Convert.ToInt32(checkUsernameCmd.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("Username นี้มีอยู่ในระบบแล้ว กรุณาเปลี่ยน Username", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ตรวจสอบว่า Tel ซ้ำหรือไม่
                string checkTelSql = "SELECT COUNT(*) FROM user WHERE Tel = @Tel";
                MySqlCommand checkTelCmd = new MySqlCommand(checkTelSql, conn);
                checkTelCmd.Parameters.AddWithValue("@Tel", textBox2.Text);

                if (Convert.ToInt32(checkTelCmd.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("เบอร์โทรนี้มีอยู่ในระบบแล้ว กรุณาเปลี่ยนเบอร์โทร", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ตรวจสอบว่า Password ซ้ำหรือไม่
                string checkPasswordSql = "SELECT COUNT(*) FROM user WHERE Password = @Password";
                MySqlCommand checkPasswordCmd = new MySqlCommand(checkPasswordSql, conn);
                checkPasswordCmd.Parameters.AddWithValue("@Password", textBox1.Text);

                if (Convert.ToInt32(checkPasswordCmd.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("รหัสผ่านนี้มีอยู่ในระบบแล้ว กรุณาเปลี่ยนรหัสผ่าน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // แสดง MessageBox เพื่อยืนยันการสมัคร
                DialogResult result = MessageBox.Show("ยืนยันการสมัคร", "ยืนยัน", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    string sql = "INSERT INTO user (Name,Tel,Username,Password) VALUES (@Name, @Tel, @Username, @Password)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Tel", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Username", tb_us.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox1.Text);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("สมัครเรียบร้อย");

                        textBox3.Clear();
                        textBox2.Clear();
                        tb_us.Clear();
                        textBox1.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            this.Hide();
            
            login form2 = new login(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

       
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }




        private void back_re_Click(object sender, EventArgs e)
        {

            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            login form2 = new login(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

        private void tb_us_TextChanged(object sender, EventArgs e)
        {

        }
    }
}