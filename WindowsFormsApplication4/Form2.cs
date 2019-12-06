using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        
    
     
       
   
     
     
       
    

      
   
      
    
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");

        SqlCommand cmd;
        SqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
         }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void Form2_Load(object sender, EventArgs e)
        {
      
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
         
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
         
       
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            
          
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void عرضنتيجةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 FrmShowResult = new Form6();
           // FrmShowResult.MdiParent = this;
            FrmShowResult.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select max(id) from stateofregisteration ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int g = Convert.ToInt32(dr[0].ToString());
                dr.Close();
                cn.Close();
                cmd = new SqlCommand("select year,semester,AdoptTheResult from stateofregisteration where id=" + g + " ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int h = Convert.ToInt32(dr[0].ToString());
                string r = dr[1].ToString();
                string k =dr[2].ToString();
                dr.Close();
                cn.Close();
                if ((r == "summer" && k == "1") || (r == "first" && k == "0"))
                {
                    if ((r == "summer" && k == "1"))
                    {
                        h = h + 1;
                        Form8 FrmAddStudent = new Form8();
                        FrmAddStudent.r = h;
                        FrmAddStudent.button1.Visible = false;
                        FrmAddStudent.label1.Visible = false;
                        FrmAddStudent.textBox1.Visible = false;
                        FrmAddStudent.button4.Visible = false;
                        FrmAddStudent.button3.Visible = false;
                        FrmAddStudent.button5.Visible = false;
                        FrmAddStudent.button2.Visible = false;
                        //   FrmAddStudent.MdiParent = this;
                        FrmAddStudent.Show();
                    }
                    else{
                     
                        Form8 FrmAddStudent = new Form8();
                        FrmAddStudent.r = h;
                        FrmAddStudent.button1.Visible = false;
                        FrmAddStudent.label1.Visible = false;
                        FrmAddStudent.textBox1.Visible = false;
                        FrmAddStudent.button4.Visible = false;
                        FrmAddStudent.button3.Visible = false;
                        FrmAddStudent.button5.Visible = false;
                        FrmAddStudent.button2.Visible = false;
                        //   FrmAddStudent.MdiParent = this;
                        FrmAddStudent.Show();

                    }
                    
                  
                }
                else
                {
                    // MessageBox.Show("لايمكن اضافه طلاب فى الوقت الحالى ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form8 FrmAddStudent = new Form8();
                    FrmAddStudent.r = h;
                    FrmAddStudent.button1.Visible = false;
                    FrmAddStudent.label1.Visible = false;
                    FrmAddStudent.textBox1.Visible = false;
                    FrmAddStudent.button4.Visible = false;
                    FrmAddStudent.button3.Visible = false;
                    FrmAddStudent.button5.Visible = false;
                    FrmAddStudent.button2.Visible = false;
                    //   FrmAddStudent.MdiParent = this;
                    FrmAddStudent.Show();



                }
            
           }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
     
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
        
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            Form7 Frmemployee = new Form7();
            // FrmControl.MdiParent = this;
            Frmemployee.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            int x = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            cn.Close();
            if(x==0)
            {
                {
                    MessageBox.Show("لا يوجد تسجيل متاح حاليا لغلقه", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {

                cmd = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string a = dr[0].ToString();
                int y;
                y = Convert.ToInt32(a);
                string k = dr[1].ToString();
                dr.Close();
                cn.Close();
                Form14 FrmClose = new Form14();
                FrmClose.label2.Text = a;
                FrmClose.label4.Text = k;
               
                //  FrmClose.MdiParent = this;
                FrmClose.Show();
            }


        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Form10 FrmChooseMaterial = new Form10();
            //   FrmChooseMaterial.MdiParent = this;
            FrmChooseMaterial.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            int x = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            cn.Close();
            if (x > 0)
            {
                MessageBox.Show("يجب قفل التسجيل اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                cmd = new SqlCommand("select stated,AdoptTheResult,year,semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string hg = dr[0].ToString();
                string n = dr[1].ToString();
                int year = Convert.ToInt32(dr[2].ToString());
                string semester = dr[3].ToString();
                if ((hg == "close") && (n == "0"))
                {

                    dr.Close();
                    cn.Close();
                    cmd = new SqlCommand("select count(*) from student where studentid is null", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string test = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    if (test == "0")
                    {
                        Form13 FrmWithdrawl = new Form13();
                        cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        FrmWithdrawl.label2.Text = dr[0].ToString();
                        FrmWithdrawl.label4.Text = dr[1].ToString();
                        string se = dr[1].ToString();
                        dr.Close();
                        cn.Close();
                        FrmWithdrawl.Show();
                        

                    }
                    else
                    {
                        MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    dr.Close();
                    cn.Close();
                    MessageBox.Show("تم اعتماد النتيجه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            /*
            cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            int x = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            cn.Close();
            if (x > 0)
            {
                MessageBox.Show("يجب قفل التسجيل اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                Form13 FrmWithdrawl = new Form13();
                cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                FrmWithdrawl.label2.Text = dr[0].ToString();
                FrmWithdrawl.label4.Text = dr[1].ToString();
                string se = dr[1].ToString();
                dr.Close();
                cn.Close();
                FrmWithdrawl.Show();
            }*/
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
          try
           {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {
                    MessageBox.Show("يجب قفل التسجيل اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    cmd = new SqlCommand("select stated,AdoptTheResult,year,semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                   string hg = dr[0].ToString();
                   string n= dr[1].ToString();
                       int year=Convert.ToInt32( dr[2].ToString());
                      string semester= dr[3].ToString();
                   if ((hg == "close") && (n == "0"))
                   {
                       
                       dr.Close();
                       cn.Close();
                        cmd = new SqlCommand("select count(*) from student where studentid is null", cn);
                       cn.Open();
                       dr = cmd.ExecuteReader();
                       dr.Read();
                       string test=dr[0].ToString();
                       dr.Close();
                       cn.Close();
                       if(test=="0")
                       {
                           cmd = new SqlCommand("select count(*) from contr where write='"+"1"+"' and year="+year+" and semester='"+semester+"'", cn);
                           cn.Open();
                           dr = cmd.ExecuteReader();
                           dr.Read();
                           string count = dr[0].ToString();
                           dr.Close();
                           cn.Close();
                           if(count!="0")
                           {
                       Form12 FrmStudentGrades = new Form12();
                       cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                       cn.Open();
                       dr = cmd.ExecuteReader();
                       dr.Read();
                       FrmStudentGrades.label4.Text= dr[0].ToString();
                       FrmStudentGrades.label6.Text = dr[1].ToString();
                   
                       string se = dr[1].ToString();
                       dr.Close();
                       cn.Close();
                       FrmStudentGrades.Show();
                           }
                           else
                           {
                               MessageBox.Show("لا يوجد مواد تم رصدها", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           }
                       }
                       else{
                             MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       }
                   }
                   else
                   {
                       dr.Close();
                       cn.Close();
                       MessageBox.Show("تم اعتماد النتيجه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
               }
         }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Form15 FrmUpdateStudentAuto = new Form15();
            FrmUpdateStudentAuto.button1.Visible = false;
            FrmUpdateStudentAuto.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            Form15 FrmDeleteStudentAuto = new Form15();
            FrmDeleteStudentAuto.button3.Visible = false;
            FrmDeleteStudentAuto.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {

         
            


       
        /*    FrmShowStudent.button3.Visible = false;
            FrmShowStudent.Size = new Size(1386, 104);
            FrmShowStudent.button4.Visible = false;
            FrmShowStudent.button2.Visible = false;
            FrmShowStudent.btnAdd.Visible = false;
            FrmShowStudent.btnLoad.Visible = false;
            FrmShowStudent.label26.Visible = false;*/
         
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
          
           // Form9 FrmSShowEmployee = new Form9();
         //   Form7 FrmSShowEmployee = new Form7();
           // FrmSShowEmployee.Size = new Size(730, 397);
          //  FrmSShowEmployee.Show();

        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
           cmd=new SqlCommand( "Select count(*) from student",cn);
           cn.Open();
           dr = cmd.ExecuteReader();
           dr.Read();
        int count=Convert.ToInt32(dr[0].ToString());
           dr.Close();
           cn.Close();
           if (count == 0)
           {
               MessageBox.Show("لايوجد طلاب مقيدين بالمعهد ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           else
           {
               cmd = new SqlCommand("select count(*) from student where studentid is null", cn);
               cn.Open();
               dr = cmd.ExecuteReader();
               dr.Read();
               int x = Convert.ToInt32(dr[0].ToString());
               dr.Close();
               cn.Close();
               if (x > 0)
               {
                   Form11 FrmGenerateCodeOfStudent = new Form11();
                   cmd = new SqlCommand("select year(DateOfAccrediation) from student where StudentId is null", cn);
                   cn.Open();
                   dr = cmd.ExecuteReader();
                   dr.Read();
                   string y = dr[0].ToString();
                   dr.Close();
                   cn.Close();
                   int c = Convert.ToInt32(y);
                   c = c + 1;
                   FrmGenerateCodeOfStudent.label2.Text = y;
                   FrmGenerateCodeOfStudent.label4.Text = "- "+c+"";
                   FrmGenerateCodeOfStudent.Show();
               }
               else
               {
                   MessageBox.Show("لايوجد طلاب بدون اكواد ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            Form8 FrmUpdateStudent = new Form8();

            FrmUpdateStudent.button2.Visible = false;
            FrmUpdateStudent.Size = new Size(1386, 104);
            FrmUpdateStudent.btnAdd.Visible = false;
            FrmUpdateStudent.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
      
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            try{

            cmd = new SqlCommand(" Select year,semester from stateofregisteration where adopttheresult='" + "0" + "' and stated='"+"close"+"'", cn);
           cn.Open();
            dr=cmd.ExecuteReader();
           if( dr.Read())
           {
        int ye= Convert.ToInt32( dr[0].ToString());
               ye=ye+1;

          string semester=dr[1].ToString();
                           Form16 FrmAdopTheResult = new Form16();
            FrmAdopTheResult.label2.Text=dr[0].ToString();
                FrmAdopTheResult.label4.Text=Convert.ToString(ye);
                FrmAdopTheResult.label6.Text =semester;
                FrmAdopTheResult.button3.Visible = false;
                FrmAdopTheResult.button4.Visible = false;
            FrmAdopTheResult.Show();
           }
           else
           {
               
         MessageBox.Show("لا يوجد نتيجة لاعتمادها", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
           }
           dr.Close();
            cn.Close();
        }
            catch{
            MessageBox.Show("من فضللك التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select max(id) from stateofregisteration ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int g = Convert.ToInt32(dr[0].ToString());
                dr.Close();
                cn.Close();
                cmd = new SqlCommand("select year,semester,AdoptTheResult from stateofregisteration where id=" + g + " ", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int h = Convert.ToInt32(dr[0].ToString());
                string r = dr[1].ToString();
                string k = dr[2].ToString();
                dr.Close();
                cn.Close();
                if ((r == "summer" && k == "1") || (r == "first" && k == "0"))
                {
                    if ((r == "summer" && k == "1"))
                    {
                        h = h + 1;
                        Form8 FrmAddStudent = new Form8();
                        FrmAddStudent.r = h;
                        FrmAddStudent.button1.Visible = false;
                        FrmAddStudent.label1.Visible = false;
                        FrmAddStudent.textBox1.Visible = false;
                        FrmAddStudent.button4.Visible = false;
                        FrmAddStudent.button3.Visible = false;
                        FrmAddStudent.button5.Visible = false;
                        FrmAddStudent.button2.Visible = false;
                        //   FrmAddStudent.MdiParent = this;
                        FrmAddStudent.Show();
                    }
                    else
                    {

                        Form8 FrmAddStudent = new Form8();
                        FrmAddStudent.r = h;
                        FrmAddStudent.button1.Visible = false;
                        FrmAddStudent.label1.Visible = false;
                        FrmAddStudent.textBox1.Visible = false;
                        FrmAddStudent.button4.Visible = false;
                        FrmAddStudent.button3.Visible = false;
                        FrmAddStudent.button5.Visible = false;
                        FrmAddStudent.button2.Visible = false;
                        //   FrmAddStudent.MdiParent = this;
                        FrmAddStudent.Show();

                    }


                }
                else
                {
                    // MessageBox.Show("لايمكن اضافه طلاب فى الوقت الحالى ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form8 FrmAddStudent = new Form8();
                    FrmAddStudent.r = h;
                    FrmAddStudent.button1.Visible = false;
                    FrmAddStudent.label1.Visible = false;
                    FrmAddStudent.textBox1.Visible = false;
                    FrmAddStudent.button4.Visible = false;
                    FrmAddStudent.button3.Visible = false;
                    FrmAddStudent.button5.Visible = false;
                    FrmAddStudent.button2.Visible = false;
                    //   FrmAddStudent.MdiParent = this;
                    FrmAddStudent.Show();

                }

            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form7 Frmemployee = new Form7();
            // FrmControl.MdiParent = this;
            Frmemployee.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {
                    MessageBox.Show("يجب قفل التسجيل اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    cmd = new SqlCommand("select stated,AdoptTheResult from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string hg = dr[0].ToString();
                    string n = dr[1].ToString();
                    if ((hg == "close") && (n == "0"))
                    {

                        dr.Close();
                        cn.Close();
                        cmd = new SqlCommand("select count(*) from student where studentid is null", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        string test = dr[0].ToString();
                        dr.Close();
                        cn.Close();
                        if (test == "0")
                        {
                            Form12 FrmStudentGrades = new Form12();
                            cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                            cn.Open();
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            FrmStudentGrades.label4.Text = dr[0].ToString();
                            FrmStudentGrades.label6.Text = dr[1].ToString();

                            string se = dr[1].ToString();
                            dr.Close();
                            cn.Close();
                            FrmStudentGrades.Show();
                        }
                        else
                        {
                            MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                        MessageBox.Show("تم اعتماد النتيجه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {

                    cmd = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string a = dr[0].ToString();
                    int y;
                    y = Convert.ToInt32(a);
                    string k = dr[1].ToString();
                    dr.Close();
                    cn.Close();
                    Form3 FrmRegister = new Form3();
                    FrmRegister.label10.Text = a;
                    FrmRegister.label11.Text = k;
                    // FrmRegister.Dock = DockStyle.Fill;
                    //   FrmRegister.MdiParent = this;
                    FrmRegister.Show();

                }
                else
                {
                    MessageBox.Show("لا يوجد تسجيل متاح حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("تاكيد الخروج", "رسالة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                Application.OpenForms[0].Show();
                this.Hide();
            }
        }

        private void toolStripMenuItem8_Click_1(object sender, EventArgs e)
        {
            try
            {

                cmd = new SqlCommand(" Select year,semester from stateofregisteration where adopttheresult='" + "1" + "' and stated='" + "close" + "' and id=(select max(id) from stateofregisteration)", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int ye = Convert.ToInt32(dr[0].ToString());
                    ye = ye + 1;

                    string semester = dr[1].ToString();
                    Form16 FrmDeleteTheResult = new Form16();
                    FrmDeleteTheResult.label2.Text = dr[0].ToString();
                    FrmDeleteTheResult.label4.Text = Convert.ToString(ye);
                    FrmDeleteTheResult.label6.Text = semester;
                    FrmDeleteTheResult.button1.Visible = false;
                    FrmDeleteTheResult.button2.Visible = false;
                    FrmDeleteTheResult.Show();
                }
                else
                {

                    MessageBox.Show("لا يوجد نتيجة لالغاء لاعتمادها", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                dr.Close();
                cn.Close();
            }
            catch
            {
                MessageBox.Show("من فضللك التاكد من الاتصال بقاعدة البيانات", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem24_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select year,semester from stateofregisteration where adopttheresult='" + "0" + "' and stated='" + "close" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string x = dr[0].ToString();
                    int z = Convert.ToInt32(x);
                    string y = dr[1].ToString();
                    dr.Close();
                    cn.Close();
                    cmd = new SqlCommand("select MaterialCode from contr where year=" + z + " and semester='" + y + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();


                    if (!dr.Read())
                    {
                        dr.Close();
                        cn.Close();
                        Form18 CreateControl = new Form18();
                        CreateControl.label2.Text = x;
                        CreateControl.label4.Text = y;
                        CreateControl.Show();
                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                        MessageBox.Show("عفوا تم انشاء الكنترول ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    dr.Close();
                    cn.Close();
                    MessageBox.Show("عفوا لايمكن فتح كنترول حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }

            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال بقاعدة البيانات  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select year,semester from stateofregisteration where adopttheresult='" + "0" + "' and stated='" + "close" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string x = dr[0].ToString();
                    int z = Convert.ToInt32(x);
                    string y = dr[1].ToString();
                    dr.Close();
                    cn.Close();
                    Form20 AddEmplyeeControl = new Form20();
                    AddEmplyeeControl.label2.Text = x;
                    AddEmplyeeControl.label4.Text = y;
                    AddEmplyeeControl.Show();

                }
                else
                {
                    dr.Close();
                    cn.Close();
                    MessageBox.Show("عفوا لايمكن اضافه اعضاء كنترول حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال بقاعدة البيانات  ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {

        /*    try
            {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {
                    MessageBox.Show("يجب قفل التسجيل اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    cmd = new SqlCommand("select stated,AdoptTheResult from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string hg = dr[0].ToString();
                    string n = dr[1].ToString();
                    if ((hg == "close") && (n == "0"))
                    {
                        dr.Close();
                        cn.Close();
                        Form21 FrmStudentGrade = new Form21();
                        cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        FrmStudentGrade.year= Convert.ToInt32( dr[0].ToString());
                        FrmStudentGrade.semester = dr[1].ToString();
                        string se = dr[1].ToString();
                        dr.Close();
                        cn.Close();
            


                        FrmStudentGrade.Show();
                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                        MessageBox.Show("تم اعتماد النتيجه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

            
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            Form23 frmshowresultstudent = new Form23();
            frmshowresultstudent.Show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {

                    cmd = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string a = dr[0].ToString();
                    int y;
                    y = Convert.ToInt32(a);
                    string k = dr[1].ToString();
                    dr.Close();
                    cn.Close();
                    Form3 FrmRegister = new Form3();
                    FrmRegister.label10.Text = a;
                    FrmRegister.label11.Text = k;
                    // FrmRegister.Dock = DockStyle.Fill;
                    //   FrmRegister.MdiParent = this;
                    FrmRegister.Show();

                }
                else
                {
                    MessageBox.Show("لا يوجد تسجيل متاح حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {

                    cmd = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string a = dr[0].ToString();
                    int y;
                    y = Convert.ToInt32(x);
                    string k = dr[1].ToString();
                    dr.Close();
                    cn.Close();
                    Form5 FrmUpdateRegister = new Form5();
                    FrmUpdateRegister.label11.Text = a;
                    FrmUpdateRegister.label12.Text = k;
                    //  FrmUpdateRegister.MdiParent = this;
                    //    FrmUpdateRegister.Dock = DockStyle.Fill;
                    FrmUpdateRegister.Show();

                }
                else
                {
                    MessageBox.Show("لا يوجد تسجيل متاح حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {

                    cmd = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string a = dr[0].ToString();
                    int y;
                    y = Convert.ToInt32(a);
                    string k = dr[1].ToString();
                    dr.Close();
                    cn.Close();
                    Form25 FrmRegister = new Form25();
                    FrmRegister.label10.Text = a;
                    FrmRegister.label11.Text = k;
                    // FrmRegister.Dock = DockStyle.Fill;
                    //   FrmRegister.MdiParent = this;
                    FrmRegister.Show();

                }
                else
                {
                    MessageBox.Show("لا يوجد تسجيل متاح حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt16(dr[0].ToString());
                dr.Close();
                cn.Close();
                if (x > 0)
                {

                    cmd = new SqlCommand("select year,semester from stateofregisteration where stated='" + "open" + "'", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string a = dr[0].ToString();
                    int y;
                    y = Convert.ToInt32(x);
                    string k = dr[1].ToString();
                    dr.Close();
                    cn.Close();
                    Form26 FrmUpdateRegister = new Form26();
                    FrmUpdateRegister.label11.Text = a;
                    FrmUpdateRegister.label12.Text = k;
                    //  FrmUpdateRegister.MdiParent = this;
                    //    FrmUpdateRegister.Dock = DockStyle.Fill;
                    FrmUpdateRegister.Show();

                }
                else
                {
                    MessageBox.Show("لا يوجد تسجيل متاح حاليا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("رجاء التاكد من الاتصال الصحيح بقاعدة البيانات ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripMenuItem25_Click_1(object sender, EventArgs e)
        {
            Form17 frmAddMaterial = new Form17();
            frmAddMaterial.Show();
        }

        private void toolStripMenuItem30_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select count(*) from student where restricted='" + "1" + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            string a = dr[0].ToString();
            dr.Close();
            cn.Close();
            if (a != "0")
            {
                Form22 FrmShowStudent = new Form22();
                FrmShowStudent.choosereport = 1;
                FrmShowStudent.Show();
            }
            else
            {
                MessageBox.Show("لا يوجد طلاب مقيدين بالمعهد", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripMenuItem31_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select count(*) from student where restricted='" + "0" + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            string a = dr[0].ToString();
            dr.Close();
            cn.Close();
            if (a != "0")
            {
                Form22 FrmShowStudent = new Form22();
                FrmShowStudent.choosereport = 2;
                FrmShowStudent.Show();
            }
            else
            {
                MessageBox.Show("لا يوجد طلاب تم حذفهم من القيد بالمعهد", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripMenuItem28_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            int x = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            cn.Close();
            if (x > 0)
            {
                MessageBox.Show("يجب قفل التسجيل اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                cmd = new SqlCommand("select stated,AdoptTheResult,year,semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string hg = dr[0].ToString();
                string n = dr[1].ToString();
                int year = Convert.ToInt32(dr[2].ToString());
                string semester = dr[3].ToString();
                if ((hg == "close") && (n == "0"))
                {

                    dr.Close();
                    cn.Close();
                    cmd = new SqlCommand("select count(*) from student where studentid is null", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string test = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    if (test == "0")
                    {
                        Form13 FrmWithdrawl = new Form13();
                        cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        FrmWithdrawl.label2.Text = dr[0].ToString();
                        FrmWithdrawl.label4.Text = dr[1].ToString();
                        string se = dr[1].ToString();
                        dr.Close();
                        cn.Close();
                        FrmWithdrawl.Show();


                    }
                    else
                    {
                        MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    dr.Close();
                    cn.Close();
                    MessageBox.Show("تم اعتماد النتيجه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripMenuItem28_Click_2(object sender, EventArgs e)
        {
             cmd = new SqlCommand("select count(stated) from stateofregisteration where stated='" + "open" + "'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            int x = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            cn.Close();
            if (x > 0)
            {
                MessageBox.Show("يجب قفل التسجيل اولا", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                cmd = new SqlCommand("select stated,AdoptTheResult,year,semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                string hg = dr[0].ToString();
                string n = dr[1].ToString();
                int year = Convert.ToInt32(dr[2].ToString());
                string semester = dr[3].ToString();
                if ((hg == "close") && (n == "0"))
                {

                    dr.Close();
                    cn.Close();
                    cmd = new SqlCommand("select count(*) from student where studentid is null", cn);
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    string test = dr[0].ToString();
                    dr.Close();
                    cn.Close();
                    if (test == "0")
                    {
                        Form28 FrmDelteWithDraw = new Form28();
                        cmd = new SqlCommand("select [year],semester from stateofregisteration where id=(select max(id) from stateofregisteration)", cn);
                        cn.Open();
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        FrmDelteWithDraw.label2.Text = dr[0].ToString();
                        FrmDelteWithDraw.label4.Text = dr[1].ToString();
                        string se = dr[1].ToString();
                        dr.Close();
                        cn.Close();
                        FrmDelteWithDraw.Show();


                    }
                    else
                    {
                        MessageBox.Show("لم يتم اكودة طلاب اعدادى", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    dr.Close();
                    cn.Close();
                    MessageBox.Show("تم اعتماد النتيجه ", "رسالة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void اضافةطالبجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form29 frm29 = new Form29();
            frm29.MdiParent = this;
            frm29.Show();
        }

        private void ادخالالموادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form30 frm30 = new Form30();
            frm30.MdiParent = this;
            frm30.Show();
        }
    }
}
