using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day2
    {
        [Fact]
        public void ProcessNavigationInstruction_Instructions_xyModifiedAppropriately()
        {
            var navigationInstructions = new List<(string, int)>()
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            };
            var expected = 150;
            var day2 = new AdventOfCode.Days.Day2();
            day2.ProcessNavigationInstructions(navigationInstructions);
            var actual = day2.GetPosition();
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void ProcessNavigationInstructionWAim_Instructions_xyModifiedAppropriately()
        {
            var navigationInstructions = new List<(string, int)>()
            {
                ("forward", 5),
                ("down", 5),
                ("forward", 8),
                ("up", 3),
                ("down", 8),
                ("forward", 2)
            };
            var expected = 900;
            var day2 = new AdventOfCode.Days.Day2();
            day2.ProcessNavigationInstructions(navigationInstructions);
            var actual = day2.GetPositionWithAim();
            Assert.Equal(actual, expected);
        }
    }
}