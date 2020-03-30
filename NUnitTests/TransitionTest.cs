using NUnit.Framework;
using PowerpointAccessories;
using PowerpointAccessories.Issues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace NUnitTests
{
    [TestFixture]
    class TransitionTest
    {
        public static string getFileDir(string filename)
        {
            var outPutDirectory = Environment.CurrentDirectory;
            return $"{outPutDirectory}\\..\\..\\..\\TestPresentations\\{filename}";
        }

        [Test, TestCaseSource("testcases")]
        public void AllAutoTransitionIssuesFound(IPowerpoint power, int res)
        {
            Console.WriteLine(getFileDir("Presentation.pptx"));
            
            IIssueScanner scanner = IssueScannerFactory.GetIssueScanner(power);
            scanner.Scan();
            Dictionary<string, SlideModel> slides = (Dictionary<string, SlideModel>)power.slides;
            int count = 0;
            foreach (KeyValuePair<string, SlideModel> slide in slides)
            {
                slide.Value.Issues.ForEach(x => { if (x.GetType() == typeof(AutoTransitionIssue)) {count++; Console.WriteLine(x.Description); } });

            }

            Assert.AreEqual(res, count);
        }

        static object[] testcases =
        {
        new object[]{PowerpointFactory.GetPowerpoint(getFileDir("Presentation1.pptx")),7},
        new object[]{PowerpointFactory.GetPowerpoint(getFileDir("Presentation2.pptx")),30},
        new object[]{PowerpointFactory.GetPowerpoint(getFileDir("Presentation1.pptx")),7},

        };

    }
}
