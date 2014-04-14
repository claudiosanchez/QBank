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
using Shared;

namespace Android.Client.Adapter
{
    public class AccountAdapter : BaseAdapter<Account>
    {
        Activity context;
       List<Account> items;

        public AccountAdapter(Activity Context, List<Account> items) : base(){
            this.context = Context;
            this.items = items;
        }

        public override int Count
        {
            get
            {
                return this.items.Count();
            }
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if(view == null){
                view = context.LayoutInflater.Inflate(Resource.Layout.AccountListView, null);
            }

            view.FindViewById<TextView>(Resource.Id.AccountNumber).Text = items[position].AccountNumber;
            view.FindViewById<TextView>(Resource.Id.Balance).Text = string.Format("{0:C}", items[position].Balance);
            return view;
        }

        public override Account this[int position]
        {
            get { return items[position]; }
        }
    }
}