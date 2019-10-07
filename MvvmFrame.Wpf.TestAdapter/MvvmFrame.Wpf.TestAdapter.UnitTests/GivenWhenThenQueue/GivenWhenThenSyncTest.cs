using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    [TestClass]
    public class GivenWhenThenSyncTest : GivenWhenThenTestBase
    {
        [Timeout(Timeouts.TwoSecond)]
        [TestMethod]
        public void GivenWhenThenTestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.TwoSecond)]
        [TestMethod]
        public void GivenWhenThen_1G_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.TwoSecond)]
        [TestMethod]
        public void GivenWhenThen_2G_TestCase()
        {
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).Void())
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.TwoSecond)]
        [TestMethod]
        public void GivenWhenThen_3G_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).Void())
                .And(_givenCode, () => WriteCodeAndTime(_givenCode).SaveParam(obj))
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).HasParam(obj).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.TwoSecond)]
        [TestMethod]
        public void GivenWhenThen_4G_TestCase()
        {
            var obj = new object();

            Given(_givenCode, frame => WriteCodeAndTime(_givenCode).SaveParam(frame))
                .And(_givenCode, frame => WriteCodeAndTime(_givenCode).HasParam(frame).SaveParam(obj))
                .When(_whenCode, () => WriteCodeAndTime(_whenCode).HasParam(obj).Void())
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode).Void())
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }
    }
}
