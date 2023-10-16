using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DamithEMS
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmemployee fe = new frmemployee();
            fe.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmemployee fe = new frmemployee();
            fe.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmview fv = new frmview();
            fv.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmview fv = new frmview();
            fv.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmlogin fe = new frmlogin();
            fe.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmdesignation fe = new frmdesignation();
            fe.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmeducation fe = new frmeducation();
            fe.Show();
        }
    }
}
