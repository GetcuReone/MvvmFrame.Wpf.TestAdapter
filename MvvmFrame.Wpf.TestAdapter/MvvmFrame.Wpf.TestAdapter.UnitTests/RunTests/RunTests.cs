using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.RunTests
{
    [TestClass]
    public sealed class RunTests: FrameTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
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
    }
}
