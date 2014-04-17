using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shared.ViewModel;
using Android.Client.Adapter;

namespace Android.Client
{
    [Activity(Label = "QBank - Account Details")]
    public class AccountDetailActivity : Activity
    {
        AccountViewModel viewModel = new AccountViewModel();  
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.AccountDetails);

            String txt = Intent.GetStringExtra("AccountNumber") ?? "Data no available";
            var data = viewModel.AccountItem(txt);

            var type = FindViewById<TextView>(Resource.Id.txtType);
            var subType = FindViewById<TextView>(Resource.Id.txtSubType);
            var Balance = FindViewById<TextView>(Resource.Id.txtBalance);
            var transactions = FindViewById<ListView>(Resource.Id.lvTransactions);
            var accountNumber = FindViewById<TextView>(Resource.Id.txtAccountNumber);

            accountNumber.Text = data.AccountNumber;
            type.Text = String.Format("Type: {0}", data.AccountType);
            subType.Text = String.Format("Sub-Type: {0}", data.AccountSubType);
            Balance.Text = String.Format("Balance: {0:C}", data.Balance);
            transactions.Adapter = new TransactionAdapter(this, data.Transactions.ToList());


            
        }
    }
}