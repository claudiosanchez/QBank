using System;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Unity;
using QBank.BasicAccountModule.Proxy;

namespace QBank.BasicAccountModule
{
    public class CurrentBalanceViewModel : NotificationObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly AccountServiceClient _proxy;
        private double _balance;
        private string _accountType;
        private string _accountHolder;

        /// <summary>
        /// Blend-Friendly Constructor
        /// </summary>
        public CurrentBalanceViewModel()
        {
            
        }

        [InjectionConstructor]
        public CurrentBalanceViewModel(IEventAggregator eventAggregator )
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AccountBalanceChangedEvent>().Subscribe(OnAccountBalanceChanged,
                                                                              ThreadOption.UIThread);
            _proxy = new AccountServiceClient();
            _proxy.CheckBalanceCompleted += OnCheckBalanceCompleted;

            _proxy.CheckBalanceAsync("001-012345");
        }

        public void OnAccountBalanceChanged(double newBalance)
        {
            Balance = newBalance;
        }

        public double Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
                RaisePropertyChanged(() => Balance);
            }
        }

        public string AccountType
        {
            get { return _accountType; }
            set
            {
                _accountType = value;
                RaisePropertyChanged(() => AccountType);
            }
        }

        public string AccountHolder
        {
            get { return _accountHolder; }
            set
            {
                _accountHolder = value;
                RaisePropertyChanged(() => AccountHolder);
            }
        }

        private void OnCheckBalanceCompleted(object sender, CheckBalanceCompletedEventArgs e)
        {
           if(e.Error==null)
           {
               Balance = e.Account.Balance;
               AccountHolder = e.Account.AccountHolder;
               AccountType = e.Account.AccountType;
           }
        }
    }
}