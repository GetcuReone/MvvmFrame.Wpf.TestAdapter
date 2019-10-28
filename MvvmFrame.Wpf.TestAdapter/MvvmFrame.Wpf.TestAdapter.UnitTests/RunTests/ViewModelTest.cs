using MvvmFrame.Wpf.Commands;
using MvvmFrame.Wpf.EventArgs;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.RunTests
{
    public sealed class ViewModelTest: ViewModelBase
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
