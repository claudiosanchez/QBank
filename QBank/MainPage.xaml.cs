using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Practices.Unity;

namespace QBank
{
    public partial class MainPage : UserControl
    {
        // Design-friendly Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModelDesign();
        }

        [InjectionConstructor]
        public MainPage(MainPageViewModel viewModel) : this()
        {
            DataContext = viewModel;
        }
    }
}