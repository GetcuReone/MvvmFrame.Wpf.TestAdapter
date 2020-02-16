using System;

namespace MvvmFrame.Wpf.TestAdapter.Tests.GivenWhenThenQueue.Env
{
    public class ResultBlockCode
    {
        public string Code { get; set; }
        public DateTime Time { get; set; }

        public override string ToString() => $"{Code} - {Time}";
    }
}
