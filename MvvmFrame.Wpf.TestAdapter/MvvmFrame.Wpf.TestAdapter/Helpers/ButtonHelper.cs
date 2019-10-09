using System.Diagnostics;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// Helper for <see cref="Button"/>
    /// </summary>
    public static class ButtonHelper
    {
        /// <summary>
        /// Emulation click button
        /// </summary>
        /// <param name="button"></param>
        /// <param name="debugInfo"></param>
        public static void OnClick(this Button button, string debugInfo = null)
        {
            typeof(ButtonBase)
                .GetMethod("OnClick", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(button, new object[0]);

            if (debugInfo != null)
                Debug.WriteLine(debugInfo);
            else
                Debug.WriteLine($"Click button {button.Name}");
        }
    }
}
