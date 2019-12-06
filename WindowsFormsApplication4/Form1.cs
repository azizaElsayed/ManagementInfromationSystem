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
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cm;
        SqlDataReader dr;
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
       
         
        }

        private void button1_Click(object sender, EventArgs e)
        {//*********************************************
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = null;
            }
            else
            {
                if (comboBox1.Text == "كنترول")
                {
                    cm = new SqlCommand("select Name,Pass,levels from controlemployee where  Name='" + textBox1.Text + "' and Pass='" + textBox2.Text + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        string levels = dr[2].ToString();
                        dr.Close();
                        cn.Close();
                        if (levels == "all")
                    {

                        cm = new SqlCommand("select stated,AdoptTheResult,year,semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                        cn.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        string hg = dr[0].ToString();
                        string n = dr[1].ToString();
                        int yea = Convert.ToInt32(dr[2].ToString());
                        string semester = dr[3].ToString();
                        dr.Close();
                        cn.Close();
                        if ((hg == "close") && (n == "0"))
                        {
                            cm = new SqlCommand("select Name from controlemployee where  Name='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'and semester='" + semester + "' and year=" + yea + " and not levels=  '" + "n" + "' ", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            if (dr.Read())
                            {
                                Form2 f2 = new Form2();
                                f2.toolStripMenuItem5.Visible = false;
                                f2.toolStripMenuItem1.Visible = false;
                                f2.ToolStripMenuItem.Visible = false;
                                f2.toolStripMenuItem7.Visible = false;


                                f2.toolStripMenuItem9.Visible = false;
                                f2.toolStripMenuItem14.Visible = false;
                                f2.toolStripButton1.Visible = false;
                                f2.toolStripButton2.Visible = false;
                                f2.toolStripButton3.Visible = false;



                                f2.toolStripSeparator1.Visible = false;
                                f2.toolStripSeparator2.Visible = false;
                                f2.toolStripSeparator3.Visible = false;
                                f2.toolStripSeparator5.Visible = false;

                                f2.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                comboBox1.Text = null;
                                this.Hide();
                            }
                            dr.Close();
                            cn.Close();
                        }



                    }
                    else if (levels == "000")
                    {
                        cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                        cn.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        string test = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        if (test == "0")
                        {

                            Form19 FrmWriteDegree = new Form19();
                            FrmWriteDegree.level = "000";
                            FrmWriteDegree.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    else if (levels == "001")
                    {
                        cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                        cn.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        string test = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        if (test == "0")
                        {
                            Form19 FrmWriteDegree = new Form19();
                            FrmWriteDegree.level = "001";
                            FrmWriteDegree.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else if (levels == "010")
                    {

                        cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                        cn.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        string test = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        if (test == "0")
                        {
                            Form19 FrmWriteDegree = new Form19();
                            FrmWriteDegree.level = "010";
                            FrmWriteDegree.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                    else if (levels == "100")
                    {
                        cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                        cn.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        string test = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        if (test == "0")
                        {
                            Form19 FrmWriteDegree = new Form19();
                            FrmWriteDegree.level = "100";
                            FrmWriteDegree.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    else if (levels == "111")
                    {
                        cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                        cn.Open();
                        dr = cm.ExecuteReader();
                        dr.Read();
                        string test = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        if (test == "0")
                        {
                            Form19 FrmWriteDegree = new Form19();
                            FrmWriteDegree.level = "111";
                            FrmWriteDegree.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {


                        string hg = dr[0].ToString();
                        string n = dr[1].ToString();
                        int yea = Convert.ToInt32(dr[2].ToString());
                        string semester = dr[3].ToString();
                        dr.Close();
                        cn.Close();
                        if ((hg == "close") && (n == "0"))
                        {
                            cm = new SqlCommand("select Name from controlemployee where  Name='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'and semester='" + semester + "' and year=" + yea + " and not levels=  '" + "n" + "' ", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            if (dr.Read())
                            {
                                Form2 f2 = new Form2();
                                f2.toolStripMenuItem5.Visible = false;
                                f2.toolStripMenuItem1.Visible = false;
                                f2.ToolStripMenuItem.Visible = false;
                                f2.toolStripMenuItem7.Visible = false;


                                f2.toolStripMenuItem9.Visible = false;
                                f2.toolStripMenuItem14.Visible = false;
                                f2.toolStripButton1.Visible = false;
                                f2.toolStripButton2.Visible = false;
                                f2.toolStripButton3.Visible = false;



                                f2.toolStripSeparator1.Visible = false;
                                f2.toolStripSeparator2.Visible = false;
                                f2.toolStripSeparator3.Visible = false;
                                f2.toolStripSeparator5.Visible = false;

                                f2.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                comboBox1.Text = null;
                                this.Hide();
                            }
                            dr.Close();
                            cn.Close();
                        }




                        else if (levels == "000")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {

                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "000";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        else if (levels == "001")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "001";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else if (levels == "010")
                        {

                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "010";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }


                        }
                        else if (levels == "100")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "100";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        else if (levels == "111")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "111";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }











                        //label3.Visible = true;
                        //label4.Visible = true;
                        //label5.Visible = true;
                        //label6.Visible = true;
                        //textBox1.Clear();
                        //textBox2.Clear();
                        //comboBox1.Text = null;




                    }



                }
                else
                {
                    cm = new SqlCommand("select Name,Pass,levels from controlemployee where  Name='" + textBox1.Text + "' and Pass='" + textBox2.Text + "' ", cn);
                    //  cn.Open();
                    //   dr = cm.ExecuteReader();
                    if (dr.Read())
                    {

                        string levels = dr[2].ToString();
                        dr.Close();
                        cn.Close();
                        string hg = dr[0].ToString();
                        string n = dr[1].ToString();
                        int yea = Convert.ToInt32(dr[2].ToString());
                        string semester = dr[3].ToString();
                        dr.Close();
                        cn.Close();
                        if ((hg == "close") && (n == "0"))
                        {
                            cm = new SqlCommand("select Name from controlemployee where  Name='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'and semester='" + semester + "' and year=" + yea + " and not levels=  '" + "n" + "' ", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            if (dr.Read())
                            {
                                Form2 f2 = new Form2();
                                f2.toolStripMenuItem5.Visible = false;
                                f2.toolStripMenuItem1.Visible = false;
                                f2.ToolStripMenuItem.Visible = false;
                                f2.toolStripMenuItem7.Visible = false;


                                f2.toolStripMenuItem9.Visible = false;
                                f2.toolStripMenuItem14.Visible = false;
                                f2.toolStripButton1.Visible = false;
                                f2.toolStripButton2.Visible = false;
                                f2.toolStripButton3.Visible = false;



                                f2.toolStripSeparator1.Visible = false;
                                f2.toolStripSeparator2.Visible = false;
                                f2.toolStripSeparator3.Visible = false;
                                f2.toolStripSeparator5.Visible = false;

                                f2.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                comboBox1.Text = null;
                                this.Hide();
                            }
                            dr.Close();
                            cn.Close();
                        }




                        else if (levels == "000")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {

                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "000";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        else if (levels == "001")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "001";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else if (levels == "010")
                        {

                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "010";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }


                        }
                        else if (levels == "100")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "100";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        else if (levels == "111")
                        {
                            cm = new SqlCommand("select count(*) from student where studentid is null", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string test = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            if (test == "0")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "111";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }


                        //   label3.Visible = true;
                        //label4.Visible = true;
                        //label5.Visible = true;
                        //label6.Visible = true;
                        //textBox1.Clear();
                        //textBox2.Clear();
                        //comboBox1.Text = null;
                        //   dr.Close();
                        //   cn.Close();


                    }

                }
            }
        
                //*********
                else if (comboBox1.Text == "رئيس شؤون الطلبه")
                {


                    cm = new SqlCommand("exec mainaffirstudent @name='" + textBox1.Text + "'  ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {

                        dr.Close();
                        cn.Close();
                        Form2 f2 = new Form2();
                        //  f2.toolStripMenuItem6.Visible = false;
                        f2.toolStripMenuItem7.Visible = false;

                        f2.toolStripButton3.Visible = false;
                        f2.toolStripButton4.Visible = false;

                        f2.toolStripSeparator2.Visible = false;
                        f2.toolStripSeparator3.Visible = false;


                        f2.Show();


                    }
                    else
                    {




                        Form2 f2 = new Form2();
                        //  f2.toolStripMenuItem6.Visible = false;
                        f2.toolStripMenuItem7.Visible = false;

                        f2.toolStripButton3.Visible = false;
                        f2.toolStripButton4.Visible = false;

                        f2.toolStripSeparator2.Visible = false;
                        f2.toolStripSeparator3.Visible = false;


                        f2.Show();


                        //dr.Close();
                        //cn.Close();

                        //label3.Visible = true;
                        //label4.Visible = true;
                        //label5.Visible = true;
                        //label6.Visible = true;
                        //textBox1.Clear();
                        //textBox2.Clear();
                        //comboBox1.Text = null;


                    }


                }
                //****

                else
                {
                    cm = new SqlCommand("select employeeName,employeePass from employee where  employeeName='" + textBox1.Text + "' and employeePass='" + textBox2.Text + "'and account='" + comboBox1.Text + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        cn.Close();

                        if (comboBox1.Text == "تسجيل")
                        {
                            Form2 f2 = new Form2();
                            f2.toolStripMenuItem5.Visible = false;
                            //  f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripMenuItem9.Visible = false;
                            f2.toolStripMenuItem14.Visible = false;

                            f2.toolStripButton1.Visible = false;
                            f2.toolStripButton2.Visible = false;
                            f2.toolStripButton4.Visible = false;

                            f2.toolStripSeparator1.Visible = false;
                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator4.Visible = false;
                            f2.toolStripSeparator5.Visible = false;

                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.Text = null;
                            this.Hide();

                        }
                        else if (comboBox1.Text == "شؤون الطلبه")
                        {
                            dr.Close();
                            cn.Close();
                            Form2 f2 = new Form2();
                            //  f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripButton3.Visible = false;
                            f2.toolStripButton4.Visible = false;

                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator3.Visible = false;

                            f2.toolStripMenuItem14.Visible = false;
                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.Text = null;
                            this.Hide();
                        }


                    }
                    else
                    {

                        Form2 f2 = new Form2();
                        //  f2.toolStripMenuItem6.Visible = false;
                        f2.toolStripMenuItem7.Visible = false;

                        f2.toolStripButton3.Visible = false;
                        f2.toolStripButton4.Visible = false;

                        f2.toolStripSeparator2.Visible = false;
                        f2.toolStripSeparator3.Visible = false;

                        f2.toolStripMenuItem14.Visible = false;
                        f2.Show();

                        //          dr.Close();
                        //     cn.Close();
                        //label3.Visible = true;
                        //  label4.Visible = true;
                        //  label5.Visible = true;
                        //  label6.Visible = true;
                        //  textBox1.Clear();
                        //  textBox2.Clear();
                        //  comboBox1.Text = null;

                    }
                }
            }

            //*********************************************************************************************************


/*
                
                if(comboBox1.Text=="كنترول")
                {
              cm = new SqlCommand("select Name,Pass,levels from controlemployee where  Name='" + textBox1.Text + "' and Pass='" + textBox2.Text + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        string levels = dr[2].ToString();
                        dr.Close();
                        cn.Close();
                        if (levels == "all")
                        {
                            cm = new SqlCommand("select stated,AdoptTheResult,year,semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            dr.Read();
                            string hg = dr[0].ToString();
                            string n = dr[1].ToString();
                            int yea = Convert.ToInt32(dr[2].ToString());
                            string semester = dr[3].ToString();
                            dr.Close();
                            cn.Close();
                            if ((hg == "close") && (n == "0"))
                            {
                                cm = new SqlCommand("select Name from controlemployee where  Name='" + textBox1.Text + "' and Pass='" + textBox2.Text + "'and semester='" + semester + "' and year=" + yea + " and not levels=  '" + "n" + "' ", cn);
                                cn.Open();
                                dr = cm.ExecuteReader();
                                if (dr.Read())
                                {
                                    Form2 f2 = new Form2();
                                    f2.toolStripMenuItem5.Visible = false;
                                    f2.toolStripMenuItem1.Visible = false;
                                    f2.ToolStripMenuItem.Visible = false;
                                    f2.toolStripMenuItem7.Visible = false;

                                 //   f2.toolStripMenuItem28.Visible = false;
                                    f2.toolStripMenuItem9.Visible = false;
                                    f2.toolStripMenuItem14.Visible = false;
                                    f2.toolStripButton1.Visible = false;
                                    f2.toolStripButton2.Visible = false;
                                    f2.toolStripButton3.Visible = false;
                                   // f2.toolStripMenuItem28.Visible = false;


                                    f2.toolStripSeparator1.Visible = false;
                                    f2.toolStripSeparator2.Visible = false;
                                    f2.toolStripSeparator3.Visible = false;
                                    f2.toolStripSeparator5.Visible = false;

                                    f2.Show();
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    comboBox1.Text = null;
                                    this.Hide();
                                }
                                dr.Close();
                                cn.Close();
                            }

                        }
                        else
                        {

                            if (levels == "000")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "000";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();

                            }
                            else if (levels == "001")
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "001";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else if (levels == "010")
                            {

                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "010";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                this.Hide();
                            }
                            else
                            {
                                Form19 FrmWriteDegree = new Form19();
                                FrmWriteDegree.level = "100";
                                FrmWriteDegree.Show();
                                textBox1.Clear();
                                textBox2.Clear();
                                comboBox1.Text = null;
                                this.Hide();
                            }
                        }

                    }
                    else
                    {
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        label6.Visible = true;
                        textBox1.Clear();
                        textBox2.Clear();
                        comboBox1.Text = null;
                        dr.Close();
                        cn.Close();
                    }
                }


//غير الكنترول


                else
                {
                   
                    //
                    cm = new SqlCommand("select employeeName,employeePass from employee where  employeeName='" + textBox1.Text + "' and employeePass='" + textBox2.Text + "'and account='"+comboBox1.Text+"' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        cn.Close();
                        if (comboBox1.Text == "تسجيل")
                        {
                            Form2 f2 = new Form2();
                            f2.toolStripMenuItem5.Visible = false;
                            f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripMenuItem9.Visible = false;
                            f2.toolStripMenuItem14.Visible = false;

                            f2.toolStripButton1.Visible = false;
                            f2.toolStripButton2.Visible = false;
                            f2.toolStripButton4.Visible = false;

                            f2.toolStripSeparator1.Visible = false;
                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator4.Visible = false;
                            f2.toolStripSeparator5.Visible = false;

                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.Text = null;
                            this.Hide();
                        }



                        else if (comboBox1.Text == "رئيس شؤون الطلبه")
                        {
                            
                            cm = new SqlCommand("exec mainaffirstudent  ", cn);
                            cn.Open();
                            dr = cm.ExecuteReader();
                            if (dr.Read())
                            {

                                dr.Close();
                                cn.Close();
                                Form2 f2 = new Form2();
                               // f2.toolStripMenuItem6.Visible = false;
                                f2.toolStripMenuItem7.Visible = false;

                                f2.toolStripButton3.Visible = false;
                                f2.toolStripButton4.Visible = false;

                                f2.toolStripSeparator2.Visible = false;
                                f2.toolStripSeparator3.Visible = false;


                                f2.Show();


                            }
                            else
                            {

                                dr.Close();
                                cn.Close();

                                label3.Visible = true;
                                label4.Visible = true;
                                label5.Visible = true;
                                label6.Visible = true;
                                textBox1.Clear();
                                textBox2.Clear();
                                comboBox1.Text = null;
                            }

                        }
                        else if (comboBox1.Text == "شؤون الطلبه")
                        {
                            dr.Close();
                            cn.Close();
                            Form2 f2 = new Form2();
                        //    f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripButton3.Visible = false;
                            f2.toolStripButton4.Visible = false;

                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator3.Visible = false;

                            f2.toolStripMenuItem14.Visible = false;
                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.Text = null;
                            this.Hide();
                        }


                        else
                        {
                            label3.Visible = true;
                            label4.Visible = true;
                            label5.Visible = true;
                            label6.Visible = true;
                            textBox1.Clear();
                            textBox2.Clear();
                            comboBox1.Text = null;
                            dr.Close();
                            cn.Close();
                        }



                    }


                }
 

            }

             /*                              else if(levels=="شؤون الطلبه")
                    {
                          
 Form2 f2 = new Form2();
                            f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripButton3.Visible = false;
                            f2.toolStripButton4.Visible = false;

                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator3.Visible = false;


                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                                 comboBox1.Text=null;
                            this.Hide();
                    }
             */

         /*   try
            {
                
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    cm = new SqlCommand("select employeeName,employeePass,account from employee where  employeeName='" + textBox1.Text + "' and employeePass='" + textBox2.Text + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();

                    if (dr.Read())
                    {


                        //ضع الثلاث حالات تسجيل وكنترول وشوؤن
                        if (dr[2].ToString() == "تسجيل")
                        {
                            Form2 f2 = new Form2();
                            f2.toolStripMenuItem5.Visible = false;
                            f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripMenuItem9.Visible = false;
                            f2.toolStripMenuItem14.Visible = false;

                            f2.toolStripButton1.Visible = false;
                            f2.toolStripButton2.Visible = false;
                            f2.toolStripButton4.Visible = false;

                            f2.toolStripSeparator1.Visible = false;
                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator4.Visible = false;
                            f2.toolStripSeparator5.Visible = false;

                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();

                        }
                        else if (dr[2].ToString() == "كنترول")
                        {
                            Form2 f2 = new Form2();
                            f2.toolStripMenuItem5.Visible = false;
                            f2.toolStripMenuItem1.Visible = false;
                            f2.ToolStripMenuItem.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;
                            f2.toolStripMenuItem21.Visible = false;
                            f2.toolStripMenuItem22.Visible = false;
                            f2.toolStripMenuItem24.Visible = false;
                            f2.toolStripMenuItem27.Visible = false;

                            f2.toolStripMenuItem9.Visible = false;
                            f2.toolStripMenuItem14.Visible = false;
                            f2.toolStripButton1.Visible = false;
                            f2.toolStripButton2.Visible = false;
                            f2.toolStripButton3.Visible = false;


                            f2.toolStripSeparator1.Visible = false;
                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator3.Visible = false;
                            f2.toolStripSeparator5.Visible = false;

                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }
                        else if (dr[2].ToString() == "رئيس الكنترول")
                        {
                            Form2 f2 = new Form2();
                            f2.toolStripMenuItem5.Visible = false;
                            f2.toolStripMenuItem1.Visible = false;
                            f2.ToolStripMenuItem.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripMenuItem28.Visible = false;
                            f2.toolStripMenuItem9.Visible = false;
                            f2.toolStripMenuItem14.Visible = false;
                            f2.toolStripButton1.Visible = false;
                            f2.toolStripButton2.Visible = false;
                            f2.toolStripButton3.Visible = false;


                            f2.toolStripSeparator1.Visible = false;
                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator3.Visible = false;
                            f2.toolStripSeparator5.Visible = false;

                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }
                        else if (dr[2].ToString() == "الاداره")
                        {

                            Form2 f2 = new Form2();
                            f2.toolStripMenuItem5.Visible = false;
                            f2.toolStripMenuItem1.Visible = false;
                            f2.ToolStripMenuItem.Visible = false;
                            f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem9.Visible = false;
                            f2.toolStripMenuItem14.Visible = false;




                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }

                        else
                        {
                            Form2 f2 = new Form2();
                            f2.toolStripMenuItem6.Visible = false;
                            f2.toolStripMenuItem7.Visible = false;

                            f2.toolStripButton3.Visible = false;
                            f2.toolStripButton4.Visible = false;

                            f2.toolStripSeparator2.Visible = false;
                            f2.toolStripSeparator3.Visible = false;


                            f2.Show();
                            textBox1.Clear();
                            textBox2.Clear();
                            this.Hide();
                        }

                        dr.Close();
                        cn.Close();
                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                        label3.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        textBox1.Clear();
                        textBox2.Clear();

                    }
                
               
            }
            catch
            {
                MessageBox.Show(" التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }*/
          



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
             
             if (e.KeyCode == Keys.Enter)
            {
              textBox2.Focus();
                
            }

            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();

            }

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                label3.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
            }
         
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                label3.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
            }
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;

            }
           
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                label3.Visible = false;
                label5.Visible = false;
                label4.Visible = false;
                label6.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else{
                textBox2.UseSystemPasswordChar = true;

            }
        }
    }
}
