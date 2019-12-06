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
using Microsoft.Reporting.WinForms;
namespace WindowsFormsApplication4
{
    public partial class Form22 : Form
    {
        public int choosereport=0;
        public int studentid = 0;
        public int year = 0;
        public string semester = "";
        public string name = "";
        SqlConnection cn = new SqlConnection(@"Server=NOURINNET-PC\SQLEXPRESS;DataBase=Mis;Integrated Security=True");

        SqlCommand cm;
        SqlDataReader dr;
        DataSet ds;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        Microsoft.Reporting.WinForms.ReportDataSource ReportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
        System.Windows.Forms.BindingSource bs1 = new System.Windows.Forms.BindingSource();
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            if(choosereport==0)
          {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication4.Report2.rdlc";
            cm = new SqlCommand("exec showgpa  @studentid=" + studentid + ", @year=" + year + ",@semester='" + semester+ "' ", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            dr.Read();
            string n = dr[0].ToString();
            dr.Close();
            cn.Close();
          

            Da = new SqlDataAdapter(" exec result  @idofstudent=" + studentid+ ",@year=" + year + ",@semester='" + semester+ "'", cn);
            ds = new DataSet();
            Da.Fill(ds);
        
            bs1.DataSource = ds.Tables[0];

            ReportDataSource1.Name = "DataSet1";
            ReportDataSource1.Value = bs1;
            this.reportViewer1.LocalReport.DataSources.Add(ReportDataSource1);
            ReportParameter pa = new ReportParameter("gpa",n);
            string student = Convert.ToString(studentid);
            ReportParameter p = new ReportParameter("studentid",student);
            ReportParameter pn = new ReportParameter("name", name);
                      string yea = Convert.ToString(year);
            ReportParameter py = new ReportParameter("year", yea);
            ReportParameter ps = new ReportParameter("semester",semester);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[]{pa});
           
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] {p});

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { pn });
                 reportViewer1.LocalReport.SetParameters(new ReportParameter[] { ps });
                 reportViewer1.LocalReport.SetParameters(new ReportParameter[] { py });

            this.reportViewer1.RefreshReport();
            }
            else if(choosereport==1)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication4.Report1.rdlc";
              


                Da = new SqlDataAdapter(" select * from student where restricted='"+"1"+"'", cn);
                ds = new DataSet();
                Da.Fill(ds);

                bs1.DataSource = ds.Tables[0];

                ReportDataSource1.Name = "DataSet1";
                ReportDataSource1.Value = bs1;
                this.reportViewer1.LocalReport.DataSources.Add(ReportDataSource1);
         

                this.reportViewer1.RefreshReport();

            }
            else if (choosereport == 2)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication4.Report1.rdlc";



                Da = new SqlDataAdapter(" select * from student where restricted='" + "0" + "'", cn);
                ds = new DataSet();
                Da.Fill(ds);

                bs1.DataSource = ds.Tables[0];

                ReportDataSource1.Name = "DataSet1";
                ReportDataSource1.Value = bs1;
                this.reportViewer1.LocalReport.DataSources.Add(ReportDataSource1);


                this.reportViewer1.RefreshReport();

            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
         
           
        }
    }
}
