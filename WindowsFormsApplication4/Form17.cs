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
    public partial class Form17 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cm;
        SqlDataReader dr;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            Da = new SqlDataAdapter("select materialcoursetitle from materials", cn);
            Da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewCheckBoxColumn sb = new DataGridViewCheckBoxColumn();
            sb.HeaderText = "select";
            dataGridView1.Columns.Add(sb);

            if (dataGridView1.ColumnCount >= 3)
            {
                dataGridView1.Columns.RemoveAt(2);
            }
            dataGridView1.Columns[0].ReadOnly = true;
            for (int m = dataGridView1.Rows.Count - 1; m >= 0; m--)
            {
                dataGridView1.Rows[m].Cells[1].Value = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("exec insertmaterial @MaterialCode='" + textBox4.Text + "',@MaterialCodeArabic='" + textBox3.Text + "',@MaterialCourseTitle='" + textBox1.Text + "',@MaterialCourseTitleEnglish='" + textBox2.Text + "',@CreditHour=" + comboBox3.Text + ",@Department='" + comboBox2.Text + "',@semester='" + comboBox1.Text + "' ", cn);
            
            cn.Open();
            dr = cmd.ExecuteReader();
           
            dr.Read();
        string test=dr[0].ToString();
          string tester=dr[1].ToString();
          if (test == "0" && tester == "0")
            {
                dr.Close();
                cn.Close();
            

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                    {
                        cmd = new SqlCommand("exec Know @coursematerial='" + dataGridView1.Rows[i].Cells[0].Value + "',@courseprequest='" + textBox1.Text + "'", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    }
                 
                }
            
                MessageBox.Show("تم الحفظ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.Text = null;
                comboBox2.Text = null;
                comboBox3.Text = null;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dt.Clear();
                Da = new SqlDataAdapter("select materialcoursetitle from materials", cn);
                Da.Fill(dt);
                dataGridView1.DataSource = dt;
                DataGridViewCheckBoxColumn sb = new DataGridViewCheckBoxColumn();
                sb.HeaderText = "select";
                dataGridView1.Columns.Add(sb);

                if (dataGridView1.ColumnCount >= 3)
                {
                    dataGridView1.Columns.RemoveAt(2);
                }
                dataGridView1.Columns[0].ReadOnly = true;
                for (int m = dataGridView1.Rows.Count - 1; m >= 0; m--)
                {
                    dataGridView1.Rows[m].Cells[1].Value = false;
                }
            }
          else if (test != "0" && tester != "0")
        {
            dr.Close();
            cn.Close();
            MessageBox.Show("عفوا كود الماده واسم الماده مسجل من قبل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
          else if (tester != "0")
             {
                 dr.Close();
                 cn.Close();
                 MessageBox.Show("عفوا اسم الماده مسجل من قبل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
          else   
             {
                 dr.Close();
                 cn.Close();
                 MessageBox.Show("عفوا كود الماده مسجل من قبل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
       
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }
    }
}
