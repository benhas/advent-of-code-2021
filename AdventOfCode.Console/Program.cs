// See https://aka.ms/new-console-template for more information

using System;
using System.Linq;
using AdventOfCode;

var depths = Utils.GetIntArrayFromInput("Day1.txt").ToArray();
var depthIncreases = AdventOfCode.Days.Day1.CalculateDepthIncreases(depths);
var rollingDepthIncreases = AdventOfCode.Days.Day1.CalculateRollingDepthIncreases(depths);
Console.WriteLine($"depth increases: {depthIncreases}");
Console.WriteLine($"rolling depth increases: {rollingDepthIncreases}");