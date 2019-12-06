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
    public partial class Form11 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cm;
        SqlDataReader dr;
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult r = MessageBox.Show("تاكيد الخروج", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            dr.Read();
     int x= Convert.ToInt32(dr[0].ToString());
            dr.Close();
            cn.Close();
            if (x > 0)
            {
                DialogResult r = MessageBox.Show("تاكيد ", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    cm = new SqlCommand("exec Coordinate @year=" + Convert.ToInt32(label2.Text) + "", cn);
                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();

                }
               
            }
            else
            {
                MessageBox.Show("لايوجد طلاب بدون اكواد ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
