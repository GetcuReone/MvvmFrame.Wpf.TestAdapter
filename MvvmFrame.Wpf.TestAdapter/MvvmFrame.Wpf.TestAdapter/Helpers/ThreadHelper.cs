using GetcuReone.MvvmFrame.Wpf.TestAdapter.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// thread helper
    /// </summary>
    public static class ThreadHelper
    {
        /// <summary>
        /// Run an action in a STA thread
        /// </summary>
        /// <param name="threadStart"></param>
        /// <param name="maxWaitTime"></param>
        public static void RunActinInSTAThread(Action threadStart, int maxWaitTime)
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                threadStart();
                return;
            }

            Exception exception = null;
            var thread = new Thread(() =>
            {
                try
                {
                    threadStart();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            thread.SetApartmentState(ApartmentState.STA);

            thread.Start();
            thread.Join(maxWaitTime);

            switch (thread.ThreadState)
            {
                case ThreadState.Running:
                    thread.Abort();
                    break;
            }

            if (exception != null)
                throw new ThreadAnotherException(exception);
        }
    }
}
