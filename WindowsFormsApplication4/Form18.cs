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
    public partial class Form18 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand cmd = new SqlCommand();
        SqlCommand cm = new SqlCommand();
        DataSet ds;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select MaterialCourseTitle from materials where CreditHour='0' and materialcode in (select MaterialCode from Registeration where year=" + Convert.ToInt32(label2.Text) + " and semester='" + label4.Text + "')", cn);
            cn.Open();
           dr= cmd.ExecuteReader();
            if(dr.Read())
            {

                dr.Close();
                cn.Close();
                Da = new SqlDataAdapter("select MaterialCourseTitle from materials where CreditHour='0' and materialcode in (select MaterialCode from Registeration where year=" + Convert.ToInt32(label2.Text) + " and semester='" + label4.Text + "')", cn);
                ds = new DataSet();
                Da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
        
                DataGridViewComboBoxColumn leve = new DataGridViewComboBoxColumn();
                leve.HeaderText = "مستوى الرصد";
                dataGridView2.Columns.Add(leve);

             leve.Items.Add("000");
             leve.Items.Add("001");
             leve.Items.Add("010");
             leve.Items.Add("100");
             leve.Items.Add("111");


                Da = new SqlDataAdapter("exec contro @year=" + Convert.ToInt32(label2.Text) + ",@semester='" + label4.Text + "'", cn);
                ds = new DataSet();
                Da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                DataGridViewTextBoxColumn final = new DataGridViewTextBoxColumn();

                DataGridViewTextBoxColumn midterm = new DataGridViewTextBoxColumn();

                DataGridViewTextBoxColumn yearofwork = new DataGridViewTextBoxColumn();

                DataGridViewTextBoxColumn quiz = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn sb = new DataGridViewComboBoxColumn();
                DataGridViewCheckBoxColumn ch = new DataGridViewCheckBoxColumn();
                final.HeaderText = "درجة النهائى";
                midterm.HeaderText = "درجة نصف الترم";
                yearofwork.HeaderText = "درجة اعمال السنة ";
                quiz.HeaderText = "درجة العملى/الشفوى";
                sb.HeaderText = "المستوى";
                ch.HeaderText = "تم";
                dataGridView1.Columns.Add(sb);
                dataGridView1.Columns.Add(final);
                dataGridView1.Columns.Add(midterm);
                dataGridView1.Columns.Add(yearofwork);
                dataGridView1.Columns.Add(quiz);
                dataGridView1.Columns.Add(ch);

                sb.Items.Add("000");
                sb.Items.Add("001");
                sb.Items.Add("010");
                sb.Items.Add("100");
                sb.Items.Add("111");
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[2]).MaxInputLength = 2;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[3]).MaxInputLength = 2;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[4]).MaxInputLength = 2;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[5]).MaxInputLength = 2;
        

            }
            else
            {
                dr.Close();
                cn.Close();
                dataGridView2.Visible = false;
                Da = new SqlDataAdapter("exec contro @year=" + Convert.ToInt32(label2.Text) + ",@semester='" + label4.Text + "'", cn);
                ds = new DataSet();
                Da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                DataGridViewTextBoxColumn final = new DataGridViewTextBoxColumn();

                DataGridViewTextBoxColumn midterm = new DataGridViewTextBoxColumn();

                DataGridViewTextBoxColumn yearofwork = new DataGridViewTextBoxColumn();

                DataGridViewTextBoxColumn quiz = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn sb = new DataGridViewComboBoxColumn();
                DataGridViewCheckBoxColumn ch = new DataGridViewCheckBoxColumn();
                final.HeaderText = "درجة النهائى";
                midterm.HeaderText = "درجة نصف الترم";
                yearofwork.HeaderText = "درجة اعمال السنة ";
                quiz.HeaderText = "درجة العملى/الشفوى";
                sb.HeaderText = "المستوى";
                ch.HeaderText = "تم";
                dataGridView1.Columns.Add(sb);
                dataGridView1.Columns.Add(final);
                dataGridView1.Columns.Add(midterm);
                dataGridView1.Columns.Add(yearofwork);
                dataGridView1.Columns.Add(quiz);
                dataGridView1.Columns.Add(ch);

                sb.Items.Add("000");
                sb.Items.Add("001");
                sb.Items.Add("010");
                sb.Items.Add("100");
                sb.Items.Add("111");
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[2]).MaxInputLength = 2;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[3]).MaxInputLength = 2;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[4]).MaxInputLength = 2;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[5]).MaxInputLength = 2;
            }
            

     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible == false)
            {
                int s = 0;
                for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView1.Rows[l].Cells[6].Value == null || (bool)dataGridView1.Rows[l].Cells[6].Value == false)
                        s = s + 1;


                }
                if (s == 0)
                {
                    int i;
                    for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                    {
                        i = 0;

                        if (dataGridView1.Rows[l].Cells[5].Value != null)
                        {
                            if (!string.IsNullOrEmpty(this.dataGridView1.Rows[l].Cells[5].Value.ToString()))
                            {
                                i = Convert.ToInt16(this.dataGridView1.Rows[l].Cells[5].Value);
                            }
                        }
                        string x = Convert.ToString(i);
                        cmd = new SqlCommand("exec  createcontro @course='" + dataGridView1.Rows[l].Cells[0].Value + "',@year=" + Convert.ToInt32(label2.Text) + ",@semester='" + label4.Text + "',@level='" + dataGridView1.Rows[l].Cells[1].Value + "' ,@final='" + dataGridView1.Rows[l].Cells[2].Value + "',@quiz='" + x + "',@mid='" + dataGridView1.Rows[l].Cells[3].Value + "',@yearofwork='" + dataGridView1.Rows[l].Cells[4].Value + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    MessageBox.Show("تم انشاء الكنترول ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("رجاء اختر لكل مادة المستوى الخاص بها وطريقه رصد الدرجات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {

                int s = 0;
                for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                {
                    if (dataGridView1.Rows[l].Cells[6].Value == null || (bool)dataGridView1.Rows[l].Cells[6].Value == false)
                        s = s + 1;


                }
                if (s == 0)
                {
                    int i;
                    for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
                    {
                        i = 0;

                        if (dataGridView1.Rows[l].Cells[5].Value != null)
                        {
                            if (!string.IsNullOrEmpty(this.dataGridView1.Rows[l].Cells[5].Value.ToString()))
                            {
                                i = Convert.ToInt16(this.dataGridView1.Rows[l].Cells[5].Value);
                            }
                        }
                        string x = Convert.ToString(i);
                        cmd = new SqlCommand("exec  createcontro @course='" + dataGridView1.Rows[l].Cells[0].Value + "',@year=" + Convert.ToInt32(label2.Text) + ",@semester='" + label4.Text + "',@level='" + dataGridView1.Rows[l].Cells[1].Value + "' ,@final='" + dataGridView1.Rows[l].Cells[2].Value + "',@quiz='" + x + "',@mid='" + dataGridView1.Rows[l].Cells[3].Value + "',@yearofwork='" + dataGridView1.Rows[l].Cells[4].Value + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    for (int l = dataGridView2.Rows.Count - 1; l >= 0; l--)
                    {
                        cmd = new SqlCommand("exec insertcredit @course='" + dataGridView2.Rows[l].Cells[0].Value + "',@year=" + Convert.ToInt32(label2.Text) + ",@semester='" + label4.Text + "',@level='" + dataGridView2.Rows[l].Cells[1].Value + "'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                    MessageBox.Show("تم انشاء الكنترول ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("رجاء اختر لكل مادة المستوى الخاص بها وطريقه رصد الدرجات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم رصد الدرجات", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int a=0, b=0, c=0,d, sum=0;
          
           
            if (this.dataGridView1.CurrentRow.Cells[2].Value == null || this.dataGridView1.CurrentRow.Cells[3].Value == null || this.dataGridView1.CurrentRow.Cells[4].Value == null )
                   {
                       dataGridView1.CurrentRow.Cells[6].Value = false;
                   }
                   else
                   {
                       if (string.IsNullOrEmpty(this.dataGridView1.CurrentRow.Cells[2].Value.ToString()) || string.IsNullOrEmpty(this.dataGridView1.CurrentRow.Cells[3].Value.ToString()) || string.IsNullOrEmpty(this.dataGridView1.CurrentRow.Cells[4].Value.ToString()) || this.dataGridView1.CurrentRow.Cells[1].Value == null )
             {
                 dataGridView1.CurrentRow.Cells[6].Value = false;
             }
            else
            {
                      a = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[2].Value);
                           b = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[3].Value);
                     c = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[4].Value);
                  d = Convert.ToInt16(this.dataGridView1.CurrentRow.Cells[5].Value);
                sum=a+b+c+d;
                if(sum==100)
                {
                    dataGridView1.CurrentRow.Cells[6].Value = true;
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[6].Value = false;
                }
            }
                   }
      
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
