using System;

namespace GetcuReone.MvvmFrame.Wpf.TestAdapter.Exceptions
{
    /// <summary>
    /// Error in another thread
    /// </summary>
    public sealed class ThreadAnotherException : Exception
    {
        public ThreadAnotherException(Exception exception) : base(exception.Message, exception)
        {

        }
    }
}
