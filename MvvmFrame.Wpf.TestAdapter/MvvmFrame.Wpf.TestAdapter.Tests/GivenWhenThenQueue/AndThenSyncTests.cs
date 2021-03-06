﻿using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue
{
    [TestClass]
    public class AndThenSyncTests : GivenWhenThenTestBase
    {
        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from then.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromSync_1_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from then with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromSync_2_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(frame))
                .Then(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(frame))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from then with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromSync_3_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(5);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from then with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromSync_4_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .When(_whenCode, frame => WriteCodeAndTime(_whenCode).HasParam(frame).SaveParam(frame))
                .Then(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(obj))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(5);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from async then.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromAsync_1_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from async then with input param.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromAsync_2_TestCase()
        {
            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(frame))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(4);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from async then with output param.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromAsync_3_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).Void())
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).Void())
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).Void())
                .And(_thenCode, () => WriteCodeAndTime(_thenCode).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(5);
        }

        [TestMethod]
        [TestCategory(TC.When), TestCategory(GetcuReoneTC.Unit)]
        [Description("Check then from async then with input and output params.")]
        [Timeout(Timeouts.Second.Five)]
        public void AndThenSyncFromAsync_4_TestCase()
        {
            var obj = new object();

            GivenAsync(_givenCode, async frame => (await WriteCodeAndTimeAsync(_givenCode)).SaveParam(frame))
                .WhenAsync(_whenCode, async frame => (await WriteCodeAndTimeAsync(_whenCode)).SaveParam(frame))
                .ThenAsync(_thenCode, async frame => (await WriteCodeAndTimeAsync(_thenCode)).SaveParam(frame))
                .And(_thenCode, frame => WriteCodeAndTime(_thenCode).HasParam(frame).SaveParam(obj))
                .And(_thenCode, param => WriteCodeAndTime(_thenCode).HasParam(param).Void())
                .RunTestWindow(Timeouts.Second.Five);

            CheckQueue(5);
        }
    }
}
