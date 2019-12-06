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
    public partial class Form14 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show(" تاكيد غلق باب التسجيل", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                cmd = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string k = dr[0].ToString();
                string m = dr[1].ToString();
                dr.Close();
                cn.Close();
                cmd = new SqlCommand("update stateofregisteration set stated='" + "close" + "'", cn);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
               
                    MessageBox.Show("" + m + "تم غلق باب التسجيل للعام الدراسى " + k + " والفصل الدراسى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                
            }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم غلق باب التسجيل", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
            
        }
    }
}
