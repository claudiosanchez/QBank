using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Shared.ViewModel;

namespace WP.Client
{
    public partial class Account : PhoneApplicationPage
    {

        AccountViewModel viewModel = new AccountViewModel();
        public Account()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var AccountId = NavigationContext.QueryString["AccountNumber"].ToString() ;


            this.DataContext = viewModel.AccountItem(AccountId);
        }
    }
}