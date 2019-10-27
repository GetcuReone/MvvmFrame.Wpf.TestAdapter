using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests
{
    public static class MockedViewModelTestsHelper
    {
        public static void AssertCallCouter(int expected, int fact, string nameMethod)
        {
            Assert.AreEqual(expected, fact, $"Method '{nameMethod}' must be called {expected} times");
        }
    }
}
