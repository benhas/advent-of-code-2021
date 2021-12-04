using System.Linq;

namespace AdventOfCode.Console
{
    public static class Day1
    {
        public static void Main(string[] args)
        {
            var depths = Utils.GetIntArrayFromInput("Day1.txt").ToArray();
            var depthIncreases = AdventOfCode.Days.Day1.CalculateDepthIncreases(depths);
            var rollingDepthIncreases = AdventOfCode.Days.Day1.CalculateRollingDepthIncreases(depths);
            System.Console.WriteLine($"Day1 - depth increases: {depthIncreases}");
            System.Console.WriteLine($"Day1 - rolling depth increases: {rollingDepthIncreases}");    
        }
    }
}

