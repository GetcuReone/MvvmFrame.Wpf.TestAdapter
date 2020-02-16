﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MvvmFrame.Wpf.TestAdapter.Tests.TestBase
{
    [TestClass]
    public sealed class TestBaseTests : GetcuReone.MvvmFrame.Wpf.TestAdapter.TestBase
    {
        [Timeout(Timeouts.HundredMillisecodnds)]
        [TestMethod]
        [Description("[test_base][expected_exception] error return check")]
        public void ErrorReturnCheckTestCase()
        {
            string message = "is error";

            var error = ExpectedException<Exception>(() => throw new Exception(message));

            Assert.AreEqual(message, error.Message, "Message text does not match");
        }

        [Timeout(Timeouts.HundredMillisecodnds)]
        [TestMethod]
        [Description("[test_base][expected_exception] return another error")]
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

        [Timeout(Timeouts.HundredMillisecodnds)]
        [TestMethod]
        [Description("[test_base][expected_exception][negative] method worked without errors")]
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
