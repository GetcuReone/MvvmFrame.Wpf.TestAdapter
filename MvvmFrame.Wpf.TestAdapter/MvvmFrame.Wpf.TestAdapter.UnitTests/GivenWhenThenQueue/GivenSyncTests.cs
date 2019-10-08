using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    [TestClass]
    public class GivenSyncTests : GivenWhenThenTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenWhenThenTestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenSyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }
    }
}
