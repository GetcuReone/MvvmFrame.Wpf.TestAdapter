using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Run.Env
{
    /// <summary>
    /// Interaction logic for PageTest.xaml
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
