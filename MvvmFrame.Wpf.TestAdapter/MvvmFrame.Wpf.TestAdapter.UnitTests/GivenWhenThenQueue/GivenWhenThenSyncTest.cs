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
            Given(_givenCode, frame => WriteCodeAndTime(_givenCode))
                .When(_whenCode, () => WriteCodeAndTime(_whenCode))
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode))
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }

        [Timeout(Timeouts.TwoSecond)]
        [TestMethod]
        public void GivenWhenThen_1G_TestCase()
        {
            Given(_givenCode, f => WriteCodeAndTime(_givenCode))
                .And(_givenCode, () => WriteCodeAndTime(_givenCode))
                .When(_whenCode, () => WriteCodeAndTime(_whenCode))
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode))
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(4);
        }

        [Timeout(Timeouts.TwoSecond)]
        [TestMethod]
        public void GivenWhenThen_2G_TestCase()
        {
            Frame frame = null;

            Given(_givenCode, f => 
            {
                WriteCodeAndTime(_givenCode);
                frame = f;
            })
                .When(_whenCode, () => WriteCodeAndTime(_whenCode))
                .Then(_thenCode, () => WriteCodeAndTime(_thenCode))
                .Run<TestWindow>(window => window.mainFrame);

            CheckQueue(3);
        }
    }
}
