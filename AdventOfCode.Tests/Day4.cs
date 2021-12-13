using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days.Day6;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day4
    {
        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public async void ProcessDay_multipleDays_lanternFishListAndSpawns(List<Lanternfish> day0, int daysToProcess, List<Lanternfish> expected)
        {
            var lanternFishTracker = new LanternfishTracker(day0);
            var result = await lanternFishTracker.ProcessDays(daysToProcess);
            Assert.Equal(expected, result);
        }

        [Theory]
        [ClassData(typeof(TestLanternFishCount))]
        public async void ProcessDay_80days_5934fish(List<Lanternfish> day0, int daysToProcess, Int64 expectedCount)
        {
            var lanternFishTracker = new LanternfishTracker(day0);
            var result = await lanternFishTracker.ProcessDays(80);
            Assert.Equal(expectedCount, result.Count());
        }
    }
    public class TestDataGenerator : IEnumerable<object[]>
    {
        /*
         * 
         * 
         * 
         * 
         * After  4 days: 6,0,6,4,5,6,7,8,8
         * After  5 days: 5,6,5,3,4,5,6,7,7,8
         * After  6 days: 4,5,4,2,3,4,5,6,6,7
         * After  7 days: 3,4,3,1,2,3,4,5,5,6
         * After  8 days: 2,3,2,0,1,2,3,4,4,5
         * After  9 days: 1,2,1,6,0,1,2,3,3,4,8
         * After 10 days: 0,1,0,5,6,0,1,2,2,3,7,8
         * After 11 days: 6,0,6,4,5,6,0,1,1,2,6,7,8,8,8
         * After 12 days: 5,6,5,3,4,5,6,0,0,1,5,6,7,7,7,8,8
         * After 13 days: 4,5,4,2,3,4,5,6,6,0,4,5,6,6,6,7,7,8,8
         * After 14 days: 3,4,3,1,2,3,4,5,5,6,3,4,5,5,5,6,6,7,7,8
         * After 15 days: 2,3,2,0,1,2,3,4,4,5,2,3,4,4,4,5,5,6,6,7
         * After 16 days: 1,2,1,6,0,1,2,3,3,4,1,2,3,3,3,4,4,5,5,6,8
         * After 17 days: 0,1,0,5,6,0,1,2,2,3,0,1,2,2,2,3,3,4,4,5,7,8
         * 
         */
        
        //Initial state: 3,4,3,1,2
        private static List<Lanternfish> day0 = new List<Lanternfish>()
        {
            new Lanternfish(3), new Lanternfish(4), new Lanternfish(3), new Lanternfish(1), 
            new Lanternfish(2)
        };
        
        //After  1 day:  2,3,2,0,1
        private static List<Lanternfish> day1 = new List<Lanternfish>()
        {
            new Lanternfish(2), new Lanternfish(3), new Lanternfish(2), new Lanternfish(0), 
            new Lanternfish(1)
        };

        //After  2 days: 1,2,1,6,0,8
        private static List<Lanternfish> day2 = new List<Lanternfish>()
        {
            new Lanternfish(1), new Lanternfish(2), new Lanternfish(1), new Lanternfish(6),
            new Lanternfish(0), new Lanternfish()
        };
        
        //After  3 days: 0,1,0,5,6,7,8
        private static List<Lanternfish> day3 = new List<Lanternfish>()
        {
            new Lanternfish(0), new Lanternfish(1), new Lanternfish(0), new Lanternfish(5),
            new Lanternfish(6), new Lanternfish(7), new Lanternfish()
        };
        
        /* After 18 days:
         6,0,6,4,
         5,6,0,1,
         1,2,6,0,
         1,1,1,2,
         2,3,3,4,
         6,7,8,8,
         8,8 */
        private static List<Lanternfish> day18 = new List<Lanternfish>()
        {
            new Lanternfish(6), new Lanternfish(0), new Lanternfish(6), new Lanternfish(4),
            new Lanternfish(5), new Lanternfish(6), new Lanternfish(0), new Lanternfish(1),
            new Lanternfish(1), new Lanternfish(2), new Lanternfish(6), new Lanternfish(0),
            new Lanternfish(1), new Lanternfish(1), new Lanternfish(1), new Lanternfish(2),
            new Lanternfish(2), new Lanternfish(3), new Lanternfish(3), new Lanternfish(4),
            new Lanternfish(6), new Lanternfish(7), new Lanternfish(8), new Lanternfish(8),
            new Lanternfish(8), new Lanternfish(8)
        };

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {day0, 18, day18}
        };      

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public class TestLanternFishCount : IEnumerable<object[]>
    {
        
        //Initial state: 3,4,3,1,2
        private static List<Lanternfish> day0 = new List<Lanternfish>()
        {
            new Lanternfish(3), new Lanternfish(4), new Lanternfish(3), new Lanternfish(1), 
            new Lanternfish(2)
        };
        
        
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {day0, 80, 5934},
            new object[]{day0, 256, 26984457539}
        };      

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
}