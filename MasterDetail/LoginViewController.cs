// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MasterDetail
{
	public partial class LoginViewController : UIViewController
	{
		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SignInButton.TouchUpInside += (sender, e) => 
			{
				if (txtPassword.Text != "nomecambies") 
				{
					new UIAlertView ("Missing fields", "You have to put the password nomecambies", null, "Ok", null).Show ();
					return;
				}


				//Some login actions

				this.PerformSegue("LoginToAccountList", this);
			};
		}
	}
}