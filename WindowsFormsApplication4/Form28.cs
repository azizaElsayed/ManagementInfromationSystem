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
    public partial class Form28 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string nationalid;
        public Form28()
        {
            InitializeComponent();
        }

        private void Form28_Load(object sender, EventArgs e)
        {
            this.Size = new Size(904, 171);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم الغاء الانسحاب", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم الغاء الانسحاب", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void button2_Click(object sender, EventArgs e)
        {
          //  try
           // {
                if (!string.IsNullOrEmpty(this.comboBox1.Text))
                {
                    int ye = Convert.ToInt16(label2.Text);
                  
                    cmd = new SqlCommand("select write from contr where materialcode =(select MaterialCode from Materials where MaterialCourseTitle='"+comboBox1.Text+"') and year=" + ye + " and semester='" + label4.Text + "'", cn);
                    cn.Open();
                  dr=  cmd.ExecuteReader();
                    dr.Read();
                  string write=dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    if(write=="0")
                    {
                      
                        int yea = Convert.ToInt16(label2.Text);
                        cmd = new SqlCommand(" exec inserte7 @idofstudent='" + nationalid + "' ,@course='" + comboBox1.SelectedItem.ToString() + "',@year=" + yea + " ,@semester='" + label4.Text + "' ", cn);
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
                    else if(write=="1")
                    {
                        int yea = Convert.ToInt16(label2.Text);
                        cmd = new SqlCommand(" update totalgpa set gpa=null where nationalid='" + nationalid + "' and year=" + yea + " and semester='" + label4.Text + "' ", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        cmd = new SqlCommand(" exec inserte7 @idofstudent='" + nationalid + "' ,@course='" + comboBox1.SelectedItem.ToString() + "',@year=" + yea + " ,@semester='" + label4.Text + "' ", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        DialogResult r = MessageBox.Show("الذهاب ورصد الدرجه الان ", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                     
                        if (r == DialogResult.Yes)
                        {
                            Form12 FrmStudentGrades = new Form12();
                            cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            FrmStudentGrades.label4.Text = dr[0].ToString();
                            FrmStudentGrades.label6.Text = dr[1].ToString();

                            string se = dr[1].ToString();
                            dr.Close();
                            cn.Close();
                            FrmStudentGrades.Show();
                           this.Close();
                        }
                        this.Close();

                    }
                   
              
                   
                }
                else
                {
                    MessageBox.Show("من فضللك المادة الدراسيه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
        /*    }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعده البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                string semester=label4.Text;
                int year=Convert.ToInt32(label2.Text);
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
               
                    cmd = new SqlCommand("select count(*) from student where StudentId=" + Convert.ToInt64(textBox1.Text) + " ", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string r = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    if (r == "1")
                    {
                       

                        cmd = new SqlCommand("select nationalid from student where StudentId =" + Convert.ToInt64(textBox1.Text) + "", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        nationalid = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        cmd = new SqlCommand("select materialcoursetitle from materials where materialcode in(select materialcode from registeration where  nationalId ='"+nationalid+"' and year="+year+" and semester='"+semester+"' and appreciation='"+"W"+"' )", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            string cours = dr[0].ToString();
                            comboBox1.Items.Add(cours);
                          
                        }
                        dr.Close();
                        cn.Close();
                        if(comboBox1.Items.Count==0)
                        {
                            MessageBox.Show("لا توجد مواد للانسحاب", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Clear();
                        }
                        else
                        {
                            this.Size = new Size(904, 258);
                            textBox1.ReadOnly = true;
                            button1.Visible = false;

                        }

                    }


                    else
                    {
                        MessageBox.Show("من فضللك ادخل رقم الجلوس الصحيح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("من فضللك ادخل رقم الجلوس الصحيح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


        /*    }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعده البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/

                  /*      cmd = new SqlCommand("select count(*) from registeration where nationalid='" + nationalid + "' and [year]=" + x + " and semester='" + label4.Text + "'  and materialcode in (select materialcode from contr where year=" + x + " and semester='" + label4.Text + "' and write='" + "0" + "')", cn);
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
                            cmd = new SqlCommand("select MaterialCourseTitle from Materials where materialcode in(select materialcode from Registeration where nationalid='" + nationalid + "' and year=" + yea + " and semester='" + label4.Text + "' and appreciation in(select Appreciation from Registeration where not  appreciation='" + "W" + "'  )  or Appreciation is null  and  nationalid='" + nationalid + "' and year=" + yea + " and semester='" + label4.Text + "') and MaterialCode in(select materialcode from contr where year=" + yea + " and semester='" + label4.Text + "' and write='" + "0" + "')", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {

                                comboBox1.Items.Add(dr[0].ToString());

                            }
                            dr.Close();
                            cn.Close();
                            if (comboBox1.Items.Count == 0)
                            {
                                MessageBox.Show("عفوا لاتوجد مواد للانسحاب", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textBox1.Clear();
                            }
                            else
                            {
                                this.Size = new Size(904, 254);
                                button1.Visible = false;
                                textBox1.ReadOnly = true;
                            }
                        }*/

                   
        }
    }
}
