using MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.RunTests
{
    /// <summary>
    /// Interaction logic for Page.xaml
    /// </summary>
    public partial class PageTest : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
