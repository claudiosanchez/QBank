using System.Threading;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using iOS.Client.Screens;
using iOS.Client.MonoTouch.Dialog;
using MonoTouch.Dialog;
using System.Drawing;

namespace iOS.Client
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private Home _home;
        private Bootstrapper _bootstrapper;
        private UIWindow _window;
        
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // create a new window instance based on the screen size
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            // If you have defined a view, add it here:
            _bootstrapper = new Bootstrapper();
            _bootstrapper.Run(app, _window);

			SetAppearance ();
            
			_bootstrapper.Container.TryResolve<Home>(out _home);
         	_home.OnFinishedBootstrapping += OnFinishedBootstrapping;
           
			_window.RootViewController = _home;
            // make the window visible
            _window.MakeKeyAndVisible();

            return true;
        }

        void OnFinishedBootstrapping(object sender, System.EventArgs e)
        {
            _home.OnFinishedBootstrapping -= OnFinishedBootstrapping;

            var login = _bootstrapper.Container.Resolve<Login>();
			var nav = new UINavigationController (login);

			BeginInvokeOnMainThread(() =>
                {
				System.Threading.Thread.Sleep (2000);
                 BigTed.BTProgressHUD.Dismiss();
				_window.RootViewController = nav;
                });
            
        }

		public void SetAppearance()
		{
			UINavigationBar.Appearance.SetBackgroundImage(Resources.NavBarBackground, UIBarMetrics.Default);
		
			UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;

		}
    }
}