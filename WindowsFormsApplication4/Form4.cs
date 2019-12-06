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
    public partial class Form4 : Form
    {

        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");

        SqlCommand cmd;
        SqlCommand cm;
        SqlCommand ca;
        SqlCommand cl;
        SqlDataReader dr;
        SqlDataReader dv;
        DataSet ds;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        public string nationalid = "";
        int m = 0;
        int sum = 0;
        int m2 = 0;
        int sum2 = 0;
        int sum3 = 0;
        int tt = 0;
        int counte;
        int td;
        int counte2;
     
 
        public Form4()
        {
            InitializeComponent();
           

        }
        private void AutoSizeTextBox(TextBox txt)
        {
            const int x_margin = 0;
            const int y_margin = 2;
            Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
            txt.ClientSize =
            new Size(size.Width + x_margin, size.Height + y_margin);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
             int s = 0;
            int k = dataGridView1.Rows.Count;
            for (int l = k - 1; l >= 0; l--)
            {

                if ((bool)dataGridView1.Rows[l].Cells[1].Value == false)
                   s = s + 1;
                
            }
            int su = 0;
            int ka = dataGridView2.Rows.Count;
            for (int l = ka - 1; l >= 0; l--)
            {

                if ((bool)dataGridView2.Rows[l].Cells[1].Value == false)
                    su = su + 1;
            }
            if (s == k && su == ka)
            {
                MessageBox.Show("من فضلك اختر من قائمة المواد ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                int sum = 0;
                int summ = 0;
                int total = 0;
                string t;
                string crhrs;
                int m;
                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {

                    if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                    {
                        string Course = (string)dataGridView1.Rows[i].Cells[0].Value;
                        cmd = new SqlCommand("exec [Cr.Hrs] @course='" + Course + "'", cn);
                        cn.Open();
                        dv = cmd.ExecuteReader();
                        dv.Read();
                        crhrs = dv[0].ToString();
                        m = Convert.ToInt32(crhrs);
                        dv.Close();
                        cn.Close();
                        sum = m + sum;

                    }
                }
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int a = dataGridView2.Rows.Count - 1; a >= 0; a--)
                        if ((bool)dataGridView2.Rows[a].Cells[1].Value == true)
                        {
                            string Course = (string)dataGridView2.Rows[a].Cells[0].Value;
                            cmd = new SqlCommand("exec [Cr.Hrs] @course='" + Course + "'", cn);
                            cn.Open();
                            dv = cmd.ExecuteReader();
                            dv.Read();
                            crhrs = dv[0].ToString();
                            m = Convert.ToInt32(crhrs);
                            dv.Close();
                            cn.Close();
                            summ = m + summ;
                        }

                }
                total = sum + summ;
                t = Convert.ToString(total);
                textBox3.Text = t;

                if (total >= 14 && total <= 18)
                {
                    DialogResult r = MessageBox.Show("سيتم حذف التسجيل القديم والابقاء عل التسجيل الجديد", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        //remove the first registeration
                        string b = label11.Text;
                        int d;
                        d = Convert.ToInt32(b);
                    
                        cmd = new SqlCommand(" Delete from registeration where nationalId='" + nationalid + "' and year=" + d + " and semester='" + label12.Text + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        //remove selection table
                        cl = new SqlCommand("exec remov @idofstudent='" + nationalid + "'", cn);
                        cn.Open();
                        cl.ExecuteNonQuery();
                        cn.Close();
                        //new registeration
                        for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                        {
                            if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                            {
                                string Course = (string)dataGridView1.Rows[i].Cells[0].Value;
                                cmd = new SqlCommand("exec selecte @course='" + Course + "',@idofstudent='" + nationalid + "',@year=" + d + ",@semester='" + label12.Text + "'", cn);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                            }
                        }
                        //
                        for (int n = dataGridView2.Rows.Count - 1; n >= 0; n--)
                        {
                            if (dataGridView2.Visible == true)
                            {
                                if ((bool)dataGridView2.Rows[n].Cells[1].Value == true)
                                {
                                    string Course = (string)dataGridView2.Rows[n].Cells[0].Value;
                                    cmd = new SqlCommand("exec selecte @course='" + Course + "',@idofstudent='" + nationalid + "',@year=" + d + ",@semester='" + label12.Text + "'", cn);
                                    cn.Open();
                                    cmd.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                        }
                        //
                      
                        Form5 FrmUpdateRegister = new Form5();

                        FrmUpdateRegister.label11.Text = label11.Text;
                        FrmUpdateRegister.label12.Text = label12.Text;

            //            FrmUpdateRegister.MdiParent = this.ParentForm;
                        FrmUpdateRegister.Show();
                        this.Close();
                    }

                }
                else
                {
                    DialogResult j = MessageBox.Show("التاكد من عدد الساعات المتاحة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
       


            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Size = new Size(705, 729);
            button1.Visible = false;
            //
            int year = Convert.ToInt16(label11.Text);
            string seme = label12.Text;
            double decide = 0;
            int test = 0;
            cmd = new SqlCommand("select count(gpa) from totalgpa where nationalid='" + nationalid + "' ", cn);
            cn.Open();
            dv = cmd.ExecuteReader();
            dv.Read();
            test = Convert.ToInt32(dv[0].ToString());
            dv.Close();
            cn.Close();
            if (test != 0)
            {
                if (seme == "first")
                {
                    year = year - 1;
                    cmd = new SqlCommand("exec sumgpa2 where @idofstudent='" + nationalid + "' and year=" + year + " ", cn);
                    cn.Open();
                    dv = cmd.ExecuteReader();
                    dv.Read();
                    decide = Convert.ToDouble(dv[0].ToString());
                    dv.Close();
                    cn.Close();
                }
                if (seme == "second")
                {
                    seme = "first";
                    cmd = new SqlCommand("select gpa from totalgpa where nationalid='" + nationalid + "' and year=" + year + " and semester='" + seme + "'", cn);
                    cn.Open();
                    dv = cmd.ExecuteReader();
                    dv.Read();
                    string bv = dv[0].ToString();
                    dv.Close();
                    cn.Close();
                    decide = Convert.ToDouble(bv);
                }
                if (seme == "summer")
                {
                    seme = "second";
                    cmd = new SqlCommand("select gpa from totalgpa where nationalid='" + nationalid + "' and year=" + year + " and semester='" + seme + "'", cn);
                    cn.Open();
                    dv = cmd.ExecuteReader();
                    dv.Read();
                    decide = Convert.ToDouble(dv[0].ToString());
                    dv.Close();
                    cn.Close();
                }
            }
            else
            {
                decide = 100;
            }
            if (decide == 100)
            {
                label4.Text = "14";
                label6.Text = "18";
            }
            if (decide < 2)
            {
                label4.Text = "14";
                label6.Text = "18";
            }
            if ((decide >= 2) && (decide < 3))
            {
                label4.Text = "18";
                label6.Text = "18";
            }
            //كمل باقى الحالات
            //
          
            Da = new SqlDataAdapter("exec register @idstudent='"+nationalid+ "'", cn);
            ds = new DataSet();
            Da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView2.DataSource = ds.Tables[1];
            //
            ca = new SqlCommand("select name from student where nationalid=" + nationalid + "", cn);
            cn.Open();
            dr = ca.ExecuteReader();
            dr.Read();
            textBox2.Text = dr[0].ToString();
            dr.Close();
            cn.Close();
            string a = label11.Text;
            int v;
            v = Convert.ToInt32(a);
            //
            cl = new SqlCommand("SELECT materials.MaterialCourseTitle FROM materials INNER JOIN registeration ON Materials.MaterialCode = registeration.MaterialCode where registeration.nationalId='" + nationalid + "' and registeration.year=" + v + " and registeration.semester='" + label12.Text + "'", cn);
            cn.Open();
            dr = cl.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

            DataGridViewCheckBoxColumn sb = new DataGridViewCheckBoxColumn();
            sb.HeaderText = "select";

            dataGridView1.Columns.Add(sb);
            if (dataGridView1.ColumnCount >= 3)
            {
                dataGridView1.Columns.RemoveAt(2);
            }

            for (int m = dataGridView1.Rows.Count - 1; m >= 0; m--)
            {
                dataGridView1.Rows[m].Cells[1].Value = false;
            }


            if (dataGridView2.Rows.Count == 0)
            {
                dataGridView2.Visible = false;

            }
            else
            {

                dataGridView2.Visible = true;
                DataGridViewCheckBoxColumn sa = new DataGridViewCheckBoxColumn();
                sa.HeaderText = "select";
                dataGridView2.Columns.Add(sa);
                if (dataGridView2.ColumnCount >= 3)
                {
                    dataGridView2.Columns.RemoveAt(2);
                }
                dataGridView2.Columns[0].ReadOnly = true;
                for (int m = dataGridView2.Rows.Count - 1; m >= 0; m--)
                {
                    dataGridView2.Rows[m].Cells[1].Value = false;
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
            string a = label11.Text;
            int v;
            v = Convert.ToInt32(a);
            cm = new SqlCommand("select nationalId from registeration where  nationalId='" + nationalid + "' and year=" + v + " and semester='" + label12.Text + "'", cn);
            //5تدل عل ان الطالب مسجل فبل ذلك
            cn.Open();
            dr = cm.ExecuteReader();
          
            if(dr.Read())
            {
               
            }
                //6تدل عل ان الطالب مسجل فبل ذلك
            else  
            {
                MessageBox.Show("الطالب غير مسجل من قبل ");
                textBox1.Clear();
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لن يتم حفظ اى تعديلات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes)
            {
               
                cl = new SqlCommand("exec remov @idofstudent='" + nationalid + "'", cn);
                cn.Open();
                cl.ExecuteNonQuery();
                cn.Close();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("رجوع للقائمة الرئيسية", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Close();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لن يتم حفظ اى تعديلات للطالب الحالى ------ذهاب لتعديل طالب جديد", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes)
            {
                
                cl = new SqlCommand("exec remov @idofstudent='" + nationalid + "'", cn);
                cn.Open();
                cl.ExecuteNonQuery();
                cn.Close();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView2.Columns.Clear();
                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();

                Form5 FrmUpdateRegister = new Form5();
                FrmUpdateRegister.label12.Text = label12.Text;
                FrmUpdateRegister.label11.Text = label11.Text;
               // FrmUpdateRegister.MdiParent = this.ParentForm;
                FrmUpdateRegister.Show();
                this.Close();
            }
           
                

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f1 = new Form3();
            this.Close();
            f1.Show();
            
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AutoSizeTextBox(sender as TextBox);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم تعديل التسجيل للطالب الحالى", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (r == DialogResult.Yes)
               {
                 
                   cl = new SqlCommand("exec remov @idofstudent='" + nationalid + "'", cn);
                   cn.Open();
                   cl.ExecuteNonQuery();
                   cn.Close();
                   dataGridView1.Columns.Clear();
                   dataGridView1.DataSource = null;
                   dataGridView1.Rows.Clear();
                   dataGridView2.Columns.Clear();
                   dataGridView2.DataSource = null;
                   dataGridView2.Rows.Clear();
                   Form3 FrmRegister= new Form3();
                   FrmRegister.label10.Text = label11.Text;
                   FrmRegister.label11.Text = label12.Text;
                 //  FrmRegister.MdiParent = this.ParentForm;
                   FrmRegister.Show();
                   this.Close();
               }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            tt = 0;
            counte = dataGridView1.Rows.Count;
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView1.Rows[i].Cells[1].Value == false)
                {
                    tt = tt + 1;
                }

            }
            td = 0;

            counte2 = dataGridView2.Rows.Count;
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView2.Rows[i].Cells[1].Value == false)
                {
                    td = td + 1;
                }

            }

            if ((tt == counte) && (td == counte2))
            {

                textBox3.Clear();
            }



            string crhr = "";
            sum = 0;
            sum2 = 0;
            sum3 = 0;
            m = 0;
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                {
                    string Course = (string)dataGridView1.Rows[i].Cells[0].Value;

                    cmd = new SqlCommand("exec [Cr.Hrs] @course='" + Course + "'", cn);
                    cn.Open();
                    dv = cmd.ExecuteReader();
                    dv.Read();
                    crhr = dv[0].ToString();
                    m = Convert.ToInt32(crhr);
                    dv.Close();
                    cn.Close();
                    sum = m + sum;
                    sum3 = sum + sum2;
                    textBox3.Text = Convert.ToString(sum3);
                }//--
            }

            string crhr2 = "";

            m2 = 0;
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView2.Rows[i].Cells[1].Value == true)
                {
                    string Course = (string)dataGridView2.Rows[i].Cells[0].Value;

                    cmd = new SqlCommand("exec [Cr.Hrs] @course='" + Course + "'", cn);
                    cn.Open();
                    dv = cmd.ExecuteReader();
                    dv.Read();
                    crhr2 = dv[0].ToString();
                    m2 = Convert.ToInt32(crhr2);
                    dv.Close();
                    cn.Close();
                    sum2 = m2 + sum2;
                    sum3 = sum + sum2;
                    textBox3.Text = Convert.ToString(sum3);
                }//--
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            tt = 0;
            counte = dataGridView1.Rows.Count;
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView1.Rows[i].Cells[1].Value == false)
                {
                    tt = tt + 1;
                }

            }
            td = 0;

            counte2 = dataGridView2.Rows.Count;
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView2.Rows[i].Cells[1].Value == false)
                {
                    td = td + 1;
                }

            }

            if ((tt == counte) && (td == counte2))
            {

                textBox3.Clear();
            }



            string crhr = "";
            sum = 0;
            sum2 = 0;
            sum3 = 0;
            m = 0;
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                {
                    string Course = (string)dataGridView1.Rows[i].Cells[0].Value;

                    cmd = new SqlCommand("exec [Cr.Hrs] @course='" + Course + "'", cn);
                    cn.Open();
                    dv = cmd.ExecuteReader();
                    dv.Read();
                    crhr = dv[0].ToString();
                    m = Convert.ToInt32(crhr);
                    dv.Close();
                    cn.Close();
                    sum = m + sum;
                    sum3 = sum + sum2;
                    textBox3.Text = Convert.ToString(sum3);
                }//--
            }

            string crhr2 = "";

            m2 = 0;
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView2.Rows[i].Cells[1].Value == true)
                {
                    string Course = (string)dataGridView2.Rows[i].Cells[0].Value;

                    cmd = new SqlCommand("exec [Cr.Hrs] @course='" + Course + "'", cn);
                    cn.Open();
                    dv = cmd.ExecuteReader();
                    dv.Read();
                    crhr2 = dv[0].ToString();
                    m2 = Convert.ToInt32(crhr2);
                    dv.Close();
                    cn.Close();
                    sum2 = m2 + sum2;
                    sum3 = sum + sum2;
                    textBox3.Text = Convert.ToString(sum3);
                }//--
            }
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
