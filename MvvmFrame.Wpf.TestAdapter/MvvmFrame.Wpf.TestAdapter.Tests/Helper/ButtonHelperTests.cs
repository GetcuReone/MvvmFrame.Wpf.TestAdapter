using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf;
using GetcuReone.MvvmFrame.Wpf.Commands;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.Helper.Env;
using System;
using System.Threading.Tasks;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.Helper
{
    [TestClass]
    public sealed class ButtonHelperTests : HelperTestsBase
    {
        [TestMethod]
        [TestCategory(TC.FrameworkElement), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check method OnClick.")]
        [Timeout(Timeouts.Second.Five)]
        public void OnClickTestCase()
        {
            object commandSuccess = false;

            Given("Init view-model", frame => ViewModelBase.CreateViewModel<ViewModel>(frame))
                .And("Init Command", viewModel =>
                {
                    viewModel.Command = new Command(_ => commandSuccess = true);
                    return viewModel;
                })
                .And("Page navigate", viewModel => ViewModelBase.Navigate<PageTest>(viewModel))
                .AndAsync("Wait page loaded", async result =>
                {
                    await Task.Delay(Timeouts.Second.One);
                    var page = CheckTypeAndGetPage<PageTest>();
                    await page.WaitLoadAsync();
                    return page;
                })
                .When("Click button", page => page.btn.OnClick())
                .Then("Check click", () => Assert.IsTrue(Convert.ToBoolean(commandSuccess), "Button not pressed"))
                .RunTestWindow(Timeouts.Second.Five);
        }
    }
}
