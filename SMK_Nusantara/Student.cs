using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CobaLKS2017
{
    internal class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string NoHp { get; set; }

        static string Connection = ConfigurationManager.ConnectionStrings["myconnstr"].ConnectionString;

        public DataTable Select()
        {
            SqlConnection Con = new SqlConnection(Connection);
            DataTable DT = new DataTable();
            
            try
            {
                string SQL = "SELECT * FROM Student";
                SqlCommand Cmd = new SqlCommand(SQL, Con);

                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);

                Con.Open();
                Adapter.Fill(DT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                Con.Close();
            }
            return DT;
        }

        public bool Insert(Student S)
        {
            bool IsSuccess = false;
            SqlConnection Con = new SqlConnection(Connection);

            try
            {
                string SQL = "INSERT INTO Student (Name, Address, Gender, DateofBirth, NoHP) VALUES (@Name, @Address, @Gender, @DateofBirth, @NoHP)";
                SqlCommand Cmd = new SqlCommand(SQL, Con);

                Cmd.Parameters.AddWithValue("@Name", S.Name);
                Cmd.Parameters.AddWithValue("@Address", S.Address);
                Cmd.Parameters.AddWithValue("@Gender", S.Gender);
                Cmd.Parameters.AddWithValue("@DateofBirth", S.DateofBirth);
                Cmd.Parameters.AddWithValue("@NoHP", S.NoHp);

                Con.Open();

                int rows = Cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                Con.Close();
            }

            return IsSuccess;
        }

        public bool Update(Student S)
        {
            bool IsSuccess = false;
            SqlConnection Con = new SqlConnection(Connection);

            try
            {
                string SQL = "UPDATE Student SET Name=@Name, Address=@Address, Gender=@Gender, DateofBirth=@DateofBirth, NoHP=@NoHP WHERE StudentID=@StudentID";
                SqlCommand Cmd = new SqlCommand(SQL, Con);

                Cmd.Parameters.AddWithValue("@StudentID", S.StudentID);
                Cmd.Parameters.AddWithValue("@Name", S.Name);
                Cmd.Parameters.AddWithValue("@Address", S.Address);
                Cmd.Parameters.AddWithValue("@Gender", S.Gender);
                Cmd.Parameters.AddWithValue("@DateofBirth", S.DateofBirth);
                Cmd.Parameters.AddWithValue("@NoHP", S.NoHp);

                Con.Open();

                int rows = Cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                Con.Close();
            }

            return IsSuccess;
        }

        public bool Delete(Student S)
        {
            bool IsSuccess = false;
            SqlConnection Con = new SqlConnection(Connection);

            try
            {
                string SQL = "DELETE FROM Student WHERE StudentID=@StudentID";
                SqlCommand Cmd = new SqlCommand(SQL, Con);

                Cmd.Parameters.AddWithValue("@StudentID", S.StudentID);

                Con.Open();

                int rows = Cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                Con.Close();
            }

            return IsSuccess;
        }
    }
}
