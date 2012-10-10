using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace QBank
{
    public class MyBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            // Resolve the Main View and set the application's root visual. 
            var rootView = Container.TryResolve<MainPage>();
            Application.Current.RootVisual = rootView;
            return rootView;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var moduleCatalog = new ModuleCatalog();
            // TODO: A more sofisticated method would 
            // be to get the modules from a Catalog.xaml file or a Web Service
            moduleCatalog.AddModule(typeof (BasicAccountModule.BasicAccountModule));

            return moduleCatalog;
        }
    }
}