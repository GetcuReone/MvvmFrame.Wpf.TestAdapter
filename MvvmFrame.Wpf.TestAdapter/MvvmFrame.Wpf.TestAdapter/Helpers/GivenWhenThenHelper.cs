using GetcuReone.MvvmFrame.Wpf.TestAdapter.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GetcuReone.MvvmFrame.Wpf.TestAdapter.Helpers
{
    /// <summary>
    /// Helper for tests.
    /// </summary>
    public static class GivenWhenThenHelper
    {
        /// <summary>
        /// Asynchronous wait.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="givenBlock"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static GivenAsyncBlock<TOut, TOut> AndWait<TIn, TOut>(this GivenBlock<TIn, TOut> givenBlock, int timeout)
        {
            return givenBlock.AndAsync($"Wait {timeout} miliseconds.", async param =>
            {
                int innerTimeout = timeout;
                await Task.Delay(innerTimeout);
                return param;
            });
        }

        /// <summary>
        /// Asynchronous wait.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="givenBlock"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static GivenAsyncBlock<TOut, TOut> AndWait<TIn, TOut>(this GivenAsyncBlock<TIn, TOut> givenBlock, int timeout)
        {
            return givenBlock.AndAsync($"Wait {timeout} miliseconds.", async param =>
            {
                int innerTimeout = timeout;
                await Task.Delay(innerTimeout);
                return param;
            });
        }

        /// <summary>
        /// Asynchronous wait.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="whenBlock"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static ThenAsyncBlock<TOut, TOut> ThenWait<TIn, TOut>(this WhenBlock<TIn, TOut> whenBlock, int timeout)
        {
            return whenBlock.ThenAsync($"Wait {timeout} miliseconds.", async param =>
            {
                int innerTimeout = timeout;
                await Task.Delay(innerTimeout);
                return param;
            });
        }

        /// <summary>
        /// Asynchronous wait.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="whenBlock"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static ThenAsyncBlock<TOut, TOut> ThenWait<TIn, TOut>(this WhenAsyncBlock<TIn, TOut> whenBlock, int timeout)
        {
            return whenBlock.ThenAsync($"Wait {timeout} miliseconds.", async param =>
            {
                int innerTimeout = timeout;
                await Task.Delay(innerTimeout);
                return param;
            });
        }

        /// <summary>
        /// Asynchronous wait.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="thenBlock"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static ThenAsyncBlock<TOut, TOut> AndWait<TIn, TOut>(this ThenBlock<TIn, TOut> thenBlock, int timeout)
        {
            return thenBlock.AndAsync($"Wait {timeout} miliseconds.", async param =>
            {
                int innerTimeout = timeout;
                await Task.Delay(innerTimeout);
                return param;
            });
        }

        /// <summary>
        /// Asynchronous wait.
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="thenBlock"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static ThenAsyncBlock<TOut, TOut> AndWait<TIn, TOut>(this ThenAsyncBlock<TIn, TOut> thenBlock, int timeout)
        {
            return thenBlock.AndAsync($"Wait {timeout} miliseconds.", async param =>
            {
                int innerTimeout = timeout;
                await Task.Delay(innerTimeout);
                return param;
            });
        }

        internal static async ValueTask RunCodeBlockAndCloseWindow<TWindow>(Stack<BlockBase> blocksStack, TWindow window, Func<TWindow, Frame> getFrame)
            where TWindow : Window, new()
        {
            object param = getFrame(window);

            while (blocksStack.Count > 0)
            {
                BlockBase currentBlock = blocksStack.Pop();

                LoggingHelper.Info($"[{currentBlock.NameBlock}] start '{currentBlock.Discription}'");

                param = currentBlock.IsAsync
                    ? await currentBlock.ExecuteAsync(param)
                    : currentBlock.Execute(param);

                LoggingHelper.Info($"[{currentBlock.NameBlock}] end '{currentBlock.Discription}'\n");
            }

            window.Dispatcher.Invoke(window.Close);
        }
    }
}
