using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.FrameTest.Env;

namespace MvvmFrame.Wpf.TestAdapter.Tests.FrameTest
{
    [TestClass]
    public sealed class NavigationPageWaitAsyncTests : FrameTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Wait navigation.")]
        [Timeout(Timeouts.Second.Five)]
        public void WaitNavigationTestCase()
        {
            GivenInitViewModel<ViewModelTest>()
                .And("Navigate page.", viewModel =>
                    ViewModelBase.Navigate<PageTest>(viewModel))
                .WhenAsync("Wait navigate.", () => 
                    WaitNavigationPageAsync<PageTest>())
                .Then("Check navigation.", () => 
                    CheckTypeAndGetPage<PageTest>())
                .RunTestWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Wait navigation without navigatio.")]
        [Timeout(Timeouts.Second.Five)]
        public void WaitNavigationWithoutNavigationTestCase()
        {
            string expectedMessage = $"Assert.Fail failed. Did not wait for the page to load. Page: <{typeof(PageTest).Name}>, Step: <{100}>, Timeout: <{1_000}>.";

            GivenEmpty()
                .WhenAsync("Wait navigate.", () =>
                    ExpectedExceptionAsync<AssertFailedException>(() => WaitNavigationPageAsync<PageTest>()))
                .Then("Check navigation.", ex =>
                    Assert.AreEqual(expectedMessage, ex.Message, "Expected another message."))
                .RunTestWindow(Timeouts.Second.Five);
        }
    }
}
