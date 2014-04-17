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
	[Register ("AccountListViewController")]
	partial class AccountListViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView AccountListTableViewOutlet { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AccountListTableViewOutlet != null) {
				AccountListTableViewOutlet.Dispose ();
				AccountListTableViewOutlet = null;
			}
		}
	}
}
