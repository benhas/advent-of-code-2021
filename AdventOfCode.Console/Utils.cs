using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Days.Day6;

namespace AdventOfCode.Console
{
    public static class Utils
    {
        public static IEnumerable<Lanternfish> GetLanternfishListFromInput(string fileName)
        {
            var integerArray = GetIntArrayFromInput(fileName, ",");
            var lanternFishList = new List<Lanternfish>();
            
            foreach (var integer in integerArray)
            {
             lanternFishList.Add(new Lanternfish(integer));   
            }

            return lanternFishList;
        }
        public static IEnumerable<int> GetIntArrayFromInput(string fileName, string separator)
        {
            return ConvertStringToIntArray(ReadFromFile(ReturnLocation(fileName)), separator);
        }

        public static IEnumerable<(string, int)> GetTuplesFromInput(string fileName)
        {
            return ConvertStringToTuples(ReadFromFile(ReturnLocation(fileName)));
        }

        public static IEnumerable<string> GetStringArrayFromInput(string fileName)
        {
            return ConvertStringToStringArray(ReadFromFile(ReturnLocation(fileName)));
        }
        private static string ReturnLocation(string fileName)
        {
            var app = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var inputs = Path.Combine(app, "Inputs");
            return Path.Combine(inputs, fileName);
        }
        private static string ReadFromFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        private static IEnumerable<string> ConvertStringToStringArray(string input)
        {
            return input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        }
        private static IEnumerable<int> ConvertStringToIntArray(string input, string separator)
        {
            return Array.ConvertAll(
                input.Split(separator, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }

        private static IEnumerable<(string, int)> ConvertStringToTuples(string input)
        {
            var tuples = new List<(string, int)>();
            var rows = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var row in rows)
            {
                tuples.Add(ConvertStringToTuple(row));
            }

            return tuples;
        }

        private static (string, int) ConvertStringToTuple(string input)
        {
            var valuePair = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return (valuePair[0], int.Parse(valuePair[1]));
        }
    }
}