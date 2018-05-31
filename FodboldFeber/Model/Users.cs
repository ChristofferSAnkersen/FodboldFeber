using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using FodboldFeber.View;
using FodboldFeber.ViewModel;

namespace FodboldFeber.Model
{
    class Customers
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
        private string _query = "";

        private static string _connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
        //Logic for adding a user of the "PrivateUser" type to the database
        public void AddPrivateUser()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the _query variable with the information of the properties
                    _query = "insert into Users(username, password, name, phonenumber, email, address) values('" + this.UserName + "','" + this.Password + "','" + this.Name + "','" + this.PhoneNumber + "','" + this.Email + "','" + this.Address + "');";
                    //Inserts the data of _query into the "Products" table in the database
                    SqlCommand cmd1 = new SqlCommand(_query, con);
                    SqlDataReader myReader = cmd1.ExecuteReader();

                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Kunne ikke tilføje bruger!");
                }
            }
        }
        //Logic for adding a user of the "Club" type to the database
        public void AddClubUser()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the _query variable with the information of the properties
                    _query = "insert into Users(name,username, password, clubname, phonenumber, email, address, clubposition) values('" + this.Name + "','" + this.UserName + "','" + this.Password + "','" + this.ClubName + "','" + this.PhoneNumber + "','" + this.Email + "','" + this.Address + "','" + this.ClubPosition + "');";
                    //Inserts the data of _query into the "Products" table in the database
                    SqlCommand cmd1 = new SqlCommand(_query, con);
                    SqlDataReader myReader = cmd1.ExecuteReader();

                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Kunne ikke tilføje bruger!");
                }
            }
        }
        //Logic for adding a user of the "Company" type to the datebase
        public void AddCompanyUser()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    //Fills the _query variable with the information of the properties
                    _query = "insert into Users(name, username, password, companyname, phonenumber, email, address, companyposition, cvr) values('" + this.Name + "','" + this.UserName + "','" + this.Password + "','" + this.CompanyName + "','" + this.PhoneNumber + "','" + this.Email + "','" + this.Address + "','" + this.CompanyPosition + "','" + this.CVR + "');";
                    //Inserts the data of _query into the "Products" table in the database
                    SqlCommand cmd1 = new SqlCommand(_query, con);
                    SqlDataReader myReader = cmd1.ExecuteReader();

                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Kunne ikke tilføje bruger");
                }
            }
        }
        //Have not made the functionality to delete a user from the database
        public void DeleteUser()
        {

        }
        //Logic for updating information about a user
        public void UpdateUser()
        {
            CustomerProfile c = new CustomerProfile();
            try
            {
                _query = "Update Private_User set name='" + this.Name + "', phonenumber='" + this.PhoneNumber + "', email='" + this.Email + "', address='" + this.Address + "' where username ='" + c.lblName.Content + "' ";
                SqlConnection con = new SqlConnection(_connectionString);
                SqlCommand cmd1 = new SqlCommand(_query, con);
                SqlDataReader myReader;
                con.Open();
                myReader = cmd1.ExecuteReader();

                con.Close();

            }
            catch (SqlException exe)
            {
                Console.WriteLine(exe + "Brugeren kunne ikke blive opdateret.");
            }
        }

        public void GetUserInfo()
        {
            CustomerProfile c = new CustomerProfile();
            CustomerVM cvm = new CustomerVM();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT name, phonenumber, email, address where username ='" + c.lblName.Content + "' ");
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        string Name1 = (string)myReader["name"];
                        int Phone1 = (int)myReader["phonenumber"];
                        string Email1 = (string)myReader["email"];
                        string Address1 = (string)myReader["address"];

                        cvm.Name = Name1;
                        cvm.PhoneNumber = Phone1;
                        cvm.Email = Email1;
                        cvm.Address = Address1;
                    }

                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e + "Kunne ikke udfylde listen");
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }  
}
