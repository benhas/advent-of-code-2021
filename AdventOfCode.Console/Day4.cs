using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AdventOfCode.Days.Day6;

namespace AdventOfCode.Console
{
    public class Day4
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var daysToProcess = 256;
            var lanternFishList = Utils.GetLanternfishListFromInput("Day4.txt");
            var lanternfishTracker = new LanternfishTracker(lanternFishList.ToList());

            var t = MainAsync(lanternfishTracker, daysToProcess);
            t.Wait();
            stopwatch.Stop();
            var ts = stopwatch.Elapsed;
            System.Console.WriteLine($"Lanternfish after {daysToProcess} days: {t.Result.Count}");
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            System.Console.WriteLine($"RunTime {elapsedTime}");

        }

        private static async Task<List<Lanternfish>> MainAsync(LanternfishTracker lanternfishTracker, int daysToProcess)
        {
            return await lanternfishTracker.ProcessDays(daysToProcess);
        }
    }
}