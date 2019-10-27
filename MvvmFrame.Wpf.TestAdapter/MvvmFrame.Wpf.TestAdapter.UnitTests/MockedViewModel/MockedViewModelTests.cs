using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvvmFrame.Wpf.TestAdapter.UnitTests.MockedViewModel.Env;
using System;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.MockedViewModel
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

            Given("Create mocked view-model", frame => CreateMockedViewModel(frame, callBase:true, behavior: MockBehavior.Loose))
                .When("Calling CreateObject", viewModel => viewModel.CreateObject(_ => new TestObj(), (object)null))
                .Then("Check result", result => 
                {
                    MockedViewModelTestsHelper.AssertCallCouter(1, _createObjectCallCount, "CreateObject");
                    Assert.AreEqual(testObj, result, "return different object");
                })
                .Run<TestWindow>(win => win.mainFrame);

        }
    }
}
