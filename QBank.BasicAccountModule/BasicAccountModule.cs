using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using QBank.BasicAccountModule.Proxy;

namespace QBank.BasicAccountModule
{
    public class BasicAccountModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public BasicAccountModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        #region IModule Members

        public void Initialize()
        {
            RegisterViews();
            RegisterViewModels();
            InjectScreensIntoRegions();
        }

        #endregion

        private void InjectScreensIntoRegions()
        {
            var view = _container.Resolve<CurrentBalanceView>();
            var mainView = _container.Resolve<WithdrawalView>();

            _regionManager.AddToRegion("TopRegion", view);
            _regionManager.AddToRegion("MainRegion", mainView);
        }

        private void RegisterViewModels()
        {
            _container.RegisterType<AccountServiceClient, AccountServiceClient>();
        }

        private void RegisterViews()
        {
            _container.RegisterType<CurrentBalanceView, CurrentBalanceView>();
            _container.RegisterType<CurrentBalanceViewModel, CurrentBalanceViewModel>();

            _container.RegisterType<WithdrawalView, WithdrawalView>();
            _container.RegisterType<WithdrawalViewModel, WithdrawalViewModel>();
        }
    }
}