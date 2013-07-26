using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using iOS.Client.Model;

namespace iOS.Client
{

	public class AccountElement:ModelBasedElement<Account, AccountCell>
	{
		public AccountElement (Account account, bool showIndicator):base(account, account.AccountNumber, new AccountCellFactory(){ShowIndicator = showIndicator} )
		{
		}

		public override string Summary ()
		{
			return Model.AccountNumber;
		}

		public override float GetHeight (UITableView tableView, NSIndexPath indexPath)
		{
			return AccountCell.GetHeight ();
		}
	}
}
