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
using Shared;

namespace Android.Client.Adapter
{
    public class TransactionAdapter : BaseAdapter<Transaction>
    {
        List<Transaction> data;
        Activity context;

        public TransactionAdapter(Activity Context, List<Transaction> Data)
        {
            data = Data;
            context = Context;
        }

        public override Transaction this[int position]
        {
            get { return data[position]; }
        }

        public override int Count
        {
            get { return data.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.TransactionListView, null);

            view.FindViewById<TextView>(Resource.Id.txtDescription).Text = data[position].Description;
            view.FindViewById<TextView>(Resource.Id.txtOccuredOn).Text = String.Format("{0:MM/dd/yyyy}", data[position].OccuredOn);
            view.FindViewById<TextView>(Resource.Id.txtAmount).Text = String.Format("{0:C}", data[position].Amount);
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(Resource.Drawable.moneysign);

            return view;
        }
    }
}