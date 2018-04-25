using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FodboldFeber.Model
{
    public class DataAccess
    {
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
        public void Access()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand();
                }
                catch(SqlException e)
                {
                    Console.WriteLine(e + "Det virker ikke :(");
                }
            }
        }
    }


}
