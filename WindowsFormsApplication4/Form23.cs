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
    public partial class Form23 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");

        SqlCommand cm;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
         
        
            label3.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label3.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;

                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
                {
                    label3.Visible = true;
                    if (string.IsNullOrEmpty(textBox1.Text))
                        label6.Visible = true;
                    if (string.IsNullOrEmpty(textBox2.Text))
                        label7.Visible = true;
                    if (string.IsNullOrEmpty(comboBox1.Text))
                        label8.Visible = true;
                }
                else
                {
                    int c = Convert.ToInt16(textBox2.Text);
                    string y = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                    cm = new SqlCommand("exec  helpresult @idofstudent= " + Convert.ToInt32(textBox1.Text) + ",@year=" + c + ",@semester='" + y + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    int b = Convert.ToInt16(dr[0].ToString());
                    dr.Close();
                    cn.Close();
                    if (b > 0)
                    {
                        cm = new SqlCommand("select name from student where studentid=" + Convert.ToInt32(textBox1.Text) + "", cn);
                        cn.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        string name = dr[0].ToString();
                        dr.Close();
                        cn.Close();

                        Form22 frmreport1 = new Form22();
                        frmreport1.studentid = Convert.ToInt32(textBox1.Text);
                        frmreport1.year = c;
                        frmreport1.semester = y;
                        frmreport1.name = name;
                        frmreport1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("من فضللك ادخل بيانات صحيحة ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox1.Clear();
                        textBox2.Clear();
                        comboBox1.Text = null;
                    }
                }
            }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            if (label7.Visible == false && label8.Visible == false)
            {
                label3.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            if (label6.Visible == false && label8.Visible == false)
            {
                label3.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
            if (label6.Visible == false && label7.Visible == false)
            {
                label3.Visible = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();

            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
