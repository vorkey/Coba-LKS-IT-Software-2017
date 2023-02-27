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
    public partial class FrmStudent : Form
    {
        Student St = new Student();

        public FrmStudent()
        {
            InitializeComponent();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            DataTable DT = St.Select();
            DgvStudent.DataSource = DT;

            for (int i = 0; i <= DgvStudent.Columns.Count - 1; i++)
            {
                DgvStudent.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            for (int i = 0; i <= DgvStudent.Columns.Count - 1; i++)
            {
                int ColumnsWidth = DgvStudent.Columns[i].Width;

                DgvStudent.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                DgvStudent.Columns[i].Width = ColumnsWidth;
            }
        }

        private void FrmStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmLogin Login = new FrmLogin();
            Login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            St.Name = TxtStudentName.Text;
            St.Address = TxtAddress.Text;
            St.DateofBirth = DtpBirth.Text;
            St.NoHp = TxtPhone.Text;

            bool IsSuccess = St.Insert(St);

            if (IsSuccess)
            {
                MessageBox.Show("Insert Success");
                Clear();
            }
            else
            {
                MessageBox.Show("Insert Failed");
            }

            DataTable DT = St.Select();
            DgvStudent.DataSource = DT;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            St.Name = TxtStudentName.Text;
            St.Address = TxtAddress.Text;
            St.DateofBirth = DtpBirth.Text;
            St.NoHp = TxtPhone.Text;
            //////////////////////////////

            bool IsSuccess = St.Update(St);

            if (IsSuccess)
            {
                MessageBox.Show("Update Success");
                Clear();
            }
            else
            {
                MessageBox.Show("Update Failed");
            }

            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;

            DataTable DT = St.Select();
            DgvStudent.DataSource = DT;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            St.StudentID = Convert.ToInt32(TxtStudentID.Text);

            bool IsSuccess = St.Delete(St);

            if (IsSuccess)
            {
                MessageBox.Show("Delete Success");
                Clear();
            }
            else
            {
                MessageBox.Show("Delete Failed");
            }

            DataTable DT = St.Select();
            DgvStudent.DataSource = DT;
            
        }

        private void Clear()
        {
            TxtStudentName.Text = "";
            TxtAddress.Text = "";
            TxtPhone.Text = "";
            TxtStudentID.Text = "";
            RbtnFemale.Checked = false;
            RbtnMale.Checked = false;
            DtpBirth.ResetText();
        }

        private void RbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnMale.Checked)
            {
                St.Gender = "Male";
                RbtnFemale.Checked = false;
            }
        }

        private void RbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (RbtnFemale.Checked)
            {
                St.Gender = "Female";
                RbtnMale.Checked = false;
            }
        }

        private void DgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtStudentID.Text = DgvStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtStudentName.Text = DgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtAddress.Text = DgvStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
            DtpBirth.Text = DgvStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtPhone.Text = DgvStudent.Rows[e.RowIndex].Cells[5].Value.ToString();

            if (DgvStudent.Rows[e.RowIndex].Cells[3].Value.ToString() == "Male")
            {
                RbtnMale.Checked = true;
            }
            else if(DgvStudent.Rows[e.RowIndex].Cells[3].Value.ToString() == "Female")
            {
                RbtnFemale.Checked = true;
            }
        }

        ///check index
        /*        private void DgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
                {
                    string Row = Convert.ToString(e.RowIndex);
                    string Column = Convert.ToString(e.ColumnIndex);

                    MessageBox.Show($"{Row} , {Column}");
                }*/
    }
}
