using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dasync.Collections;

namespace AdventOfCode.Days.Day6
{
    public class LanternfishTracker
    {
        public LanternfishTracker()
        {
            LanternfishList = new List<Lanternfish>();
        }

        public LanternfishTracker(List<Lanternfish> lanternfishList)
        {
            LanternfishList = lanternfishList;
        }
        private List<Lanternfish> LanternfishList {  get; }

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