using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue
{
    [TestClass]
    public class ThenAsyncTests : GivenWhenThenTestBase
    {
        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from when.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .ThenAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from when with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from when with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .ThenAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from when with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from async when.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from async when with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from async when with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async () => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async then from async when with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void ThenAsyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }
    }
}
