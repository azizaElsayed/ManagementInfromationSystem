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
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Form29 : Form
        {
            SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            SqlCommand cm = new SqlCommand();
            SqlDataReader dr;
            String imgloc = "";
            string Qualification;
            string Joining;
            string Religion;
            string Gender;
            public int r;
            public string Update = "";
            public string NationalId;
        public Form29()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            label2.Visible = false;
            label42.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label41.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            try
            {
                int Compare = Convert.ToInt32(dtpDateOfAccrediation.Value.Year.ToString());
                if ( string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHighSchoolDegree.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHighSchoolId.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(txtStreet.Text) || string.IsNullOrEmpty(txtRegion.Text) || string.IsNullOrEmpty(txtNationalId.Text) || string.IsNullOrEmpty(comboBox3.Text) || string.IsNullOrEmpty(this.comboBox1.Text) || string.IsNullOrEmpty(txtYearOfQualification.Text) || string.IsNullOrEmpty(txtNumberOfAccrediation.Text) || string.IsNullOrEmpty(Qualification) || string.IsNullOrEmpty(Joining) || string.IsNullOrEmpty(Religion) || string.IsNullOrEmpty(Gender) || txtNationalId.TextLength < 14 || txtYearOfQualification.TextLength < 4)
                {
                    label42.Visible = true;
                    if (string.IsNullOrEmpty(txtName.Text))
                        label27.Visible = true;

                    if (string.IsNullOrEmpty(txtHighSchoolDegree.Text))
                        label29.Visible = true;
                    if (string.IsNullOrEmpty(txtHighSchoolId.Text))
                        label30.Visible = true;
                    if (string.IsNullOrEmpty(comboBox2.Text))
                        label31.Visible = true;
                    if (string.IsNullOrEmpty(txtStreet.Text))
                        label33.Visible = true;
                    if (string.IsNullOrEmpty(txtRegion.Text))
                        label32.Visible = true;
                    if (string.IsNullOrEmpty(txtNationalId.Text) || txtNationalId.TextLength < 14)
                        label34.Visible = true;
                    if (string.IsNullOrEmpty(comboBox3.Text))
                        label37.Visible = true;
                    if (string.IsNullOrEmpty(this.comboBox1.Text))
                        label38.Visible = true;
                    if (string.IsNullOrEmpty(txtYearOfQualification.Text) || txtYearOfQualification.TextLength < 4)
                        label40.Visible = true;
                    if (string.IsNullOrEmpty(txtNumberOfAccrediation.Text))
                        label41.Visible = true;

                    if (string.IsNullOrEmpty(Qualification))
                        label28.Visible = true;
                    if (string.IsNullOrEmpty(Joining))
                        label35.Visible = true;
                    if (string.IsNullOrEmpty(Religion))
                        label36.Visible = true;
                    if (string.IsNullOrEmpty(Gender))
                        label39.Visible = true;
                    //if (Compare != r)
                    //    label2.Visible = true;
                    //label3.Visible = true;
                    if (string.IsNullOrEmpty(txtCode.Text))
                        label3.Visible = true;
                    if (string.IsNullOrEmpty(this.comboBox4.Text))
                        label5.Visible = true;

                }
                else
                {

                    cm = new SqlCommand("Select count(nationalId) from student where nationalId='" + txtNationalId.Text + "' ", cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    int Nationalid = Convert.ToInt32(dr[0].ToString());

                    dr.Close();
                    cn.Close();
                    if (Nationalid == 1)
                    {
                        MessageBox.Show("الرقم القومى " + txtNationalId.Text + " مستخدم من قبل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cn.Open();
                        string sql = "insert into Student(StudentId,shears,Name,NationalId,Telephone,Qualification,Gender,BirthDate,Nationality,Religion,HighSchoolDegree,YearOfQualification,HighSchoolId,NumberOfAccrediation,DateOfAccrediation,NumberOfOpportunities,Joining,Governorate,Region,Street,HouseNumber,Notes,FatherData,Picture) VALUES(" + Convert.ToInt32(txtCode.Text) + ",1,@Name,@NationalId,@Telephone,@Qualification,@Gender,@BirthDate,@Nationality,@Religion,@HighSchoolDegree,@YearOfQualification,@HighSchoolId,@NumberOfAccrediation,@DateOfAccrediation,@NumberOfOpportunities,@Joining,@Governorate,@Region ,@Street,@HouseNumber,@Notes,@FatherData,@Picture) ";
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = dtpBirthDate.Value.Date;
                        cmd.Parameters.Add("@DateOfAccrediation", SqlDbType.Date).Value = dtpDateOfAccrediation.Value.Date;
                        //   cmd.Parameters.Add("@name", textBox1.Text);
                        cmd.Parameters.Add(new SqlParameter("@Name", txtName.Text));
                        //  cmd.Parameters.Add("@q", qualification);
                        cmd.Parameters.Add(new SqlParameter("@Qualification", Qualification));
                        // cmd.Parameters.Add("@total", Convert.ToInt64(textBox2.Text));
                        cmd.Parameters.Add(new SqlParameter("@HighSchoolDegree", txtHighSchoolDegree.Text));
                        //   cmd.Parameters.Add("@numberseat", Convert.ToInt64(textBox3.Text));
                        cmd.Parameters.Add(new SqlParameter("@HighSchoolId", txtHighSchoolId.Text));
                        // cmd.Parameters.Add("@g", textBox16.Text);
                        cmd.Parameters.Add(new SqlParameter("@Governorate", this.comboBox2.Text));
                        // cmd.Parameters.Add("@r", textBox5.Text);
                        cmd.Parameters.Add(new SqlParameter("@Region", txtRegion.Text));
                        //   cmd.Parameters.Add("@s", textBox6.Text);
                        cmd.Parameters.Add(new SqlParameter("@Street", txtStreet.Text));
                        //  cmd.Parameters.Add("@case",Case);
                        cmd.Parameters.Add(new SqlParameter("@Joining", Joining));


                        if (string.IsNullOrEmpty(txtTelephone.Text))
                            cmd.Parameters.Add(new SqlParameter("@Telephone", DBNull.Value));
                        else
                            cmd.Parameters.Add(new SqlParameter("@Telephone", txtTelephone.Text));


                        if (string.IsNullOrEmpty(txtHouseNumber.Text))
                            cmd.Parameters.Add(new SqlParameter("@HouseNumber", DBNull.Value));
                        else
                            cmd.Parameters.Add(new SqlParameter("@HouseNumber", txtHouseNumber.Text));

                        if (string.IsNullOrEmpty(txtNotes.Text))
                            cmd.Parameters.Add(new SqlParameter("@Notes", DBNull.Value));
                        else
                            cmd.Parameters.Add(new SqlParameter("@Notes", txtNotes.Text));

                        if (string.IsNullOrEmpty(txtFatherData.Text))
                            cmd.Parameters.Add(new SqlParameter("@FatherData", DBNull.Value));
                        else
                            cmd.Parameters.Add(new SqlParameter("@FatherData", txtFatherData.Text));



                        cmd.Parameters.Add(new SqlParameter("@NationalId", txtNationalId.Text));
                        //    cmd.Parameters.Add("@national", Convert.ToInt64(textBox8.Text));
                        cmd.Parameters.Add(new SqlParameter("@NumberOfOpportunities", this.comboBox1.SelectedItem));
                        //   cmd.Parameters.Add("@numofopp", Convert.ToInt16(textBox11.Text));
                        cmd.Parameters.Add(new SqlParameter("@Religion", Religion));
                        //cmd.Parameters.Add("@religion", religion);
                        cmd.Parameters.Add(new SqlParameter("@Gender", Gender));
                        //  cmd.Parameters.Add("@gender", gender);
                        cmd.Parameters.Add(new SqlParameter("@Nationality", this.comboBox3.Text));
                        //  cmd.Parameters.Add("@nationality", textBox10.Text);
                        cmd.Parameters.Add(new SqlParameter("@Numberofaccrediation", txtNumberOfAccrediation.Text));
                        //  cmd.Parameters.Add("@numberofaccre", Convert.ToInt64(textBox13.Text));
                        cmd.Parameters.Add(new SqlParameter("@YearOfQualification", Convert.ToInt64(txtYearOfQualification.Text)));
                        // cmd.Parameters.Add("@yearof", Convert.ToInt64(textBox12.Text));
                        if (!String.IsNullOrWhiteSpace(imgloc))
                        {
                            byte[] img = null;
                            FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            img = br.ReadBytes((int)fs.Length);
                            SqlParameter paramPicture = new SqlParameter("@Picture", SqlDbType.Binary, img.Length);
                            paramPicture.Value = img;
                            cmd.Parameters.Add(paramPicture);
                        }
                        else { cmd.Parameters.Add("@Picture", System.Data.SqlDbType.VarBinary).Value = DBNull.Value; }

                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show(" تم حفظ الطالب  " + txtName.Text + " ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //

                        //int year = Convert.ToInt32(dtpDateOfAccrediation.Value.Year.ToString());
                        //string yea = Convert.ToString(year + 1);

                        //cmd = new SqlCommand("select count(*) from student where studentid is not null and DateOfAccrediation>='" + dtpDateOfAccrediation.Value.Year.ToString() + "'and  DateOfAccrediation<'" + yea + "' ", cn);
                        //cn.Open();
                        //dr = cmd.ExecuteReader();
                        //dr.Read();
                        //int cou = Convert.ToInt32(dr[0].ToString());
                        //dr.Close();
                        //cn.Close();
                        //if (cou > 0)
                        //{
                        //    cou = cou + 1;
                        //    cou = (year * 1000) + cou;
                        //    cmd = new SqlCommand("update student  set studentid=" + cou + " where nationalid='" + txtNationalId.Text + "' ", cn);
                        //    cn.Open();
                        //    cmd.ExecuteNonQuery();
                        //    cn.Close();
                        //}
                        //string pro = "";
                        //int z = Convert.ToInt32(dtpDateOfAccrediation.Value.Year.ToString());
                        //cmd = new SqlCommand("select stated from stateofregisteration where  year=" + z + " and semester='" + "first" + "'", cn);
                        //cn.Open();
                        //dr = cmd.ExecuteReader();
                        //if (dr.Read())
                        //{
                        //    pro = dr[0].ToString();

                        //}
                        //dr.Close();
                        //cn.Close();
                        //if (pro == "open")
                        //{
                        //    cmd = new SqlCommand("exec autoregister2  @year=" + z + ",@semester='" + "first" + "',@idofstudent='" + txtNationalId.Text + "'", cn);
                        //    cn.Open();
                        //    cmd.ExecuteNonQuery();
                        //    cn.Close();
                        //}

                        if (rdo1.Checked == true)
                            rdo1.Checked = false;
                        if (rdo1.Checked == true)
                            rdo1.Checked = false;
                        if (rdo2.Checked == true)
                            rdo2.Checked = false;
                        if (rdo3.Checked == true)
                            rdo3.Checked = false;
                        if (rdo4.Checked == true)
                            rdo4.Checked = false;
                        if (rdo5.Checked == true)
                            rdo5.Checked = false;
                        if (rdo6.Checked == true)
                            rdo6.Checked = false;
                        if (rdo7.Checked == true)
                            rdo7.Checked = false;
                        if (rdo8.Checked == true)
                            rdo8.Checked = false;
                        if (rdo9.Checked == true)
                            rdo9.Checked = false;
                        if (rdo10.Checked == true)
                            rdo10.Checked = false;
                        if (rdo11.Checked == true)
                            rdo11.Checked = false;
                        if (rdo12.Checked == true)
                            rdo12.Checked = false;
                        if (rdo13.Checked == true)
                            rdo13.Checked = false;
                        if (rdo14.Checked == true)
                            rdo14.Checked = false;
                        txtCode.Text = "";
                        comboBox4.Text = null;
                        Qualification = "";
                        Joining = "";
                        Religion = "";
                        Gender = "";
                        txtName.Clear();
                        txtHighSchoolDegree.Clear();
                        txtHighSchoolId.Clear();
                        comboBox2.Text = null;
                        txtStreet.Clear();
                        txtRegion.Clear();
                        txtHouseNumber.Clear();
                        txtNotes.Clear();
                        txtTelephone.Clear();
                        txtNationalId.Clear();
                        comboBox3.Text = null;
                        comboBox1.SelectedItem = null;
                        txtYearOfQualification.Clear();
                        txtNumberOfAccrediation.Clear();
                        txtFatherData.Clear();
                        pictureBox1.Image = null;
                        imgloc = null;
                        pictureBox1.Invalidate();
                        pictureBox1.Image = pictureBox1.InitialImage;
                        if (txtReligion.Visible == true)
                        {
                            txtReligion.Clear();
                            txtReligion.Visible = false;
                            label25.Visible = false;

                        }
                        txtName.Focus();
                    }
                }
            }
            catch
            {
                cn.Close();
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form29_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label42.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label41.Visible = false;
            label3.Visible = false;
            label25.Visible = false;
            label2.Visible = false;
            txtReligion.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdo12_CheckedChanged(object sender, EventArgs e)
        {
            if (label36.Visible == true)
                label36.Visible = false;
            if (txtReligion.Visible == true)
            {
                txtReligion.Visible = false;
                label25.Visible = false;
            }
            Religion = rdo12.Text;
        }

        private void rdo11_CheckedChanged(object sender, EventArgs e)
        {
            if (label36.Visible == true)
                label36.Visible = false;
            if (txtReligion.Visible == true)
            {
                txtReligion.Visible = false;
                label25.Visible = false;
            }
            Religion = rdo11.Text;
        }

        private void rdo10_CheckedChanged(object sender, EventArgs e)
        {
            if (txtReligion.Visible == false)
            {
                txtReligion.Visible = true;
                label25.Visible = true;
            }
            Religion = txtReligion.Text;
        }

        private void rdo7_CheckedChanged(object sender, EventArgs e)
        {
            if (label35.Visible == true)
                label35.Visible = false;
            Joining = rdo7.Text;
        }

        private void rdo8_CheckedChanged(object sender, EventArgs e)
        {
            if (label35.Visible == true)
                label35.Visible = false;
            Joining = rdo8.Text;
        }

        private void rdo9_CheckedChanged(object sender, EventArgs e)
        {
            if (label36.Visible == true)
                label36.Visible = false;
            Joining = rdo9.Text;
        }

        private void rdo13_CheckedChanged(object sender, EventArgs e)
        {
            if (label39.Visible == true)
                label39.Visible = false;
            Gender = rdo13.Text;
        }

        private void rdo14_CheckedChanged(object sender, EventArgs e)
        {
            if (label39.Visible == true)
                label39.Visible = false;
            Gender = rdo14.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label42.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label32.Visible = false;
            label33.Visible = false;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            label38.Visible = false;
            label39.Visible = false;
            label40.Visible = false;
            label41.Visible = false;
            if (rdo1.Checked == true)
                rdo1.Checked = false;
            if (rdo1.Checked == true)
                rdo1.Checked = false;
            if (rdo2.Checked == true)
                rdo2.Checked = false;
            if (rdo3.Checked == true)
                rdo3.Checked = false;
            if (rdo4.Checked == true)
                rdo4.Checked = false;
            if (rdo5.Checked == true)
                rdo5.Checked = false;
            if (rdo6.Checked == true)
                rdo6.Checked = false;
            if (rdo7.Checked == true)
                rdo7.Checked = false;
            if (rdo8.Checked == true)
                rdo8.Checked = false;
            if (rdo9.Checked == true)
                rdo9.Checked = false;
            if (rdo10.Checked == true)
                rdo10.Checked = false;
            if (rdo11.Checked == true)
                rdo11.Checked = false;
            if (rdo12.Checked == true)
                rdo12.Checked = false;
            if (rdo13.Checked == true)
                rdo13.Checked = false;
            if (rdo14.Checked == true)
                rdo14.Checked = false;
            txtCode.Text = "";
            comboBox4.Text = "";
            Qualification = "";
            Joining = "";
            Religion = "";
            Gender = "";
            txtName.Clear();
            txtHighSchoolDegree.Clear();
            txtHighSchoolId.Clear();
            comboBox2.Text = null;
            txtStreet.Clear();
            txtRegion.Clear();
            txtHouseNumber.Clear();
            txtNotes.Clear();
            txtTelephone.Clear();
            txtNationalId.Clear();
            comboBox3.Text = null;
            comboBox1.SelectedItem = null;
            txtYearOfQualification.Clear();
            txtNumberOfAccrediation.Clear();
            txtFatherData.Clear();
            pictureBox1.Image = null;
            imgloc = null;
            pictureBox1.Invalidate();
            pictureBox1.Image = pictureBox1.InitialImage;
            if (txtReligion.Visible == true)
            {
                txtReligion.Clear();
                txtReligion.Visible = false;
                label25.Visible = false;

            }
            txtCode.Text = "";
            label3.Visible = false;
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo1.Text;
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo2.Text;
        }

        private void rdo3_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo3.Text;
        }

        private void rdo6_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo6.Text;
        }

        private void grpQualification_Enter(object sender, EventArgs e)
        {

        }

        private void rdo5_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo5.Text;
        }

        private void rdo4_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo4.Text;
        }
    }
}
