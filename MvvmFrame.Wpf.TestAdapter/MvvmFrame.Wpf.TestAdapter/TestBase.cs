using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GetcuReone.MvvmFrame.Wpf.TestAdapter
{
    /// <summary>
    /// Class base for test
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Method expects error from <paramref name="action"/>
        /// </summary>
        /// <typeparam name="TException">type exception</typeparam>
        /// <param name="action">action</param>
        /// <returns></returns>
        protected virtual TException ExpectedException<TException>(Action action)
            where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException e)
            {
                return e;
            }
            catch
            {
                throw;
            }

            Assert.Fail("The method worked without errors");
            return default;
        }
    }
}
