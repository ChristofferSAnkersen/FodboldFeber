﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FodboldFeber.ViewModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FodboldFeber.View
{
    /// <summary>
    /// Interaction logic for CreateCompanyCustomer.xaml
    /// </summary>
    public partial class CreateCompanyCustomer : Page
    {
        private CustomerVM customerVM;
        public CreateCompanyCustomer()
        {   
            InitializeComponent();
            customerVM = CustomerVM.Instance;
            this.DataContext = customerVM;
            txtbox_name.Text = "Angiv dit fulde navn";
            txtbox_username.Text = "Angiv Brugernavn";
            txtbox_password.Text = "Angiv Kodeord";
            txtbox_phonenumber.Text = "Angiv Telefonnummer";
            txtbox_email.Text = "Angiv Email";
            txtbox_companyaddress.Text = "Angiv Firma Adresse";
            txtbox_companyname.Text = "Angiv Firmanavn";
            txtbox_companyposition.Text = "Angiv din position i firmaet";
            txtbox_cvr.Text = "Angiv CVR";

        }

        private void BtnAddUser(object sender, RoutedEventArgs e)
        {
            customerVM.AddCompanyUserControl();
            MessageBox.Show("Du er nu oprettet, Tak for at vise interesse for fodboldfeber :)");
            //Navigation back to the frontpage
            CompanyCustomerFrame.Content = new Frontpage();

        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "txtbox_name" && textbox.Text == "" || textbox.Text == "Angiv dit fulde navn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_email" && textbox.Text == "" || textbox.Text == "Angiv Email")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_username" && textbox.Text == "" || textbox.Text == "Angiv Brugernavn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_password" && textbox.Text == "" || textbox.Text == "Angiv Kodeord")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_phonenumber" && textbox.Text == "" || textbox.Text == "Angiv Telefonnummer")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_companyname" && textbox.Text == "" || textbox.Text == "Angiv Firmanavn")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_companyposition" && textbox.Text == "" || textbox.Text == "Angiv din position i firmaet")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_companyaddress" && textbox.Text == "" || textbox.Text == "Angiv Firma Adresse")
            {
                textbox.Text = string.Empty;
            }
            if (textbox.Name == "txtbox_cvr" && textbox.Text == "" || textbox.Text == "Angiv CVR")
            {
                textbox.Text = string.Empty;
            }

            textbox.GotFocus -= TextBox_GotFocus;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (textbox.Name == "txtbox_name" && textbox.Text == "")
            {
                textbox.Text = "Angiv dit fulde navn";
            }
            else if (textbox.Name == "txtbox_email" && textbox.Text == "")
            {
                textbox.Text = "Angiv Email";
            }
            else if (textbox.Name == "txtbox_username" && textbox.Text == "")
            {
                textbox.Text = "Angiv Brugernavn";
            }
            else if (textbox.Name == "txtbox_password" && textbox.Text == "")
            {
                textbox.Text = "Angiv Kodeord";
            }
            else if (textbox.Name == "txtbox_phonenumber" && textbox.Text == "")
            {
                textbox.Text = "Angiv Telefonnummer";
            }
            else if (textbox.Name == "txtbox_companyname" && textbox.Text == "")
            {
                textbox.Text = "Angiv Firmanavn";
            }
            else if (textbox.Name == "txtbox_companyposition" && textbox.Text == "")
            {
                textbox.Text = "Angiv din position i firmaet";
            }
            else if (textbox.Name == "txtbox_companyaddress" && textbox.Text == "")
            {
                textbox.Text = "Angiv Firma Adresse";
            }
            else if (textbox.Name == "txtbox_cvr" && textbox.Text == "")
            {
                textbox.Text = "Angiv CVR";
            }
            textbox.GotFocus += TextBox_GotFocus;
        }
    }
}
