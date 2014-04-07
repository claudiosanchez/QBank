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
    public partial class Account : PhoneApplicationPage
    {
        public Account()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var AccountId = NavigationContext.QueryString["AccountNumber"].ToString() ;

            var Accounts = new Shared.AccountsRepository();
            var account = Accounts.GetByAccountNumber(AccountId);
            llsTransactions.ItemsSource = account.Transactions.ToList();
            txtAccount.Text = AccountId;
            txtAcountHolder.Text = account.AccountHolder;
            txtAccountType.Text = account.AccountType;
            txtAccountSubType.Text = account.AccountSubType;
            txtBalance.Text = String.Format("{0:c}", account.Balance);
        }
    }
}