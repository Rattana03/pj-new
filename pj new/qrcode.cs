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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using iTextSharp.text.pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Diagnostics;


namespace pj_new
{
    public partial class qrcode : Form
    {

    private string _username;


        public string Username
        {
            get { return _username; }
            set { _username = value; label2.Text = value; }
        }

        private MySqlConnection databaseConnection()
        {
            string connectionstring = "datasource=127.0.0.1;port=3306;username=root;password=;database=bingsu;";

            MySqlConnection conn = new MySqlConnection(connectionstring);

            return conn;
        }

        public event Action<string> OnUpdateTextBox;
        public qrcode()
        {
            InitializeComponent();
            
        }

        private void qrcode_Load(object sender, EventArgs e)
        {
            LoadSumTotal();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoadSumTotal()
        {
            MySqlConnection conn = databaseConnection();
            try
            {
                conn.Open();
                // คิวรีเพื่อดึง Total จากตาราง cart โดยเลือกจากผู้ใช้เฉพาะเจาะจง (หากมี username ใช้ในกรณีเฉพาะ)
                string sql = "SELECT Total FROM cart WHERE username = @username"; // ดึงเฉพาะผู้ใช้ตาม username
                MySqlCommand cmd = new MySqlCommand(sql, conn);


                // ส่งค่า username ที่ใช้ในการกรองผลลัพธ์
                cmd.Parameters.AddWithValue("@username", label2.Text);

                // ดึงค่าผลลัพธ์จากฐานข้อมูล
                object result = cmd.ExecuteScalar();

                // ตรวจสอบและแสดงผลลัพธ์ใน TextBox
                if (result != null && result != DBNull.Value)
                {
                    double totalSum = Convert.ToDouble(result);
                    textBox1.Text = totalSum.ToString("N2"); // แสดงเป็นเลขทศนิยม 2 ตำแหน่ง

                }
                else
                {
                    textBox1.Text = "0.00"; // กรณีไม่มีค่าให้แสดง 0.00
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

        //private decimal vatAmount = 0;
        private decimal totalPrice = 0;
        //กดเสร็จสิ้น
        private void pay_Click(object sender, EventArgs e)
        {
            
            // ถามผู้ใช้ว่าต้องการใบเสร็จหรือไม่
            DialogResult result = MessageBox.Show("Do you want a receipt?", "Receipt", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string connectionString = "server=localhost;user=root;password=;database=bingsu";

                // คัดลอกข้อมูลจาก cart ไปยัง `all`
                string insertIntoAllQuery = @"
                INSERT INTO `all order` (`date`, `id`,`id_product`, `username`, `order`,  `amount`, `price`,`totalprice`, `VAT`, `Total`, `Picture`,`BillNumber`, `IDuser`)
                SELECT `date`,`id`,`productID`, `username`, `name_bingsu`, `amount`, `price`, `totalprice`, `VAT`, `Total`,`Picture`,@BillNumber,
                    (SELECT `Id` FROM `user` WHERE `Username` = @Username)
                FROM `cart`";



                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand insertCommand = new MySqlCommand(insertIntoAllQuery, connection);

                    insertCommand.Parameters.AddWithValue("@Username", label2.Text);
                   

                    string bill = DateTime.Now.Ticks.ToString();
                    string filename = @"c:\bill\" + bill + ".pdf";

                    insertCommand.Parameters.AddWithValue("@BillNumber", filename);
                    

                    try
                    {
                        connection.Open();

                        // คัดลอกข้อมูลจาก cart ไปยัง `all`
                        insertCommand.ExecuteNonQuery();

                        // ลบข้อมูลทั้งหมดใน cart

                        connection.Close();

                        ///ปริ้นใบเสร็จ
                        MySqlConnection conn = databaseConnection();
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM cart WHERE username = '" + label2.Text + "';", conn);


                        conn.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();

                        string tick = DateTime.Now.Ticks.ToString();                   //ตัวเลขสุ่มสำหรับเลขใบเสร็จและชื่อไฟล์pdf
                        string charge_date = DateTime.Now.ToString("dd MM yyyy");   //วันที่ปริ้นใบเสร็จ
                        string charge_time = DateTime.Now.ToString("HH:mm:ss");

                        const string address = "999 Moo 9,\n" +    //ที่อยู่ใส่ในใบเสร็จ
                        "Mueang Amnatcharoen  District,\n" +
                        "Amnatcharoen 37000";

                        //ใช้ pdfsharp สร้างpdf โหลดใน nuget
                        PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                        PdfSharp.Pdf.PdfPage page = document.AddPage();
                        XGraphics gfx = XGraphics.FromPdfPage(page);


                        //ฟ้อนต์ตัวอักษร
                        XFont font = new XFont("Arial", 14, XFontStyleEx.Regular);
                        XTextFormatter tf = new XTextFormatter(gfx);


                        // โหลดฟอนท์ภาษาไทย

                        //เนื้อหาในpdf
                        gfx.DrawString($"Receipt", font, XBrushes.Black, new XPoint(250, 30));
                        gfx.DrawString($"THANK YOU", font, XBrushes.Black, new XPoint(250, 800));
                        gfx.DrawString($"Booking No. : {tick}", font, XBrushes.Black, new XPoint(360, 70));                               //เลขที่ใบเสร็จ
                        gfx.DrawString($"Charge Date : {charge_date}", font, XBrushes.Black, new XPoint(360, 90));                        //วันที่ปริ้นใบเสร็จ
                        //DrawImage(gfx, "C:\\PJ", 25, 20, 300, 150);      // logo  //โลโก้เอามาจากไฟล์ในเครื่อง
                        gfx.DrawString($"Charge time : {charge_time}", font, XBrushes.Black, new XPoint(360, 110));
                        gfx.DrawString($"Customer : {label2.Text}", font, XBrushes.Black, new XPoint(360, 130));
                        tf.Alignment = XParagraphAlignment.Left;                                                                          //ทำให้ ที่อยู่ ชิดซ้าย
                        tf.DrawString(address, font, XBrushes.Black, new XRect(200, 180, 400, 400));               //ที่อยู่
                                                                                                                   //gfx.DrawString($"Customer Name : {customer_qr}", font, XBrushes.Black, new XPoint(40, 190));                      //ชื่อลูกค้า
                                                                                                                   //gfx.DrawString($"Email Address : {email_qr}", font, XBrushes.Black, new XPoint(40, 210));                         //อีเมลลูกค้า


                        //ตาราง 1บรรทัดคือ1เส้น
                        gfx.DrawLine(new XPen(XColor.FromName("Black")), new XPoint(40, 250), new XPoint(40, 720)); //เส้นข้างหน้า
                        gfx.DrawLine(new XPen(XColor.FromName("Black")), new XPoint(570, 250), new XPoint(570, 720));//เส้นข้างหลัง
                        gfx.DrawLine(new XPen(XColor.FromName("Black")), new XPoint(40, 250), new XPoint(570, 250));
                        gfx.DrawLine(new XPen(XColor.FromName("Black")), new XPoint(40, 280), new XPoint(570, 280));
                        gfx.DrawLine(new XPen(XColor.FromName("Black")), new XPoint(40, 600), new XPoint(570, 600));
                        gfx.DrawLine(new XPen(XColor.FromName("Black")), new XPoint(40, 720), new XPoint(570, 720));

                        //รายละเอียดในตาราง
                        int space = 0;

                        gfx.DrawString($"Description", font, XBrushes.Black, new XPoint(100, 270));
                        gfx.DrawString($"Quantity", font, XBrushes.Black, new XPoint(290, 270));
                        gfx.DrawString($"price", font, XBrushes.Black, new XPoint(390, 270)); 
                        gfx.DrawString($"Total price", font, XBrushes.Black, new XPoint(470, 270));

                        while (reader.Read())
                        {
                            gfx.DrawString($"{reader.GetString("name_bingsu")}", font, XBrushes.Black, new XPoint(80, 310 + space));      //ปรับตำแหน่งชื่อสินค้าและยอด ใน PDF
                            gfx.DrawString($"{reader.GetString("amount")}", font, XBrushes.Black, new XPoint(305, 310 + space));
                            gfx.DrawString($"{reader.GetInt32("price")}", font, XBrushes.Black, new XPoint(400, 310 + space));
                            gfx.DrawString($"{reader.GetInt32("totalprice").ToString("N0")}", font, XBrushes.Black, new XPoint(490, 310 + space));
                            space += 30;
                        }
                        conn.Close();


                        MySqlCommand cmd1 = new MySqlCommand("SELECT VAT, Total, SUM(price), Discount FROM cart WHERE username = '" + label2.Text + "';", conn);


                        conn.Open();

                        MySqlDataReader reader12 = cmd1.ExecuteReader();  // ยอดรวมหน้า PDF
                        while (reader12.Read())
                        {


                            int total = reader12.GetInt32(2);
                            int discount = reader12.GetInt32(3);

                            //กำหนดสรุปราคา
                            gfx.DrawString($"Sub Total", font, XBrushes.Black, new XPoint(70, 620));
                            gfx.DrawString($"{total.ToString("N2")}", font, XBrushes.Black, new XPoint(500, 620));  // แสดง total เป็นทศนิยม 2 ตำแหน่ง

                            gfx.DrawString($"Vat 7%", font, XBrushes.Black, new XPoint(70, 645));
                            gfx.DrawString($"{reader12.GetString(0)}", font, XBrushes.Black, new XPoint(500, 645));

                            gfx.DrawString($"discount", font, XBrushes.Black, new XPoint(70, 670));
                            gfx.DrawString($"{discount.ToString("N2")}", font, XBrushes.Black, new XPoint(500, 670));

                            gfx.DrawString($"Total", font, XBrushes.Black, new XPoint(70, 695));
                            gfx.DrawString($"{reader12.GetString(1)}", font, XBrushes.Black, new XPoint(500, 695));
                        }

                        conn.Close();
                        
                        
                        document.Save(filename);

                        Process.Start(new ProcessStartInfo
                        {
                            FileName = filename, 
                            UseShellExecute = true 
                        });




                        // ลบข้อมูลทั้งหมดใน cart
                        MySqlConnection connection12 = new MySqlConnection(connectionString);
                        string deleteCartQuery = "DELETE FROM `cart` WHERE username = '" + label2.Text + "'";
                        MySqlCommand deleteCommand = new MySqlCommand(deleteCartQuery, connection12);
                        connection12.Open();
                        deleteCommand.ExecuteNonQuery();
                        connection12.Close();


                        // ซ่อนฟอร์มปัจจุบัน
                        this.Hide();

                        // สร้างและแสดงหน้าฟอร์มใหม่
                        login form2 = new login(); // ปรับตามฟอร์มที่คุณต้องการเปิด
                        form2.ShowDialog();

                        // ปิดฟอร์มปัจจุบัน
                        this.Close();



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                // ซ่อนฟอร์มปัจจุบัน
                this.Hide();

                // สร้างและแสดงหน้าฟอร์มใหม่
                login form2 = new login(); // ปรับตามฟอร์มที่คุณต้องการเปิด
                form2.ShowDialog();

                // ปิดฟอร์มปัจจุบัน
                this.Close();

            }


        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void back_L_Click(object sender, EventArgs e)
        {
            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            login form2 = new login(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        

    }   
} 


