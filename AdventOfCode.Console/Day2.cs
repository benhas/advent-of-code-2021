using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Console
{
    public static class Day2
    {
        public static void Main(string[] args)
        {
            var navigationInstructions = Utils.GetTuplesFromInput("Day2.txt").ToList();
            var day2 = new Days.Day2();
            day2.ProcessNavigationInstructions(navigationInstructions);
            var value = day2.GetPosition();
            var value_aim = day2.GetPositionWithAim();
            System.Console.WriteLine($"x * y: {value}");
            System.Console.WriteLine($"x * y with aim: {value_aim}");
        }
    }
}