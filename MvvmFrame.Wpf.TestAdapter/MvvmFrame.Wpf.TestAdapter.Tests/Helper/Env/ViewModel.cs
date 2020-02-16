using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.Commands;
using GetcuReone.MvvmFrame.Wpf.EventArgs;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Helper.Env
{
    public sealed class ViewModel : ViewModelBase
    {
        public Command Command { get; set; }

        protected override void Initialize()
        {
        }

        protected override ValueTask OnGoPageAsync(object navigateParam) => default;

        protected override ValueTask OnLeavePageAsync(NavigatingEventArgs args) => default;

        protected override ValueTask OnLoadPageAsync() => default;
    }
}
