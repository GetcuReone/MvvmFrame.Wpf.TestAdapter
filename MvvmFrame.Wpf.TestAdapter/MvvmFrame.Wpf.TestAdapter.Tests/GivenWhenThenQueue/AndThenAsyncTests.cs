using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue
{
    [TestClass]
    public class AndThenAsyncTests : GivenWhenThenTestBase
    {
        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .AndAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).SaveParam(frame))
                .Then(_thenCode, frame => WriteCodeAndTime(_thenCode).SaveParam(frame))
                .AndAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .AndAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(5);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(frame))
                .Then(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(frame))
                .AndAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(5);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .AndAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(frame))
                .AndAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(4);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .AndAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(5);
        }

        [Timeout(Timeouts.FiveSecond)]
        [TestMethod]
        public void AndThenAsyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(frame))
                .AndAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.FiveSecond);

            CheckQueue(5);
        }
    }
}
