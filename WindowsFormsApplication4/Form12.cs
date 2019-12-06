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
    public partial class Form12 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand();
        SqlCommand cm = new SqlCommand();
        DataSet ds;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        string Variable;
        int X;
        int Y;
        int Z;
                int Q;
        
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

            this.Size = new Size(742, 179);
            
            int yea = Convert.ToInt16(label4.Text);

            cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "' or year="+yea+" and semester='"+label6.Text+"' and Appreciation is null))", cn);
                //   cmd = new SqlCommand("select materialcoursetitle from materials where materialcode in(select materialcode from registeration where  year=" + yea + " and semester='" + label6.Text + "')", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    comboBox1.Items.Add(dr[0].ToString());

                }
                dr.Close();
                cn.Close();
            
         
           
            //----------------------------
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label18.Visible = true;
            label8.Visible = true;
            label17.Visible = true;
        
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label7.Visible = true;
        //    try
          //  {
                if (!string.IsNullOrEmpty(comboBox1.Text))
                {
                 
                    //
                    cmd = new SqlCommand("exec determine @course='" + comboBox1.Text + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    Q = Convert.ToInt32(dr[0].ToString());
                    X = Convert.ToInt32(dr[1].ToString());
                    Y = Convert.ToInt32(dr[2].ToString());
                    Z = Convert.ToInt32(dr[3].ToString());
                    dr.Close();
                    cn.Close();
                    if (Q == 0)
                    {
                        label18.Visible = false;
                        label8.Visible = false;
                        label17.Visible = false;
                        label9.Text = Convert.ToString(Z);
                        label11.Text = Convert.ToString(Y);
                        label13.Text = Convert.ToString(X);
                        label15.Visible = false;
                        label14.Visible = false;
                    
                        /*   label9.Text = Convert.ToString(X);
                           label11.Text = Convert.ToString(Y);
                           label13.Text = Convert.ToString(Z);
                           label15.Visible = false;
                           label14.Visible = false;*/
                        Da = new SqlDataAdapter(" SELECT student.Studentid as [رقم الجلوس], registeration.YearOfWork as[اعمال السنه],Registeration.midterm as[درجه نصف الترم],Registeration.Final as[درجه نهائي],Registeration.degree as [مجوع الدرجات],registeration.appreciation as[التقدير],registeration.gpa as[عدد النقاط المكتسبه] FROM student INNER JOIN registeration ON Student.NationalId = Registeration.nationalid where appreciation in(select Appreciation from Registeration where not  appreciation='W'  )   and year=" + Convert.ToInt32(label4.Text) + " and semester='" + label6.Text + "' and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "') or appreciation is null and year=" + Convert.ToInt32(label4.Text) + " and semester='" + label6.Text + "' and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "')", cn);
                     //   Da = new SqlDataAdapter(" SELECT student.Studentid as [رقم الجلوس], registeration.YearOfWork as[اعمال السنه],Registeration.midterm as[درجه نصف الترم],Registeration.Final as[درجه نهائي],Registeration.degree as [مجوع الدرجات],registeration.appreciation as[التقدير],registeration.gpa as[عدد النقاط المكتسبه] FROM student INNER JOIN registeration ON Student.NationalId = Registeration.nationalid where not registeration.appreciation='" + "W" + "' and year=" + Convert.ToInt32(label4.Text) + "and semester='" + label6.Text + "'and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "') ", cn);
                     //   Da = new SqlDataAdapter(" SELECT student.Studentid as [رقم الجلوس], registeration.YearOfWork as[اعمال السنه],Registeration.midterm as[درجه نصف الترم],Registeration.Final as[درجه نهائي],Registeration.degree as [مجوع الدرجات],registeration.appreciation as[التقدير],registeration.gpa as[عدد النقاط المكتسبه] FROM student INNER JOIN registeration ON Student.NationalId = Registeration.nationalid where not appreciation='"+"W"+"' and year=" + Convert.ToInt32(label4.Text) + "and semester='" + label6.Text + "'and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "') ", cn);
                        ds = new DataSet();
                        Da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        string v = comboBox1.Text;
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add(v);
                        comboBox1.Text = v;

                        dataGridView1.Columns[0].ReadOnly = true;
                        dataGridView1.Columns[4].ReadOnly = true;
                        dataGridView1.Columns[5].ReadOnly = true;
                        dataGridView1.Columns[6].ReadOnly = true;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[1]).MaxInputLength = 2;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[2]).MaxInputLength = 2;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[3]).MaxInputLength = 2;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[4]).MaxInputLength = 3;
                        button1.Visible = false;
                        this.Size = new Size(742, 609);
                        button1.Visible = true;
                        button2.Visible = false;


                    }
                    else if(Q==100)
                    {
                    //مواد زى الكمبيوتر
                        label7.Visible = false;
                       
                        label9.Visible = false;
                        label10.Visible = false;
                        label11.Visible = false;
                        label12.Visible = false;
                        label13.Visible = false;
                        label14.Visible = false;
                        label15.Visible = false;
                        label16.Visible = false;
                        label1.Visible = false;
                        Da = new SqlDataAdapter(" SELECT student.Studentid as [رقم الجلوس] FROM student INNER JOIN registeration ON Student.NationalId = Registeration.nationalid where appreciation in(select Appreciation from Registeration where not  appreciation='W'  )   and year=" + Convert.ToInt32(label4.Text) + " and semester='" + label6.Text + "' and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "') or appreciation is null and year=" + Convert.ToInt32(label4.Text) + " and semester='" + label6.Text + "' and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "')", cn);
                       // Da = new SqlDataAdapter(" SELECT student.Studentid as [رقم الجلوس] FROM student INNER JOIN registeration ON Student.NationalId = Registeration.nationalid where year=" + Convert.ToInt32(label4.Text) + "and semester='" + label6.Text + "'and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "') ", cn);
                        ds = new DataSet();
                        Da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        string v = comboBox1.Text;
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add(v);
                        comboBox1.Text = v;
                        DataGridViewComboBoxColumn apprciation = new DataGridViewComboBoxColumn();
                        apprciation.HeaderText = "التقدير";
                        dataGridView1.Columns.Add(apprciation);
                        apprciation.Items.Add("P");
                        apprciation.Items.Add("NP");
                        for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                        {

                            cmd = new SqlCommand("select appreciation from registeration where nationalid in (select nationalid from student where studentid='" + dataGridView1.Rows[l].Cells[0].Value + "')", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                string app = dr[0].ToString();
                                dr.Close();
                                cn.Close();
                                if (app == "P")
                                    dataGridView1.Rows[l].Cells[1].Value = "P";
                                else if (app == "NP")
                                    dataGridView1.Rows[l].Cells[1].Value = "NP";

                            }
                            dr.Close();
                            cn.Close();


                        }


                        dataGridView1.Columns[0].ReadOnly = true;
                        this.Size = new Size(742, 639);
                        button2.Visible = false;

                    }
                    else
                    {
                        label18.Visible = false;
                        label8.Visible = false;
                        label17.Visible = false;
                        label9.Text = Convert.ToString(Z);
                        label11.Text = Convert.ToString(Y);
                        label13.Text = Convert.ToString(X);
                        label15.Text = Convert.ToString(Q);
                        //   dataGridView2.Visible = false;
                        /*  label9.Text = Convert.ToString(X);
                          label11.Text = Convert.ToString(Y);
                          label13.Text = Convert.ToString(Z);
                          label15.Text = Convert.ToString(Q);*/
                        Da = new SqlDataAdapter(" SELECT student.Studentid as [رقم الجلوس], registeration.YearOfWork as[اعمال السنه],Registeration.midterm as[درجه نصف الترم],Registeration.Quiz as[العملى/الشفوى],Registeration.Final as [درجه نهائي],Registeration.degree as [مجوع الدرجات],registeration.appreciation as[التقدير],registeration.gpa as[عدد النقاط المكتسبه] FROM student INNER JOIN registeration ON Student.NationalId = Registeration.nationalid where appreciation in(select Appreciation from Registeration where not  appreciation='W'  )   and year=" + Convert.ToInt32(label4.Text) + " and semester='" + label6.Text + "' and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "') or appreciation is null and year=" + Convert.ToInt32(label4.Text) + " and semester='" + label6.Text + "' and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "')", cn);
                     //   Da = new SqlDataAdapter(" SELECT student.Studentid as [رقم الجلوس], registeration.YearOfWork as[اعمال السنه],Registeration.midterm as[درجه نصف الترم],Registeration.Quiz as [العملى/الشفوى],Registeration.Final as[درجه نهائي],Registeration.degree as [مجوع الدرجات],registeration.appreciation as[التقدير],registeration.gpa as[عدد النقاط المكتسبه] FROM student INNER JOIN registeration ON Student.NationalId = Registeration.nationalid where year=" + Convert.ToInt32(label4.Text) + "and semester='" + label6.Text + "'and materialcode=(select materialcode from materials where materialcoursetitle='" + comboBox1.Text + "') ", cn);
                        ds = new DataSet();
                        Da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        string v = comboBox1.Text;
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add(v);
                        comboBox1.Text = v;
                        dataGridView1.Columns[0].ReadOnly = true;
                        dataGridView1.Columns[5].ReadOnly = true;
                        dataGridView1.Columns[6].ReadOnly = true;
                        dataGridView1.Columns[7].ReadOnly = true;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[1]).MaxInputLength = 2;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[2]).MaxInputLength = 2;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[3]).MaxInputLength = 2;
                        ((DataGridViewTextBoxColumn)dataGridView1.Columns[4]).MaxInputLength = 2;
                        //     ((DataGridViewTextBoxColumn)dataGridView1.Columns[]).MaxInputLength = 3;
                        button1.Visible = false;
                        this.Size = new Size(742, 609);
                        button1.Visible = true;
                        button2.Visible = false;
                    }
                }
        
                else
            {
                MessageBox.Show("رجاء ادخل الماده الدراسيه  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }

        
            //}
            //
        /*    try
            {

                int y = Convert.ToInt16(label4.Text);
                cmd = new SqlCommand("select materialcode from materials where materialCourseTitle='" + comboBox1.Items[comboBox1.SelectedIndex].ToString() + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string b = dr[0].ToString();
                dr.Close();
                cn.Close();
                if (b == "HUM 081")
                {

                    dataGridView1.Visible = false;
                    Da = new SqlDataAdapter("select student.Studentid,apprection from student inner join registeration on student.nationalid=registeration.nationalid", cn);
                    ds = new DataSet();
                    Da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    DataGridViewComboBoxColumn sb = new DataGridViewComboBoxColumn();
                    sb.HeaderText = "apprciation";
                    dataGridView2.Columns.Add(sb);
                    sb.Items.Add("P");
                    sb.Items.Add("NP");
                    dataGridView2.Columns[0].ReadOnly = true;
                    button2.Visible = false;
                    button5.Visible = false;
                    label1.Visible = false;
                    comboBox2.Visible = false;
                    string v = comboBox1.Text;
                    comboBox1.Items.Clear();

                    button2.Visible = false;
                    comboBox1.Items.Add(v);
                    comboBox1.Text = v;
                    this.Size = new Size(742, 511);
                }
                else
                {
                    string v = comboBox1.Text;
                    comboBox1.Items.Clear();
                 
                    button2.Visible = false;
                    comboBox1.Items.Add(v);
                    comboBox1.Text = v;
                    this.Size = new Size(742, 220);
                }
            }*/
         /*   catch
            {
                MessageBox.Show("رجاء ادخل الماده الدراسيه  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Q == 0)
            {
                int s = 0;
                for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView1.Rows[l].Cells[5].Value ==DBNull.Value)
                        s = s + 1;
                }
                if (s != 0)
                {
                    MessageBox.Show("لم يتم رصد درجات الطلاب من فضلك قم بادخال الدرجات لجميع الطلاب  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    DialogResult r = MessageBox.Show("تاكيد رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int year = Convert.ToInt16(label4.Text);
                        for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                        {
                            cmd = new SqlCommand(" select nationalid from student where studentid=" + dataGridView1.Rows[l].Cells[0].Value + " ", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            string NationalId = dr[0].ToString();
                            dr.Close();
                            cn.Close();

                            cmd = new SqlCommand(" exec inserte @idofstudent='" + NationalId + "' ,@course='" + comboBox1.Text + "',@degree=" + dataGridView1.Rows[l].Cells[4].Value + ",@year=" + year + " ,@semester='" + label6.Text + "', @appreciation='" + dataGridView1.Rows[l].Cells[5].Value + "',@gpa=" + dataGridView1.Rows[l].Cells[6].Value + ",@final=" + dataGridView1.Rows[l].Cells[3].Value + ",@midterm=" + dataGridView1.Rows[l].Cells[1].Value + ",@YearOfWork=" + dataGridView1.Rows[l].Cells[2].Value + " ", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cm = new SqlCommand(" exec sumgpa @idofstudent='" + NationalId + "' ,@year=" + year + " ,@semester='" + label6.Text + "' ", cn);
                            cn.Open();
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        comboBox1.Items.Remove(comboBox1.Text);
                        //




                        comboBox1.Text = null;
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();


                        int yea = Convert.ToInt16(label4.Text);
                        cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "' or year=" + yea + " and semester='" + label6.Text + "' and Appreciation is null))", cn);
                      //  cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "'))", cn);
                    //    cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "')", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            comboBox1.Items.Add(dr[0].ToString());

                        }
                        dr.Close();
                        cn.Close();
                        button1.Visible = true;
                        this.Size = new Size(742, 179);
                        button2.Visible = true;


                    }
                }
            }
            else if(Q==100)
            {
//مواد زى الكمبيوتر
                int s = 0;
                for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView1.Rows[l].Cells[1].Value == null)
                        s = s + 1;
                }
                if (s != 0)
                {
                    MessageBox.Show("لم يتم رصد درجات الطلاب من فضلك قم بادخال الدرجات لجميع الطلاب  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    DialogResult r = MessageBox.Show("تاكيد رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int year = Convert.ToInt16(label4.Text);
                        for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                        {
                            cmd = new SqlCommand(" select nationalid from student where studentid=" + dataGridView1.Rows[l].Cells[0].Value + " ", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            string NationalId = dr[0].ToString();
                            dr.Close();
                            cn.Close();

                            cmd = new SqlCommand(" exec inserte2 @idofstudent='" + NationalId + "', @course='" + comboBox1.Text + "',@appreciation='" + dataGridView1.Rows[l].Cells[1].Value + "', @year=" + year + " , @semester='" + label6.Text + "' ", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cm = new SqlCommand(" exec sumgpa @idofstudent='" + NationalId + "' ,@year=" + year + " ,@semester='" + label6.Text + "' ", cn);
                            cn.Open();
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }

                        cmd = new SqlCommand(" exec insertwrite @course='" + comboBox1.Text + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();

                        comboBox1.Items.Remove(comboBox1.Text);
                        //




                        comboBox1.Text = null;
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();


                        int yea = Convert.ToInt16(label4.Text);
                        cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "' or year=" + yea + " and semester='" + label6.Text + "' and Appreciation is null))", cn);
                      //  cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "'))", cn);
                 //       cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "')", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            comboBox1.Items.Add(dr[0].ToString());

                        }
                        dr.Close();
                        cn.Close();
                        button1.Visible = true;
                        this.Size = new Size(742, 179);
                        button2.Visible = true;




                    }

                }

            }
            else
            {

                int s = 0;
                for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView1.Rows[l].Cells[5].Value == DBNull.Value)
                        s = s + 1;
                }
                if (s != 0)
                {
                    MessageBox.Show("لم يتم رصد درجات الطلاب من فضلك قم بادخال الدرجات لجميع الطلاب  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    DialogResult r = MessageBox.Show("تاكيد رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int year = Convert.ToInt16(label4.Text);
                        for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                        {
                            cmd = new SqlCommand(" select nationalid from student where studentid=" + dataGridView1.Rows[l].Cells[0].Value + " ", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            string NationalId = dr[0].ToString();
                            dr.Close();
                            cn.Close();

                            cmd = new SqlCommand(" exec inserte5 @idofstudent='" + NationalId + "' ,@course='" + comboBox1.Text + "',@degree=" + dataGridView1.Rows[l].Cells[5].Value + ",@year=" + year + " ,@semester='" + label6.Text + "', @appreciation='" + dataGridView1.Rows[l].Cells[6].Value + "',@gpa=" + dataGridView1.Rows[l].Cells[7].Value + ",@final=" + dataGridView1.Rows[l].Cells[4].Value + ",@midterm=" + dataGridView1.Rows[l].Cells[2].Value + ",@YearOfWork=" + dataGridView1.Rows[l].Cells[1].Value + ",@quiz=" + dataGridView1.Rows[l].Cells[3].Value + " ", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cm = new SqlCommand(" exec sumgpa @idofstudent='" + NationalId + "' ,@year=" + year + " ,@semester='" + label6.Text + "' ", cn);
                            cn.Open();
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        comboBox1.Items.Remove(comboBox1.Text);
                        //




                        comboBox1.Text = null;
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();


                        int yea = Convert.ToInt16(label4.Text);
                        cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "' or year=" + yea + " and semester='" + label6.Text + "' and Appreciation is null))", cn);
                     //   cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "'))", cn);
                     //   cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "')", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            comboBox1.Items.Add(dr[0].ToString());

                        }
                        dr.Close();
                        cn.Close();
                        button1.Visible = true;
                        button2.Visible = true;
                        this.Size = new Size(742, 179);


                    }
                }
            }


            /*if (dataGridView1.Visible == true)
            {
                int s = 0;
                for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView1.Rows[l].Cells[4].Value == DBNull.Value)
                        s = s + 1;
                }
                if (s != 0)
                {
                    MessageBox.Show("لم يتم رصد درجات الطلاب من فضلك قم بادخال الدرجات لجميع الطلاب  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    DialogResult r = MessageBox.Show("تاكيد رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int year = Convert.ToInt16(label4.Text);
                        for (int l = dataGridView1.Rows.Count-1 ; l >= 0; l--)
                        {
                            cmd = new SqlCommand(" select nationalid from student where studentid=" + dataGridView1.Rows[l].Cells[0].Value+" ", cn);
                            cn.Open();
                           dr= cmd.ExecuteReader();
                            dr.Read();
                           string NationalId =dr[0].ToString();
                            dr.Close();
                            cn.Close();
                          
                            cmd = new SqlCommand(" exec inserte @idofstudent='" + NationalId + "' ,@course='" + comboBox1.Text + "',@degree=" + dataGridView1.Rows[l].Cells[4].Value + ",@year=" + year + " ,@semester='" + label6.Text + "', @appreciation='" + dataGridView1.Rows[l].Cells[5].Value + "',@gpa=" + dataGridView1.Rows[l].Cells[6].Value + ",@final=" + dataGridView1.Rows[l].Cells[3].Value + ",@midterm=" + dataGridView1.Rows[l].Cells[1].Value + ",@YearOfWork=" + dataGridView1.Rows[l].Cells[2].Value + " ", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cm = new SqlCommand(" exec sumgpa @idofstudent='" + NationalId + "' ,@year=" + year + " ,@semester='" + label6.Text + "' ", cn);
                            cn.Open();
                            cm.ExecuteNonQuery();
                            cn.Close();

                          


                        }
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add("A");
                        comboBox2.Items.Add("B");
                        comboBox2.Items.Add("C");
                        comboBox1.Items.Remove(comboBox1.Text);
                        //
                        this.Size = new Size(742, 176);
                        button5.Visible = true;
                        label1.Visible = true;
                        comboBox2.Visible = true;
                        comboBox2.Text = null;
                        comboBox1.Text = null;
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        dataGridView2.Visible = true;
                        button2.Visible = true;
                        int yea = Convert.ToInt16(label4.Text);
                        cmd = new SqlCommand("select materialcoursetitle from materials where materialcode in(select materialcode from registeration where  year=" + yea + " and semester='" + label6.Text + "')", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            comboBox1.Items.Add(dr[0].ToString());

                        }
                        dr.Close();
                        cn.Close();

                    }
                }

            }
            else
            {

                int s = 0;
                for (int l = dataGridView2.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView2.Rows[l].Cells[1].Value == DBNull.Value)
                        s = s + 1;
                }
                if (s != 0)
                {
                    MessageBox.Show("لم يتم رصد درجات الطلاب من فضلك قم بادخال الدرجات لجميع الطلاب  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    DialogResult r = MessageBox.Show("تاكيد رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        int year = Convert.ToInt16(label4.Text);
                        for (int l = dataGridView2.Rows.Count - 1; l >= 0; l--)
                        {
                            cmd = new SqlCommand(" select nationalid from student where studentid=" + dataGridView2.Rows[l].Cells[0].Value + " ", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            string NationalId = dr[0].ToString();
                            dr.Close();
                            cn.Close();
                            cmd = new SqlCommand(" exec inserte2 @idofstudent='" + NationalId + "', @course='" + comboBox1.Text + "',@appreciation='" + dataGridView2.Rows[l].Cells[1].Value + "', @year=" + year + " , @semester='" + label6.Text + "' ", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                            cm = new SqlCommand(" exec sumgpa @idofstudent='" + NationalId + "',@year=" + year + " ,@semester='" + label6.Text + "' ", cn);
                            cn.Open();
                            cm.ExecuteNonQuery();
                            cn.Close();
                         
                          
                        }
                        comboBox2.Items.Clear();
                        comboBox2.Items.Add("A");
                        comboBox2.Items.Add("B");
                        comboBox2.Items.Add("C");
                        comboBox1.Items.Remove(comboBox1.Text);
                        //
                        this.Size = new Size(742, 176);
                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = null;
                        dataGridView2.Rows.Clear();
                        dataGridView1.Visible = true;
                        button2.Visible = true;
                        button5.Visible = true;
                        label1.Visible = true;
                        comboBox2.Visible = true;
                        comboBox2.Text=null;
                        comboBox1.Text = null;
                        int yea = Convert.ToInt16(label4.Text);
                        cmd = new SqlCommand("select materialcoursetitle from materials where materialcode in(select materialcode from registeration where  year=" + yea + " and semester='" + label6.Text + "')", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            comboBox1.Items.Add(dr[0].ToString());

                        }
                        dr.Close();
                        cn.Close();
                      

                    }
                }
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
            comboBox1.Items.Remove(comboBox1.Text);
            this.Size = new Size(742, 179);
               button1.Visible = true;
            button2.Visible = true;
      
            comboBox1.Text = null;
            int yea = Convert.ToInt16(label4.Text);
            cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "' or year=" + yea + " and semester='" + label6.Text + "' and Appreciation is null))", cn);
          //  cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "' and materialcode in(select materialcode from registeration where year=" + yea + " and semester='" + label6.Text + "' and  not appreciation='" + "W" + "'))", cn);
           // cmd = new SqlCommand("select MaterialCourseTitle from Materials  where MaterialCode in(select MaterialCode from contr where write='" + "1" + "')", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                comboBox1.Items.Add(dr[0].ToString());

            }
            dr.Close();
            cn.Close();



            //if (dataGridView1.Visible == true)
            //{
            //    dataGridView1.Columns.Clear();
            //    dataGridView1.DataSource = null;
            //    dataGridView1.Rows.Clear();
              
            //}
            //else
            //{
            //    dataGridView2.Columns.Clear();
            //    dataGridView2.DataSource = null;
            //    dataGridView2.Rows.Clear();
            //    dataGridView1.Visible = true;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        //    try
      //      {

                if (Q == 0)
                {


                    this.dataGridView1.CurrentRow.Cells[4].Value = DBNull.Value;
                    this.dataGridView1.CurrentRow.Cells[5].Value = DBNull.Value;
                    this.dataGridView1.CurrentRow.Cells[6].Value = DBNull.Value;


                    int a = 0;
                    int b = 0;
                    int c = 0;

                    int yea = Convert.ToInt16(label4.Text);
                    if (this.dataGridView1.CurrentRow.Cells[1].Value.ToString() != DBNull.Value.ToString())
                        a = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[1].Value);

                    if (this.dataGridView1.CurrentRow.Cells[2].Value .ToString()!= DBNull.Value.ToString())
                        b = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[2].Value);

                    if (this.dataGridView1.CurrentRow.Cells[3].Value.ToString() != DBNull.Value.ToString())
                        c = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[3].Value);




                    if ((a < 0 || a > Z) || (b < 0 || b > Y) || (c < 0 || c > X))
                    {
                        if ((a < 0 || a > Z))
                            this.dataGridView1.CurrentRow.Cells[1].Value = DBNull.Value;
                        if ((b < 0 || b > Y))
                            this.dataGridView1.CurrentRow.Cells[2].Value = DBNull.Value;
                        if ((c < 0 || c > X))
                            this.dataGridView1.CurrentRow.Cells[3].Value = DBNull.Value;



                    }
                    if (this.dataGridView1.CurrentRow.Cells[1].Value.ToString() != DBNull.Value.ToString() && this.dataGridView1.CurrentRow.Cells[2].Value.ToString() != DBNull.Value.ToString() && this.dataGridView1.CurrentRow.Cells[3].Value.ToString() != DBNull.Value.ToString())
                    {
                        this.dataGridView1.CurrentRow.Cells[4].Value = a + b + c;
                        cmd = new SqlCommand(" select nationalid from student where studentid='" + dataGridView1.CurrentRow.Cells[0].Value + "' ", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        string NationalId = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        cmd = new SqlCommand("exec gpa @course='" + comboBox1.Text + "',@idofstudent='" + NationalId + "',@degree=" + dataGridView1.CurrentRow.Cells[4].Value + ", @semester='" + label6.Text + "' ,@year=" + yea + " ", cn);
                        cn.Open();
                        SqlDataReader dv = cmd.ExecuteReader();
                        dv.Read();
                        this.dataGridView1.CurrentRow.Cells[5].Value = dv.GetString(1);
                        this.dataGridView1.CurrentRow.Cells[6].Value = dv.GetDouble(0);
                        dv.Close();
                        cn.Close();
                        int degr = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                        string app = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                        if ((app == "B+") && (degr > 84))
                        {
                            dataGridView1.CurrentRow.Cells[4].Value = 84;
                        }


                    }
                }
                else if(Q==100)
                {
                    //مواد زى الكمبيوتر
                }
                else
                {

                    this.dataGridView1.CurrentRow.Cells[5].Value = DBNull.Value;
                    this.dataGridView1.CurrentRow.Cells[6].Value = DBNull.Value;
                    this.dataGridView1.CurrentRow.Cells[7].Value = DBNull.Value;


                    int a = 0;
                    int b = 0;
                    int c = 0;
                    int d = 0;

                    int yea = Convert.ToInt16(label4.Text);
                    if (this.dataGridView1.CurrentRow.Cells[1].Value.ToString() != DBNull.Value.ToString())
                        a = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[1].Value);

                    if (this.dataGridView1.CurrentRow.Cells[2].Value.ToString() != DBNull.Value.ToString())
                        b = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[2].Value);

                    if (this.dataGridView1.CurrentRow.Cells[3].Value.ToString() != DBNull.Value.ToString())
                        c = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[3].Value);

                    if (this.dataGridView1.CurrentRow.Cells[4].Value.ToString() != DBNull.Value.ToString())
                        d = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[4].Value);





                    if ((a < 0 || a > Z) || (b < 0 || b > Y) || (c < 0 || c > Q) || (d < 0 || d > X))
                    {
                        if ((a < 0 || a > Z))
                            this.dataGridView1.CurrentRow.Cells[1].Value = null;
                        if ((b < 0 || b > Y))
                            this.dataGridView1.CurrentRow.Cells[2].Value = null;
                        if ((c < 0 || c > Q))
                            this.dataGridView1.CurrentRow.Cells[3].Value = null;
                        if ((d < 0 || d > X))
                            this.dataGridView1.CurrentRow.Cells[4].Value = null;



                    }
                    if (this.dataGridView1.CurrentRow.Cells[1].Value != DBNull.Value && this.dataGridView1.CurrentRow.Cells[2].Value != DBNull.Value && this.dataGridView1.CurrentRow.Cells[3].Value != DBNull.Value && this.dataGridView1.CurrentRow.Cells[4].Value != DBNull.Value)
                    {
                        this.dataGridView1.CurrentRow.Cells[5].Value = d + a + b + c;
                        cmd = new SqlCommand(" select nationalid from student where studentid='" + dataGridView1.CurrentRow.Cells[0].Value + "' ", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        string NationalId = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        cmd = new SqlCommand("exec gpa @course='" + comboBox1.Text + "',@idofstudent='" + NationalId + "',@degree=" + dataGridView1.CurrentRow.Cells[5].Value + ", @semester='" + label6.Text + "' ,@year=" + yea + " ", cn);
                        cn.Open();
                        SqlDataReader dv = cmd.ExecuteReader();
                        dv.Read();
                        this.dataGridView1.CurrentRow.Cells[6].Value = dv.GetString(1);
                        this.dataGridView1.CurrentRow.Cells[7].Value = dv.GetDouble(0);
                        dv.Close();
                        cn.Close();
                        int degr = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                        string app = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                        if ((app == "B+") && (degr > 89))
                        {
                            dataGridView1.CurrentRow.Cells[5].Value = 89;
                        }


                    }

                }

         /*   }
            catch
            {
                if (this.dataGridView1.ColumnCount.ToString() == "8")
                    this.dataGridView1.CurrentRow.Cells[7].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[6].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[5].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[4].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[3].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[2].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[1].Value = DBNull.Value;

            }*/
            /*try
            {




                this.dataGridView1.CurrentRow.Cells[4].Value =DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[5].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[6].Value = DBNull.Value;
               
                
                int a = 0;
                int b = 0;
                int c =0;

                int yea = Convert.ToInt16(label4.Text);
                if (this.dataGridView1.CurrentRow.Cells[1].Value != DBNull.Value)
                    a = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[1].Value);

                if (this.dataGridView1.CurrentRow.Cells[2].Value != DBNull.Value)
                    b = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[2].Value);

                if (this.dataGridView1.CurrentRow.Cells[3].Value != DBNull.Value)
                    c = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[3].Value);
                



                if ((a < 0 || a > X) || (b < 0 || b > Y) || (c < 0 || c > Z))
                {
                    if ((a < 0 || a > X))
                        this.dataGridView1.CurrentRow.Cells[1].Value = DBNull.Value;
                    if ((b < 0 || b > Y))
                        this.dataGridView1.CurrentRow.Cells[2].Value = DBNull.Value;
                    if ((c < 0 || c > Z))
                        this.dataGridView1.CurrentRow.Cells[3].Value = DBNull.Value;



                }
                if (this.dataGridView1.CurrentRow.Cells[1].Value != DBNull.Value && this.dataGridView1.CurrentRow.Cells[2].Value != DBNull.Value && this.dataGridView1.CurrentRow.Cells[3].Value != DBNull.Value)
                    {
                        this.dataGridView1.CurrentRow.Cells[4].Value = a + b + c;
                        cmd = new SqlCommand(" select nationalid from student where studentid='" + dataGridView1.CurrentRow.Cells[0].Value + "' ", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        string NationalId = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        cmd = new SqlCommand("exec gpa @course='" + comboBox1.Text + "',@idofstudent='" + NationalId + "',@degree=" + dataGridView1.CurrentRow.Cells[4].Value + ", @semester='" + label6.Text + "' ,@year=" + yea + " ", cn);
                        cn.Open();
                        SqlDataReader dv = cmd.ExecuteReader();
                        dv.Read();
                        this.dataGridView1.CurrentRow.Cells[5].Value = dv.GetString(1);
                        this.dataGridView1.CurrentRow.Cells[6].Value = dv.GetDouble(0);
                        dv.Close();
                        cn.Close();
                        int degr = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                        string app = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                        if ((app == "B+") && (degr > 89))
                        {
                        dataGridView1.CurrentRow.Cells[4].Value=89 ;
                        }


                    }
               
        }
          catch
            {

                this.dataGridView1.CurrentRow.Cells[6].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[5].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[4].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[3].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[2].Value = DBNull.Value;
                this.dataGridView1.CurrentRow.Cells[1].Value = DBNull.Value;

            }*/
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          /* try
            {
                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    Variable = comboBox2.Text;
                    if (Variable == "A")
                    {
                        X = 20;
                        Y = 20;
                        Z = 60;
                    }
                    else if (Variable == "B")
                    {
                        X = 15;
                        Y = 25;
                        Z = 60;
                    }
                    else
                    {
                        X = 25;
                        Y = 25;
                        Z = 50;
                    }

                    int y = Convert.ToInt16(label4.Text);
                    cmd = new SqlCommand("select materialcode from materials where materialCourseTitle='" + comboBox1.Items[comboBox1.SelectedIndex].ToString() + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string b = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    Da = new SqlDataAdapter("exec contro2 @code='" + b + "' , @year=" + y + ", @semester='" + label6.Text + "'  ", cn);
                    ds = new DataSet();
                    Da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
           
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[6].ReadOnly = true;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[1]).MaxInputLength = 2;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[2]).MaxInputLength = 2;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[3]).MaxInputLength = 2;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[4]).MaxInputLength = 3;
                    button2.Visible = false;
                   
                    this.Size = new Size(742, 511);
                    dataGridView2.Visible = false;
                  
                }
                else
                {
                    MessageBox.Show("اختر طريقة رصد الدرجات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           }
           
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال بقاعدة البيانات  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }*/
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           e.Control.KeyPress -= new KeyPressEventHandler(dataGridView1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 1 || dataGridView1.CurrentCell.ColumnIndex == 2 || dataGridView1.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
