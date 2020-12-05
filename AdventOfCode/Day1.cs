using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day1 : Day
    {
        public object Part1()
        {
            var numbers = File.ReadLines("input1.txt").Select(int.Parse).ToList();
            foreach (var a in numbers)
            foreach (var b in numbers.Where(b => a + b == 2020))
                return a * b;
            return null;
        }

        public object Part2()
        {
            var numbers = File.ReadLines("input1.txt").Select(int.Parse).ToList();
            foreach (var a in numbers)
            foreach (var b in numbers)
            foreach (var c in numbers.Where(c => a + b + c == 2020))
                return a * b * c;
            return null;
        }
    }
}