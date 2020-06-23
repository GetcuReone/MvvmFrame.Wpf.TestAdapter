using System;
using GetcuReone.GetcuTestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCommon;

namespace MvvmFrame.Wpf.TestAdapter.Tests.TestBase
{
    [TestClass]
    public sealed class TestBaseTests : GetcuReone.MvvmFrame.Wpf.TestAdapter.TestBase
    {
        [TestMethod]
        [TestCategory(TC.TestBase), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Error return check.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ErrorReturnCheckTestCase()
        {
            string message = "is error";

            var error = ExpectedException<Exception>(() => throw new Exception(message));

            Assert.AreEqual(message, error.Message, "Message text does not match");
        }

        [TestMethod]
        [TestCategory(TC.TestBase), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Return another error.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void ReturnAnotherErrorTestCase()
        {
            try
            {
                ExpectedException<ArgumentNullException>(() => throw new InvalidOperationException());
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex is InvalidOperationException, "InvalidOperationException was expected");
                return;
            }

            Assert.Fail("The method worked without errors");
        }

        [TestMethod]
        [TestCategory(TC.TestBase), TestCategory(GetcuReoneTC.Negative), TestCategory(GetcuReoneTC.Unit)]
        [Description("Method worked without errors.")]
        [Timeout(Timeouts.Millisecond.FiveHundred)]
        public void MethodWorkedWithoutErrorsTestCase()
        {
            string message = "Assert.Fail failed. The method worked without errors";
            
            try
            {
                ExpectedException<Exception>(() => { });
            }
            catch (AssertFailedException ex)
            {
                Assert.AreEqual(message, ex.Message);
                return;
            }
            catch
            {
                throw;
            }

            Assert.Fail("The method did not throw an error");
        }
    }
}
