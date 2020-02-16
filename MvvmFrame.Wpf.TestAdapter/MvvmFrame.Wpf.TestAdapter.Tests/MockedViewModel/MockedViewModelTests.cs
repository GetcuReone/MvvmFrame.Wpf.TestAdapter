using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmFrame.Wpf.TestAdapter.Tests.MockedViewModel.Env;
using System;

namespace MvvmFrame.Wpf.TestAdapter.Tests.MockedViewModel
{
    [TestClass]
    public sealed class MockedViewModelTests : MockedViewModelTestBase<ViewModel>
    {
        private Action<Mock<ViewModel>> _setupMock;
        private int _createObjectCallCount = 0;

        protected override void SetupMock(Mock<ViewModel> mock)
        {
            _setupMock(mock);
        }

        [TestMethod]
        [Description("[mock] mocking CreateObject")]
        [Timeout(Timeouts.FiveSecond)]
        public void CreateObjectMockedTestCase()
        {
            var testObj = new TestObj();
            _setupMock = mock =>
            {
                mock.Setup(vm => vm.CreateObject(It.IsAny<Func<object, TestObj>>(), It.IsAny<object>()))
                    .Returns(testObj)
                    .Callback(() => _createObjectCallCount++);
            };

            Given("Create mocked view-model", frame => CreateMockedViewModel(frame, behavior: MockBehavior.Loose))
                .When("Calling CreateObject", viewModel => viewModel.CreateObject(_ => new TestObj(), (object)null))
                .Then("Check result", result =>
                {
                    TestHelper.AssertCallCouter(1, _createObjectCallCount, "CreateObject");
                    Assert.AreEqual(testObj, result, "return different object");
                })
                .RunTestWindow(Timeouts.FiveSecond);

        }

        [TestMethod]
        [Description("[mock] mocking ViewModel")]
        [Timeout(Timeouts.FiveSecond)]
        public void CreateViewModelMockedTestCase()
        {
            bool isCallSetupMock = false;

            _setupMock = _ => isCallSetupMock = true;

            Given("Create mocked view-model", frame => frame)
                .When("Calling CreateMockedViewModel", frame => CreateMockedViewModel(frame))
                .Then("Check result", viewModel =>
                {
                    Assert.IsTrue(isCallSetupMock, "method SetupMock must be called");
                    Assert.IsNotNull(viewModel, "view-model cannot be null");
                    Assert.IsNotNull(viewModel.NavigationManager, "NavigationManager cannot be null");
                    Assert.IsNotNull(viewModel.UiServices, "UiServices cannot be null");
                })
                .RunTestWindow(Timeouts.FiveSecond);

        }
    }
}
