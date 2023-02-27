using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Configuration;

namespace CobaLKS2017
{
    internal class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        static string Connection = ConfigurationManager.ConnectionStrings["myconnstr"].ConnectionString;

        public bool LoginCheck()
        {
            bool IsSuccess = false;
            SqlConnection Con = new SqlConnection(Connection);

            try
            {
                string SQL = "SELECT * FROM Users Where Username=@Username AND Password=@Password";
                SqlCommand Cmd = new SqlCommand(SQL, Con);

                Cmd.Parameters.AddWithValue("@Username", Username);
                Cmd.Parameters.AddWithValue("@Password", Password);

                SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
                DataTable DT = new DataTable();
                Adapter.Fill(DT);

                if (DT.Rows.Count > 0)
                {
                    IsSuccess = true;
                    UserType = DT.Rows[0]["Role"].ToString();
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
