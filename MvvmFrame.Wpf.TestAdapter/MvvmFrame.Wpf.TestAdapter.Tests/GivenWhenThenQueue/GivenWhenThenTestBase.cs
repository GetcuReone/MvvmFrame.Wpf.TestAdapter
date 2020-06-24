using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GetcuReone.GetcuTestAdapter;
using GetcuReone.MvvmFrame.Wpf.TestAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue.Env;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue
{
    public abstract class GivenWhenThenTestBase : FrameTestBase
    {
        protected readonly string _givenCode = "given";
        protected readonly string _whenCode = "when";
        protected readonly string _thenCode = "then";
        protected readonly List<ResultBlockCode> _resultBlockCodes = new List<ResultBlockCode>();

        private object _givanWhenThanParam;

        public GivenWhenThenTestBase WriteCodeAndTime(string code)
        {
            // Activity simulation
            Thread.Sleep(Timeouts.Millisecond.Hundred);
            _resultBlockCodes.Add(new ResultBlockCode { Code = code, Time = DateTime.Now });
            return this;
        }

        public Task<GivenWhenThenTestBase> WriteCodeAndTimeAsync(string code) => Task.Run(() => WriteCodeAndTime(code));

        public TParam SaveParam<TParam>(TParam param)
        {
            _givanWhenThanParam = param;
            return param;
        }

        public GivenWhenThenTestBase HasParam<TParam>(TParam param)
        {
            Assert.AreEqual(param, _givanWhenThanParam);
            return this;
        }

        public void Void()
        {

        }

        public void CheckQueue(int countItems)
        {
            Assert.AreEqual(countItems, _resultBlockCodes.Count, "Blocks have not triggered the expected number of times");

            if (countItems <= 0)
                return;

            ResultBlockCode previous = _resultBlockCodes[0];

            Assert.AreEqual(_givenCode, previous.Code, "The first was to work out the block given");

            for (int i = 1; i < _resultBlockCodes.Count; i++)
            {
                ResultBlockCode current = _resultBlockCodes[i];

                if (current.Code != previous.Code)
                {
                    if (previous.Code == _givenCode)
                    {
                        if (current.Code != _whenCode)
                            Assert.Fail($"After the block is '{previous.Code}', the block is '{current.Code}' was called");
                    }
                    else if (previous.Code == _whenCode)
                    {
                        if (current.Code != _thenCode)
                            Assert.Fail($"After the block is '{previous.Code}', the block is '{current.Code}' was called");
                    }
                    else if (previous.Code == _thenCode)
                        Assert.Fail($"After the block is '{previous.Code}', the block is '{current.Code}' was called");
                }
                else if (current.Code == _whenCode)
                    Assert.Fail("When should meet only once");

                Assert.IsTrue(current.Time > previous.Time, $"After the block '{current.Code}' was called before the block '{previous.Code}'\n" +
                    $"current '{current.Code}' - {current.Time}\n" +
                    $"prevous '{previous.Code}' = {previous.Time}");

                previous = current;
            }
        }
    }
}
