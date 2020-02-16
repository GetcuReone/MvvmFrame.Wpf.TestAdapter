using GetcuReone.MvvmFrame.Wpf.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.Tests
{
    public static class TestHelper
    {
        public static void AssertCallCouter(int expected, int fact, string nameMethod)
        {
            Assert.AreEqual(expected, fact, $"Method '{nameMethod}' must be called {expected} times");
        }

        public static void RunTestWindow<TInput, TOutput>(this ThenBlock<TInput, TOutput> thenBlock, int maxWaitTime)
        {
            thenBlock.Run<TestWindow>(window => window.mainFrame, maxWaitTime);
        }

        public static void RunTestWindow<TInput, TOutput>(this ThenAsyncBlock<TInput, TOutput> thenBlock, int maxWaitTime)
        {
            thenBlock.Run<TestWindow>(window => window.mainFrame, maxWaitTime);
        }
    }
}
