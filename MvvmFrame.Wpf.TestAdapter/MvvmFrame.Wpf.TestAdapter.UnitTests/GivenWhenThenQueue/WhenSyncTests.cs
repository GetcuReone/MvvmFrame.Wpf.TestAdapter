using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    [TestClass]
    public class WhenSyncTests : GivenWhenThenTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenSyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }
    }
}
