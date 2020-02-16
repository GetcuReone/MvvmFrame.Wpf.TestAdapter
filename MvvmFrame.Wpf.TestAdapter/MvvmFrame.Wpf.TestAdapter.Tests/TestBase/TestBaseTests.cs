using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MvvmFrame.Wpf.TestAdapter.Tests.TestBase
{
    [TestClass]
    public sealed class TestBaseTests : GetcuReone.MvvmFrame.Wpf.TestAdapter.TestBase
    {
        [Timeout(Timeouts.HundredMillisecodnds)]
        [TestMethod]
        [Description("[test_base] error return check")]
        public void ErrorReturnCheckTestCase()
        {
            string message = "is error";

            var error = ExpectedException<Exception>(() => throw new Exception(message));

            Assert.AreEqual(message, error.Message, "Message text does not match");
        }
    }
}
