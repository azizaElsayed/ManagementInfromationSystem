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
    public partial class Form13 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string nationalid;
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            this.Size = new Size(904, 171);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
           {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    string y = label2.Text;
                    int v;
                    v = Convert.ToInt32(y);
                    cmd = new SqlCommand("select count(*) from student where StudentId=" + Convert.ToInt64(textBox1.Text) + " ", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string r = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    if (r == "1")
                    {
                        string n = label2.Text;
                        int x;
                        x = Convert.ToInt32(n);

                        cmd = new SqlCommand("select nationalid from student where StudentId =" + Convert.ToInt64(textBox1.Text) + "", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        nationalid = dr[0].ToString();
                        dr.Close();
                        cn.Close();

                        cmd = new SqlCommand("select count(*) from registeration where nationalid='" + nationalid + "' and [year]=" + x + " and semester='" + label4.Text + "'  and materialcode in (select materialcode from contr where year=" + x + " and semester='" + label4.Text + "' and write='" + "0" + "')", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        string k = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        int p = Convert.ToInt32(k);
                        if (p == 0)
                        {
                            MessageBox.Show("لا توجد مواد للانسحاب حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox1.Clear();
                        }

                        else
                        {
                            int id = Convert.ToInt32(textBox1.Text);
                            int yea = Convert.ToInt16(label2.Text);
                            cmd = new SqlCommand("select MaterialCourseTitle from Materials where materialcode in(select materialcode from Registeration where nationalid='" + nationalid + "' and year="+yea+" and semester='"+label4.Text+"' and appreciation in(select Appreciation from Registeration where not  appreciation='" + "W" + "'  )  or Appreciation is null  and  nationalid='" + nationalid + "' and year="+yea+" and semester='"+label4.Text+"') and MaterialCode in(select materialcode from contr where year=" + yea + " and semester='" + label4.Text + "' and write='" + "0" + "')", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {

                                comboBox1.Items.Add(dr[0].ToString());

                            }
                            dr.Close();
                            cn.Close();
                            if(comboBox1.Items.Count==0)
                            {
                                MessageBox.Show("عفوا لاتوجد مواد للانسحاب", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox1.Clear();
                            }
                            else{
                            this.Size = new Size(904, 254);
                            button1.Visible = false;
                            textBox1.ReadOnly = true;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("من فضللك ادخل رقم الجلوس الصحيح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                    }
                }

               
           }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعده البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          try
            {
                if (!string.IsNullOrEmpty(this.comboBox1.Text))
                {
                    int id = Convert.ToInt32(textBox1.Text);
                    int yea = Convert.ToInt16(label2.Text);
                    cmd = new SqlCommand(" exec inserte4 @idofstudent='" + nationalid + "' ,@course='" + comboBox1.SelectedItem.ToString() + "',@year=" + yea + " ,@semester='" + label4.Text + "' ", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    button1.Visible = true;
                    textBox1.Clear();
                    textBox1.ReadOnly = false;
                    comboBox1.Text = null;
                    comboBox1.Items.Clear();
                    this.Size = new Size(904, 171);
                }
                else
                {
                    MessageBox.Show("من فضللك المادة الدراسيه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعده البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم الانسحاب", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Size = new Size(904, 201);
                textBox1.Clear();
                comboBox1.Items.Clear();
                button1.Visible = true;
                textBox1.ReadOnly = false;
                this.Size = new Size(904, 171);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم الانسحاب", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
