using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue
{
    [TestClass]
    public class WhenAsyncTests : GivenWhenThenTestBase
    {
        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from given.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from given with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from given with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from given with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from async given.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from async given with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from async given with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async () => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check async when from async given with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenAsyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }
    }
}
