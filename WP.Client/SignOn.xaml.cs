using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WP.Client
{
    public partial class SignOn : PhoneApplicationPage
    {
        public SignOn()
        {
            InitializeComponent();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a very generic form, please, remember that you must enter the password twice.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == String.Empty || txtEmail.Text == String.Empty || txtPassword.Password == String.Empty || txtConfirm.Password == String.Empty)
            {
                MessageBox.Show("You must fill all fields to proceed to create an account with our bank.");
                return;
            }

            if (txtConfirm.Password != txtPassword.Password)
            {
                MessageBox.Show("The password doesn't match, please re-check.");
                txtConfirm.Focus();
                return;
            }

            var Question = MessageBox.Show("Thank you so much for fill the info, but actualy we haven't implemented the SQLite or API yet. But! Lets look into Lorenzo's finances, Shall we?", "Confirm",  MessageBoxButton.OKCancel);
            if (Question  == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new Uri("/Accounts.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}