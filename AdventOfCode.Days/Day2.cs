using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AdventOfCode.Tests")]
namespace AdventOfCode.Days
{
    public class Day2
    {
        private int X { get; set; } = 0;

        private int Y { get;  set; } = 0;

        private int Y_aim { get;  set; } = 0;

        public void ProcessNavigationInstructions(List<(string, int)> instructions)
        {
            foreach (var instruction in instructions)
            {
                ProcessNavigationInstruction(instruction);
            }
        }

        public int GetPosition()
        {
            return X * Y;
        }

        public int GetPositionWithAim()
        {
            return X * Y_aim;
        }

        internal void ProcessNavigationInstruction((string, int) instruction)
        {
            switch(instruction.Item1.ToLower())
            {
                case "forward":
                    X += instruction.Item2;
                    Y_aim += Y * instruction.Item2;
                    break;
                case "up":
                    Y -= instruction.Item2;
                    break;
                case "down":
                    Y += instruction.Item2;
                    break;
            }
        }
    }
}