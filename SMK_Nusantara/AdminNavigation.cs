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
    public partial class AdminNavigation : Form
    {
        public AdminNavigation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmStudent Student = new FrmStudent();
            Student.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmTeacher Teacher = new FrmTeacher();
            Teacher.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmManageClass ManageClass = new FrmManageClass();
            ManageClass.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAddSchedule Schedule = new FrmAddSchedule();
            Schedule.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmLogin Login = new FrmLogin();
            Login.Show();
            this.Hide();
        }

        private void AdminNavigation_Load(object sender, EventArgs e)
        {
            LblAdmin.Text += FrmLogin.LoggedUsername;
        }
    }
}
