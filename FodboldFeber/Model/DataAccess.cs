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
        Authenticated auth = new Authenticated();
        //Products products = new Products();
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
        public void Access()
        {
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        SqlCommand cmd1 = new SqlCommand(products.Query, con);
            //        SqlDataReader myReader;
            //        con.Open();
            //        myReader = cmd1.ExecuteReader();
            //        while (myReader.Read())
            //        {
            //        }
            //        con.Close();

            //    }
            //    catch (SqlException e)
            //    {
            //        Console.WriteLine(e + "Det virker ikke :(");
            //    }
            //}
        }
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
                    sqlCmd.Parameters.AddWithValue("@username", login.Username);
                    sqlCmd.Parameters.AddWithValue("@password", login.Password);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        auth.IsAuthenticated = true;
                    }
                }
                catch (SqlException ee)
                {
                    Console.WriteLine(ee + "Det lort virkede sku ikke");
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }


}
