using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day1 : IDay
    {
        [ExpectedResult(440979)]
        public object Part1()
        {
            // TODO: Linqify
            var numbers = File.ReadLines("input1.txt").Select(int.Parse).ToList();
            foreach (var a in numbers)
            foreach (var b in numbers.Where(b => a + b == 2020))
                return a * b;
            return null;
        }

        [ExpectedResult(82498112)]
        public object Part2()
        {
            // TODO: Linqify
            var numbers = File.ReadLines("input1.txt").Select(int.Parse).ToList();
            foreach (var a in numbers)
            foreach (var b in numbers)
            foreach (var c in numbers.Where(c => a + b + c == 2020))
                return a * b * c;
            return null;
        }
    }
}