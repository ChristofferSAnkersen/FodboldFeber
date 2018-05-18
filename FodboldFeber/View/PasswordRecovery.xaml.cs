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
        
        SmtpClient client;
        MailMessage msg;
        CustomerVM cVM = new CustomerVM();
        public PasswordRecovery()
        {
            InitializeComponent();
        }

        private void BtnSendEmailClick(object sender, RoutedEventArgs e)
        {
            msg = new MailMessage
            {
                From = new MailAddress("fodboldfeberprojekt@gmail.com")
            };
            msg.To.Add(new MailAddress(txtEmail.Text));
            msg.Subject = "Kodeords Nulstilling";
            msg.Body = "Dit kodeord er blevet nulstillet";
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("fodboldfeberprojekt@gmail.com", "Fodboldfeber123");
            client.EnableSsl = true;
            client.Send(msg);
            MessageBox.Show("Email Sendt!");
        }
        


    }
}
