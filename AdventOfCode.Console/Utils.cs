using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public static class Utils
    {
        public static IEnumerable<int> GetIntArrayFromInput(string fileName)
        {
            return ConvertStringToIntArray(ReadFromFile(ReturnLocation(fileName)));
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

        private static IEnumerable<int> ConvertStringToIntArray(string input)
        {
            return Array.ConvertAll(
                input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}