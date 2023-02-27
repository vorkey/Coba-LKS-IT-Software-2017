using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CobaLKS2017
{
    public partial class StudentNavigation : Form
    {
        public StudentNavigation()
        {
            InitializeComponent();
        }

        private void StudentNavigation_Load(object sender, EventArgs e)
        {
            LblStudent.Text += FrmLogin.LoggedUsername;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEditProfile Profile = new FrmEditProfile();
            Profile.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmViewSchedule ViewSchedule = new FrmViewSchedule();
            ViewSchedule.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmLogin Login = new FrmLogin();
            Login.Show();
            this.Close();
        }

        private void StudentNavigation_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmLogin Login = new FrmLogin();
            Login.Show();
            this.Close();
        }
    }
}
