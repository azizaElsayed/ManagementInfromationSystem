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
    public partial class Form15 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            Da = new SqlDataAdapter("select Name,NationalId,Telephone,Qualification,Gender,BirthDate,Nationality,Religion,HighSchoolDegree,YearOfQualification,HighSchoolId,NumberOfAccrediation,DateOfAccrediation,NumberOfOpportunities,Joining,Governorate,Region,Street,HouseNumber,Notes,FatherData from student where restricted='"+"1"+"'", cn);
            Da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("تاكيد الخروج", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form8 FrmUpdateStudent = new Form8();
            FrmUpdateStudent.Update = "update1";
            FrmUpdateStudent.NationalId = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FrmUpdateStudent.button2.Visible = false;
            FrmUpdateStudent.button1.Visible = false;
            FrmUpdateStudent.label1.Visible = false;
            FrmUpdateStudent.textBox1.Visible = false;
            FrmUpdateStudent.label2.Visible = false;
            FrmUpdateStudent.dtpDateOfAccrediation.Visible = false;
            FrmUpdateStudent.lblDateOfAccrediation.Visible = false;
       
            FrmUpdateStudent.btnAdd.Visible = false;
            FrmUpdateStudent.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form8 FrmdeleteStudent = new Form8();
        
            FrmdeleteStudent.NationalId = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FrmdeleteStudent.Update = "delete";
            FrmdeleteStudent.button3.Visible = false;
            FrmdeleteStudent.button1.Visible = false;
            FrmdeleteStudent.label1.Visible = false;
            FrmdeleteStudent.textBox1.Visible = false;
            FrmdeleteStudent.label2.Visible = false;
            FrmdeleteStudent.dtpDateOfAccrediation.Visible = false;
            FrmdeleteStudent.lblDateOfAccrediation.Visible = false;
        
            FrmdeleteStudent.btnAdd.Visible = false;
            FrmdeleteStudent.Show();
        }
    }
}
