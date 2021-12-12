using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day3
    {
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
            var expected = new string[] {"1", "0", "1", "1", "0"};
            var day3 = new Days.Day3(5);
            var actual = day3.CalculateDominantBits(binaryInput, 5);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateNonDominantBits_DominantBitsString_InvertedString()
        {
            var input = "10110";
            var expected = "01001";
            var day3 = new Days.Day3(5);
            var actual = Days.Day3.InvertNonDominantBitsString(input);
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

        [Fact]
        public void GetDominantBitString_listOfBinaryNumbers_remainingDominantString()
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
            var expected = "10111";
            var day3 = new Days.Day3(5);
            var actual = day3.GetDominantBitString(binaryInput);
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GetDominantBitString_listOfBinaryNumbers_NonDominantFlag_remainingNonDominantString()
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
            var expected = "01010";
            var day3 = new Days.Day3(5);
            var actual = day3.GetDominantBitString(binaryInput, false);
            Assert.Equal(expected, actual);
        }
    }
}