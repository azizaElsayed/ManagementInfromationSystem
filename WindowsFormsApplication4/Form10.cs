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
    public partial class Form10 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cm;
        SqlDataReader dr;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1009, 306);
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            try
            {
                if (string.IsNullOrEmpty(this.comboBox1.Text) ||string.IsNullOrEmpty(textBox1.Text) )
                {
                    label8.Visible = true;
                         if (string.IsNullOrEmpty(this.comboBox1.Text))
                        {
                            label10.Visible = true;
                            label8.Text = "رجاء ادخل الترم الدراسى";
                            label8.Location = new Point(421, 108);
                        }
                        if  (string.IsNullOrEmpty(textBox1.Text))
                        {
                            label9.Visible = true;
                            label8.Text = "رجاء ادخل العام الدراسى";
                            label8.Location = new Point(421, 108);
                        }
                        if (string.IsNullOrEmpty(this.comboBox1.Text) && string.IsNullOrEmpty(textBox1.Text))
                        {
                           
                            label8.Text = "رجاء ادخل العام الدراسى و الترم الدراسى";
                            label8.Location = new Point(360, 105);
                        }
                    

                }
                else{
                  
                string x, y;
                int c;
                y = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
                x = textBox1.Text;
                c = Convert.ToInt32(x);
                cmd = new SqlCommand("exec show @year=" + c + " ,@semester='" + y + "' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string v = dr[0].ToString();
                     string copy="";
                     int cop=c-1;
                if (v == "yes")
                {
                    dr.Close();
                    cn.Close();
                      cmd = new SqlCommand("select adopttheresult from stateofregisteration where id=(select max(id) from stateofregisteration) ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string result = dr[0].ToString();
                dr.Close();
                cn.Close();
                    if(result=="1")
                    {
                    button1.Hide();
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    comboBox1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label11.Visible = false;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    this.Size = new Size(1009, 729);
                    label5.Text = x;
                    label6.Text = y;
                  
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
                    cmd = new SqlCommand("UPDATE materials SET available = " + 0 + " ", cn);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                    else{
                        if(y=="summer")
                        {
                            copy = "second";
                        }
                        if (y == "second")
                        {
                            copy = "first";
                        }
                        if (y == "first")
                        {
                            copy = "summer";
                            
                        }
                        textBox1.Clear();
                        textBox2.Clear();
                        comboBox1.Text = null;

                         MessageBox.Show("  النتيجه للعام الدراسى لم تعتمد " + cop+"" + copy+ " والفصل الدراسى ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                   
                
                else if (v == "no")
                {

                    DialogResult r = MessageBox.Show("من فضللك ادخل العام الدراسى الصحيح والترم الصحيح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Clear();
                    comboBox1.Text = null;
                    dr.Close();
                    cn.Close();
                }//
                else if (v == "uncomplete")
                {
                    DialogResult r = MessageBox.Show("يجب الانتهاء رصد درجات الطلاب اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dr.Close();
                    cn.Close();
                    comboBox1.Text = null;
                    textBox1.Clear();
                }
               
                else
                {
                    dr.Close();
                    cn.Close();
                    cm = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    string k = dr[0].ToString();
                    string m = dr[1].ToString();
                    DialogResult r = MessageBox.Show("" + m + "باب التسجيل مفتوح للعام الدراسى " + k + " والفصل الدراسى ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dr.Close();
                    cn.Close();
                    comboBox1.Text = null;
                    textBox1.Clear();

                }
            }
            }
            catch
            {
                DialogResult r = MessageBox.Show("من فضللك العام الدراسى الصح والترم الصحيح", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                comboBox1.Text = null;
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x, y;
            int c;
            y = comboBox1.Text;
            x = textBox1.Text;
            c = Convert.ToInt32(x);
            int sum = 0;
            int k = dataGridView1.Rows.Count;
            for (int l = dataGridView1.Rows.Count - 1; l >= 0; l--)
            {

                if ((bool)dataGridView1.Rows[l].Cells[1].Value == false)
                    sum = sum + 1;
            }
            if (sum == k)
            {
                MessageBox.Show("من فضلك اختر من قائمة المواد ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                try
                {
                    DialogResult r = MessageBox.Show("تاكيد الاختيار", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                        {

                            if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                            {
                                cmd = new SqlCommand("UPDATE materials SET available = " + 1 + "where materialcoursetitle='" + dataGridView1.Rows[i].Cells[0].Value + "' ", cn);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                                cmd = new SqlCommand("  exec  SaveMaterials @Course='" + dataGridView1.Rows[i].Cells[0].Value + "' ,@year="+c+",@Semester='"+y+"'", cn);
                                cn.Open();
                                cmd.ExecuteNonQuery();
                                cn.Close();
                            }
                        }
           
                        cmd = new SqlCommand("insert into stateofregisteration values(" + c + ",'" + y + "','open','0')", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        string n = label5.Text;
                        string v = label6.Text;
                        int b = Convert.ToInt32(n);
                        MessageBox.Show("" + v + "تم فتح باب التسجيل  للعام الدراسى " + b + " والفصل الدراسى ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmd = new SqlCommand("exec autoregister  @year="+b+",@semester='"+v+"'", cn);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        this.Close();
                    }

                }

                catch
                {
                    MessageBox.Show("لم يتم التاكيد رجاء التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && textBox1.TextLength==4)
            {
            int x=Convert.ToInt32(textBox1.Text);
            x=x+1;
            string c=Convert.ToString(x);
            textBox2.Text=c;
            }
            else
            {
                textBox2.Text = null;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("لم يتم فتح باب التسجيل", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
