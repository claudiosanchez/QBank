using System.Windows.Controls;
using Microsoft.Practices.Unity;

namespace QBank.BasicAccountModule
{
    public partial class CurrentBalanceView : UserControl
    {
        [InjectionConstructor]
        public CurrentBalanceView(CurrentBalanceViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }

        public CurrentBalanceView()
        {
            InitializeComponent();
            DataContext = new CurrentBalanceViewModelDesign();
        }
    }
}