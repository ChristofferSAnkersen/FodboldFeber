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

        private static string _connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";

        public DataAccess()
        {
            CheckAuthentification = new Model.Authenticated { IsAuthenticated = false };
        }
        public Model.Authenticated CheckAuthentification { get; set; }



        public string Access()
        {
            return _connectionString;
        }
        public void InitializeLogin()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    // Checks if the the tabel "users" has any rows where the txtboxes' text match eachother 
                    String query = "SELECT COUNT(1) FROM  Users WHERE Username=@username AND password=@password";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@username", login.Username);
                    sqlCmd.Parameters.AddWithValue("@password", login.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    // makes sure there is only one match in the database, for secruity reasons. 
                    if (count == 1)
                    {
                        CheckAuthentification.IsAuthenticated = true;
                    }
                    // Does not allow you to log in if a match is not found
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
