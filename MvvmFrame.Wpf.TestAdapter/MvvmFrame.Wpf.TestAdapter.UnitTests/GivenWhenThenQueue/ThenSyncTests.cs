using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    [TestClass]
    public class ThenSyncTests : GivenWhenThenTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).SaveParam(frame))
                .Then(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).SaveParam(obj))
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).HasParam(obj).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).SaveParam(obj))
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).HasParam(obj).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void ThenSyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).HasParam(obj).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }
    }
}
