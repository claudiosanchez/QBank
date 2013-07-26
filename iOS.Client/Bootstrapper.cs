using MonoTouch.UIKit;
using TinyIoC;
using TinyMessenger;
using iOS.Client.Screens;

namespace iOS.Client
{
    public class Bootstrapper
    {
        public TinyIoCContainer Container { get; private set; }

        public void Run(UIApplication application, UIWindow window)
        {
            CreateContainer();
            RegisterMessengerHub();
            RegisterScreens();
			RegisterRepository ();

            Container.Register(window); 
            Container.Register(application);
        }

		private void RegisterRepository()
		{
			Container.Register<IAccountsRepository, AccountsRepository> ();
		}

        private void RegisterScreens()
        {
            Container.Register<Home>();
            Container.Register<Login>();
        }

        private  void RegisterMessengerHub()
        {
            var hub = new TinyMessengerHub();
            Container.Register<ITinyMessengerHub>(hub);
        }

        private  void CreateContainer()
        {
            Container = TinyIoCContainer.Current;
        }
    }
}