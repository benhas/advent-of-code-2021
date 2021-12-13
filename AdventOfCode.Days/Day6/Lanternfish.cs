using System;

namespace AdventOfCode.Days.Day6
{
    public class Lanternfish: IComparable<Lanternfish>
    {
        public int Timer { get; private set; }
        public bool Spawn { get; set; }

        public Lanternfish(int timer)
        {
            Timer = timer;
            Spawn = false;
        }

        public Lanternfish()
        {
            Timer = 8;
            Spawn = false;
        }

        public void ProcessDay()
        {
            if (Timer > 0)
            {
                Timer--;
                Spawn = false;
            }
            else
            {
                Timer = 6;
                Spawn = true;
            }
        }
        
        public int CompareTo(Lanternfish? other)
        {
            if (other == null)
                return 1;
            var otherLanterfish = other as Lanternfish;
            return this.Timer.CompareTo(otherLanterfish.Timer);
        }
    }
}