using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    [TestClass]
    public class GivenAsyncTests: GivenWhenThenTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncWhenThenTestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .AndAsync(_givenCode, async () => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .And(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).HasParam(frame).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .AndAsync(_givenCode, async () => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .AndAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).HasParam(frame).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .AndAsync(_givenCode, async () => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .AndAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).HasParam(frame).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .AndAsync(_givenCode, async () => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(obj))
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).HasParam(obj).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void GivenAsyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .AndAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).HasParam(frame).SaveParam(obj))
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).HasParam(obj).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }
    }
}
