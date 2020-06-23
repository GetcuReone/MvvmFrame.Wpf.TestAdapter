using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.Entities;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.Run.Env;
using System.Windows.Controls;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Run
{
    [TestClass]
    public sealed class RunTests : FrameTestBase
    {
        [TestMethod]
        [TestCategory(TC.Run), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check frame transmission.")]
        [Timeout(Timeouts.Second.Ten)]
        public void CheckInputFrameTestCase()
        {
            Frame frame1 = null;
            Given("Check frame", frame =>
            {
                Assert.IsNotNull(frame);
                Assert.AreEqual(frame1, frame, "Frames must match");
            })
                .When("Empty block", () => { })
                .Then("Empty block", () => { })
                .Run<TestWindow>(window =>
                {
                    frame1 = window.mainFrame;
                    return window.mainFrame;
                }, Timeouts.Second.Ten);
        }

        [TestMethod]
        [TestCategory(TC.Run), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method CheckTypeAndGetPage.")]
        [Timeout(Timeouts.Second.Ten)]
        public void CheckTypeAndGetPageTestCase()
        {
            Frame frame = null;

            Given("Init view-model", f =>
            {
                frame = f;
                return ViewModelBase.CreateViewModel<ViewModelTest>(f);
            })
                .When("Navigate page", viewModel =>
                {
                    NavigateResult<ViewModelBase> result = ViewModelBase.Navigate<PageTest>(viewModel);

                    if (!result.IsNavigate)
                        Assert.Fail("Navigation attempt failed");

                    return result.ViewModel;
                })
                .ThenWait(Timeouts.Second.One)
                .And("Check page", viewModel =>
                {
                    var page = CheckTypeAndGetPage<PageTest>();
                    Assert.AreEqual(frame.NavigationService.Content, page, "Pages do not match");
                    Assert.AreEqual(page.DataContext, viewModel, "DataContext is not view-model");
                })
                .RunTestWindow(Timeouts.Second.Ten);
        }
    }
}
