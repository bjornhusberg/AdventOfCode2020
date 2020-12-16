using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day3 : IDay
    {
        [ExpectedResult("280")]
        public object Part1() => File.ReadLines("input3.txt")
            .Where((l, i) => l.Length > 0 && l[3 * i % l.Length] == 35)
            .Count();

        [ExpectedResult("4355551200")]
        public object Part2() => new List<(int x, int y)> { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) }
            .Select(r => File.ReadLines("input3.txt")
                .Where((l, i) => l.Length > 0 && i % r.y == 0 && l[r.x * i / r.y % l.Length] == 35))
            .Aggregate(1l, (x, y) => x * y.Count());        
    }
}