using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.Entities;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.Run.Env;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Run
{
    [TestClass]
    public sealed class RunTests : FrameTestBase
    {
        [Timeout(Timeouts.TenSecond)]
        [Description("[Run] Check frame transmission")]
        [TestMethod]
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
                }, Timeouts.TenSecond);
        }

        [Timeout(Timeouts.FiveSecond)]
        [Description("[Run] Check method CheckTypeAndGetPage")]
        [TestMethod]
        public void CheckTypeAndGetPageTestCase()
        {
            Frame frame = null;

            Given("Init view-model", f =>
            {
                frame = f;
                return ViewModelBase.CreateViewModel<ViewModelTest>(f);
            })
                .WhenAsync("Navigate page", async viewModel =>
                {
                    NavigateResult<ViewModelBase> result = ViewModelBase.Navigate<PageTest>(viewModel);
                    if (!result.IsNavigate)
                        Assert.Fail("Navigation attempt failed");
                    await Task.Delay(Timeouts.OneSecond);
                    return result.ViewModel;
                })
                .Then("Check page", viewModel =>
                {
                    var page = CheckTypeAndGetPage<PageTest>();
                    Assert.AreEqual(frame.NavigationService.Content, page, "Pages do not match");
                    Assert.AreEqual(page.DataContext, viewModel, "DataContext is not view-model");
                })
                .RunTestWindow(Timeouts.FiveSecond);
        }
    }
}
