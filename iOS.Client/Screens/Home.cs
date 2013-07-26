using System;
using System.Drawing;
//using BigTed;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TinyMessenger;
using BigTed;

namespace iOS.Client
{
    [Register("Home")]
    public class Home : UIViewController
    {
        public event EventHandler OnFinishedBootstrapping;
    
        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void LoadView()
        {
            base.LoadView();
            UIImage background = UIImage.FromBundle("default-568h.png");
            var backgroundView = new UIImageView(background);
            
            View.AddSubview(backgroundView);
       }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

			BTProgressHUD.Show("Loading");
           RaiseOnFinishedBootstrapping();
        }

        private void RaiseOnFinishedBootstrapping()
        {
			if(OnFinishedBootstrapping!=null)OnFinishedBootstrapping(this, new EventArgs());
        }
    }
}