using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers
{
    internal static class LoggingHelper
    {
        internal static void Info(string message)
            => Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}
