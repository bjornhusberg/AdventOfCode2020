using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day5 : IDay
    {
        [ExpectedResult("978")]
        public object Part1() => File.ReadAllLines("input5.txt")
            .Select(l => l.Aggregate(0l, (a, b) => a << 1 ^ (b == 'B' || b == 'R' ? 1 : 0)))
            .Max();

        [ExpectedResult("727")]
        public object Part2() => File.ReadAllLines("input5.txt")
            .Select(l => l.Aggregate(0l, (a, b) => a << 1 ^ (b == 'B' || b == 'R' ? 1 : 0)))
            .OrderBy(l => l)
            .Aggregate(0l, (a, b) => a == 0 || b == a + 1 ? b : a) + 1;
    }
}