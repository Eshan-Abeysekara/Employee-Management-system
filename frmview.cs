using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace DamithEMS
{
    public partial class frmview : Form
    {
        public frmview()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome fh = new frmHome();
            fh.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txt_empid_TextChanged(object sender, EventArgs e)
        {
            if (txt_epf.Text == "")
            {
                 cleardata();
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_epf.Text))
                {

                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "SearchEmployees";
                            cmd.Parameters.AddWithValue("@empEPF", Convert.ToInt32(txt_epf.Text));

                            //String str = "select E.[empEPF], E.[employeename], E.[employeeaddress], D.DesignationDescription, E.[phoneno], Ed.EducationDescription, E.[isactive] from tblEmployee E INNER JOIN tblDesignation D ON E.designationID = D.ID inner join tblEducation Ed ON Ed.ID = E.educationID";

                            DataTable dt = new DataTable();

                            SqlDataAdapter da = new SqlDataAdapter(cmd);

                            da.Fill(dt);
                            //con.Close();

                            if (dt.Rows.Count > 0)
                            {

                                // tblEmployeeDataGridView.DataSource = dt;
                                    lbl_empname.Text = dt.Rows[0]["employeename"].ToString();
                                    lbl_empaddress.Text = dt.Rows[0]["employeeaddress"].ToString();
                                    lbl_empgender.Text = dt.Rows[0]["employeegender"].ToString();
                                    lbl_empposition.Text = dt.Rows[0]["DesignationDescription"].ToString();
                                    DateTime dtdateofbirth = Convert.ToDateTime(dt.Rows[0]["dateofbirth"]);
                                    lbl_dob.Text = dtdateofbirth.ToString("yyyy-MM-dd");
                                    lbl_phoneno.Text = dt.Rows[0]["phoneno"].ToString();
                                    DateTime dtJoinedDate = Convert.ToDateTime(dt.Rows[0]["JoinedDate"]);
                                    lbl_jd.Text = dtJoinedDate.ToString("yyyy-MM-dd");
                                    lbl_education.Text = dt.Rows[0]["EducationDescription"].ToString();

                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter EPF no to search.", "Epf No", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
   
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cleardata()
        {
            lbl_jd.Text = "";
            lbl_empname.Text = "";
            lbl_empaddress.Text = "";
            lbl_empgender.Text = "";
            lbl_empposition.Text = "";
            lbl_dob.Text = "";
            lbl_phoneno.Text = "";
            lbl_education.Text = "";
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (txt_epf.Text == "")
            {
                MessageBox.Show("Please , Enter Employee ID", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.Show();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("\n\n\t ------------------------- Employee Details -------------------------------", new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 60));
            e.Graphics.DrawString("\n\n\t EPF ID -\t\t" + lbl_jd.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 100));
            e.Graphics.DrawString("\n\n\t Employee Name -\t\t" + lbl_empname.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 140));
            e.Graphics.DrawString("\n\n\t Employee Address -\t" + lbl_empaddress.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 180));
            e.Graphics.DrawString("\n\n\t Gender -\t" + lbl_empgender.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 220));
            e.Graphics.DrawString("\n\n\t Position -\t" + lbl_empposition.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 260));
            e.Graphics.DrawString("\n\n\t Date of Birth -\t" + lbl_dob.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 300));
            e.Graphics.DrawString("\n\n\t Phone No. -\t" + lbl_phoneno.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 340));
            e.Graphics.DrawString("\n\n\t Education -\t" + lbl_education.Text, new Font("Palatino Linotype", 16, FontStyle.Bold), Brushes.Black, new Point(40, 380));
            e.Graphics.DrawString("\n\n\t --------------------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(40, 420));
          
          
        }
    }
}
