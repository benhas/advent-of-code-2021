using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AdventOfCode.Tests")]
namespace AdventOfCode.Days
{
    public static class Day1
    {
        private static bool DepthIncrease(int? previousMeasure, int thisMeasure)
        {
            return thisMeasure > previousMeasure;
        }

        //Part 1
        public static int CalculateDepthIncreases(int[] depths)
        {
            var increases = 0;
            var lastDepth = 0;
            
            for (var i = 0; i < depths.Length; i++)
            {
                if (i > 0)
                {
                    var thisDepth = depths[i];
                    increases += (DepthIncrease(lastDepth, thisDepth) ? 1 : 0);
                }

                lastDepth = depths[i];
            }

            return increases;
        }

        //Part 2
        public static int CalculateRollingDepthIncreases(int[] depths)
        {
            return CalculateDepthIncreases(GetRollingSumArray(depths));
        }
        
        internal static int[] GetRollingSumArray(int[] depths)
        {
            var rollingSumsArray = new List<int>();

            var firstRollingElement = 0;
            var secondRollingElement = 1;
            var thirdRollingElement = 2;
            
            do
            {
                var holdingList = new List<int>
                {
                    depths[firstRollingElement],
                    depths[secondRollingElement],
                    depths[thirdRollingElement]
                };

                rollingSumsArray.Add(holdingList.Sum());

                firstRollingElement++;
                secondRollingElement++;
                thirdRollingElement++;
                
            } while (thirdRollingElement < depths.Length);
            
            return rollingSumsArray.ToArray();
        }
    }
}
