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
    public partial class TeacherNavigation : Form
    {
        public TeacherNavigation()
        {
            InitializeComponent();
        }

        private void TeacherNavigation_Load(object sender, EventArgs e)
        {
            LblTeacher.Text += FrmLogin.LoggedUsername;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEditProfile Profile = new FrmEditProfile();
            Profile.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmViewScheduleTeacher ViewScheduleTeacher = new FrmViewScheduleTeacher();
            ViewScheduleTeacher.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmLogin Login = new FrmLogin();
            Login.Show();
            this.Close();
        }

        private void TeacherNavigation_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmLogin Login = new FrmLogin();
            Login.Show();
            this.Close();
        }
    }
}
