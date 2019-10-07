﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.UnitTests.GivenWhenThenQueue
{
    public abstract class GivenWhenThenTestBase: FrameTestBase
    {
        protected readonly string _givenCode = "given";
        protected readonly string _whenCode = "given";
        protected readonly string _thenCode = "given";
        protected readonly List<ResultBlockCode> _resultBlockCodes = new List<ResultBlockCode>();

        protected void WriteCodeAndTime(string code)
        {
            _resultBlockCodes.Add(new ResultBlockCode { Code = code, Time = DateTime.Now });
        }

        protected async ValueTask WriteCodeAndTimeAsync(string code)
        {
            await Task.Run(() => WriteCodeAndTime(code));
        }

        protected void CheckQueue(int countItems)
        {
            Assert.AreEqual(countItems, _resultBlockCodes.Count, "Blocks have not triggered the expected number of times");

            if (countItems <= 0)
                return;

            ResultBlockCode previous = _resultBlockCodes[0];

            Assert.AreEqual(_givenCode, previous.Code, "The first was to work out the block given");

            for (int i = 1; i < _resultBlockCodes.Count; i++)
            {
                ResultBlockCode current = _resultBlockCodes[i];

                if (previous.Code == _givenCode)
                {
                    if (current.Code != _givenCode && current.Code != _whenCode)
                        Assert.Fail($"After the block is {current.Code}, the block is {previous.Code} was called");
                }
                else if (previous.Code == _whenCode)
                {
                    if (current.Code != _whenCode && current.Code != _thenCode)
                        Assert.Fail($"After the block is {current.Code}, the block is {previous.Code} was called");
                }
                else if (previous.Code == _thenCode)
                {
                    if (current.Code != _thenCode)
                        Assert.Fail($"After the block is {current.Code}, the block is {previous.Code} was called");
                }

                Assert.IsTrue(current.Time > previous.Time, $"After the block {current.Code} was called before the block {previous.Code}");
            }
        }
    }
}
