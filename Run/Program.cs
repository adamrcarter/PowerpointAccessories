using PowerpointAccessories;
using System;
using System.Collections.Generic;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            IPowerpoint powerpoint;
            IIssueScanner scanner;
            while (true)
            {
                Console.WriteLine("Drag in Powerpoint and press enter..");
                input = Console.ReadLine();
                input = input.ToLower().Trim('"');
                if (input == "q" || input == "quit")
                {
                    break;
                }
                else
                {
                    powerpoint = PowerpointFactory.GetPowerpoint(input);
                    scanner = IssueScannerFactory.GetIssueScanner(powerpoint);
                    scanner.Scan();
                    Dictionary<string, SlideModel> slides = (Dictionary<string, SlideModel>)powerpoint.slides;

                    foreach (KeyValuePair<string, SlideModel> slide in slides)
                    {
                        if (slide.Value.Issues.Count != 0)
                        {
                            slide.Value.Issues.ForEach(x => Console.WriteLine($"{x.GetType()} {x.Description}"));
                        }
                        else
                        {
                            Console.WriteLine($"{slide.Value.slideId} has no issues");
                        }

                    }
                }
            }
        }
    }
}

