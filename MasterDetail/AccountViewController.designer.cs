// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MasterDetail
{
	[Register ("AccountViewController")]
	partial class AccountViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel AccountNumberLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel AccountSubTypeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel AccountTypeLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel BalanceLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TransactionsTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AccountNumberLabel != null) {
				AccountNumberLabel.Dispose ();
				AccountNumberLabel = null;
			}

			if (AccountSubTypeLabel != null) {
				AccountSubTypeLabel.Dispose ();
				AccountSubTypeLabel = null;
			}

			if (AccountTypeLabel != null) {
				AccountTypeLabel.Dispose ();
				AccountTypeLabel = null;
			}

			if (BalanceLabel != null) {
				BalanceLabel.Dispose ();
				BalanceLabel = null;
			}

			if (TransactionsTableView != null) {
				TransactionsTableView.Dispose ();
				TransactionsTableView = null;
			}
		}
	}
}
