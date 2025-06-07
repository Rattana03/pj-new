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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            

        }

        private void button1_Click(object sender, EventArgs e) //คือ b_menu
        {

            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            login form2 = new login(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

        private void Developer_Click(object sender, EventArgs e) 
        {

            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            Developer form2 = new Developer(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

       
    }
}
