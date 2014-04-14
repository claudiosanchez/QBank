using System;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Shared.ViewModel;

namespace WP.Client
{
    public partial class Accounts : PhoneApplicationPage
    {
        AccountViewModel viewModel = new AccountViewModel();

        public Accounts()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            llsAccounts.ItemsSource = viewModel.AccountItems() ;
        }

        private void llsAccounts_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var data = ((LongListSelector)sender).SelectedItem as Shared.Account;
            NavigationService.Navigate(new Uri("/Account.xaml?AccountNumber=" + data.AccountNumber, UriKind.Relative));
        }


    }
}