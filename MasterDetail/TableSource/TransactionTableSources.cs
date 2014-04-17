using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using Shared;

namespace MasterDetail
{
	public class TransactionTableSources :UITableViewSource
	{
		List<Transaction> tableTransaction;
		string cellIdentifier = "TransactionsCell";

		public TransactionTableSources ( List<Transaction> items)
		{
			tableTransaction = items;
		}
			

		#region implemented abstract members of UITableViewSource

		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableTransaction.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			cell.TextLabel.Text = tableTransaction [indexPath.Row].Description;
			cell.DetailTextLabel.Text = String.Format("{0:C}",tableTransaction [indexPath.Row].Amount);

			return cell;
		}

		#endregion


		public Transaction GetItem(int id)
		{
			return tableTransaction [id];
		}
	}
}

