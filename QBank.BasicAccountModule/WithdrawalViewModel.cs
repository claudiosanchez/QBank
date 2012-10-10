using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using QBank.BasicAccountModule.Proxy;

namespace QBank.BasicAccountModule
{
    public class WithdrawalViewModel : NotificationObject
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly AccountServiceClient _proxy;

        public WithdrawalViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
                       
                
                
                WithdrawCommand = new DelegateCommand<object>(ExecuteWithdrawCommand);

            _proxy = new AccountServiceClient();
            _proxy.WithdrawCompleted += OnWithdrawCompleted;
        }

        public ICommand WithdrawCommand { get; set; }

        private void OnWithdrawCompleted(object sender, WithdrawCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrWhiteSpace(e.ErrorMessage))
            {
                _eventAggregator.GetEvent<AccountBalanceChangedEvent>().Publish(e.Account.Balance);
            }
            else if (!string.IsNullOrWhiteSpace(e.ErrorMessage))
            {
            }
        }

        private void ExecuteWithdrawCommand(object amount)
        {
           //TODO: Get account number from Context Service
            var  val = double.Parse(amount.ToString());   
            _proxy.WithdrawAsync("001-012345",val);
        }
    }
}