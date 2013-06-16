using System.Drawing;
using BigTed;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOS.Client
{
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds)
            : base(bounds)
        {
            Initialize();
        }

        private void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("Home")]
    public class Home : UIViewController
    {
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
            var backgroundView = new UIImageView(UIScreen.MainScreen.Bounds) {Image = background};
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
        }
    }
}