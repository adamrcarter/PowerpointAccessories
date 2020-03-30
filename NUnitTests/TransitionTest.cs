using NUnit.Framework;
using PowerpointAccessories;
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
        public void AllAutoTransitionIssuesFound(IPowerpoint power)
        {
            IIssueScanner scanner = IssueScannerFactory.GetIssueScanner(power);
            scanner.Scan();
            Dictionary<string, SlideModel> slides = (Dictionary<string, SlideModel>)powerpoint.slides;
            foreach (KeyValuePair<string, SlideModel> slide in slides)
            {

            }
        }
        //[OneTimeSetUp]
        //public void Setup()
        //{
        //    powerpoint = PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase1.pptx");
        //    scanner = IssueScannerFactory.GetIssueScanner(powerpoint);
        //}

        static object[] testcases =
        {
        new object[]{PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase1.pptx")},
        new object[]{PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase2.pptx")},
        new object[]{PowerpointFactory.GetPowerpoint("C:\\Users\\conta\\OneDrive\\Desktop\\testCase3.pptx")},

        };

    }
}
