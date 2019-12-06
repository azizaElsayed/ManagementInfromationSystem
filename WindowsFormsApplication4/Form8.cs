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
    public partial class Form8 : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        String imgloc = "";
        string  Qualification;
        string Joining;
        string Religion;
        string Gender;
    public    int r;
    public string Update="";
    public string NationalId;
    


        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = " select student picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgloc = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = imgloc;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            if ((Update == "update1") || (Update == "delete"))
            {
            

                try
                {
                int y ;
                cmd = new SqlCommand("select count(nationalid) from student where nationalid='" + NationalId+ "' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                y = Convert.ToInt32(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (y != 0)
                {

                    cmd = new SqlCommand("select Name,NationalId,Telephone,Qualification,Gender,BirthDate,Nationality,Religion,HighSchoolDegree,YearOfQualification,HighSchoolId,NumberOfAccrediation,DateOfAccrediation,NumberOfOpportunities,Joining,Governorate,Region,Street,HouseNumber,Notes,FatherData,picture from student where nationalid='" + NationalId + "' ", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    txtName.Text = dr[0].ToString();
                    txtNationalId.Text = dr[1].ToString();
                    txtTelephone.Text = dr[2].ToString();
                    Qualification = dr[3].ToString();
                    if (Qualification == "ثانوية عامة ")
                        rdo1.Checked = true;
                    if (Qualification == "ثانوية أزهرية")
                        rdo2.Checked = true;
                    if (Qualification == "معادلة")
                        rdo3.Checked = true;
                    if (Qualification == "وافد")
                        rdo4.Checked = true;
                    if (Qualification == "معهد فنى صناعى ")
                        rdo5.Checked = true;
                    if (Qualification == "ثانوى صناعى")
                        rdo6.Checked = true;

                    Gender = dr[4].ToString();

                    if (Gender == "ذكر")
                        rdo13.Checked = true;
                    if (Gender == "انثى")
                        rdo14.Checked = true;
                    comboBox3.Text = dr[6].ToString();
                    dtpBirthDate.Value = Convert.ToDateTime(dr[5]); ;


                    Religion = dr[7].ToString();

                    if (Religion == "مسلم" || Religion == "مسيحى")
                    {
                        if (Religion == "مسلم")
                            rdo12.Checked = true;
                        if (Religion == "مسيحى")
                            rdo11.Checked = true;
                    }
                    else
                    {
                        txtReligion.Visible = true;
                        txtReligion.Text = Religion;
                    }

                    txtHighSchoolDegree.Text = dr[8].ToString();
                    txtYearOfQualification.Text = dr[9].ToString();
                    txtHighSchoolId.Text = dr[10].ToString();
                    txtNumberOfAccrediation.Text = dr[11].ToString();
                    dtpDateOfAccrediation.Value = Convert.ToDateTime(dr[12]);
                    comboBox1.Text = dr[13].ToString();
                    Joining = dr[14].ToString();
                    if (Joining == "تنسيق")
                        rdo7.Checked = true;
                    if (Joining == "تحويل")
                        rdo8.Checked = true;
                    if (Joining == "بيان حالة")
                        rdo9.Checked = true;
                    comboBox2.Text = dr[15].ToString();
                    txtRegion.Text = dr[16].ToString();
                    txtStreet.Text = dr[17].ToString();
                    txtHouseNumber.Text = dr[18].ToString();
                    txtNotes.Text = dr[19].ToString();
                    txtFatherData.Text = dr[20].ToString();
                    if (dr[21] != DBNull.Value)
                    {
                        byte[] img = (byte[])(dr[21]);
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }

                    dr.Close();
                    cn.Close();
                    textBox1.ReadOnly = true;
                    button1.Visible = false;
                    this.Size = new Size(1386, 788);
                }
                else
                {
                    MessageBox.Show("رجاء التاكد من الرقم القومى ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            }
            
            this.ActiveControl = txtName;
            label2.Visible = false;
            txtReligion.Visible = false;
            label25.Visible = false;
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
            label42.Visible = false;
            
            
         
        }

        private void button1_Click(object sender, EventArgs e)
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
           
            try
            {
       int Compare =  Convert.ToInt32(dtpDateOfAccrediation.Value.Year.ToString());
       if (Compare != r || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHighSchoolDegree.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHighSchoolId.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(txtStreet.Text) || string.IsNullOrEmpty(txtRegion.Text) || string.IsNullOrEmpty(txtNationalId.Text) || string.IsNullOrEmpty(comboBox3.Text) || string.IsNullOrEmpty(this.comboBox1.Text) || string.IsNullOrEmpty(txtYearOfQualification.Text) || string.IsNullOrEmpty(txtNumberOfAccrediation.Text) || string.IsNullOrEmpty(Qualification) || string.IsNullOrEmpty(Joining) || string.IsNullOrEmpty(Religion) || string.IsNullOrEmpty(Gender) || txtNationalId.TextLength < 14 || txtYearOfQualification.TextLength<4)
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
                    if (string.IsNullOrEmpty(txtYearOfQualification.Text) || txtYearOfQualification.TextLength<4)
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
           //if (Compare!=r)
           //         label2.Visible = true;

                }
                else
                {
                    
                      cm = new SqlCommand("Select count(nationalId) from student where nationalId='"+txtNationalId.Text+"' ",cn);
                    cn.Open();
                    dr = cm.ExecuteReader();
                    dr.Read();
                    int Nationalid = Convert.ToInt32(dr[0].ToString());
                    
                    dr.Close();
                    cn.Close();
                    if (Nationalid==1)
                    {
                        MessageBox.Show("الرقم القومى "+txtNationalId.Text+" مستخدم من قبل", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                    cn.Open();
                    string sql = "insert into Student(shears,Name,NationalId,Telephone,Qualification,Gender,BirthDate,Nationality,Religion,HighSchoolDegree,YearOfQualification,HighSchoolId,NumberOfAccrediation,DateOfAccrediation,NumberOfOpportunities,Joining,Governorate,Region,Street,HouseNumber,Notes,FatherData,Picture) VALUES(0,@Name,@NationalId,@Telephone,@Qualification,@Gender,@BirthDate,@Nationality,@Religion,@HighSchoolDegree,@YearOfQualification,@HighSchoolId,@NumberOfAccrediation,@DateOfAccrediation,@NumberOfOpportunities,@Joining,@Governorate,@Region ,@Street,@HouseNumber,@Notes,@FatherData,@Picture) ";
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
                    cmd.Parameters.Add(new SqlParameter("@Joining",Joining));


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
                    cmd.Parameters.Add(new SqlParameter("@Religion",Religion));
                    //cmd.Parameters.Add("@religion", religion);
                    cmd.Parameters.Add(new SqlParameter("@Gender",Gender));
                    //  cmd.Parameters.Add("@gender", gender);
                    cmd.Parameters.Add(new SqlParameter("@Nationality", this.comboBox3.Text));
                    //  cmd.Parameters.Add("@nationality", textBox10.Text);
                    cmd.Parameters.Add(new SqlParameter("@Numberofaccrediation",txtNumberOfAccrediation.Text));
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
                    MessageBox.Show(" تم حفظ الطالب  " + txtName.Text+ " ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //

       int year=Convert.ToInt32(dtpDateOfAccrediation.Value.Year.ToString());
       string yea = Convert.ToString(year+1);

       cmd = new SqlCommand("select count(*) from student where studentid is not null and DateOfAccrediation>='" + dtpDateOfAccrediation.Value.Year.ToString() + "'and  DateOfAccrediation<'" + yea + "' ", cn);
                           cn.Open();
                  dr=cmd.ExecuteReader();
                  dr.Read();
                int cou= Convert.ToInt32( dr[0].ToString());
                  dr.Close();
                  cn.Close();
                        if(cou>0)
                        {
                            cou=cou+1;
                            cou = (year * 1000) + cou;
                            cmd = new SqlCommand("update student  set studentid="+cou+" where nationalid='" + txtNationalId.Text + "' ", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }
                        string pro="";
                        int z = Convert.ToInt32(dtpDateOfAccrediation.Value.Year.ToString());
                        cmd = new SqlCommand("select stated from stateofregisteration where  year=" + z + " and semester='"+"first"+"'", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            pro = dr[0].ToString();
                           
                        }
                        dr.Close();
                        cn.Close();
                        if(pro=="open")
                        {
                            cmd = new SqlCommand("exec autoregister2  @year=" + z + ",@semester='" + "first" + "',@idofstudent='" + txtNationalId.Text + "'", cn);
                            cn.Open();
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }

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
                    pictureBox1.Image =null;
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Enter)
            {
                grpQualification.Focus();
                rdo1.Checked = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHighSchoolId.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpBirthDate.Focus();
            }
        }

        private void Governorate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Governorate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRegion.Focus();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Enter)
            {
                txtStreet.Focus();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Enter)
            {
                txtHouseNumber.Focus();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNotes.Focus();
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Enter)
            {
                txtFatherData.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.Enter)
            {
                txtTelephone.Focus();
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNationalId.Focus();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grpJoining.Focus();
                rdo7.Checked = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();

            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumberOfAccrediation.Focus();

            }
        }

        private void textBox13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDateOfAccrediation.Focus();

            }
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
              comboBox2.Focus();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible =false;
            Qualification = rdo1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo3.Text;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo6.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo5.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (label28.Visible == true)
                label28.Visible = false;
            Qualification = rdo4.Text;
        }

        private void groupBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHighSchoolDegree.Focus();
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (label35.Visible == true)
                label35.Visible = false;
            Joining = rdo7.Text;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

            if (label35.Visible == true)
                label35.Visible = false; 
            Joining = rdo8.Text;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (label36.Visible == true)
                label36.Visible = false; 
            Joining = rdo9.Text;
        }

        private void groupBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox3.Focus();
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
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

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
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

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
  
            if (txtReligion.Visible == false)
            {
                txtReligion.Visible = true;
                label25.Visible = true;
            }
            Religion = txtReligion.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (label36.Visible == true)
                label36.Visible = false; 
            Religion = txtReligion.Text;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                groupBox4.Focus();
                rdo13.Checked = true;

            }
        }

        private void textBox11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grpReligion.Focus();
                rdo12.Checked = true;

            }
        }

        private void groupBox4_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtYearOfQualification.Focus();

            }
        }

        private void TxtYearOfQualification_TextChanged(object sender, EventArgs e)
        {
            if (label40.Visible == true)
                label40.Visible = false; 
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            String sql = "select picture from student where studentId=7 ";
            cn.Open();
            cmd = new SqlCommand(sql, cn);
            dr = cmd.ExecuteReader();
            dr.Read();
            byte[] img = (byte[])(dr[0]);
            dr.Close();
            cn.Close();
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grpReligion.Focus();
                rdo12.Checked = true;
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRegion.Focus();
            }
        }

        private void comboBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();

            }
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (label27.Visible == true)
                label27.Visible = false;
        }

        private void txtHighSchoolDegree_TextChanged(object sender, EventArgs e)
        {
            if (label29.Visible == true)
                label29.Visible = false;
        }

        private void txtHighSchoolId_TextChanged(object sender, EventArgs e)
        {
            if (label30.Visible == true)
                label30.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {
            if (label33.Visible == true)
                label33.Visible = false;
        }

        private void txtRegion_TextChanged(object sender, EventArgs e)
        {
            if (label32.Visible == true)
                label32.Visible = false;
        }

        private void txtNationalId_TextChanged(object sender, EventArgs e)
        {
            if (label34.Visible == true && txtNationalId.TextLength == 14)
                label34.Visible = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (label38.Visible == true)
                label38.Visible = false; 
        }

        private void txtNumberOfAccrediation_TextChanged(object sender, EventArgs e)
        {
            if (label41.Visible == true)
                label41.Visible = false; 
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (label37.Visible == true)
                label37.Visible = false; 
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (label31.Visible == true)
                label31.Visible = false;
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                int y ;
                cmd = new SqlCommand("select count(nationalid) from student where nationalid='" + textBox1.Text + "' ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                y = Convert.ToInt32(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (y != 0)
                {

                    cmd = new SqlCommand("select Name,NationalId,Telephone,Qualification,Gender,BirthDate,Nationality,Religion,HighSchoolDegree,YearOfQualification,HighSchoolId,NumberOfAccrediation,DateOfAccrediation,NumberOfOpportunities,Joining,Governorate,Region,Street,HouseNumber,Notes,FatherData,picture from student where nationalid='" + textBox1.Text + "' ", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    txtName.Text = dr[0].ToString();
                    txtNationalId.Text = dr[1].ToString();
                    txtTelephone.Text = dr[2].ToString();
                    Qualification = dr[3].ToString();
                    if (Qualification == "ثانوية عامة ")
                        rdo1.Checked = true;
                    if (Qualification == "ثانوية أزهرية")
                        rdo2.Checked = true;
                    if (Qualification == "معادلة")
                        rdo3.Checked = true;
                    if (Qualification == "وافد")
                        rdo4.Checked = true;
                    if (Qualification == "معهد فنى صناعى ")
                        rdo5.Checked = true;
                    if (Qualification == "ثانوى صناعى")
                        rdo6.Checked = true;

                    Gender = dr[4].ToString();

                    if (Gender == "ذكر")
                        rdo13.Checked = true;
                    if (Gender == "انثى")
                        rdo14.Checked = true;
                    comboBox3.Text = dr[6].ToString();
                    dtpBirthDate.Value = Convert.ToDateTime(dr[5]); ;


                    Religion = dr[7].ToString();

                    if (Religion == "مسلم" || Religion == "مسيحى")
                    {
                        if (Religion == "مسلم")
                            rdo12.Checked = true;
                        if (Religion == "مسيحى")
                            rdo11.Checked = true;
                    }
                    else
                    {
                        txtReligion.Visible = true;
                        txtReligion.Text = Religion;
                    }

                    txtHighSchoolDegree.Text = dr[8].ToString();
                    txtYearOfQualification.Text = dr[9].ToString();
                    txtHighSchoolId.Text = dr[10].ToString();
                    txtNumberOfAccrediation.Text = dr[11].ToString();
                    dtpDateOfAccrediation.Value = Convert.ToDateTime(dr[12]);
                    comboBox1.Text = dr[13].ToString();
                    Joining = dr[14].ToString();
                    if (Joining == "تنسيق")
                        rdo7.Checked = true;
                    if (Joining == "تحويل")
                        rdo8.Checked = true;
                    if (Joining == "بيان حالة")
                        rdo9.Checked = true;
                    comboBox2.Text = dr[15].ToString();
                    txtRegion.Text = dr[16].ToString();
                    txtStreet.Text = dr[17].ToString();
                    txtHouseNumber.Text = dr[18].ToString();
                    txtNotes.Text = dr[19].ToString();
                    txtFatherData.Text = dr[20].ToString();
                    if (dr[21] != DBNull.Value)
                    {
                        byte[] img = (byte[])(dr[21]);
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }

                    dr.Close();
                    cn.Close();
                    textBox1.ReadOnly = true;
                    button1.Visible = false;
                    this.Size = new Size(1386, 788);
                }
                else
                {
                    MessageBox.Show("رجاء التاكد من الرقم القومى ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            //صفر
        }

        private void button2_Click(object sender, EventArgs e)
        {
           try{ 
            cmd = new SqlCommand("update student set restricted='"+"0"+"' where NationalId='" + NationalId + "'", cn);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
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

            MessageBox.Show("تم الحذف", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Focus();
            textBox1.ReadOnly = false;
            textBox1.Clear();
            this.Size = new Size(1386, 104);
        }
        catch
    {
        MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
          
        }

        private void button3_Click(object sender, EventArgs e)
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
            if (textBox1.Visible == true)
            {
                NationalId = textBox1.Text;
            }

       // try
         //  {
               if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHighSchoolDegree.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtHighSchoolId.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(txtStreet.Text) || string.IsNullOrEmpty(txtRegion.Text) || string.IsNullOrEmpty(txtNationalId.Text) || string.IsNullOrEmpty(comboBox3.Text) || string.IsNullOrEmpty(this.comboBox1.Text) || string.IsNullOrEmpty(txtYearOfQualification.Text) || string.IsNullOrEmpty(txtNumberOfAccrediation.Text) || string.IsNullOrEmpty(Qualification) || string.IsNullOrEmpty(Joining) || string.IsNullOrEmpty(Religion) || string.IsNullOrEmpty(Gender) || txtNationalId.TextLength < 14 || txtYearOfQualification.TextLength<4)
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
                    if (string.IsNullOrEmpty(txtYearOfQualification.Text) || txtYearOfQualification.TextLength<4)
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

                }
                else
                {

                    cm = new SqlCommand("exec updatestudent  @nationalid='" + txtNationalId.Text + "',@nationalidold='" + NationalId + "'", cn);
                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                        cn.Open();
                        string sql = "update Student set Name=@Name,Telephone=@Telephone,Qualification=@Qualification,Gender=@Gender,BirthDate=@BirthDate,Nationality=@Nationality,Religion=@Religion,HighSchoolDegree=@HighSchoolDegree,YearOfQualification=@YearOfQualification,HighSchoolId=@HighSchoolId,NumberOfAccrediation=@NumberOfAccrediation,NumberOfOpportunities=@NumberOfOpportunities,Joining=@Joining,Governorate=@Governorate,Region=@Region,Street=@Street,HouseNumber=@HouseNumber,Notes=@Notes,FatherData=@FatherData,Picture=@Picture where nationalid='" +txtNationalId.Text + "' ";
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = dtpBirthDate.Value.Date;
                    //    cmd.Parameters.Add("@DateOfAccrediation", SqlDbType.Date).Value = dtpDateOfAccrediation.Value.Date;
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
                        else {
                            cmd.Parameters.Add("@Picture", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
                        }

                        cmd.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show(" تم تعديل  بيانات الطالب  " + txtName.Text + " ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
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
               
                        textBox1.Visible = true;
                        textBox1.Focus();
                        textBox1.ReadOnly = false;
                        textBox1.Clear();
                        button1.Visible = true;
                        label1.Visible = true;

                        this.Size = new Size(1386, 104);
                    
                }
         /*   }
            catch 
            {
                cn.Close();
             
                 MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = pictureBox1.InitialImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            button1.Visible = true;
            textBox1.Clear();

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
            label1.Visible = true;
            textBox1.Visible = true;
            textBox1.Focus();
            this.Size = new Size(1386, 104);


        }

        private void dtpDateOfAccrediation_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
