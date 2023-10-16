using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamithEMS
{
    public partial class frmdesignation : Form
    {
        public frmdesignation()
        {
            InitializeComponent();
        }

        private void txtd_destination_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnd_save_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtd_destination.Text == "")
                {
                    MessageBox.Show("Please , Enter Designation Title", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                            cmd.CommandText = "InsertDesignation";

                            cmd.Parameters.AddWithValue("@DesignationDescription", txtd_destination.Text);

                            cmd.ExecuteNonQuery();




                            MessageBox.Show("Designation Added Successful", "Thank You.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnd_clear_Click(object sender, EventArgs e)
        {
            txtd_destination.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome fh = new frmHome();
            fh.Show();
        }
    }
}
