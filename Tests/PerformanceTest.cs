
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class PerformanceTest
    {
        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
        [Test]
        public void AsyncPerformance_Pin()
        {
            Assert.That(Time(() => r.Foo()), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(0.8));
        }
    }
}
