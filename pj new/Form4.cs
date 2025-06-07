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
    public partial class management : Form
    {
        public management()
        {
            InitializeComponent();
        }

        private void management_Load(object sender, EventArgs e)
        {

        }

        private void stock_Click(object sender, EventArgs e)
        {
            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            admin form2 = new admin(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }

        private void income_Click(object sender, EventArgs e)
        {
            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            income2 form2 = new income2(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
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

        private void customer_Click(object sender, EventArgs e)
        {
            this.Hide();
            // สร้างหน้าฟอร์มใหม่
            customers form2 = new customers(); // แทน Form2 ด้วยชื่อของหน้าฟอร์มที่คุณต้องการเปิด

            // แสดงหน้าฟอร์มใหม่โดยใช้ Show() หรือ ShowDialog() ตามความต้องการ
            form2.ShowDialog(); // การใช้ ShowDialog() จะทำให้หน้าฟอร์มใหม่เป็นหน้าต่างโมดอล ซึ่งจะบล็อกการใช้งานของหน้าจอหลักจนกว่าจะปิดหน้าฟอร์มใหม่

            // เมื่อปิดหน้าฟอร์มใหม่เสร็จสิ้น ให้แสดงหน้าฟอร์มปัจจุบันอีกครั้ง
            this.Close();
        }
    }
}
