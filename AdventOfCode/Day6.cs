using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day6 : IDay
    {
        [ExpectedResult(7128)]
        public object Part1() => File.ReadAllText("input6.txt")
            .Split("\n\n")
            .Select(group => group.ToCharArray().Where(ch => ch >= 'a' && ch <= 'z').Distinct().Count())
            .Sum();

        [ExpectedResult(3640)]
        public object Part2() => File.ReadAllText("input6.txt")
            .Split("\n\n")
            .Select(group => group.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Aggregate((IEnumerable<char>) null, (a, b) => 
                    a == null ? b : a.Intersect(b))
                .Count())
            .Sum();
    }
}