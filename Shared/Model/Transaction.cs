using Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Transaction : ViewModelBase
    {

        private int referenceNumber;
        private double remainingBalance, amount;
        private string description;
        private DateTime occuredOn;
        public int ReferenceNumber {
            get
            {
                return referenceNumber;
            }
            set
            {
                referenceNumber = value;
                OnPropertyChanged("ReferenceNumber");
            }
        }
        public double RemainingBalance
        {
            get
            {
                return remainingBalance;
            }
            set
            {
                remainingBalance = value;
                OnPropertyChanged("RemainingBalance");
            }
        }
        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public DateTime OccuredOn
        {
            get
            {
                return occuredOn;
            }
            set
            {
                occuredOn = value;
                OnPropertyChanged("OccuredOn");
            }
        }
    }
}
