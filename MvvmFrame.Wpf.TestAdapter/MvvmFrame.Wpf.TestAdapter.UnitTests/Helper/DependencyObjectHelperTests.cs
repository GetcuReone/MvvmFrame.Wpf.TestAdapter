using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Helpers;
using MvvmFrame.Wpf.TestAdapter.UnitTests.Helper.Env;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.Helper
{
    [TestClass]
    public sealed class DependencyObjectHelperTests: HelperTestsBase
    {
        [TestMethod]
        [Description("[dependency_object] check method FindParentByType")]
        [Timeout(Timeouts.FiveSecond)]
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

                    await Task.Delay(Timeouts.OneSecond);
                    var page = CheckTypeAndGetPage<PageTest>();
                    await page.WaitLoadAsync();
                    return page;
                })
                .When("Get frame", page => page.FindParentByType<Frame>())
                .Then("Check result", frame => Assert.AreEqual(mainFrame, frame, "frames must be mutch"))
                .Run<TestWindow>(win => win.mainFrame);

        }
    }
}
