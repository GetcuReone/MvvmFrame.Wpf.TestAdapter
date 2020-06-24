using System.Threading.Tasks;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.EventArgs;

namespace MvvmFrame.Wpf.TestAdapter.Tests.FrameTest.Env
{
    public sealed class ViewModelTest : ViewModelBase
    {
        protected override void Initialize()
        {

        }

        protected override ValueTask OnGoPageAsync(object navigateParam) => default;

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args) => default;

        protected override ValueTask OnLoadPageAsync() => default;
    }
}
