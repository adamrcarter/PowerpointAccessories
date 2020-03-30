using NUnit.Framework;
using PowerpointAccessories;
using System;
using System.Diagnostics;
using System.Threading;

namespace NUnitTests
{
    [TestFixture]
    public class PerformanceTest
    {
        IPowerpoint powerpoint;
        IIssueScanner scanner;
        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }
        [TearDown]
        public void TearDown()
        {
            powerpoint = null;
            scanner = null;
        }
        [SetUp]
        public void Setup()
        {
            powerpoint = PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\1045 Biology of mating, Juliana Rangel, 27 June 2019.pptx");
            scanner = IssueScannerFactory.GetIssueScanner(powerpoint);
        }
        [Test]
        public void SeqPerformance_Pin()
        {
            Assert.That(Time(() => scanner.Scan()), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(.6)));
        }


        //[Test]
        //public void AsyncPerformance_Pin()
        //{
        //    Assert.That(Time(async () => await scanner.ScanAsync()), Is.LessThanOrEqualTo(TimeSpan.FromSeconds(.2)));
        //}

    }
}
