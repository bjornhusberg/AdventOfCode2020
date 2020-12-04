using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day1 : Day
    {
        public override void Part1()
        {
            var numbers = File.ReadLines("input1.txt").Select(int.Parse).ToList();
            foreach (var a in numbers)
            foreach (var b in numbers.Where(b => a + b == 2020))
            {
                PrintResult(a * b);
                return;
            }
        }

        public override void Part2()
        {
            var numbers = File.ReadLines("input1.txt").Select(int.Parse).ToList();
            foreach (var a in numbers)
            foreach (var b in numbers)
            foreach (var c in numbers.Where(c => a + b + c == 2020))
            {
                PrintResult(a * b * c);
                return;
            }
        }
    }
}