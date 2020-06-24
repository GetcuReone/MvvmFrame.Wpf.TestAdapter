using GetcuReone.MvvmFrame.Interfaces;
using GetcuReone.MvvmFrame.Wpf.TestAdapter.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace GetcuReone.MvvmFrame.Wpf.TestAdapter
{
    /// <summary>
    /// base class for testing pages written on the MvvmFrame.Wpf
    /// </summary>
    [TestClass]
    public abstract class FrameTestBase : TestBase
    {
        private Frame _frame;

        /// <summary>
        /// Check the type of the current page and return
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        protected virtual TPage CheckTypeAndGetPage<TPage>() where TPage: Page
        {
            if (_frame?.NavigationService == null)
                Assert.Fail("frame or frame.NavigationService should not be (maybe you did not use the block given).");
            else if (!(_frame.NavigationService.Content is Page))
                Assert.Fail($"frame.NavigationService.Content not contains Page. Contain <{_frame.NavigationService.Content.GetType().Name}>");
            else if (_frame.NavigationService.Content is TPage page)
                return page;

            Assert.Fail($"_frame.NavigationService.Content contain not expected content. Expected <{typeof(TPage).Name}> Actual <{_frame.NavigationService.Content.GetType().Name}>.");
            return null;

        }

        /// <summary>
        /// Asynchronously waiting for a page to load.
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="step">Verification interval.</param>
        /// <param name="timeout">Maximum waiting time.</param>
        /// <returns></returns>
        protected virtual async ValueTask WaitNavigationPageAsync<TPage>(int step = 100, int timeout = 1_000)
            where TPage : Page, IPage
        {
            if (IsPageType<TPage>())
                return;

            int maxCount = timeout / step;

            for(int i = 0; i < maxCount; i++)
            {
                await Task.Delay(step);

                if (IsPageType<TPage>())
                    return;
            }

            Assert.Fail($"Did not wait for the page to load. Page: <{typeof(TPage).Name}>, Step: <{step}>, Timeout: <{timeout}>.");
        }

        /// <summary>
        /// True - if the main frame contains a page of <typeparamref name="TPage"/> type.
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        protected virtual bool IsPageType<TPage>()
            where TPage : Page, IPage
        {
            return _frame?.NavigationService != null
                && _frame.NavigationService.Content is Page page
                && page is TPage;
        }

        /// <summary>
        /// Given block with create view-model.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <returns></returns>
        protected virtual GivenBlock<Frame, TViewModel> GivenInitViewModel<TViewModel>()
            where TViewModel: ViewModelBase, new()
        {
            return Given("Init view-model.", frame => ViewModelBase.CreateViewModel<TViewModel>(frame));
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenBlock<Frame, TResult> Given<TResult>(string discription, Func<Frame, TResult> givenBlock)
        {
            return new GivenBlock<Frame, TResult>
            {
                Discription = discription,
                CodeBlock = frame => 
                {
                    _frame = frame;
                    return givenBlock(frame);
                },
            };
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenBlock<Frame, object> Given(string discription, Action<Frame> givenBlock)
        {
            return new GivenBlock<Frame, object>
            {
                Discription = discription,
                CodeBlock = frame => 
                {
                    _frame = frame;
                    givenBlock(frame);
                    return null;
                },
            };
        }

        protected virtual GivenBlock<Frame, Frame> GivenEmpty()
        {
            return Given("Empty given block.", frame => frame);
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenAsyncBlock<Frame, TResult> GivenAsync<TResult>(string discription, Func<Frame, ValueTask<TResult>> givenBlock)
        {
            return new GivenAsyncBlock<Frame, TResult>
            {
                Discription = discription,
                CodeBlock = frame => 
                {
                    _frame = frame;
                    return givenBlock(frame);
                },
            };
        }

        /// <summary>
        /// Block given
        /// </summary>
        /// <param name="discription"></param>
        /// <param name="givenBlock"></param>
        /// <returns></returns>
        protected virtual GivenAsyncBlock<Frame, object> GivenAsync(string discription, Func<Frame, ValueTask> givenBlock)
        {
            return new GivenAsyncBlock<Frame, object>
            {
                Discription = discription,
                CodeBlock = async frame => 
                {
                    _frame = frame;
                    await givenBlock(frame);
                    return null;
                },
            };
        }

        /// <summary>
        /// Clean up
        /// </summary>
        /// <remarks>
        /// Thank you very much https://www.meziantou.net/unit-tests-with-a-wpf-window.htm
        /// </remarks>
        [TestCleanup]
        public virtual void Cleanup()
        {
            if (!Dispatcher.CurrentDispatcher.HasShutdownStarted)
                Dispatcher.CurrentDispatcher.InvokeShutdown();
        }
    }
}
