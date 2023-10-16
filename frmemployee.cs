using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Data.Common;
using System.Configuration;

namespace DamithEMS
{
    public partial class frmemployee : Form
    {
        public frmemployee()
        {
            InitializeComponent();
        }
        private Dictionary<string, string> IsActiveData = new Dictionary<string, string>();
        private Dictionary<string, string> GenderData = new Dictionary<string, string>();




        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome fh = new frmHome();
            fh.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_empname.Text == "")
                {
                    MessageBox.Show("Please , Enter Employee Name", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    if (txt_empaddress.Text == "")
                {
                    MessageBox.Show("Please , Enter Employee Address", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                        if (cmb_gender.Text == "")
                {
                    MessageBox.Show("Please , Select Employee Gender", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                            if (cmb_position.Text == "")
                {
                    MessageBox.Show("Please , Select Employee Position", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                                if (txt_phoneno.Text == "")
                {
                    MessageBox.Show("Please , Enter Employee Phone No.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                                    if (cmb_education.Text == "")
                {
                    MessageBox.Show("Please , Select Employee Education", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "InsertEmployee";

                            cmd.Parameters.AddWithValue("@empEPF", txt_epf.Text);
                            cmd.Parameters.AddWithValue("@employeename", txt_empname.Text);
                            cmd.Parameters.AddWithValue("@employeeaddress", txt_empaddress.Text);
                            cmd.Parameters.AddWithValue("@employeegender", cmb_gender.Text); 
                            cmd.Parameters.AddWithValue("@designationID", cmb_position.SelectedValue);
                            cmd.Parameters.AddWithValue("@dateofbirth", Convert.ToDateTime(dtp_dob.Text).ToString());   
                            cmd.Parameters.AddWithValue("@phoneno", txt_phoneno.Text);
                            cmd.Parameters.AddWithValue("@educationID", cmb_education.SelectedValue);
                            cmd.Parameters.AddWithValue("@isactive", (cmbIsActive.SelectedValue != null && cmbIsActive.SelectedValue.ToString() == "1") ? true : false);
                            cmd.Parameters.AddWithValue("@JoinedDate", Convert.ToDateTime(join_date.Text).ToString());

                            cmd.ExecuteNonQuery();


                      

                            MessageBox.Show("Employee Added Successful", "Thank You.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDetail();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }



        private void frmemployee_Load(object sender, EventArgs e)
        {


            LoadDetail();
        }

        private void LoadDetail()
        {
          
            LoadEducationdata();
            LoadDesignationdata();

            IsActiveData.Clear();   
            IsActiveData.Add("1", "Yes");
            IsActiveData.Add("0", "No");
            cmbIsActive.DataSource = new BindingSource(IsActiveData, null);
            cmbIsActive.DisplayMember = "Value";
            cmbIsActive.ValueMember = "Key";


            GenderData.Clear();
            GenderData.Add("M", "Male");
            GenderData.Add("F", "Female");
            cmb_gender.DataSource = new BindingSource(GenderData, null);
            cmb_gender.DisplayMember = "Value";
            cmb_gender.ValueMember = "Key";


            showdata();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_empname.Text == "")
                {
                    MessageBox.Show("Please , Enter Employee Name", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    if (txt_empaddress.Text == "")
                {
                    MessageBox.Show("Please , Enter Employee Address", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                        if (cmb_gender.Text == "")
                {
                    MessageBox.Show("Please , Select Employee Gender", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                            if (cmb_position.Text == "")
                {
                    MessageBox.Show("Please , Select Employee Position", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                                if (txt_phoneno.Text == "")
                {
                    MessageBox.Show("Please , Enter Employee Phone No.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                                    if (cmb_education.Text == "")
                {
                    MessageBox.Show("Please , Select Employee Education", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "UpdateEmployee";

                            cmd.Parameters.AddWithValue("@empEPF", txt_epf.Text);
                            cmd.Parameters.AddWithValue("@employeename", txt_empname.Text);
                            cmd.Parameters.AddWithValue("@employeeaddress", txt_empaddress.Text);
                            cmd.Parameters.AddWithValue("@employeegender", cmb_gender.Text);
                            cmd.Parameters.AddWithValue("@designationID", cmb_position.SelectedValue);
                            cmd.Parameters.AddWithValue("@dateofbirth", Convert.ToDateTime(dtp_dob.Text).ToString());
                            cmd.Parameters.AddWithValue("@phoneno", txt_phoneno.Text);
                            cmd.Parameters.AddWithValue("@educationID", cmb_education.SelectedValue);
                            cmd.Parameters.AddWithValue("@isactive", (cmbIsActive.SelectedValue != null && cmbIsActive.SelectedValue.ToString() == "1") ? true : false);
                            cmd.Parameters.AddWithValue("@JoinedDate", Convert.ToDateTime(join_date.Text).ToString());

                            cmd.ExecuteNonQuery();
                            showdata();
                            MessageBox.Show("Employee Added Successful", "Thank You.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDetail();
                            
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void showdata()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM vw_SelectAllEmployees";


                     //String str = "select E.[empEPF], E.[employeename], E.[employeeaddress], D.DesignationDescription, E.[phoneno], Ed.EducationDescription, E.[isactive] from tblEmployee E INNER JOIN tblDesignation D ON E.designationID = D.ID inner join tblEducation Ed ON Ed.ID = E.educationID";

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);

                    tblEmployeeDataGridView.DataSource = dt;
                }
            }


        }

        private void LoadDesignationdata()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd2 = new SqlCommand())
                {
                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "LoadDesignationdata";

                       con.Open();

                       DataTable dt = new DataTable();

                       SqlDataAdapter da = new SqlDataAdapter(cmd2);

                       da.Fill(dt);
                      con.Close();
                   
                    if (dt.Rows.Count > 0)
                    {

                        DataTable defaultTable = new DataTable();
                        defaultTable.Columns.Add("ID", typeof(int));
                        defaultTable.Columns.Add("DesignationDescription", typeof(string));
                        defaultTable.Rows.Add(99, "-- Select --");

                        dt.Merge(defaultTable);

                        cmb_position.DataSource = dt;
                        cmb_position.DisplayMember = "DesignationDescription";
                        cmb_position.ValueMember = "ID";
                        cmb_position.SelectedValue = 99;

                    }
                }
                
            }

        }

        private void LoadEducationdata()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd3 = new SqlCommand())
                {
                    cmd3.Connection = con;
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandText = "LoadEducationdata";

                    con.Open();

                    DataTable dt = new DataTable();

                    SqlDataAdapter da = new SqlDataAdapter(cmd3);

                    da.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {

                        DataTable defaultTable = new DataTable();
                        defaultTable.Columns.Add("ID", typeof(int));
                        defaultTable.Columns.Add("EducationDescription", typeof(string));
                        defaultTable.Rows.Add(99, "-- Select --");

                        dt.Merge(defaultTable);

                        cmb_education.DataSource = dt;
                        cmb_education.DisplayMember = "EducationDescription";
                        cmb_education.ValueMember = "ID";
                        cmb_education.SelectedValue = 99;


                    }
                }

            }
        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {

            txt_empname.Text = "";
            txt_phoneno.Text = "";
            txt_empaddress.Text = "";
            txt_epf.Text = "";

            cmb_gender.SelectedIndex = -1;
            cmb_position.SelectedIndex = -1;
            cmb_education.SelectedIndex = -1;

            dtp_dob.Text = "";
        }

        private void tblEmployeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            

        }

        private void tblEmployeeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tblEmployeeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;

            index = e.RowIndex;

            DataGridViewRow dgvr = tblEmployeeDataGridView.Rows[index];


            txt_empname.Text = dgvr.Cells[1].Value.ToString();
            txt_empaddress.Text = dgvr.Cells[2].Value.ToString();
            cmb_gender.Text = dgvr.Cells[3].Value.ToString();
            cmb_position.Text = dgvr.Cells[4].Value.ToString();
            dtp_dob.Text = dgvr.Cells[5].Value.ToString();
            txt_phoneno.Text = dgvr.Cells[6].Value.ToString();
            cmb_education.Text = dgvr.Cells[7].Value.ToString();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pb_Search_Click(object sender, EventArgs e)
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
                            txt_empname.Text = dt.Rows[0]["employeename"].ToString();
                            txt_empaddress.Text = dt.Rows[0]["employeeaddress"].ToString();
                            cmb_gender.SelectedValue = (dt.Rows[0]["employeegender"] == "Male") ? "F" : "M";
                            cmb_position.SelectedValue = Convert.ToInt32(dt.Rows[0]["designationID"].ToString());
                            dtp_dob.Text = dt.Rows[0]["dateofbirth"].ToString();
                            txt_phoneno.Text = dt.Rows[0]["phoneno"].ToString();
                            cmbIsActive.SelectedValue = (dt.Rows[0]["isactive"].ToString() == "True") ? "1" : "0";
                            cmb_education.SelectedValue = Convert.ToInt32(dt.Rows[0]["educationID"].ToString());
                        }


                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter EPF no to search.", "Epf No", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmb_gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}