using System.Windows;
using System.Windows.Media;

namespace MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// <see cref="DependencyObject"/> helper
    /// </summary>
    public static class DependencyObjectHelper
    {
        /// <summary>
        /// Find parent
        /// </summary>
        /// <typeparam name="TDependencyObject">type of object sought</typeparam>
        /// <param name="child"></param>
        /// <returns>parent object</returns>
        /// <remarks>
        /// Thanks https://stackoverflow.com/questions/15198104/find-parent-of-control-by-name
        /// </remarks>
        public static TDependencyObject FindParentByType<TDependencyObject>(this DependencyObject child)
            where TDependencyObject : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            TDependencyObject parent = parentObject as TDependencyObject;
            if (parent != null)
                return parent;
            else
                return FindParentByType<TDependencyObject>(parentObject);
        }

    }
}
