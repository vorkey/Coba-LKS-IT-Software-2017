using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CobaLKS2017
{
    public partial class FrmLogin : Form
    {
        Login L = new Login();

        public static string LoggedUsername;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Do You Want to Exit Application?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                Application.Restart();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        { 
            L.Username = TxtUsername.Text.Trim();
            L.Password = TxtPassword.Text.Trim();

            try
            {
                if (TxtUsername.Text == "" || TxtPassword.Text == "")
                {
                    MessageBox.Show("Value can't be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
                else
                {
                    bool IsSuccess = L.LoginCheck();

                    if (IsSuccess)
                    {
                        MessageBox.Show("Login Successful");
                        LoggedUsername = L.Username;
                        //MessageBox.Show(L.UserType);

                        switch (L.UserType)
                        {
                            case "Admin":
                                {
                                    AdminNavigation Admin = new AdminNavigation();
                                    Admin.Show();
                                    this.Hide();
                                }
                                break;
                            case "Teacher":
                                {
                                    TeacherNavigation Teacher = new TeacherNavigation();
                                    Teacher.Show();
                                    this.Hide();
                                }
                                break;
                            case "Student":
                                {
                                    StudentNavigation Student = new StudentNavigation();
                                    Student.Show();
                                    this.Hide();
                                }
                                break;
                            default:
                                {
                                    MessageBox.Show("Invalid User Type", "Error", MessageBoxButtons.OK);
                                }
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK);
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Clear()
        {
            TxtPassword.Text = "";
            TxtUsername.Text = "";
        }

    }
}
