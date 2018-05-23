using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail; 
using System.Web;
using FodboldFeber.ViewModel;
using System.Data;
using System.Data.SqlClient;

namespace FodboldFeber.View
{
    public partial class PasswordRecovery : Page
    {
    
        SmtpClient client;
        MailMessage msg;
        CustomerVM cVM = new CustomerVM();
        private static string connectionString = "Server=EALSQL1.eal.local; Database=DB2017_A27; User Id= USER_A27; Password=SesamLukOp_27;";
       


        public PasswordRecovery()
        {
            InitializeComponent();
        }
        private void BtnSendEmailClick(object sender, RoutedEventArgs e)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    String query = "select count(1) from Users where email=@email AND username=@username";
                    SqlCommand sqlCmd = new SqlCommand(query, con);
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    sqlCmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        //Generates random password since we cant send a reset link because we are doing a wpf app.
                        char[] newPassword = "qwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();
                        Random r = new Random();
                        String randomString = "";
                        for (int i = 0; i < 15; i++)
                        {
                            randomString += newPassword[r.Next(0, 35)].ToString();
                        }                      
                        if (con.State == ConnectionState.Closed)
                        con.Open();
                        String query2 = "Update Users set password ='" + randomString + "' where email = '" + txtEmail.Text + "' AND username= '" + txtUserName.Text + "' ";
                        SqlCommand sqlCmd2 = new SqlCommand(query2, con);
                        sqlCmd2.CommandType = CommandType.Text;
                        SqlDataReader myReader;                        
                        myReader = sqlCmd2.ExecuteReader();
                        while (myReader.Read())
                        {

                        }
                        con.Close();
                        //Email message information
                        msg = new MailMessage();
                        msg.From = new MailAddress("fodboldfeberprojekt@gmail.com");
                        msg.To.Add(new MailAddress(txtEmail.Text));
                        msg.Subject = "Kodeords Nulstilling";
                        msg.Body = "Dit kodeord er midlertigdigt lavet om til " + randomString;
                        //Smtp information
                        client = new SmtpClient("smtp.gmail.com");
                        client.Port = 587;
                        client.Credentials = new System.Net.NetworkCredential("fodboldfeberprojekt@gmail.com", "Fodboldfeber123");
                        client.EnableSsl = true;
                        client.Send(msg);
                        //MessageBox Confirmation
                        MessageBox.Show("Email Sendt til dig!");
                    }
                    else
                    {
                        MessageBox.Show("Brugernavn og Email stemmer ikke overens");
                    }
                }

                finally
                {
                    con.Close();
                }
            }

        }

        private void BtnForgotUserNameClick(object sender, RoutedEventArgs e)
        {
            SmtpClient client;
            MailMessage msg;
            // Email message information
            msg = new MailMessage();
            msg.From = new MailAddress("fodboldfeberprojekt@gmail.com");
            msg.To.Add(new MailAddress(txtEmail.Text));
            msg.Subject = "Dit brugernavn er!";
            msg.Body = "Dit brugernavn er @UserName";
            // Smtp information 
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("fodboldfeberprojekt@gmail.com", "Fodboldfeber123");
            client.EnableSsl = true;
            client.Send(msg);
            // MessageBox Confirmation 
            MessageBox.Show("Email Sendt til dig!");
        }
        
    }
}


