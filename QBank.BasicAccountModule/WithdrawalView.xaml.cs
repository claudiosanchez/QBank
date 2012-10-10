using System.Windows.Controls;

namespace QBank.BasicAccountModule
{
    public partial class WithdrawalView : UserControl
    {
        public WithdrawalView()
        {
            InitializeComponent();
        }

        public WithdrawalView(WithdrawalViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }
    }
}