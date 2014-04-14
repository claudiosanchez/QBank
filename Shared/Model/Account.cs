using Shared.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace Shared
{
    public class Account : ViewModelBase
    {
        public Account()
        {
            Transactions = new List<Transaction>();
        }

        private double balance;
        public string accountHolder, accountSubType, accountType, nickName, accountNumber;

        private IList<Transaction> transactions;

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }


        public string AccountHolder
        {
            get
            {
                return accountHolder;
            }
            set
            {
                accountHolder = value;
                OnPropertyChanged("AccountHolder");
            }
        }
        public string AccountSubType
        {
            get
            {
                return accountSubType;
            }
            set 
            {
                accountSubType = value;
                OnPropertyChanged("AccountSubType");
            }
        }
        public string AccountType
        {
            get
            {
                return accountType;
            }
            set
            {
                accountType = value;
                OnPropertyChanged("AccountType");
            }
        }
        public string NickName
        {
            get
            {
                return nickName;
            }
            set
            {
                nickName = value;
                OnPropertyChanged("NickName");
            }
        }

        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
                OnPropertyChanged("AccountNumber");
            }
        }


        public IList<Transaction> Transactions
        {
            get
            {
                return transactions;
            }
            set
            {
                transactions = value;
                OnPropertyChanged("Transactions");
            }
        }

       
    }

}
