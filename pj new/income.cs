using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pj_new
{
    public partial class income : Form
    {
        //DataTable dt = new DataTable();
        //string connectionString = "Server=localhost\\SQLEXPRESS;Database=YourDatabaseName;User Id=YourUsername;Password=YourPassword;";
        // Connection string สำหรับเชื่อมต่อกับฐานข้อมูล
        //private string connectionString1 = "your_connection_string_here";

        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=bingsu;";

            MySqlConnection conn = new MySqlConnection(connectionstring);

            return conn;
        }

        public income()
        {
            InitializeComponent();
            

        }



        private void income_Load(object sender, EventArgs e)
        {
            
        }


        private void dataincome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void textBoxdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e) //ปุ่มค้นหา
        {
            if (comboBox1.SelectedIndex == 0)// ปุ่มค้นหา username
            {
                MySqlConnection conn = databaseConnection(); // ทำการเลือกข้อมูลและเลือกแถวโดยอิงจาก username
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `all order` WHERE username = @username", conn);
                cmd.Parameters.AddWithValue("@username", textBoxusername.Text);  // เอาค่าใน textbox ไปใส่ใน username
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    dataincome.DataSource = dt; // สร้างตารางแล้วเอา db เข้าตาราง
                }
                catch (MySqlException ex)  // ตรวจจับ error
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally // ถ้าสำเร็จจะทำการปิด db
                {
                    conn.Close();
                }
                int total = 0;  //ประกาศตัวแปร total ชนิด double เพื่อเก็บผลรวมของค่าที่จะคำนวณในลูปถัดไป
                foreach (DataGridViewRow r in dataincome.Rows) //ดึงตารางจากข้อมูลมาเรื่อย ๆ
                {
                    {
                        total += Convert.ToInt32(r.Cells["Total"].Value);// บวกคอลลัมProduct_totalในตารางไปเรื่อยๆ 
                    }

                }
                int vat = (total * 7) / 100;
                txttotal.Text = (vat + total).ToString();
                //best_selling();
            }
            else if (comboBox1.SelectedIndex == 1)   // ค้นวันเดือนปี
            {
                //สร้างการเชื่อมต่อกับฐานข้อมูล:
                MySqlConnection conn = databaseConnection();  //เก็บข้อมูลเข้า cmd
                //สร้างคำสั่ง SQL เพื่อดึงข้อมูลจากตาราง history ตามวัน เดือน และปี ที่กำหนดใน textBox3, textBox4, และ textBox5 ตามลำดับ โดยใช้พารามิเตอร์ @day, @month, และ @year
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `all order` WHERE date = @date ", conn);
                cmd.Parameters.AddWithValue("@day", txtdate.Text);
                cmd.Parameters.AddWithValue("@month", textBoxmonth.Text);
                cmd.Parameters.AddWithValue("@year", textBoxyear.Text);
                //สร้าง DataTable เพื่อเก็บผลลัพธ์ของการคิวรีจากฐานข้อมูล
                DataTable dt = new DataTable(); 
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    //ตั้งค่า DataGridView dataGridView2 เพื่อแสดงผลลัพธ์จาก DataTable
                    dataincome.DataSource = dt;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                double total = 0;  //ประกาศตัวแปร total ชนิด double เพื่อเก็บผลรวมของค่าที่จะคำนวณในลูปถัดไป
                foreach (DataGridViewRow r in dataincome.Rows)
                {
                    {
                        // แปลงค่า Product total เป็นตัวเลขแล้วมาบวกเข้า tatal
                        total += Convert.ToInt32(r.Cells["Total"].Value);  // บวกคอลลัมProduct_totalในตารางไปเรื่อยๆ 
                    }

                }
                double vat = (total * 7) / 100;

                txttotal.Text = (vat + total).ToString();
                //best_selling(); // โชว์สินค้าที่ขายดี

            }
            else if (comboBox1.SelectedIndex == 2)   // เลือกเดือน
            {
                MySqlConnection conn = databaseConnection();  //เลือกจาก history โดยอิงจากเดือนและปี
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `all order` WHERE month = @month AND year = @year", conn);
                cmd.Parameters.AddWithValue("@month", textBoxmonth.Text);
                cmd.Parameters.AddWithValue("@year", textBoxyear.Text);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);  //ดึงมาจาก reader  และเก็บไว้ในตาราง db
                    dataincome.DataSource = dt;
                }
                catch (MySqlException ex)    // เช็ค error
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                double total = 0;  //ประกาศตัวแปร total ชนิด double เพื่อเก็บผลรวมของค่าที่จะคำนวณในลูปถัดไป
                foreach (DataGridViewRow r in dataincome.Rows)
                {
                    {
                        // แปลงค่า Product total เป็นตัวเลขแล้วมาบวกเข้า tatal
                        total += Convert.ToInt32(r.Cells["Total"].Value);
                    }

                }
                double vat = (total * 7) / 100;

                txttotal.Text = (vat + total).ToString();
               // best_selling();  // คำนวนและโชว์สินค้าขายดี

            }
            else if (comboBox1.SelectedIndex == 3)   //การเลือกปี
            {
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `all order` WHERE year = @year", conn);
                cmd.Parameters.AddWithValue("@year", textBoxyear.Text); // ใส่ปี
                DataTable dt = new DataTable();  //สร้างตัวแปรที่เอาไว้เรียกตาราง
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader); //ดึงมาจาก reader  และเก็บไว้ในตาราง db
                    dataincome.DataSource = dt;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                double total = 0;  //ประกาศตัวแปร total ชนิด double เพื่อเก็บผลรวมของค่าที่จะคำนวณในลูปถัดไป
                foreach (DataGridViewRow r in dataincome.Rows)
                {
                    {
                        // แปลงค่า Product total เป็นตัวเลขแล้วมาบวกเข้า tatal
                        total += Convert.ToInt32(r.Cells["Total"].Value);
                    }

                }
                double vat = (total * 7) / 100;

                txttotal.Text = (vat + total).ToString();
                //best_selling();  // คำนวนและโชว์สินค้าขายดี


            }
            else if (comboBox1.SelectedIndex == 4)   // ค้นหาจากเลขของบิล
            {
                //MySqlConnection conn = databaseConnection();
                //MySqlCommand cmd = new MySqlCommand("SELECT * FROM history WHERE billnum = @billnum", conn);
                //cmd.Parameters.AddWithValue("@billnum", textBox1.Text); //ให้ใส่เลขบิล
                //DataTable dt = new DataTable(); //สร้างตัวแปรที่เอาไว้เรียกตาราง
                //try
                //{
                //    conn.Open();  //ประกาศตัวแปร total ชนิด double เพื่อเก็บผลรวมของค่าที่จะคำนวณในลูปถัดไป
                //    MySqlDataReader reader = cmd.ExecuteReader();
                //    dt.Load(reader);
                //    dataincome.DataSource = dt;
                //}
                //catch (MySqlException ex)
                //{
                //    MessageBox.Show("Error: " + ex.Message);
                //}
                //finally
                //{
                //    conn.Close();
                //}
                //double total = 0;   //ประกาศตัวแปร total ชนิด double เพื่อเก็บผลรวมของค่าที่จะคำนวณในลูปถัดไป
                //foreach (DataGridViewRow r in dataincome.Rows)
                //{
                //    {
                //        // แปลงค่า Product total เป็นตัวเลขแล้วมาบวกเข้า tatal
                //        total += Convert.ToDouble(r.Cells["Product_total"].Value);
                //    }

                //}
                //double vat = (total * 7) / 100;

                //txttotal.Text = (vat + total).ToString();
                ////best_selling(); // คำนวนและโชว์สินค้าขายดี
            }


        



    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBoxusername.Text = "username";  //กดเลือกชื่อในคอมโบบ็อก จะขึ้นแค่ให้กรอกชื่อ
                txtdate.Visible = false;
                textBoxmonth.Visible = false;
                textBoxyear.Visible = false;
                textBoxusername.Visible = true;

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                txtdate.Text = "31";  //กดเลือกชื่อวันโบบ็อก จะขึ้นแค่ให้กรอกวันเดือนปี
                txtdate.Visible = true;
                textBoxmonth.Text = "01";
                textBoxmonth.Visible = true;
                textBoxyear.Visible = true;
                textBoxyear.Text = "2024";
                textBoxusername.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 2)
            {

                txtdate.Visible = false;    //กดเลือกเดือนโบบ็อก จะขึ้นแค่ให้กรอกเดือนปี
                textBoxmonth.Visible = true;
                textBoxmonth.Text = "01";
                textBoxyear.Visible = true;
                textBoxyear.Text = "2024";
                textBoxyear.Visible = false;

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                textBoxusername.Text = "2024";    //กดเลือกปีโบบ็อก จะขึ้นแค่ให้กรอกปี
                txtdate.Visible = false;
                textBoxmonth.Visible = false;
                textBoxyear.Visible = true;
                textBoxyear.Text = "2024";
                textBoxusername.Visible = false;

            }

        }
    }
}
