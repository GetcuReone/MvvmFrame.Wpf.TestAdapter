using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.EventArgs;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Tests.MockedViewModel.Env
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
