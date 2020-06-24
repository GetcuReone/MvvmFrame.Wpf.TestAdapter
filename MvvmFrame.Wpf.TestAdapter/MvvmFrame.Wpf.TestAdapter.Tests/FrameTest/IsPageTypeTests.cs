using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.FrameTest.Env;

namespace MvvmFrame.Wpf.TestAdapter.Tests.FrameTest
{
    [TestClass]
    public sealed class IsPageTypeTests : FrameTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Navigate to the page.")]
        [Timeout(Timeouts.Second.Five)]
        public void NavigationPageTestCase()
        {
            Given("Init view-model.", frame => ViewModelBase.CreateViewModel<ViewModelTest>(frame))
                .When("Navigate page.", viewModel => ViewModelBase.Navigate<PageTest>(viewModel))
                .ThenWait(Timeouts.Second.One)
                .And("Check page type.", () =>
                    Assert.IsTrue(IsPageType<PageTest>(), $"Main frame does not contain a page of type {nameof(PageTest)}."))
                .RunTestWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Run without actions.")]
        [Timeout(Timeouts.Second.Five)]
        public void RunWithoutActionsTestCase()
        {
            GivenEmpty()
                .WhenEmpty()
                .Then("Check page type.", () =>
                    Assert.IsFalse(IsPageType<PageTest>(), $"Main frame does contain a page of type {nameof(PageTest)}."))
                .RunTestWindow(Timeouts.Second.Five);
        }

        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Navigate to the another page.")]
        [Timeout(Timeouts.Second.Five)]
        public void NavigationAnotherPageTestCase()
        {
            Given("Init view-model.", frame => ViewModelBase.CreateViewModel<ViewModelTest>(frame))
                .When("Navigate page.", viewModel => ViewModelBase.Navigate<AnotherTest>(viewModel))
                .ThenWait(Timeouts.Second.One)
                .And("Check page type.", () =>
                    Assert.IsFalse(IsPageType<PageTest>(), $"Main frame does contain a page of type {nameof(PageTest)}."))
                .RunTestWindow(Timeouts.Second.Five);
        }
    }
}
