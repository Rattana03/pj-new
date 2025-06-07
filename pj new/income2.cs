using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Image = System.Drawing.Image;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace pj_new
{
    public partial class income2 : Form
    {
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=bingsu;charset=utf8;";  // เพิ่ม charset=utf8 เพื่อรองรับภาษาไทย

        private MySqlConnection databaseConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public income2()
        {
            InitializeComponent();
            
            LoadUsernames();
           

        }

        private void income2_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `all order` ", conn);

            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                dtgincome.DataSource = dt;

                // ตรวจสอบว่ามีข้อมูลที่แสดงหรือไม่
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("ไม่มีข้อมูลที่ตรงกัน");
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

            double total = 0;
            HashSet<string> uniqueBills = new HashSet<string>(); // ตรวจสอบว่าหมายเลขบิล (BillNumber) ซ้ำหรือไม่
            Dictionary<string, int> productSales = new Dictionary<string, int>(); //เก็บข้อมูลจำนวนสินค้าที่ขายแต่ละประเภท



            foreach (DataGridViewRow r in dtgincome.Rows)
            {
                // ตรวจสอบว่าเซลล์ในคอลัมน์ "BillNumber" และ "Total" ไม่เป็น null
                if (r.Cells["BillNumber"].Value != null && r.Cells["BillNumber"].Value != DBNull.Value &&
                    r.Cells["total"].Value != null && r.Cells["total"].Value != DBNull.Value)
                {
                    string billNumber = r.Cells["BillNumber"].Value.ToString();
                    string productName = r.Cells["order"].Value.ToString();  // ชื่อสินค้าที่ขาย
                    int quantity = Convert.ToInt32(r.Cells["amount"].Value); // จำนวนสินค้าที่ขาย

                    // ตรวจสอบว่าถ้าหมายเลขบิล ถ้าหมายเลขบิล ยังไม่ถูกนับ
                    if (!uniqueBills.Contains(billNumber))
                    {
                        // แปลงค่าในเซลล์ "total" เป็นตัวเลข และเพิ่มเข้าไปในยอดรวม
                        total += Convert.ToDouble(r.Cells["total"].Value);
                        uniqueBills.Add(billNumber); // เพิ่มหมายเลขบิลเข้าไปใน HashSet
                    }
                    // นับจำนวนสินค้าที่ขาย ถ้าสินค้านั้น มีอยู่ใน Dictionary แล้วเพิ่มจำนวนสินค้าเข้าไป
                    if (productSales.ContainsKey(productName))
                    {
                        productSales[productName] += quantity; //บวกค่า quantity (จำนวนสินค้าที่ขาย) เข้าไปใน productSales[productName]
                    }
                    else
                    {
                        productSales[productName] = quantity;
                    }
                }
            }

            textBoxtotal.Text = total.ToString("N2");  // แสดงยอดรวมใน textBoxtotal

            // หาสินค้าที่ขายดีที่สุด   เพื่อเรียงสินค้าตามจำนวนที่ขายมากไปน้อย จากนั้นดึงชื่อสินค้าที่ยอดขายมากที่สุดออกมา
            string bestSellingProduct = productSales.OrderByDescending(p => p.Value).First().Key;

            //แสดงภาพสินค้าที่ขายดีที่สุดใน PictureBox
            best_selling();
        }

        


        private void ShowBestSellingProductImage(string productName) //โชว์รูปสินค้าขายดี
        {
            // ค้นหาเส้นทางของภาพจากฐานข้อมูลหรือ DataGridView
            MySqlConnection conn = databaseConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT Picture FROM `stockbingsu` WHERE `Menu` = @productName LIMIT 1", conn);
            cmd.Parameters.AddWithValue("@productName", productName);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result is byte[])
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //วนลูปผ่านผลลัพธ์ของการคิวรีและแปลงข้อมูลภาพ:
                    while (reader.Read())
                    {
                        byte[] productImageBytes = (byte[])reader["Picture"];  //อ่านจากpicเก็บไว้ในตัวแปร productImageBytes 
                        if (productImageBytes != null && productImageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(productImageBytes))
                            {
                                Image productImage = Image.FromStream(ms);
                                pictureBox1.Image = productImage;
                            }
                            // แสดงชื่อสินค้าใน TextBox
                            textBox2.Text = productName;
                        }

                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบภาพสำหรับสินค้าที่ขายดีที่สุด");
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




        private void dtgincome_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        // ฟังก์ชันที่เรียกใช้เมื่อพิมพ์ใน TextBox เพื่อค้นหา Username
        private void tbusername_TextChanged(object sender, EventArgs e)
        {
            //SearchUsernames(tbusername.Text);
        }

        // ฟังก์ชันโหลดชื่อผู้ใช้จากฐานข้อมูลลงใน ComboBox
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
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend; //เมื่อพิมพ์ค้นหาขึ้นมูลที่ตรงกัน
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

        private void best_selling()  // ฟังก์ชันคำนวณยอดขายและจัดอันดับสินค้าขายดี
        {
            double total = 0;
            HashSet<string> uniqueBills = new HashSet<string>(); // ใช้เก็บบิลที่ไม่ซ้ำกัน
            Dictionary<string, int> productSales = new Dictionary<string, int>(); // ใช้เก็บจำนวนการขายของแต่ละสินค้า

            foreach (DataGridViewRow r in dtgincome.Rows)
            {
                // ตรวจสอบว่าเซลล์ในคอลัมน์ "BillNumber", "order" และ "amount" ไม่เป็น null
                if (r.Cells["BillNumber"].Value != null && r.Cells["BillNumber"].Value != DBNull.Value &&
                    r.Cells["total"].Value != null && r.Cells["total"].Value != DBNull.Value &&
                    r.Cells["order"].Value != null && r.Cells["order"].Value != DBNull.Value &&
                    r.Cells["amount"].Value != null && r.Cells["amount"].Value != DBNull.Value)
                {
                    string billNumber = r.Cells["BillNumber"].Value.ToString();
                    string productName = r.Cells["order"].Value.ToString();  // ชื่อสินค้าที่ขาย
                    int quantity = Convert.ToInt32(r.Cells["amount"].Value); // จำนวนสินค้าที่ขาย

                    // ตรวจสอบว่าหมายเลขบิลยังไม่ได้ถูกนับรวม //ถ้าหมายเลขบิล (billNumber) ยังไม่เคยถูกนับ
                    if (!uniqueBills.Contains(billNumber))
                    {
                        

                        // นำยอดขาย (total) ของบิลนั้นมารวม
                        total += Convert.ToDouble(r.Cells["total"].Value);
                        uniqueBills.Add(billNumber); // เพิ่มหมายเลขบิลเข้าไปใน HashSet
                    }

                    // นับจำนวนสินค้าที่ขาย ถ้าสินค้านั้น มีอยู่ใน Dictionary แล้วเพิ่มจำนวนสินค้าเข้าไป
                    if (productSales.ContainsKey(productName))
                    {
                        productSales[productName] += quantity; //บวกค่า quantity (จำนวนสินค้าที่ขาย) เข้าไปใน productSales[productNam
                    }
                    else
                    {
                        productSales[productName] = quantity;
                    }
                }
            }

            // แสดงยอดรวมใน textBoxtotal
            textBoxtotal.Text = total.ToString("N2");

            // จัดอันดับสินค้าตามจำนวนที่ขายได้
            var top3Products = productSales
                .OrderByDescending(p => p.Value) // เรียงลำดับจากมากไปน้อย
                .Take(3) // เอาเฉพาะ 3 อันดับแรก
                .Select((p, index) => new
                {
                    Rank = index + 1, // อันดับ 1, 2, 3
                    ProductName = p.Key, // ชื่อสินค้า
                    QuantitySold = p.Value // จำนวนที่ขายได้
                })
                .ToList();

            // แปลงข้อมูลเป็น DataTable เพื่อแสดงใน DataGridView
            DataTable dtBestSelling = new DataTable();
            dtBestSelling.Columns.Add("Rank", typeof(int));  //ทำการเพิ่มคอลัมอันดับ
            dtBestSelling.Columns.Add("ProductName", typeof(string));
            dtBestSelling.Columns.Add("QuantitySold", typeof(int));

            foreach (var product in top3Products)
            {
                dtBestSelling.Rows.Add(product.Rank, product.ProductName, product.QuantitySold);
            }

            dataGridViewbest.DataSource = dtBestSelling;

            // ตรวจสอบว่ามีสินค้าขายดีหรือไม่
            if (top3Products.Any())
            {
                ShowBestSellingProductImage(top3Products.First().ProductName);
            }
        }


        private void buttonSearch_Click(object sender, EventArgs e) //ปุ่มค้นหา
        {
            if (comboBox.SelectedIndex == 0)
            {
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `all order` WHERE username = @username", conn);
                cmd.Parameters.AddWithValue("@username", comboBox1.Text);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    dtgincome.DataSource = dt;
                    // ตรวจสอบว่ามีข้อมูลที่แสดงหรือไม่
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("ไม่มีข้อมูลที่ตรงกัน");
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


                best_selling();

            }
            else if (comboBox.SelectedIndex == 1)
            {
                MySqlConnection conn = databaseConnection();

                // ตรวจสอบว่าผู้ใช้กรอกวันที่ เดือน ปี ครบถ้วนหรือไม่
                if (string.IsNullOrWhiteSpace(textBoxdate.Text) ||
                    string.IsNullOrWhiteSpace(textBoxmount.Text) ||
                    string.IsNullOrWhiteSpace(textBoxyear.Text))
                {
                    MessageBox.Show("กรุณากรอกวันที่ เดือน และปีให้ครบถ้วน");
                    return;
                }

                // ตรวจสอบความถูกต้องของวันที่และเดือน
                if (!int.TryParse(textBoxdate.Text, out int day) || day < 1 || day > 31 ||
                    !int.TryParse(textBoxmount.Text, out int month) || month < 1 || month > 12 ||
                    !int.TryParse(textBoxyear.Text, out int year))
                {
                    MessageBox.Show("กรุณากรอกวันที่ เดือน และปีให้ถูกต้อง");
                    return;
                }

                // แปลงวันที่เป็นรูปแบบ YYYY-MM-DD สำหรับการค้นหาในฐานข้อมูล
                string dateString = $"{year:D4}-{month:D2}-{day:D2}";

                // SQL query สำหรับดึงข้อมูลจากตาราง 'all order' ที่มีวันที่ตรงกับวันที่ที่ผู้ใช้กรอก
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM `all order` WHERE DATE(date) = @date",
                    conn
                );
                cmd.Parameters.AddWithValue("@date", dateString);

                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    dtgincome.DataSource = dt;

                    // ตรวจสอบว่ามีข้อมูลที่แสดงหรือไม่
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("ไม่มีข้อมูลที่ตรงกัน");
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


                best_selling();

            }
            else if (comboBox.SelectedIndex == 2)
            {
                MySqlConnection conn = databaseConnection();

                // ตรวจสอบความถูกต้องของเดือน
                if (!int.TryParse(textBoxmount.Text, out int month) || month < 1 || month > 12)
                {
                    MessageBox.Show("กรุณากรอกเดือนให้ถูกต้อง (1-12)");
                    return;
                }

                // ตรวจสอบความถูกต้องของปี
                if (!int.TryParse(textBoxyear.Text, out int year))
                {
                    MessageBox.Show("กรุณากรอกปีให้ถูกต้อง");
                    return;
                }

                // คำสั่ง SQL สำหรับดึงข้อมูลตามเดือนและปีจากฐานข้อมูล
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT * FROM `all order` WHERE MONTH(date) = @month AND YEAR(date) = @year",
                    conn
                );

                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    dtgincome.DataSource = dt;

                    // ตรวจสอบว่ามีข้อมูลที่แสดงหรือไม่
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("ไม่มีข้อมูล");
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


                best_selling();

            }
            else if (comboBox.SelectedIndex == 3)
            {
                if (int.TryParse(textBoxyear.Text, out int year))
                {
                    MySqlConnection conn = databaseConnection();
                    if (conn == null)
                    {
                        MessageBox.Show("Database connection is not initialized.");
                        return;
                    }

                    // ปรับคำสั่ง SQL เพื่อกรองข้อมูลเฉพาะปี
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `all order` WHERE YEAR(date) = @year", conn);
                    cmd.Parameters.AddWithValue("@year", year);
                    DataTable dt = new DataTable();

                    try
                    {
                        conn.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                        dtgincome.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("ไม่มีข้อมูลที่ตรงกัน");
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
                best_selling();
            }
               

                // ตรวจสอบว่ามีแถวใน DataGridView หรือไม่
            /*if (dtgincome.Rows.Count > 0)
                {
                    // นำชื่อเมนูจากแถวแรกมาแสดงใน TextBox
                    textBox2.Text = dtgincome.Rows[0].Cells["order"].Value.ToString();

                    // นำภาพจากแถวแรกมาแสดงใน PictureBox
                    if (dtgincome.Rows[0].Cells["Picture"].Value is System.Drawing.Image img)
                    {
                        pictureBox1.Image = img;
                    }
                }
            else
                {
                    MessageBox.Show("ไม่มีข้อมูลใน DataGridView");
            }
            */

            
        
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                comboBox1.Text = "username";  //กดเลือกชื่อในคอมโบบ็อก จะขึ้นแค่ให้กรอกชื่อ
                textBoxdate.Visible = false;   //ซ่อน
                textBoxmount.Visible = false;
                textBoxyear.Visible = false;
                comboBox1.Visible = true;  //แสดง

            }
            else if (comboBox.SelectedIndex == 1)
            {
                textBoxdate.Text = "31";  //กดเลือกชื่อวันโบบ็อก จะขึ้นแค่ให้กรอกวันเดือนปี
                textBoxdate.Visible = true;
                textBoxmount.Text = "01";
                textBoxmount.Visible = true;
                textBoxyear.Visible = true;
                textBoxyear.Text = "2024";
                comboBox1.Visible = false;
            }
            else if (comboBox.SelectedIndex == 2)
            {

                textBoxdate.Visible = false;    //กดเลือกเดือนโบบ็อก จะขึ้นแค่ให้กรอกเดือนปี
                textBoxmount.Visible = true;
                textBoxmount.Text = "01";
                textBoxyear.Visible = true;
                textBoxyear.Text = "2024";
                comboBox1.Visible = false;

            }
            else if (comboBox.SelectedIndex == 3)
            {
                comboBox1.Text = "2024";    //กดเลือกปีโบบ็อก จะขึ้นแค่ให้กรอกปี
                textBoxdate.Visible = false;
                textBoxmount.Visible = false;
                textBoxyear.Visible = true;
                textBoxyear.Text = "2024";
                comboBox1.Visible = false;

            }


        }

       
        //ค้นหาข้อมูลจากฐานข้อมูลตาม username ที่กรอกใน textBox1 
        //แล้วนำข้อมูลมาแสดงใน dataGridView2 หากข้อมูลไม่ตรงกัน จะแสดงกล่องข้อความแจ้งเตือน
        //คำนวณยอดรวมจากบิลที่ไม่ซ้ำกันและแสดงยอดรวมใน textBox6
        private void button1_Click(object sender, EventArgs e) //ค้นหาข้อมูล
        {
            

        }

        private void textBoxdate_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxtyear_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxtotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxusername_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgincome_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void back_L_Click(object sender, EventArgs e)
        {
            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            management form2 = new management(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

        private void dataGridViewbest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    

        
}

