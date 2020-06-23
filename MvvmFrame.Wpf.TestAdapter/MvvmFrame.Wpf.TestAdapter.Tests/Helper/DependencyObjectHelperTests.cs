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
    public sealed class DependencyObjectHelperTests : HelperTestsBase
    {
        [TestMethod]
        [TestCategory(TC.FrameworkElement), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method FindParentByType.")]
        [Timeout(Timeouts.Second.Five)]
        public void FindParentByTypeTestCase()
        {
            Frame mainFrame = null;

            Given("Init view-model", frame =>
            {
                mainFrame = frame;
                return ViewModelBase.CreateViewModel<ViewModel>(frame);
            })
                .AndAsync("Navigate and wait page", async viewModel =>
                {
                    var nResult = ViewModelBase.Navigate<PageTest>(viewModel);
                    Assert.IsTrue(nResult.IsNavigate, "navigate not runed");

                    await Task.Delay(Timeouts.Second.One);
                    var page = CheckTypeAndGetPage<PageTest>();
                    await page.WaitLoadAsync();
                    return page;
                })
                .When("Get frame", page => page.FindParentByType<Frame>())
                .Then("Check result", frame => Assert.AreEqual(mainFrame, frame, "frames must be mutch"))
                .RunTestWindow(Timeouts.Second.One);
        }

        [TestMethod]
        [TestCategory(TC.FrameworkElement), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method FindChildByName.")]
        [Timeout(Timeouts.Second.Five)]
        public void FindChildByNameTestCase()
        {
            GivenNavigatePage()
                .When("Get frame", page => page.FindChildByName<Button>("btn"))
                .Then("Check result", button => Assert.AreEqual(CheckTypeAndGetPage<PageTest>().btn, button, "buttons must be mutch"))
                .RunTestWindow(Timeouts.Second.Five);
        }
    }
}
