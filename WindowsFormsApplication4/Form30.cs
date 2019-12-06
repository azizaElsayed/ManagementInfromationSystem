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
    public partial class Form30 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        SqlDataReader dr;
        int StudentId;
        string semester;
        int yea;
        string NationalId;
        public Form30()
        {
            InitializeComponent();
        }

        private void Form30_Load(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
            dataGridView1.Visible = false;
            this.Size = new Size(814, 152);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                da = new SqlDataAdapter("select shears from Student where StudentId='" + textBox1.Text + "'", cn);
                da.Fill(dt);
                if ((bool)dt.Rows[0][0] == true)
                {
                    
                    textBox1.Visible = false;
                    button1.Visible = false;
                    this.Size = new Size(814, 428);
                    dataGridView1.Visible = true;
                   
                    StudentId = Convert.ToInt32(textBox1.Text);
                    da = new SqlDataAdapter("select MaterialCode as 'كود المادة', MaterialCourseTitle as 'اسم المادة' from Materials", cn);
                    dt2.Clear();
                    da.Fill(dt2);
                    dataGridView1.DataSource = dt2;
                    DataGridViewTextBoxColumn midTem = new DataGridViewTextBoxColumn();
                    midTem.HeaderText = "الميدترم";
                    DataGridViewTextBoxColumn yearWork = new DataGridViewTextBoxColumn();
                    yearWork.HeaderText = "أعمال السنة";
                    DataGridViewTextBoxColumn final = new DataGridViewTextBoxColumn();
                    final.HeaderText = "درجة الفينال";
                    DataGridViewTextBoxColumn total = new DataGridViewTextBoxColumn();
                    total.HeaderText = "المجموع";
                    DataGridViewTextBoxColumn appreciation = new DataGridViewTextBoxColumn();
                    appreciation.HeaderText = "التقدير";
                    DataGridViewTextBoxColumn gpa = new DataGridViewTextBoxColumn();
                    gpa.HeaderText = "النقاط";
                    dataGridView1.Columns.Add(midTem);
                    dataGridView1.Columns.Add(yearWork);
                    dataGridView1.Columns.Add(final);
                    dataGridView1.Columns.Add(total);
                    dataGridView1.Columns.Add(appreciation);
                    dataGridView1.Columns.Add(gpa);

                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[6].ReadOnly = true;
                    dataGridView1.Columns[7].ReadOnly = true;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[2]).MaxInputLength = 2;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[3]).MaxInputLength = 2;
                    ((DataGridViewTextBoxColumn)dataGridView1.Columns[4]).MaxInputLength = 2;
                }
                else 
                {
                    MessageBox.Show("هذا الطالب لم يتم تسجيه كمقصة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
               // MessageBox.Show(ex.Message);
                MessageBox.Show("هذا الطالب لم يتم تسجيه كمقصة ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(" select Levels from student where studentid=" + StudentId + " ", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            Program.levels = dr[0].ToString();
            dr.Close();
            cn.Close();


            DialogResult r = MessageBox.Show("تاكيد رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int s = 0;
                for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView1.Rows[l].Cells[5].Value == null)
                        s = s + 1;
                }

                if (s == dataGridView1.Rows.Count)
                {
                    MessageBox.Show("لم يتم ادخال اي مواد  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    int year = Convert.ToInt16(DateTime.Now.Year);
                    cmd = new SqlCommand(" select nationalid from student where studentid=" + StudentId + " ", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    NationalId = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    cmd = new SqlCommand(" select max(Id) from StateOfRegisteration ", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string maxId = dr[0].ToString();
                    int Id = Convert.ToInt32(maxId);
                    dr.Close();
                    cn.Close();
                    cmd = new SqlCommand(" select Semester from StateOfRegisteration where Id=" + Id + " ", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    semester = dr[0].ToString();

                    dr.Close();
                    cn.Close();
                    for (int l = 0; l < dataGridView1.Rows.Count; l++)
                    {
                        if (this.dataGridView1.Rows[l].Cells[4].Value != null)
                        {
                           
                           

                            cmd = new SqlCommand("insert into Registeration (nationalid, MaterialCode, Degree, Year, Semester, NumberOfRegisteration, Gpa, Appreciation, Final, midterm, YearOfWork) values(" + NationalId + ",'" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "','" + this.dataGridView1.CurrentRow.Cells[5].Value.ToString() + "'," + year + ",'" + semester + "'," + 1 + ",'" + this.dataGridView1.CurrentRow.Cells[7].Value.ToString() + "','" + this.dataGridView1.CurrentRow.Cells[6].Value.ToString() + "','" + this.dataGridView1.CurrentRow.Cells[4].Value.ToString() + "','" + this.dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" + this.dataGridView1.CurrentRow.Cells[3].Value.ToString() + "') ", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();


                            //cmd = new SqlCommand(" exec inserte @idofstudent='" + NationalId + "' ,@course='" + comboBox1.Text + "',@degree=" + dataGridView1.Rows[l].Cells[4].Value + ",@year=" + year + " ,@semester='" + label6.Text + "', @appreciation='" + dataGridView1.Rows[l].Cells[5].Value + "',@gpa=" + dataGridView1.Rows[l].Cells[6].Value + ",@final=" + dataGridView1.Rows[l].Cells[3].Value + ",@midterm=" + dataGridView1.Rows[l].Cells[1].Value + ",@YearOfWork=" + dataGridView1.Rows[l].Cells[2].Value + " ", cn);
                            //cn.Open();
                            //cmd.ExecuteNonQuery();
                            //cn.Close();

                        }
                        
                        
                        
                    }
                    MessageBox.Show("تم الانتهاء من رصد الدرجات", "معلومة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    cmd = new SqlCommand("insert into TotalGpa (nationalid, Year, Semester,levels) values('" + NationalId + "','" + year + "','" + semester + "','" + Program.levels + "')", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    cmd = new SqlCommand(" exec shearsSumgpa @idofstudent='" + NationalId + "' ,@year=" + year + " ,@semester='" + semester + "' ", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }

        }            

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //int Q = 0;
            //if (Q == 0)
            //{

            //    //this.dataGridView1.CurrentRow.Cells[2].Value = DBNull.Value; 
            //    //this.dataGridView1.CurrentRow.Cells[3].Value = DBNull.Value;
            //    //this.dataGridView1.CurrentRow.Cells[4].Value = DBNull.Value;
            //    this.dataGridView1.CurrentRow.Cells[5].Value = DBNull.Value;
            //    this.dataGridView1.CurrentRow.Cells[6].Value = DBNull.Value;
            //    this.dataGridView1.CurrentRow.Cells[7].Value = DBNull.Value;
            int a = 0;
            int b = 0;
            int c = 0;


            //    if (this.dataGridView1.CurrentRow.Cells[2].Value.ToString() != DBNull.Value.ToString())
            a = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[2].Value);

            //     if (this.dataGridView1.CurrentRow.Cells[3].Value.ToString() != DBNull.Value.ToString())
            b = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[3].Value);

            //      if (this.dataGridView1.CurrentRow.Cells[4].Value.ToString() != DBNull.Value.ToString())
                   c = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[4].Value);
                   if (this.dataGridView1.CurrentRow.Cells[2].Value != null && this.dataGridView1.CurrentRow.Cells[3].Value != null && this.dataGridView1.CurrentRow.Cells[4].Value != null)
                   {
                       int total = a + b + c;
                       if (total <= 100)
                       {
                           this.dataGridView1.CurrentRow.Cells[5].Value = a + b + c;
                           cmd = new SqlCommand(" select nationalid from student where studentid='" + StudentId + "' ", cn);
                           cn.Open();
                           dr = cmd.ExecuteReader();
                           dr.Read();
                           string NationalId = dr[0].ToString();
                           dr.Close();
                           cn.Close();
                           cmd = new SqlCommand("exec shearsGpa @course='" + this.dataGridView1.CurrentRow.Cells[1].Value.ToString() + "',@idofstudent='" + NationalId + "',@degree=" + dataGridView1.CurrentRow.Cells[5].Value + ", @semester='" + semester + "' ,@year=" + yea + " ", cn);
                           cn.Open();
                           SqlDataReader dv = cmd.ExecuteReader();
                           dv.Read();
                           this.dataGridView1.CurrentRow.Cells[6].Value = dv.GetString(1);
                           this.dataGridView1.CurrentRow.Cells[7].Value = dv.GetDouble(0);
                           dv.Close();
                           cn.Close();
                           int degr = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                           string app = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                           //if ((app == "B+") && (degr > 84))
                           //{
                           //    dataGridView1.CurrentRow.Cells[4].Value = 84;
                           //}
                       }
                       else
                       {
                           MessageBox.Show("اقصى درجة ممكنة هي 100", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
                       }
                   }
            }
        

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("هل تريد الخروج", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(DialogResult.OK==r)
            {
                this.Close();
            }
            
        }
    }
}