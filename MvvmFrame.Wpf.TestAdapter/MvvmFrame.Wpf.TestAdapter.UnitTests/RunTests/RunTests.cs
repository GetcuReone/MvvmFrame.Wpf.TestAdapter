using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.Commands;
using MvvmFrame.Wpf.Entities;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.RunTests
{
    [TestClass]
    public sealed class RunTests: FrameTestBase
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
                });
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
                .Run<TestWindow>(window => window.mainFrame);
        }

        [Timeout(Timeouts.FiveSecond)]
        [Description("[Run] Check method OnClick")]
        [TestMethod]
        public void CheckOnClickButtonTestCase()
        {
            bool commandSuccess = false;

            Given("Init view-model", frame => ViewModelBase.CreateViewModel<ViewModelTest>(frame))
                .And("Init Command", viewModel =>
                {
                    viewModel.Command = new Command(_ => commandSuccess = true);
                    return viewModel;
                })
                .And("Page navigate", viewModel => ViewModelBase.Navigate<PageTest>(viewModel))
                .AndAsync("Wait page loaded", async result =>
                {
                    await Task.Delay(Timeouts.OneSecond);
                    var page = CheckTypeAndGetPage<PageTest>();
                    await page.WaitLoadAsync();
                    return page;
                })
                .When("Click button", page => page.btnTest.OnClick())
                .Then("Check click", () => Assert.IsTrue(commandSuccess, "Button not pressed"))
                .Run<TestWindow>(window => window.mainFrame);
        }
    }
}
