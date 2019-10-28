using Moq;
using MvvmFrame.Interfaces;
using MvvmFrame.Wpf.Interfaces;
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
        /// <param name="modelOptions"></param>
        /// <param name="configUiServices"></param>
        /// <returns></returns>
        protected virtual TViewModel CreateMockedViewModel(Frame frame, MockBehavior behavior = MockBehavior.Default, IModelOptions modelOptions = null, IConfigUiServices configUiServices = null)
        {
            var mockViewModel = new Mock<TViewModel>(behavior);

            SetupMock(mockViewModel);

            var viewModel = ViewModelBase.CreateViewModel<PrivateViewModel>(frame, modelOptions, configUiServices);

            var filter = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;

            typeof(ViewModelBase).GetProperty(nameof(ViewModelBase.NavigationManager), filter)
                .SetValue(mockViewModel.Object, viewModel.NavigationManager);
            typeof(ViewModelBase).GetProperty(nameof(ViewModelBase.UiServices), filter)
                .SetValue(mockViewModel.Object, viewModel.UiServices);
            mockViewModel.Object.ModelOptions = viewModel.ModelOptions;

            return mockViewModel.Object;

        }

        private class PrivateViewModel: ViewModelBase
        {

        }
    }
}
