using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;




namespace pj_new
{
    public partial class Form3 : Form
    {
        public string Username { get; set; }

        public Form3()
        {
            InitializeComponent();

        }

        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=bingsu;";

            MySqlConnection conn = new MySqlConnection(connectionstring);

            return conn;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // ใช้ค่า Username ตามต้องการ
            textBox_name.Text = Username;

            showcart();
            LoadProductButtons();
            // หลังจากเพิ่มสินค้าแล้วให้คำนวณราคารวมและแสดงผล
           
            UpdateTotalPrice();

        }

        private void showcart() //โชว์ตะกร้าใน datagridview
        {
            MySqlConnection conn = databaseConnection();

            DataSet ds = new DataSet();

            MySqlCommand cmd; 

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT name_bingsu, amount, price, totalprice FROM cart WHERE username = @username";
            cmd.Parameters.AddWithValue("@username", textBox_name.Text);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            datacart.DataSource = ds.Tables[0].DefaultView;

        }

        private const int BUTTON_WIDTH = 170;
        private const int BUTTON_HEIGHT = 170;
        private const int BUTTON_PADDING = 40;

        private void LoadProductButtons(string query = null) //ฟังก์ชันนี้จะโหลดข้อมูลสินค้า
        {
            string connectionString = "server=localhost;user=root;password=;database=bingsu"; //เชื่อมต่อกับฐานข้อมูล
            if (query == null)
            {
                query = "SELECT Id, Menu, Price, Picture FROM stockbingsu";
            }

            int buttonCount = 0;  //เก็บจำนวนปุ่มที่ถูกสร้างขึ้น
            int currentRow = 0;  //เก็บค่าของแถวปัจจุบันที่ปุ่มถูกแสดงอยู่

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(0);   //อ่านค่าจากคอลัมน์แรกในผลลัพธ์ของ query ซึ่งมีลำดับเป็น 0
                        string productName = reader.GetString(1);  //อ่านค่าจากคอลัมน์ที่สองในผลลัพธ์ของ query ซึ่งมีลำดับเป็น 1 
                        decimal productPrice = reader.GetDecimal(2);

                        byte[] productImageBytes = (byte[])reader["Picture"];  //อ่านจากpicเก็บไว้ในตัวแปร productImageBytes 

                        //สร้างอ็อบเจกต์ของคลาส PictureBox 
                        PictureBox bg_product = new PictureBox();
                        bg_product.Size = new Size(BUTTON_WIDTH + 15, BUTTON_HEIGHT + 40);
                        bg_product.BackColor = Color.White;

                        //ปุ่มเลือกซื้อ
                        Button productButton = new Button();
                        productButton.Size = new Size(100, 25);
                        productButton.Text = productName; // + "\n" + productPrice.ToString("C2");
                        productButton.Tag = productId;
                        productButton.Click += productButton_Click;  //เชื่อมโยงเหตุการณ์คลิก
                        productButton.ForeColor = Color.Red;
                        productButton.BackColor = Color.White;


                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Size = new Size(BUTTON_WIDTH, BUTTON_WIDTH);
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;  //ปรับขนาดของภาพให้พอดีกับกรอบโดยคงอัตราส่วนเดิม
                        pictureBox.BackColor = Color.Black;

                        //เช็คว่าตัวแปร productImageBytes ไม่เท่ากับ null และมีความยาว (length) มากกว่าศูนย์
                        if (productImageBytes != null && productImageBytes.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(productImageBytes))
                            {
                                Image productImage = Image.FromStream(ms);
                                pictureBox.Image = productImage;
                            }
                        }
                        //กำหนดตำแหน่งของpictureBox
                        int x = (BUTTON_WIDTH + BUTTON_PADDING) * (buttonCount % 3);  //คำนวณx มี3แถว
                        int y = (BUTTON_WIDTH + BUTTON_PADDING + 25) * currentRow;   //คำนวณy currentRow คือตัวนับแถว
                        pictureBox.Location = new Point(x + 25, y + 30);
                        panel1.Controls.Add(pictureBox); //เพิ่ม pictureBox ลงใน panel1
                                                         //กำหนดตำแหน่งปุ่ม
                        int buttonX = x + 35;
                        int buttonY = y + BUTTON_WIDTH + 10;
                        productButton.Location = new Point(28 + buttonX, buttonY + 22); //กำหนดตำแหน่งของปุ่ม button
                        panel1.Controls.Add(productButton);
                        //กำหนดตำแหน่งและเพิ่ม bg_product (PictureBox ที่เป็นพื้นหลัง) เข้าไปใน panel1
                        int bgx = (BUTTON_WIDTH + BUTTON_PADDING) * (buttonCount % 3);
                        int bgy = (BUTTON_WIDTH + BUTTON_PADDING + 25) * currentRow;
                        bg_product.Location = new Point(x + 17, y + 20);
                        panel1.Controls.Add(bg_product);

                        panel1.AutoScroll = true;

                        //เพิ่มจำนวนปุ่มและการเพิ่มแถวในการจัดวาง
                        buttonCount++;
                        if (buttonCount % 3 == 0)
                        {
                            currentRow++;
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)  //จัดการข้อผิดพลาด
                {
                    MessageBox.Show("Error: " + ex.Message);  //ตามด้วยข้อความข้อผิดพลาด
                }
            }

        }



        //////////////////////////////////////////////////////////////////////////////////////////
        // ตัวแปรเก็บชื่อเมนูที่ถูกคลิก
        private string selectedProductName;
        private int selectedProductID;
        private string selectedProductImagePath;
        

        // Event handler สำหรับคลิกที่ปุ่มเมนู
        private void productButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            selectedProductName = clickedButton.Text; // เก็บชื่อเมนูที่ถูกคลิก
           

        }

        private string GetProductImageFromDatabase(string productName) //ดึงข้อมูลรูปภาพของสินค้าตามชื่อสินค้า 
        {
            string connectionString = "server=localhost;user=root;password=;database=bingsu";
            string selectQuery = "SELECT Picture FROM stockbingsu WHERE Menu = @productName";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@productName", productName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString(); // คืนค่าเส้นทางของรูปภาพ
                    }
                    else
                    {
                        return null; // ไม่มีรูปภาพ
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null; // คืนค่า null ในกรณีเกิดข้อผิดพลาด
                }
            }
        }


        // ฟังก์ชันสำหรับดึงราคาสินค้าจากฐานข้อมูล
        private decimal GetProductPriceFromDatabase(string productName)
        {
            string connectionString = "server=localhost;user=root;password=;database=bingsu";
            string selectQuery = "SELECT Price  FROM stockbingsu WHERE Menu = @productName";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@productName", productName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToDecimal(result);
                    }
                    else
                    {
                        return -1; // คืนค่า -1 เมื่อไม่พบราคาสินค้า
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return -1; // คืนค่า -1 ในกรณีเกิดข้อผิดพลาด
                }
            }
        }

        private int GetProductIDFromDatabase(string productName) // ฟังก์ชันสำหรับดึงไอดีสินค้าจากฐานข้อมูล
        {
            int productID = -1; // ค่าเริ่มต้นในกรณีไม่พบสินค้า

            string connectionString = "server=localhost;user=root;password=;database=bingsu";
            string selectQuery = "SELECT Id FROM stockbingsu WHERE Menu = @productName";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@productName", productName);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        productID = Convert.ToInt32(result); // ดึง Id ของสินค้า
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while fetching Product ID: " + ex.Message);
                }
            }
            return productID; // คืนค่า Id หรือ -1 หากไม่พบสินค้า
        }






        // Event handler สำหรับคลิกที่ปุ่ม Order ปุ่มสั่งสินค้า
        private void order_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามีเมนูที่ถูกคลิกไว้แล้วหรือไม่
            if (selectedProductName == null)
            {
                MessageBox.Show("โปรดเลือกเมนู");
                return;
            }
            // ตรวจสอบความถูกต้องของจำนวนที่ผู้ใช้ป้อน
            if (!int.TryParse(textbox_amount.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("กรุณากรอกจำนวนที่ถูกต้อง");
                return;
            }
            else if (!int.TryParse(textbox_amount.Text, out int quantity1) || quantity1 > 20)
            {
                MessageBox.Show("สินค้ามีไม่เพียงพอ");
                return;
            }

            // ดึงราคาสินค้าจากฐานข้อมูล
            decimal productPrice = GetProductPriceFromDatabase(selectedProductName);
            string producImage = GetProductImageFromDatabase(selectedProductName);
            int productID = (int)GetProductIDFromDatabase(selectedProductName);

            if (productID == -1)
            {
                MessageBox.Show("Product ID not found.");
                return;
            }

            if (productPrice == -1)
            {
                MessageBox.Show("Product price not found.");
                return;
            }

            // คำนวณราคารวม
            decimal totalPrice = productPrice * quantity;

            tb_total.Text = totalPrice.ToString("N2");
                        
            // เพิ่มข้อมูลเข้าไปในฐานข้อมูล cart
            AddToCart(productID, selectedProductName, quantity, totalPrice, productPrice,producImage);
        }

        // ฟังก์ชันสำหรับเพิ่มข้อมูลลงในฐานข้อมูล cart
        private void AddToCart(int productID ,string productName, int quantity, decimal totalPrice, decimal Price, string producImage)
        {
            
            string connectionString = "server=localhost;user=root;password=;database=bingsu";
            string insertQuery = "INSERT INTO cart (date,productID,username, name_bingsu, amount, price,totalprice,Picture) VALUES (@date,@productID,@username, @name_bingsu, @amount, @price,@totalprice,@Picture)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                

                command.Parameters.AddWithValue("@date", DateTime.Now); // เพิ่มวันที่ปัจจุบัน
                command.Parameters.AddWithValue("@productID", productID);
                command.Parameters.AddWithValue("@username", Username);
                command.Parameters.AddWithValue("@name_bingsu", productName);
                command.Parameters.AddWithValue("@price", Price); // ตั้งค่าราคารวม
                command.Parameters.AddWithValue("@amount", quantity); // ตั้งค่าจำนวนจาก TextBox
                command.Parameters.AddWithValue("@totalprice",totalPrice);
                command.Parameters.AddWithValue("@Picture", producImage);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // เคลียร์ตัวแปรเมื่อเสร็จสิ้นการสั่งซื้อ
            selectedProductName = null; 
            textbox_amount.Text = ""; 
            showcart();
            UpdateTotalPrice();
        }

        //#####################################################################################################
        

        





        private void label1_Click(object sender, EventArgs e)
        {

        }

      
        private void textbox_amount_TextChanged(object sender, EventArgs e)
        {

        }

        //เมื่อผู้ใช้คลิกใน DataGridView
        private void datacart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            datacart.CurrentRow.Selected = true;

            // ดึงข้อมูลจากเซลล์แต่ละคอลัมน์ในแถวที่เลือกมาแสดงใน TextBox
            textbox_amount.Text = datacart.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();

            // เก็บ ชื่อ ของแถวที่เลือกไว้ในตัวแปร selectedRowId
            selectedProductName = datacart.Rows[e.RowIndex].Cells["name_bingsu"].FormattedValue.ToString();
        }

        private void delete_cart_Click(object sender, EventArgs e) //เมื่อกดลบสินค้าที่เลือก
        {
            if (string.IsNullOrEmpty(selectedProductName))
            {
                MessageBox.Show("กรุณาเลือกสินค้า");
                return;
            }

            string connectionString = "server=localhost;user=root;password=;database=bingsu";
            string deleteQuery = "DELETE FROM cart WHERE name_bingsu = @name_bingsu";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@name_bingsu", selectedProductName);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        showcart(); // อัพเดท DataGridView หลังจากลบข้อมูล
                        UpdateTotalPrice(); // อัพเดทราคาทั้งหมด
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.");
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private decimal vatAmount = 0;
        private decimal totalPrice = 0;
        

        private void UpdateTotalPrice()  //ไว้อัปเดตตารางและราคา
        {
            string connectionString = "server=localhost;user=root;password=;database=bingsu";
            string selectQuery = "SELECT SUM(totalprice) FROM cart";  
            string userCheckQuery = "SELECT COUNT(*) FROM user WHERE Username = @Username";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlCommand userCheckCommand = new MySqlCommand(userCheckQuery, connection);

               
                userCheckCommand.Parameters.AddWithValue("@UserName", textBox_name.Text);

                try
                {
                    connection.Open();

                    // ตรวจสอบว่ามีชื่อในตาราง user หรือไม่
                    int userCount = Convert.ToInt32(userCheckCommand.ExecuteScalar());
                    bool hasDiscount = userCount > 0;



                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        // ราคาทั้งหมด
                        decimal totalPrice = Convert.ToDecimal(result);

                        // คำนวณภาษีมูลค่าเพิ่ม 7%
                        decimal vatAmount = totalPrice * 0.07m;

                        // คำนวณราคาส่วนลดถ้ามี
                        decimal discount = 0;
                        if (hasDiscount)
                        {
                            discount = totalPrice * 0.05m;// ลด 5%
                        }

                        // แสดงราคาทั้งหมดใน TextBox
                        tb_total.Text = totalPrice.ToString("N2");

                        // แสดง VAT ใน TextBox
                        textBoxVAT.Text = vatAmount.ToString("N2");

                        // แสดงส่วนลดใน TextBox
                        textBoxdiscount.Text = discount.ToString("N2");

                        // คำนวณและแสดงราคาทั้งหมดรวมภาษี
                        decimal grandTotal = totalPrice + vatAmount-discount;
                        textBoxSum.Text = grandTotal.ToString("N2");


                        
                    }
                    else
                    {
                        tb_total.Text = "0.00"; // กรณีไม่มีสินค้าในตะกร้า
                        textBoxVAT.Text = "0.00"; // กรณีไม่มีสินค้าในตะกร้า
                        textBoxdiscount.Text = "0.00"; // กรณีไม่มีสินค้าในตะกร้า
                        textBoxSum.Text = "0.00"; // กรณีไม่มีสินค้าในตะกร้า
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void edit_cart_Click(object sender, EventArgs e) //แก้ไขสินค้า
        {
            if (string.IsNullOrEmpty(selectedProductName))
            {
                MessageBox.Show("กรุณาเลือกสินค้า");
                return;
            }

            // อ่านค่าจำนวนใหม่จาก TextBox
            if (!int.TryParse(textbox_amount.Text, out int newQuantity))
            {
                MessageBox.Show("กรุณากรอกจำนวน.");
                return;
            }

            // ดึงราคาสินค้าจากฐานข้อมูล
            decimal productPrice = GetProductPriceFromDatabase(selectedProductName);
            

            if (productPrice == -1)
            {
                MessageBox.Show("Product price not found.");
                return;
            }

            // คำนวณราคารวมใหม่
            decimal newTotalPrice = productPrice * newQuantity;

            string connectionString = "server=localhost;user=root;password=;database=bingsu";
            string updateQuery = "UPDATE cart SET amount = @newAmount, price = @newPrice WHERE name_bingsu = @name_bingsu";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@newAmount", newQuantity);
                command.Parameters.AddWithValue("@newPrice", newTotalPrice);
                command.Parameters.AddWithValue("@name_bingsu", selectedProductName);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                       
                        showcart(); // อัพเดท DataGridView หลังจากอัพเดทข้อมูล
                        UpdateTotalPrice(); // อัพเดทราคาทั้งหมด
                    }
                    else
                    {
                        MessageBox.Show("Failed to update product.");
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        
        private void confirm_Click(object sender, EventArgs e) //ชำระเงิน
        {
            string connection = "server=localhost;user=root;password=;database=bingsu";
            string updateCommandText = "UPDATE cart SET VAT = @VAT,Total=@Total, Discount=@Discount";


            // Create the connection and command objects
            using (MySqlConnection conn = new MySqlConnection(connection))
            using (MySqlCommand ucmd = new MySqlCommand(updateCommandText, conn))
            {
                // Define the parameter and its value
                ucmd.Parameters.AddWithValue("@VAT", textBoxVAT.Text);
                ucmd.Parameters.AddWithValue("@Total", textBoxSum.Text);
                ucmd.Parameters.AddWithValue("@Discount", textBoxdiscount.Text);

                try
                {
                    

                    // Open the connection
                    conn.Open();

                    // Execute the command
                    int rowsAffected = ucmd.ExecuteNonQuery();
                    

                    // Output the number of rows affected
                    Console.WriteLine($"{rowsAffected} rows updated.");
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally { conn.Close(); }
            }

            string connectionString1 = "server=localhost;user=root;password=;database=bingsu";
            string countQuery = "SELECT COUNT(*) FROM cart";
            

            using (MySqlConnection connection1 = new MySqlConnection(connectionString1))
            {
                MySqlCommand command = new MySqlCommand(countQuery, connection1);

                try
                {
                    connection1.Open();
                    object result = command.ExecuteScalar();
                    int itemCount = Convert.ToInt32(result);

                    if (itemCount > 0)
                    {

                        // ซ่อนฟอร์มปัจจุบัน
                        this.Hide();

                        // สร้างและแสดงหน้าฟอร์มใหม่
                        qrcode qr = new qrcode(); // ปรับตามฟอร์มที่คุณต้องการเปิด
                        qr.Username = textBox_name.Text;
                        qr.ShowDialog();

                        // ปิดฟอร์มปัจจุบัน
                        this.Close();
                    }
                    else
                    {
                        // แจ้งเตือนว่าต้องเลือกสินค้าก่อนชำระเงิน
                        MessageBox.Show("กรุณาเลือกสินค้าก่อนชำระเงิน", "ไม่มีสินค้าในตะกร้า", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    connection1.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void back_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=;database=bingsu";

            // ลบข้อมูลทั้งหมดใน cart
            string deleteCartQuery = "DELETE FROM `cart`";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand deleteCommand = new MySqlCommand(deleteCartQuery, connection);

                try
                {
                    connection.Open();
                    deleteCommand.ExecuteNonQuery();
                    connection.Close();

                    //MessageBox.Show("Cart cleared successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // ซ่อนฟอร์มปัจจุบัน
            this.Hide();

            // เปิดหน้าฟอร์มใหม่
            Form1 form2 = new Form1(); // ใช้ชื่อ Form1
            form2.ShowDialog();

            // ปิดฟอร์มปัจจุบัน
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void datacart_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxdiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_total_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void textBoxSum_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVAT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}   

