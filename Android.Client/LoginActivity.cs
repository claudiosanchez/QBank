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

namespace Android.Client
{
    [Activity(Label = "Login", MainLauncher=true)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Login);

            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            var txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            var txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);


            btnLogin.Click += (object sender, EventArgs e)=>
            {
                if (txtPassword.Text != "nomecambies")
                {
                    Toast.MakeText(this, "You can't change the default password value, please put it again.", ToastLength.Short).Show();
                    
                    return;
                }

                var accountActivity = new Intent(this, typeof(AccountActivity));
                StartActivity(accountActivity);
                    
            };
        }

    }
}