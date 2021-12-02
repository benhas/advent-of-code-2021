using System.Collections.Generic;
using System.Linq;

namespace SonarSweep
{
    public class SonarSweep
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

        public static int[] GetRollingSumArray(int[] depths)
        {
            /* WIP */
            var rollingSumsArray = new List<int>();
            
            if (depths.Length <= 3)
            {
                var rollingSumDepth = depths.Sum();
                rollingSumsArray.Add(rollingSumDepth);
            }
            var firstDepth = 0;
            var secondDepth = 0;
            var thirdDepth = 0;
            for (var i = 0; i < depths.Length; i++)
            {
                var depthsSum = 0;
                if (i < 2)
                {
                    firstDepth = depths[i];
                }
            }
            return rollingSumsArray.ToArray();
        }
    }
}