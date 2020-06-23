using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue
{
    [TestClass]
    public class WhenSyncTests : GivenWhenThenTestBase
    {
        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from given.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from given with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from given with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from given with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from async given.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from async given with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from async given with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check when from async given with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void WhenSyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(obj))
                .Then(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }
    }
}
