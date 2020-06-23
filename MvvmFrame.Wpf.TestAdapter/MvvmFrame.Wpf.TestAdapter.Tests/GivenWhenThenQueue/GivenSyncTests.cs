using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue
{
    [TestClass]
    public class GivenSyncTests : GivenWhenThenTestBase
    {
        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenWhenThenTestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(3);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from given.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from given with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from given when with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from given with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from async given.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from async given with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from async given with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check given from async given with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void GivenSyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).SaveParam(obj))
                .When(_whenCode, param => WriteCodeAndTime(_whenCode).HasParam(param).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }
    }
}
