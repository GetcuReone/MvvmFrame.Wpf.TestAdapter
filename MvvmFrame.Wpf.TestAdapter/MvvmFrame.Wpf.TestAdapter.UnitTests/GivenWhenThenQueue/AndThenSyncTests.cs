using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    [TestClass]
    public class AndThenSyncTests : GivenWhenThenTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(frame))
                .Then(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(frame))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(5);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(frame))
                .Then(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(obj))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(5);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(frame))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(5);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenSyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(frame))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(5);
        }
    }
}
