using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Entities;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.Helper.Env;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Helper
{
    [TestClass]
    public abstract class HelperTestsBase : FrameTestBase
    {
        protected GivenAsyncBlock<ViewModel, PageTest> GivenNavigatePage()
        {
            return Given("Init view-model", frame => ViewModelBase.CreateViewModel<ViewModel>(frame))
                .AndAsync("Navigate and wait page", async viewModel =>
                {
                    var nResult = ViewModelBase.Navigate<PageTest>(viewModel);
                    Assert.IsTrue(nResult.IsNavigate, "navigate not runed");

                    await Task.Delay(Timeouts.Second.One);
                    var page = CheckTypeAndGetPage<PageTest>();
                    await page.WaitLoadAsync();
                    return page;
                });
        }
    }
}
