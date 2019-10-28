using System.Threading.Tasks;
using MvvmFrame.Wpf.EventArgs;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.MockedViewModel.Env
{
    public class ViewModel : ViewModelBase
    {
        protected override void Initialize()
        {
            
        }

        protected override ValueTask OnGoPageAsync(object navigateParam) => default;

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args) => default;

        protected override ValueTask OnLoadPageAsync() => default;
    }
}
