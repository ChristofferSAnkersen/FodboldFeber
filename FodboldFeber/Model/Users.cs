using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;


namespace FodboldFeber.Model
{
    class Users
    {
        public int UserID { get; set; }
        private string _username = "ChangeMe";
        private string _name = "ChangeMe";
        private string _address = "ChangeMe";
        private string _password = "ChangeMe";
        private int _phonenumber;
        private string _email = "ChangeMe";
        public string ClubAddress { get; set; }
        public string ClubName { get; set; }
        public string ClubPosition { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public int CVR { get; set; }
        public int UserType { get; set; }


        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != this._name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }

            }
        }
        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                if (value != this._username)
                {
                    _username = value;
                    OnPropertyChanged("UserName");
                }

            }
        }
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                if (value != this._password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }

            }
        }
        public int PhoneNumber
        {
            get
            {
                return this._phonenumber;
            }
            set
            {
                if (value != this._phonenumber)
                {
                    _phonenumber = value;
                    OnPropertyChanged("PhoneNumber");
                }

            }
        }
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (value != this._email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }

            }
        }
        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                if (value != this._address)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }

            }
        }
        string query = "";
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
        public void AddPrivateUser()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the query variable with the information of the properties
                    query = "insert into Private_User(username, password, name, phonenumber, email, address) values('" + this.UserName + "','" + this.Password + "','" + this.Name + "','" + this.PhoneNumber + "','" + this.Email + "','" + this.Address + "');";
                    //Inserts the data of query into the "Products" table in the database
                    SqlCommand cmd1 = new SqlCommand(query, con);

                    SqlDataReader myReader = cmd1.ExecuteReader();

                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Could not add User");
                }
            }
        }
        public void AddClubUser()
        {

        }
        public void AddCompanyUser()
        {

        }
        public void DeleteUser()
        {

        }
        public void UpdateUser()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }  
}
