using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.UnitTests.Helper.Env;
using System.Threading.Tasks;
using System.Windows.Controls;
using MvvmFrame.Wpf.TestAdapter.Helpers;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.Helper
{
    [TestClass]
    public sealed class FrameworkElementHelperTests: FrameTestBase
    {
        [TestMethod]
        [Description("[framework_element] check method WaitLoadAsync")]
        [Timeout(Timeouts.FiveSecond)]
        public void WaitLoadAsyncTestCase()
        {
            Frame mainFrame = null;

            Given("Init view-model and frame", frame =>
            {
                mainFrame = frame;
                return ViewModelBase.CreateViewModel<ViewModel>(frame);
            })
                .AndAsync("Navigate page", async viewModel =>
                {
                    var nResult = ViewModelBase.Navigate<PageTest>(viewModel);
                    Assert.IsTrue(nResult.IsNavigate, "navigate not run");

                    if (!(mainFrame.NavigationService.Content is PageTest))
                        await Task.Delay(Timeouts.HundredMillisecodnds);
                    return (PageTest)mainFrame.NavigationService.Content;
                })
                .WhenAsync("Wait load page", page => page.WaitLoadAsync())
                .Then("Check result", () =>
                {
                    var page = CheckTypeAndGetPage<PageTest>();
                    Assert.IsTrue(page.IsLoaded, "Page not loaded");
                })
                .Run<TestWindow>(win => win.mainFrame);
        }
    }
}
