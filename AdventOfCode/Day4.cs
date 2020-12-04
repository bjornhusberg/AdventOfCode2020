using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day4 : Day
    {
        public override void Part1()
        {
            var text = File.ReadAllText("input4.txt");
            var passports = text.Split("\n\n").Select(p => p.Split('\n', ' '));
            
        }

        public override void Part2()
        {
        }
    }
}