using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

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

        /// <summary>
        /// Method expects error from <paramref name="func"/>.
        /// </summary>
        /// <typeparam name="TException">type exception.</typeparam>
        /// <param name="func">async func.</param>
        /// <returns></returns>
        protected virtual async ValueTask<TException> ExpectedExceptionAsync<TException> (Func<ValueTask> func)
            where TException : Exception
        {
            try
            {
                await func();
            }
            catch (TException e)
            {
                return e;
            }
            catch
            {
                throw;
            }

            Assert.Fail("The method worked without errors.");
            return default;
        }
    }
}
