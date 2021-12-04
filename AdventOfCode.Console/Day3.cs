namespace AdventOfCode.Console
{
    public class Day3
    {
        public static void Main(string[] args)
        {
            var binaryReadings = Utils.GetStringArrayFromInput("Day3.txt");
            var day3 = new Days.Day3(12);
            day3.CalculatePowerValues(binaryReadings);
            var powerValue = day3.GetPowerValue();
            System.Console.WriteLine($"Power value: {powerValue}");
        }
    }
}