using Moq;
using System.Reflection;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter
{
    /// <summary>
    /// Base class for tests with mocked view-models
    /// </summary>
    public abstract class MockedViewModelTestBase<TViewModel>: FrameTestBase
        where TViewModel: ViewModelBase, new()
    {
        /// <summary>
        /// Setup mock for instance <typeparamref name="TViewModel"/>
        /// </summary>
        /// <param name="mock"></param>
        protected abstract void SetupMock(Mock<TViewModel> mock);

        /// <summary>
        /// Create mocked view-model
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="behavior">behavior of the mock</param>
        /// <param name="callBase">Whether the base member virtual implementation will be called for mocked classes if no setup is matched. Defaults to false</param>
        /// <returns></returns>
        protected virtual TViewModel CreateMockedViewModel(Frame frame, MockBehavior behavior = MockBehavior.Default, bool callBase = false)
        {
            var mockViewModel = new Mock<TViewModel>(behavior);

            SetupMock(mockViewModel);

            var viewModel = ViewModelBase.CreateViewModel<PrivateViewModel>(frame);

            var filter = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            typeof(ViewModelBase).GetProperty(nameof(ViewModelBase.NavigationManager), filter)
                .SetValue(mockViewModel.Object, viewModel.NavigationManager);
            typeof(ViewModelBase).GetProperty(nameof(ViewModelBase.UiServices), filter)
                .SetValue(mockViewModel.Object, viewModel.UiServices);
            mockViewModel.Object.ModelOptions = viewModel.ModelOptions;

            mockViewModel.CallBase = callBase;
            return mockViewModel.Object;

        }

        private class PrivateViewModel: ViewModelBase
        {

        }
    }
}
