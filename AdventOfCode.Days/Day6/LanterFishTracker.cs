using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dasync.Collections;

namespace AdventOfCode.Days.Day6
{
    public class LanternfishTracker
    {
        private long[] LanternFishBuckets { get; }
        public LanternfishTracker()
        {
            LanternFishBuckets = new long[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
        }

        public LanternfishTracker(List<Lanternfish> lanternfishList): this()
        {
            LanternfishList = lanternfishList;
        }

        internal void DayZero()
        {
            var bucketsToEmpty = LanternfishList.GroupBy(lf => lf.Timer);
            foreach (var bucket in bucketsToEmpty)
            {
                LanternFishBuckets[bucket.Key] = bucket.Count();
            }
        }

        public long Process_Days(int days)
        {
            DayZero();
            var counter = 0;
            do
            {
                var timer0 = LanternFishBuckets[0];
                var timer1 = LanternFishBuckets[1];
                var timer2 = LanternFishBuckets[2];
                var timer3 = LanternFishBuckets[3];
                var timer4 = LanternFishBuckets[4];
                var timer5 = LanternFishBuckets[5];
                var timer6 = LanternFishBuckets[6];
                var timer7 = LanternFishBuckets[7];
                var timer8 = LanternFishBuckets[8];
                
                LanternFishBuckets[8] = timer0;
                LanternFishBuckets[7] = timer8;
                LanternFishBuckets[6] = timer0 + timer7;
                LanternFishBuckets[5] = timer6;
                LanternFishBuckets[4] = timer5;
                LanternFishBuckets[3] = timer4;
                LanternFishBuckets[2] = timer3;
                LanternFishBuckets[1] = timer2;
                LanternFishBuckets[0] = timer1;
                
                counter++;

            } while (counter < days);

            return LanternFishBuckets.Sum();
        }
        private List<Lanternfish> LanternfishList {  get; }
        
        //part 1
        public void AddLanternfish(Lanternfish lanternfish)
        {
            LanternfishList.Add(lanternfish);
        }

        private async Task AddNewSpawn()
        {
            var spawners = CheckForSpawn();
            var lanternfishes = spawners.ToList();
            var newSpawn = lanternfishes.Count();

            LanternfishList.AddRange(Enumerable.Range(0, newSpawn).Select(lf => new Lanternfish()));

            await lanternfishes.ParallelForEachAsync(async spawner => spawner.Spawn = false);
        }

        private async Task ProcessDay()
        {
            await LanternfishList.ParallelForEachAsync(async lanternfish =>
            {
                lanternfish.ProcessDay();
            }).ContinueWith(t=> AddNewSpawn());
        }

        public async Task<List<Lanternfish>> ProcessDays(int days)
        {
            for (var i = 0; i < days; i++)
            {
                await ProcessDay();
            }

            return LanternfishList;
        }

        private IEnumerable<Lanternfish> CheckForSpawn()
        {
            return LanternfishList.Where(lf => lf.Spawn);
        }
    }
}