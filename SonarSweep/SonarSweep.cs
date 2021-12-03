using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SonarSweepTests")]
namespace SonarSweep
{
    public static class SonarSweep
    {
        private static bool DepthIncrease(int? previousMeasure, int thisMeasure)
        {
            return thisMeasure > previousMeasure;
        }

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

        public static int CalculateRollingDepthIncreases(int[] depths)
        {
            return CalculateDepthIncreases(GetRollingSumArray(depths));
        }
    }
}