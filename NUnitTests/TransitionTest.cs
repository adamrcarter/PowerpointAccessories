using NUnit.Framework;
using PowerpointAccessories;
using PowerpointAccessories.Issues;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests
{
    [TestFixture]
    class TransitionTest
    {
        //IIssueScanner scanner;
        //IPowerpoint powerpoint;

        [Test, TestCaseSource("testcases")]
        public void AllAutoTransitionIssuesFound(IPowerpoint power, int res)
        {
            IIssueScanner scanner = IssueScannerFactory.GetIssueScanner(power);
            scanner.Scan();
            Dictionary<string, SlideModel> slides = (Dictionary<string, SlideModel>)power.slides;
            int count = 0;
            foreach (KeyValuePair<string, SlideModel> slide in slides)
            {
                slide.Value.Issues.ForEach(x => { if (x.GetType() == typeof(AutoTransitionIssue)) count++; });

            }
            Assert.AreEqual(res, count);
        }
        //[OneTimeSetUp]
        //public void Setup()
        //{
        //    powerpoint = PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase1.pptx");
        //    scanner = IssueScannerFactory.GetIssueScanner(powerpoint);
        //}

        static object[] testcases =
        {
        new object[]{PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase1.pptx"),1},
        new object[]{PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase2.pptx"),4},
        new object[]{PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase3.pptx"),3},

        };

    }
}
