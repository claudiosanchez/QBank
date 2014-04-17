using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Shared;

namespace MasterDetail
{
	public partial class DetailViewController : UIViewController
	{
		object detailItem;
		Account current;

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		AccountListViewController Delegate;
		public void SetData(AccountListViewController d, Account data)
		{
			Delegate = d;
			current = data;
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);


		}

		public void SetDetailItem (object newDetailItem)
		{
			if (detailItem != newDetailItem) {
				detailItem = newDetailItem;

				// Update the view
				ConfigureView ();
			}
		}

		void ConfigureView ()
		{
			// Update the user interface for the detail item
			if (IsViewLoaded && detailItem != null)
				detailDescriptionLabel.Text = detailItem.ToString ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureView ();
		}
	}
}

