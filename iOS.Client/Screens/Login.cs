using System;
using System.Drawing;
using MonoTouch.CoreFoundation;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using iOS.Client.MonoTouch.Dialog;

namespace iOS.Client.Screens
{
	[Register("Login")]
	public class Login : UIViewController
	{
		private readonly UIWindow _window;
		RootElement _root;
		IAccountsRepository repository;

		public Login (UIWindow window, IAccountsRepository repository)
		{
			this.repository = repository;
			_window = window;
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
          
			_root = new RootElement ("Login") { 
				new Section(String.Empty)
                        {
                            new EntryElement("Username", "myusername", "lorenzo.martinez"),
				},
				new Section(String.Empty)
				{
                            new EntryElement("Password", "", "nomecambies", isPassword: true),
                          
                        },
				new Section()
				{
					new StyledStringElement("Login", () => {

						var nav = new UINavigationController( new Accounts(_window,repository));
						_window.RootViewController =nav;

					}),
				}
			};

			var dialog = new DialogViewController (_root);

			Add (dialog.View);

			// Perform any additional setup after loading the view
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			var paper = UIImage.FromBundle ("paper");
			var paperView = new UIView (_window.Bounds) {
				BackgroundColor = UIColor.FromPatternImage(paper)
			};


			_root.TableView.AddSubview (paperView);
			_root.TableView.SendSubviewToBack (paperView);

		}
	}
}