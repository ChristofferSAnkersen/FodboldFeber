using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FodboldFeber.Model;

namespace FodboldFeber.Model
{
    public class DataAccess
    {
        Login login = new Login();
        
        public DataAccess()
        {
            CheckAuthentification = new Model.Authenticated { IsAuthenticated = false };
        }
        public Model.Authenticated CheckAuthentification { get; set; }

        public static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";


        public string Access()
        {
            return connectionString;
        }
        public void InitializeLogin()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    String query = "SELECT COUNT(1) FROM  Users WHERE Username=@username AND password=@password";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@username", login.Username);
                    sqlCmd.Parameters.AddWithValue("@password", login.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        CheckAuthentification.IsAuthenticated = true;
                    }
                    else if (count == 0)
                    {
                        CheckAuthentification.IsAuthenticated = false;
                    }
                }
                catch (SqlException ee)
                {
                    Console.WriteLine(ee + "Kunne ikke logge ind");
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
