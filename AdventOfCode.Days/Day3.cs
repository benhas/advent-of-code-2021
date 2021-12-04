using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days
{
    public class Day3
    {
        public Day3(int readingLength)
        {
            ReadingLength = readingLength;
        }
        private int Gamma { get; set; }
        private int Epsilon { get; set; }
        private int ReadingLength { get; set; }

        public void CalculatePowerValues(IEnumerable<string> input)
        {
            var dominantBits = CalculateDominantBits(input);
            CalculateGamma(dominantBits);
            CalculateEpsilon(dominantBits);
        }

        public int GetPowerValue()
        {
            return Gamma * Epsilon;
        }

        internal void CalculateEpsilon(string binaryGamma)
        {
            var binaryEpsilon = CalculateNonDominantBits(binaryGamma);
            Epsilon = Convert.ToInt32(binaryEpsilon, 2);
        }

        internal void CalculateGamma(string binaryGamma)
        {
            Gamma = Convert.ToInt32(binaryGamma, 2);
        }

        internal string CalculateNonDominantBits(string dominantBits)
        {
            var nonDominantBits = new StringBuilder();
            foreach (var t in dominantBits)
            {
                nonDominantBits.Append(t.ToString() == "1" ? '0' : '1');
            }
            
            return nonDominantBits.ToString();
        }
        internal string CalculateDominantBits(IEnumerable<string> input)
        {
            var dominantBits = new string[this.ReadingLength];
            
            for (var i = 0; i < dominantBits.Length; i++)
            {
                var ones = 0;
                var zeroes = 0;
                
                foreach (var row in input)
                {
                    if (row[i].ToString() == "1")
                    {
                        ones++;
                    }
                    else
                        zeroes++;
                }

                dominantBits[i] = ones > zeroes ? "1" : "0";
            }

            return string.Join(string.Empty, dominantBits);
        }
    }
}