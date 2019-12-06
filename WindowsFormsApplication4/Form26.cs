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
    public partial class Form26 : Form
    {

        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");

        SqlCommand cmd;
        SqlCommand cm;
        SqlCommand ca;
        SqlCommand cl;
        SqlCommand ci;
        SqlDataReader dr;
        SqlDataReader dv;
        DataSet ds;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        int m = 0;
        int sum = 0;
        int m2 = 0;
        int sum2 = 0;
        int sum3 = 0;
        int tt = 0;
        int counte;
        int td;
        int counte2;
        string nationalid;
        string name;
        public Form26()
        {
            InitializeComponent();
        }

        private void Form26_Load(object sender, EventArgs e)
        {
            this.Size = new Size(702, 197);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();  
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
            this.dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            td = 0;

            counte2 = dataGridView2.Rows.Count;
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView2.Rows[i].Cells[1].Value == false)
                {
                    td = td + 1;
                }

            }
            tt = 0;
            counte = dataGridView1.Rows.Count;
            for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
            {

                if ((bool)dataGridView1.Rows[i].Cells[1].Value == false)
                {
                    tt = tt + 1;
                }

            }

            if ((tt == counte) && (td == counte2))
            {

                textBox3.Clear();
            }



            string crhr2 = "";
            sum2 = 0;
            sum3 = 0;
            sum = 0;
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

            string crhr = "";
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
        
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  try{

            string y;
            y = label11.Text;
            int v;
            v = Convert.ToInt32(y);
            cmd = new SqlCommand("select name,nationalId from student where studentId=" + Convert.ToInt32(textBox1.Text) + " and restricted='"+"1"+"'", cn);
         
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {//1
                name = dr[0].ToString();
                nationalid = dr[1].ToString();
                dr.Close();
                cm = new SqlCommand("select count(*) from registeration where nationalId='" + nationalid + "' and [year]=" + v + " and semester='" + label12.Text + "'", cn);
                dv = cm.ExecuteReader();
                dv.Read();
                string h = dv[0].ToString();
                int r = Convert.ToInt32(h);
                if (r > 0)
                {//2

                    //فى حالة ان الطالب مسجل من قبل
                    cn.Close();
                    dr.Close();
                    ci = new SqlCommand("select count(*) from selection where nationalId='" + nationalid + "'", cn);
                    cn.Open();
                    dr = ci.ExecuteReader();
                    dr.Read();
                    string p = dr[0].ToString();
                    int w;
                    w = Convert.ToInt32(p);
                    if (w > 0)
                    {//رسالة يتم الان التسجيل بنفس الرقم 
                        MessageBox.Show(" يتم الان التسجيل بنفس الرقم", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dr.Close();
                        textBox1.Clear();
                        cn.Close();
                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                        int year = Convert.ToInt16(label11.Text);
                        string seme = label12.Text;
                        double decide = 0;
                        int test = 0;
                        cmd = new SqlCommand("select count(gpa) from totalgpa where nationalid='" +nationalid + "' ", cn);
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
                        button1.Visible = false;
                        textBox1.ReadOnly = true;
                        this.Size = new Size(702, 714);
                        button2.Visible = false;

                        //

                        Da = new SqlDataAdapter("exec register @idstudent='" + nationalid + "'", cn);
                        ds = new DataSet();
                        Da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView2.DataSource = ds.Tables[1];
                        //
                        ca = new SqlCommand("select name from student where nationalId='" + nationalid + "'", cn);
                        cn.Open();
                        dr = ca.ExecuteReader();
                        dr.Read();
                        textBox2.Text = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        //
                        string b = label11.Text;
                        int l;
                        l = Convert.ToInt32(b);
                        cl = new SqlCommand("SELECT materials.MaterialCourseTitle FROM materials INNER JOIN registeration ON Materials.MaterialCode = registeration.MaterialCode where registeration.nationalId='" +nationalid + "' and registeration.year=" + l + " and registeration.semester='" + label12.Text + "'", cn);
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
                        if (dataGridView1.ColumnCount == 3)
                        {
                            dataGridView1.Columns.RemoveAt(2);
                        }
                        dataGridView1.Columns[0].ReadOnly = true;

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



                }//2
                else
                {
                    MessageBox.Show("لم يتم التسحيل من قبل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Clear();
                    dr.Close();
                    cn.Close();
                }
            }//1
            else
            {
                //فى حالة ان الرقم غير متاح او لم يدخل رقم للطالب من الاساس
                MessageBox.Show("من فضللك ادخل رقم الجلوس الصحيح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Clear();
                dr.Close();
                cn.Close();
            }
            /*   }
                   catch{
                       MessageBox.Show("من فضللك ادخل رقم الجلوس ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int s = 0;
            int k = dataGridView1.Rows.Count;
            for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
            {

                if ((bool)dataGridView1.Rows[l].Cells[1].Value == false)
                    s = s + 1;
            }
            int su = 0;
            int ka = dataGridView2.Rows.Count;
            for (int l = dataGridView2.Rows.Count - 1; l >= 0; l--)
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
                        string h = Convert.ToString(sum);
                        textBox3.Text = h;
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
                    //--
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

                        cmd = new SqlCommand(" Delete from registeration where nationalid='" + nationalid + "' and year=" + d + " and semester='" + label12.Text + "'", cn);
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
                        this.Size = new Size(702, 198);
                        button2.Visible = true;
                        textBox3.Clear();
                        textBox1.Clear();
                        textBox2.Clear();
                        listBox1.Items.Clear();
                        button1.Visible = true;
                        textBox1.ReadOnly = false;
                        button1.Visible = true;
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = null;
                        dataGridView1.Rows.Clear();
                        dataGridView2.Columns.Clear();
                        dataGridView2.DataSource = null;
                        dataGridView2.Rows.Clear();

                    }

                }
                else
                {
                    DialogResult j = MessageBox.Show("التاكد من عدد الساعات المتاحة", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
    }
}
