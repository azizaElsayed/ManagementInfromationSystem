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
    public partial class Form6 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");

        SqlCommand cm;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try{
               label3.Visible=false;
               label6.Visible=false;
               label7.Visible=false;
               label8.Visible=false;

               if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
               {
                   label3.Visible=true;
 if (string.IsNullOrEmpty(textBox1.Text))
     label6.Visible=true;
      if (string.IsNullOrEmpty(textBox2.Text))
          label7.Visible=true;
           if (string.IsNullOrEmpty(comboBox1.Text))
label8.Visible=true;
               }
               else{
            int c = Convert.ToInt16(textBox2.Text);
        string    y = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
        cm = new SqlCommand("exec  helpresult @idofstudent= " + Convert.ToInt32(textBox1.Text) + ",@year=" + c + ",@semester='" + y + "' ", cn);
                cn.Open();
          dr  =cm.ExecuteReader();
            dr.Read();
      int b=  Convert.ToInt16(dr[0].ToString());
            dr.Close();
            cn.Close();
            if (b > 0)
            {
                Da = new SqlDataAdapter("exec result @idofstudent=" + Convert.ToInt32(textBox1.Text) + ",@year=" + c + ",@semester='" + y + "'", cn);
                ds = new DataSet();
                Da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                cm = new SqlCommand("exec showgpa  @studentid=" + Convert.ToInt32(textBox1.Text) + ", @year=" + c + ",@semester='" + y + "' ", cn);
                cn.Open();
                dr = cm.ExecuteReader();
                dr.Read();
                string n = dr[0].ToString();
                textBox3.Text = n;

                dr.Close();
                cn.Close();
                textBox1.ReadOnly=true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                button1.Visible = false;
                button2.Visible = true;

                this.Size = new Size(917, 522);
             string text=comboBox1.Text;
             comboBox1.Items.Clear();
             comboBox1.Items.Add(text);
             comboBox1.Text = text;
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


        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            label7.Visible = false;
           if(label6.Visible==false&&label8.Visible==false)
           {
               label3.Visible = false;
           }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            this.Size = new Size(917, 196);
            button2.Visible = false;
            label3.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            button2.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text=null;

            comboBox1.Items.Clear();
            this.Size = new Size(917, 196);
            comboBox1.Items.Add("first");
            comboBox1.Items.Add("second");
            comboBox1.Items.Add("summer");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();

            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               comboBox1.Focus();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
               label8.Visible=false;
               if (label6.Visible == false && label7.Visible == false)
               {
                   label3.Visible = false;
               }
        }
    }
}
