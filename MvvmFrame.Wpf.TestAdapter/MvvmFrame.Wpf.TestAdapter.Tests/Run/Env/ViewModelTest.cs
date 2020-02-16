using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.Commands;
using GetcuReone.MvvmFrame.Wpf.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Run.Env
{
    public sealed class ViewModelTest : ViewModelBase
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
