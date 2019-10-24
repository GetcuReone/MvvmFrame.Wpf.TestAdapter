using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.Commands;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.TestAdapter.UnitTests.Helper.Env;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.Helper
{
    [TestClass]
    public sealed class ButtonHelperTests: FrameTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [Description("[button] Check method OnClick")]
        [TestMethod]
        public void OnClickTestCase()
        {
            bool commandSuccess = false;

            Given("Init view-model", frame => ViewModelBase.CreateViewModel<ViewModel>(frame))
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
                .When("Click button", page => page.btn.OnClick())
                .Then("Check click", () => Assert.IsTrue(commandSuccess, "Button not pressed"))
                .Run<TestWindow>(window => window.mainFrame);
        }
    }
}
