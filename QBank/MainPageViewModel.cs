using System;
using System.Windows.Controls;
using Microsoft.Practices.Prism.ViewModel;

namespace QBank
{
    public class MainPageViewModel : NotificationObject
    {
        public MainPageViewModel()
        {
            ApplicationName = "QBank Demo";
        }

        private string _applicationName;

        public string ApplicationName
        {
            get { return _applicationName; }
            set
            {
                _applicationName = value;
                RaisePropertyChanged(() => ApplicationName);
            }
        }

    }
}