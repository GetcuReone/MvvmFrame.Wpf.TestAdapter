using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.Helper.Env;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Helper
{
    [TestClass]
    public sealed class FrameworkElementHelperTests : HelperTestsBase
    {
        [TestMethod]
        [TestCategory(TC.FrameworkElement), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method WaitLoadAsync.")]
        [Timeout(Timeouts.Second.Five)]
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
                        await Task.Delay(Timeouts.Millisecond.Hundred);
                    return (PageTest)mainFrame.NavigationService.Content;
                })
                .WhenAsync("Wait load page", page => page.WaitLoadAsync())
                .Then("Check result", () =>
                {
                    var page = CheckTypeAndGetPage<PageTest>();
                    Assert.IsTrue(page.IsLoaded, "Page not loaded");
                })
                .RunTestWindow(Timeouts.Second.Five);
        }
    }
}
