using GetcuReone.MvvmFrame.Interfaces;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Tests.FrameTest.Env
{
    /// <summary>
    /// Interaction logic for PageTest.xaml
    /// </summary>
    public partial class AnotherTest : Page, IPage
    {
        public void InitializePageComponent<TViewModel>(TViewModel viewModel) where TViewModel : IViewModel
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
