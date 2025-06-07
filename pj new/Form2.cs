using MySql.Data.MySqlClient;
using Mysqlx.Notice;
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
    public partial class login : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=bingsu;";

            MySqlConnection conn = new MySqlConnection(connectionstring);

            return conn;
        }

        public string Username { get; set; }
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            


        }

        private void g_login_Enter(object sender, EventArgs e)
        {
            
        }

        private void tb_us_TextChanged(object sender, EventArgs e)
        {

        }

        private void la_pass_Click(object sender, EventArgs e)
        {

        }

        private void tb_pw_TextChanged(object sender, EventArgs e)
        {

        }

        private bool CheckUsername(string username) //เช็ค username
        {
            MySqlConnection conn = databaseConnection();
            string sql = "SELECT * FROM user WHERE Username = @Username ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Username", username);


            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            bool found = reader.Read(); // ถ้าพบข้อมูล user จะ return true ถ้าไม่พบจะ return false
            conn.Close();

            return found;
        }

        // เมธอดสำหรับเช็คข้อมูลลูกค้าในฐานข้อมูล
        private bool CheckUser(string username, string password)
        {
            MySqlConnection conn = databaseConnection();
            string sql = "SELECT * FROM user WHERE Username = @Username AND Password = @Password";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            bool found = reader.Read(); // ถ้าพบข้อมูล user จะ return true ถ้าไม่พบจะ return false
            conn.Close();

            return found;
        }


        //ปุ่ม login
        private void but_log_Click(object sender, EventArgs e)
        {
            string username = tb_us.Text;
            string password = tb_pw.Text;

            // ตรวจสอบว่าเป็น admin หรือไม่
            if (username == "admin" && password == "000000")
            {
                tb_us.Clear(); // เคลียร์ textbox
                tb_pw.Clear();

                this.Hide();
                // เปิดหน้า admin
                management adminForm = new management(); // สมมติว่าฟอร์มของ admin ชื่อ AdminForm
                adminForm.ShowDialog();
                // แสดงหน้า login อีกครั้งหลังจากปิดหน้า admin
                this.Close();
            }
            else
            {
                // ตรวจสอบว่ารหัสผ่านมีความยาวอย่างน้อย 6 ตัวอักษร
                if (password.Length < 6)
                {
                    MessageBox.Show("รหัสผ่านต้องมีความยาวอย่างน้อย 6 ตัวอักษร", "แจ้งเตือน");
                    tb_pw.Clear();
                    return;
                }
                if (CheckUsername(username)) // ตรวจสอบว่ามี username ในฐานข้อมูลหรือไม่
                {
                    if (CheckUser(username,password)) // ตรวจสอบว่ารหัสผ่านตรงกับ username หรือไม่
                    {
                        tb_us.Clear(); // เคลียร์ textbox
                        tb_pw.Clear();

                        this.Hide();
                        // เปิดหน้าเมนู
                        Form3 form2 = new Form3();
                        form2.Username = username; // ส่งค่า username ไปยัง Form3
                        form2.ShowDialog();
                        // แสดงหน้า login อีกครั้งหลังจากปิดหน้าเมนู
                        this.Close();
                    }
                    else
                    {
                        // แสดง MessageBox แจ้งเตือนว่ารหัสผ่านไม่ถูกต้อง
                        MessageBox.Show("รหัสผ่านไม่ถูกต้อง", "แจ้งเตือน");

                        tb_pw.Clear();
                    }
                }
                else
                {
                    // แสดง MessageBox แจ้งเตือนว่าไม่มีข้อมูลลูกค้า
                    MessageBox.Show("ไม่มีข้อมูลลูกค้า", "แจ้งเตือน");

                    tb_us.Clear();
                    tb_pw.Clear();
                }

            }



        }




        private void but_re_Click(object sender, EventArgs e) //สมัตรสมาชิก
        {

            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            Register form2 = new Register(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

        private void back_L_Click(object sender, EventArgs e)
        {

            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            Form1 form2 = new Form1(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }
    }
}
