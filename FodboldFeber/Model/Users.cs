using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;

namespace FodboldFeber.Model
{
    class Users
    {
        // public int UserID { get; set; }
        private string _username = "ChangeMe";
        private string _name = "ChangeMe";
        private string _address = "ChangeMe";
        private string _password = "ChangeMe";
        private int _phonenumber;
        private string _email = "ChangeMe";
        private string _clubAddress = "ChangeMe";
        private string _clubName = "ChangeMe";
        private string _clubPosition = "ChangeMe";
        private string _companyName = "ChangeMe";
        private string _companyAddress = "ChangeMe";
        private int _cvr;
        private string _companyPosition = "ChangeMe";
        private string _checkUserExist;


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
        public string ClubAddress
        {
            get
            {
                return this._clubAddress;
            }
            set
            {
                if (value != this._clubAddress)
                {
                    _clubAddress = value;
                    OnPropertyChanged("ClubAddress");
                }

            }
        }
        public string CompanyAddress
        {
            get
            {
                return this._companyAddress;
            }
            set
            {
                if (value != this._companyAddress)
                {
                    _companyAddress = value;
                    OnPropertyChanged("CompanyAddress");
                }

            }
        }
        public string ClubPosition
        {
            get
            {
                return this._clubPosition;
            }
            set
            {
                if (value != this._clubPosition)
                {
                    _clubPosition = value;
                    OnPropertyChanged("ClubPosition");
                }

            }
        }
        public int CVR
        {
            get
            {
                return this._cvr;
            }
            set
            {
                if (value != this._cvr)
                {
                    _cvr = value;
                    OnPropertyChanged("CVR");
                }

            }
        }
       
        
        public string ClubName
        {
            get
            {
                return this._clubName;
            }
            set
            {
                if (value != this._clubName)
                {
                    _clubName = value;
                    OnPropertyChanged("ClubName");
                }

            }
        }
        public string CompanyName
        {
            get
            {
                return this._companyName;
            }
            set
            {
                if (value != this._companyName)
                {
                    _companyName = value;
                    OnPropertyChanged("CompanyName");
                }

            }
        }
        public string CompanyPosition
        {
            get
            {
                return this._companyPosition;
            }
            set
            {
                if (value != this._companyPosition)
                {
                    _companyPosition = value;
                    OnPropertyChanged("CompanyPosition");
                }

            }
        }
        public string CheckIfExist
        {
            get
            {
                return this._checkUserExist;
            }
            set
            {
                if (value != this._checkUserExist)
                {
                      _checkUserExist = value;
                    OnPropertyChanged("CheckIfExist");
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the query variable with the information of the properties
                    query = "insert into Club_User(name,username, password, clubname, phonenumber, email, clubaddress, clubposition) values('" + this.UserName + "','" + this.Password + "','" + this.ClubName + "','" + this.PhoneNumber + "','" + this.Email + "','" + this.ClubAddress + "','" + this.ClubPosition
                        + "');";
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
        public void AddCompanyUser()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the query variable with the information of the properties
                    query = "insert into Company_User(name, username, password, companyname, phonenumber, email, companyaddress, companyposition, cvr) values('" + this.Name + "','" + this.UserName + "','" + this.Password + "','" + this.CompanyName + "','" + this.PhoneNumber + "','" + this.Email + "','" + this.CompanyAddress + "','" + this.CompanyPosition + "','" + this.CVR + "');";
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
        public void CheckIfUserExists()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    String CheckIfExist = "select from Private_User where Email=txtEmail.Text && UserName=txtEmail.Text";
                }
                finally
                {
                    con.Close();
                }
            }
            
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
