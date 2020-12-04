using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day4 : Day
    {
        public override void Part1()
        {
            PrintResult(File.ReadAllText("input4.txt")
                .Split("\n\n")
                .Select(p => p.Split("\n").SelectMany(s => s.Split(" ")))
                .Count(p => new[]
                {
                    "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
                }.All(header => p.Any(row => row.StartsWith(header + ":")))));
        }

        public override void Part2()
        {
            var rules = new[]
            {
                "byr:(192[0-9]|19[3-9][0-9]|200[0-2])",
                "iyr:20(1[0-9]|20)",
                "eyr:20(2[0-9]|30)",
                "hgt:(1[5-8][0-9]|19[0-3])cm|hgt:(59|6[0-9]|7[0-6])in",
                "hcl:#[0-9a-f]{6}",
                "ecl:(amb|blu|brn|gry|grn|hzl|oth)",
                "pid:[0-9]{9}"
            }.Select(r => new Regex(r));
            
            PrintResult(File.ReadAllText("input4.txt")
                .Split("\n\n")
                .Select(p => p.Split("\n").SelectMany(s => s.Split(" ")))
                .Count(p => p.All(l => l.StartsWith("cid:") || rules.Any(regex => regex.IsMatch(l))) 
                            && rules.All(regex => p.Any(regex.IsMatch))));
        }
    }
}