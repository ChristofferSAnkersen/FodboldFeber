using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using FodboldFeber.ViewModel;

namespace FodboldFeber.Model
{
    class Login : INotifyPropertyChanged
    {
        //Authenticated auth = new Authenticated();
        //private string _email = "Fakeemail";
        //private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
        private static string _username = "";
        private static string _password = "";

        //public string Email { get; set; }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (_username.Equals(value) == false)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get
            {
                    return _password;
            }
            set
            {
                if (_password.Equals(value) == false)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }


        //public void InitializeLogin()
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            if (con.State == ConnectionState.Closed)
        //            con.Open();
        //            String query = "SELECT COUNT(1) FROM tblUser WHERE Username=@username AND password=@password";
        //            SqlCommand sqlCmd = new SqlCommand(query, con);
        //            sqlCmd.CommandType = CommandType.Text;
        //            sqlCmd.Parameters.AddWithValue("@username", Username);
        //            sqlCmd.Parameters.AddWithValue("@password", Password);
        //            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
        //            if (count == 1)
        //            {
        //                auth.IsAuthenticated = true;
                        
        //            }
        //        }
        //        catch (SqlException ee)
        //        {
        //            Console.WriteLine(ee + "Det lort virkede sku ikke");
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}