using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace WindowsFormsApplication4
{
    public partial class Form16 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Form16()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لن يتم اعتماد النتيجه", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("تاكيد الاعتماد", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    cmd = new SqlCommand(" Select count(*) from totalgpa where gpa is null and nationalid in(select nationalid from student where restricted='"+"1"+"')", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string g = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    if (g == "0")
                    {
                        cmd = new SqlCommand("update stateofregisteration set adopttheresult='" + 1 + "' where year=" + Convert.ToInt32(label2.Text) + "and semester='" + label6.Text + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("لم يتم اعتماد النتيجه بسبب عدم رصد درجات جميع الطلاب ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("تاكيدالغاء الاعتماد", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    
                        cmd = new SqlCommand("update stateofregisteration set adopttheresult='" + 0 + "' where year=" + Convert.ToInt32(label2.Text) + "and semester='" + label6.Text + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        this.Close();

                }
            }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لن يتم الغاء اعتماد النتيجه", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
