using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day3
    {
        public void GetPowerConsumption_binaryInput_getsGammaTimesEpsilon()
        {
            var binaryInput = new List<string>()
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
        }
        
        [Fact]
        public void CalculateDominantBits_binariesInput_stringWithDominantBitsInPositions()
        {
            var binaryInput = new List<string>()
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
            var expected = "10110";
            var day3 = new Days.Day3(5);
            var actual = day3.CalculateDominantBits(binaryInput);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateNonDominantBits_DominantBitsString_InvertedString()
        {
            var input = "10110";
            var expected = "01001";
            var day3 = new Days.Day3(5);
            var actual = day3.CalculateNonDominantBits(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatePowerValues_binariesInput_IntPower()
        {
            var binaryInput = "10110";
            var expected = 198;
            var day3 = new Days.Day3(5);
            day3.CalculateGamma(binaryInput);
            day3.CalculateEpsilon(binaryInput);
            
            var actual = day3.GetPowerValue();
            
            Assert.Equal(expected, actual);

        }
    }
}