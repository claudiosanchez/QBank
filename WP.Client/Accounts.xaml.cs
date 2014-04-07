using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Shared;

namespace WP.Client
{
    public partial class Accounts : PhoneApplicationPage
    {
        public Accounts()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var accounts = new AccountsRepository();
            var accountsList = accounts.GetAccountByCustomerId(0).ToList();//The default one i guess
            llsAccounts.ItemsSource = accountsList;
        }

        private void llsAccounts_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var data = ((LongListSelector)sender).SelectedItem as Shared.Account;
            NavigationService.Navigate(new Uri("/Account.xaml?AccountNumber=" + data.AccountNumber, UriKind.Relative));
        }


    }
}