using System.Diagnostics;
using System.Windows;
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
        /// Click button
        /// </summary>
        /// <param name="button"></param>
        /// <param name="debugInfo"></param>
        public static void Click(this Button button, string debugInfo = null)
        {
            button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

            if (debugInfo != null)
                Debug.WriteLine(debugInfo);
            else
                Debug.WriteLine($"Click button {button.Name}");
        }
    }
}
