using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AdventOfCode.Days.Day6;

namespace AdventOfCode.Console
{
    public class Day6
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var daysToProcess = 256;
            var lanternFishList = Utils.GetLanternfishListFromInput("Day6.txt");
            var lanternfishTracker = new LanternfishTracker(lanternFishList.ToList());
            var results = lanternfishTracker.Process_Days(daysToProcess);
            stopwatch.Stop();
            var ts = stopwatch.Elapsed;
            
            System.Console.WriteLine($"Lanternfish after {daysToProcess} days: {results}");
            
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            System.Console.WriteLine($"RunTime {elapsedTime}");

        }
    }
}