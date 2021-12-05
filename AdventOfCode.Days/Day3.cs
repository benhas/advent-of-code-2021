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
        private int ReadingLength { get; }

        //part 1
        public void CalculatePowerValues(IEnumerable<string> input)
        {
            var dominantBits = DominantBitsArrayToString(CalculateDominantBits(input, this.ReadingLength));
            CalculateGamma(dominantBits);
            CalculateEpsilon(dominantBits);
        }
        private static string DominantBitsArrayToString(IEnumerable<string> input)
        {
            return string.Join(string.Empty,input);
        }
        public int GetPowerValue()
        {
            return Gamma * Epsilon;
        }
        internal void CalculateEpsilon(string binaryGamma)
        {
            var binaryEpsilon = InvertNonDominantBitsString(binaryGamma);
            Epsilon = Convert.ToInt32(binaryEpsilon, 2);
        }
        internal void CalculateGamma(string binaryGamma)
        {
            Gamma = Convert.ToInt32(binaryGamma, 2);
        }
        internal static string InvertNonDominantBitsString(string dominantBits)
        {
            var nonDominantBits = new StringBuilder();
            foreach (var t in dominantBits)
            {
                nonDominantBits.Append(t.ToString() == "1" ? '0' : '1');
            }
            
            return nonDominantBits.ToString();
        }
        //part 2

        public int GetLifeSupportRating(IEnumerable<string> input)
        {
            var oxygenRating = CalculateOxygenRating(input);
            var co2Rating = CalculateCO2Rating(input);
            
            return oxygenRating * co2Rating;
        }
        internal int CalculateOxygenRating(IEnumerable<string> input)
        {
            var binaryOxygenSequence = GetDominantBitString(input, true);
            return Convert.ToInt32(binaryOxygenSequence, 2);
        }
        internal int CalculateCO2Rating(IEnumerable<string> input)
        {
            var binaryCO2Sequence = GetDominantBitString(input, false);
            return Convert.ToInt32(binaryCO2Sequence, 2);
        }
        internal string GetDominantBitString(IEnumerable<string> input, bool dominant = true)
        {
            var inputArray = input.ToArray();
            var bitsToKeep = input;
            var position = 0;
            do
            {
                var dominantBit = CalculateDominantBits(bitsToKeep, position + 1);

                bitsToKeep = bitsToKeep
                    .Where(x => x[position].ToString() == FlipDominantBit(dominantBit[position], dominant)).ToList();
                position++;
                
            } while (bitsToKeep.Count()>1);

            return bitsToKeep.First();
        }
        private string FlipDominantBit(string dominantBit, bool dominant)
        {
            if (dominant)
                return dominantBit;

            return dominantBit.Equals("1") ? "0" : "1";
        }
        
        //part 1 and part 2
        internal string[] CalculateDominantBits(IEnumerable<string> input, int arrayLength)
        {
            var dominantBits = new string[arrayLength];

            for (var i = 0; i < dominantBits.Length; i++)
            {
                var inputList = input.ToList();
                dominantBits[i] = CalculateDominantBitsInPosition(inputList, i);
            }

            return dominantBits;
        }
        private static string CalculateDominantBitsInPosition(IEnumerable<string> input, int position)
        {
            var ones = 0;
            var zeroes = 0;
            foreach (var row in input)
            {
                if (row[position].ToString() == "1")
                {
                    ones++;
                }
                else
                    zeroes++;
            }

            return ones >= zeroes ? "1" : "0";
        }
    }
}