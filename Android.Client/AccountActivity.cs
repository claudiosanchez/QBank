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
    [Activity(Label = "QBank - Accounts")]
    public class AccountActivity : Activity
    {
        AccountViewModel viewModel = new AccountViewModel();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            var lista = FindViewById<ListView>(Resource.Id.lvAccount);

            lista.Adapter = new AccountAdapter(this, viewModel.AccountItems());

            lista.ItemClick += delegate(object sender, Android.Widget.AdapterView.ItemClickEventArgs args)
            {
                   var t = viewModel.AccountItems()[args.Position];

                    var intent = new Intent(this, typeof(AccountDetailActivity));
                    intent.PutExtra("AccountNumber", t.AccountNumber);
                    StartActivity(intent);
            };
        }



    }
}