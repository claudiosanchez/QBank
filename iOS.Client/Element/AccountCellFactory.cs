using System;
using MonoTouch.Foundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using iOS.Client.Model;

namespace iOS.Client
{
	public class AccountCellFactory: IModelBasedCellFactory<Account>
	{
		public bool ShowIndicator {
			get;
			set;
		}
		public ModelBasedCell<Account> BuildCell(NSString key)
		{
			return new AccountCell (key, ShowIndicator);
		}
	}
}
