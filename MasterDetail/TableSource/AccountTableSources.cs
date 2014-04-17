using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using Shared;

namespace MasterDetail
{
		public class AccountTableSources : UITableViewSource
		{
			List<Account> tableAccounts;
		string cellIdentifier = "AccountListCell";

			public AccountTableSources ( List<Account> items)
			{
				tableAccounts = items;
			}

			#region implemented abstract members of UITableViewSource

			public override int RowsInSection (UITableView tableview, int section)
			{
				return tableAccounts.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
				cell.TextLabel.Text = tableAccounts [indexPath.Row].AccountNumber;
				cell.DetailTextLabel.Text = tableAccounts [indexPath.Row].AccountType;

				return cell;
			}

			#endregion


			public Account GetItem(int id)
			{
				return tableAccounts [id];
			}
		}
}

