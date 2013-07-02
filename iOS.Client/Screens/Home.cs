using System;
using System.Drawing;
using BigTed;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOS.Client
{
    [Register("Home")]
    public class Home : UIViewController
    {
        private readonly Action _bootstrapper;
        public event EventHandler OnFinishedBootstrapping;
    
    
        public Home(Action bootstrapper)
        {
            _bootstrapper = bootstrapper;

        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void LoadView()
        {
            base.LoadView();
            UIImage background = UIImage.FromBundle("Default-568h");
            var backgroundView = new UIImageView(background);
            
            View.AddSubview(backgroundView);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            BTProgressHUD.Show("Loading");

            _bootstrapper.BeginInvoke(RaiseOnFinishedBootstrapping, null);
        }

        private void RaiseOnFinishedBootstrapping(IAsyncResult ar)
        {
          if(OnFinishedBootstrapping!=null)OnFinishedBootstrapping(this, new EventArgs());
        }
    }
}