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
    public partial class Form7 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cm;
        SqlDataReader dr;
        string EmployeeName;
        string EmployeePass;
     
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false; 
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label16.Visible = false;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label16.Visible = false;
            try
            {

                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(this.comboBox1.Text) ||textBox5.Text!=textBox6.Text)
                {
                    label13.Visible = true;
                    if (string.IsNullOrEmpty(textBox1.Text))
                        label7.Visible = true;
                    if (string.IsNullOrEmpty(textBox2.Text))
                        label8.Visible = true;
                    if (string.IsNullOrEmpty(textBox3.Text))
                        label9.Visible = true;
                    if (string.IsNullOrEmpty(textBox4.Text))
                        label10.Visible = true;
                    if (string.IsNullOrEmpty(textBox5.Text) || textBox5.TextLength < 9)
                    {
                      if (string.IsNullOrEmpty(textBox5.Text))
                        textBox6.Clear();
                        label12.Visible = true;
                        label16.Visible = true;
                        label12.Text = "*";
                        label16.Text = "*";
                    }
                    if( string.IsNullOrEmpty(this.comboBox1.Text))
                        label11.Visible = true;
                    if (textBox5.Text != textBox6.Text)
                    {
                        label16.Visible = true;
                        label16.Text = "رقم التاكيد غير صحيح";
                    }


                
                
                }
                else
                {
                    cm = new SqlCommand("select EmployeeName,EmployeePass from Employee where EmployeeName='" + textBox1.Text + "' and EmployeePass='" + textBox5.Text + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        label14.Visible = true;
                        label12.Visible = true;
                        label12.Text = "!";
                        dr.Close();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                        cm = new SqlCommand("insert into Employee values('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + this.comboBox1.GetItemText(this.comboBox1.SelectedItem) + "','" + textBox3.Text + "')", cn);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        comboBox1.SelectedItem = null;
                        MessageBox.Show("تم حفظ الموظف ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show(" التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)&&!char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
             
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();

            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();

            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();

            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();

            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
            }
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox6.Clear();
            }
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
         
        
    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.comboBox1.Text))
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();

            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                e.Handled = true;
          
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label16.Visible = false;
            try
            {

                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(this.comboBox1.Text) || textBox5.Text != textBox6.Text)
                {
                    label13.Visible = true;
                    if (string.IsNullOrEmpty(textBox1.Text))
                        label7.Visible = true;
                    if (string.IsNullOrEmpty(textBox2.Text))
                        label8.Visible = true;
                    if (string.IsNullOrEmpty(textBox3.Text))
                        label9.Visible = true;
                    if (string.IsNullOrEmpty(textBox4.Text))
                        label10.Visible = true;
                    if (string.IsNullOrEmpty(textBox5.Text) || textBox5.TextLength < 9)
                    {
                        if (string.IsNullOrEmpty(textBox5.Text))
                            textBox6.Clear();
                        label12.Visible = true;
                        label16.Visible = true;
                        label12.Text = "*";
                    }
                    if (string.IsNullOrEmpty(this.comboBox1.Text))
                        label11.Visible = true;
                    if (textBox5.Text != textBox6.Text)
                    {
                        label16.Visible = true;
                        label16.Text = "رقم التاكيد غير صحيح";
                    }




                }
                else
                {
                    cm = new SqlCommand("select EmployeeName,EmployeePass from Employee where EmployeeName='" + EmployeeName + "' and EmployeePass='" + EmployeePass + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        label14.Visible = true;
                        label12.Visible = true;
                        label12.Text = "!";
                        dr.Close();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                        cm = new SqlCommand("update  Employee set EmployeeName='" + textBox1.Text + "',EmployeePass='" + textBox5.Text + "',Email='" + textBox4.Text + "',EmployeeTelephone='" + textBox2.Text + "',Account='" + this.comboBox1.GetItemText(this.comboBox1.SelectedItem) + "',EmployeeQualification='" + textBox3.Text + "' where EmployeeName='" + EmployeeName + "' and EmployeePass='" + EmployeePass + "'", cn);
                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        comboBox1.SelectedItem = null;
                        MessageBox.Show("تم تعديل الموظف ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show(" التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm = new SqlCommand("delete from employee where  EmployeeName='" + EmployeeName + "' and EmployeePass='" + EmployeePass + "' ", cn);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmployeePass = textBox5.Text;
               EmployeeName = textBox1.Text;
        }
        }
}
