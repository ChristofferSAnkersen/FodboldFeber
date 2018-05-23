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

namespace FodboldFeber.View
{
    public partial class PasswordRecovery : Page
    {
        
        CustomerVM cVM = new CustomerVM();
        public PasswordRecovery()
        {
            InitializeComponent();
        }
        //private void BtnSendEmailClick(object sender, RoutedEventArgs e)
        //{
        //    if (cVM.CheckIfExist)
        //    {
        //        SmtpClient client;
        //        MailMessage msg;
        //        // Generates random password since we cant send a reset link because we are doing a wpf app.
        //        char[] newPassword = "qwertyuiopasdfghjklzxcvbnm1234567890".ToCharArray();
        //        Random r = new Random();
        //        String randomString = "";
        //        for (int i = 0; i < 10; i++)
        //        {
        //            randomString += newPassword[r.Next(0, 35)].ToString();
        //        }
        //        cVM.Password = randomString;
        //        // Email message information
        //        msg = new MailMessage();
        //        msg.From = new MailAddress("fodboldfeberprojekt@gmail.com");
        //        msg.To.Add(new MailAddress(txtEmail.Text));
        //        msg.Subject = "Kodeords Nulstilling";
        //        msg.Body = "Dit kodeord er midlertigdigt lavet op til " + randomString;
        //        // Smtp information 
        //        client = new SmtpClient("smtp.gmail.com");
        //        client.Port = 587;
        //        client.Credentials = new System.Net.NetworkCredential("fodboldfeberprojekt@gmail.com", "Fodboldfeber123");
        //        client.EnableSsl = true;
        //        client.Send(msg);
        //        // MessageBox Confirmation 
        //        MessageBox.Show("Email Sendt til dig!");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Brugernavn og Email stemmer ikke overens");
        //    }
        //}

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
