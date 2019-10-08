using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    [TestClass]
    public class WhenAsyncTests: GivenWhenThenTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void WhenAsyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }
    }
}
