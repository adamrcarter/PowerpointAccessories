using PowerpointAccessories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Run
{
    class Program
    {

        static void Main(string[] args)
        {
            string input;
            IPowerpoint powerpoint;
            IIssueScanner scanner;
            string welcomeMessage = "Drag in Powerpoint and press enter..";
            while (true)
            {;
                Console.Clear();
                Console.SetCursorPosition(Console.WindowLeft + (Console.WindowWidth / 2) -(welcomeMessage.Length/2), Console.WindowTop + (Console.WindowHeight / 2)) ;
                Loader loader = new Loader(0, 0, 100);
                Console.WriteLine(welcomeMessage);
                input = Console.ReadLine();
                input = input.ToLower().Trim('"');
                if (input == "q" || input == "quit")
                {
                    break;
                }
                else
                {
                    var timer = Stopwatch.StartNew();
                    

                    powerpoint = PowerpointFactory.GetPowerpoint(input);
                    scanner = IssueScannerFactory.GetIssueScanner(powerpoint);
                    loader.start();
                    scanner.Scan();

                    timer.Stop();
                    loader.stop();
                    loader.Task.Wait();
                    Console.Clear();

                    Dictionary<string, SlideModel> slides = (Dictionary<string, SlideModel>)powerpoint.slides;

                    foreach (KeyValuePair<string, SlideModel> slide in slides)
                    {
                        if (slide.Value.Issues.Count != 0)
                        {
                            slide.Value.Issues.ForEach(x => Console.WriteLine($"{x.Type} {x.Description}"));
                        }
                        else
                        {
                            Console.WriteLine($"{slide.Value.slideId} has no issues");
                        }

                    }

                    Console.WriteLine($"Took {timer.Elapsed.TotalSeconds} seconds to scan");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}

