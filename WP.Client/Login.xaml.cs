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
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPassword.Password == String.Empty || txtUsername.Text == String.Empty)
                {
                    MessageBox.Show("You can't leave any field blank.");
                    return;
                }

                if (txtPassword.Password != "nomecambies")
                {
                    MessageBox.Show("For some odd reason we don't accept any changes to the password field, please, put it again how it was. :|");
                    return;
                }

                NavigationService.Navigate(new Uri("/Accounts.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {

            }
        }
    }
}