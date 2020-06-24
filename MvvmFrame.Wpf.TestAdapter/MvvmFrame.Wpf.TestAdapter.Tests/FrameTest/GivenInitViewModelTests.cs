using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.FrameTest.Env;

namespace MvvmFrame.Wpf.TestAdapter.Tests.FrameTest
{
    [TestClass]
    public sealed class GivenInitViewModelTests : FrameTestBase
    {
        [TestMethod]
        [TestCategory(GetcuReoneTC.Unit)]
        [Description("Create view-model.")]
        [Timeout(Timeouts.Second.Five)]
        public void CreateViewModelTestCase()
        {
            GivenInitViewModel<ViewModelTest>()
                .WhenEmpty()
                .Then("Check view-model.", viewModel =>
                    Assert.IsNotNull(viewModel, "View-model cannot be null."))
                .RunTestWindow(Timeouts.Second.Five);
        }
    }
}
