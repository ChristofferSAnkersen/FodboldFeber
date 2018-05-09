/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;

namespace FodboldFeber.Model
{
    class Login
    {
 
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
       
       
        public void InitializeLogin()
        {
            using (SqlConnection con = new SqlConnection(connectionString)) 
            {  
                try
                {
                    if (con.State == ConnectionState.Closed)
                    con.Open();
                    String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@username AND password=@password";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@username", Username);
                    sqlCmd.Parameters.AddWithValue("@password", Password);
                
                }
                catch (SqlException e)
                {
                   MessageBox.Show(e + "Brugernavn eller kodeord var forkert:(");
                }
                finally
                {
                   con.Close();
                }
            }

        }
    }
}
*/