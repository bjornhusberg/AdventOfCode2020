using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day2 : IDay
    {
        [ExpectedResult("465")]
        public object Part1() => File.ReadLines("input2.txt")
            .Select(line => new Regex("^(\\d*)-(\\d*) (\\w): (\\w*)$").Match(line))
            .Select(match => (
                from: int.Parse(match.Groups[1].Captures[0].Value),
                to: int.Parse(match.Groups[2].Captures[0].Value),
                count: match.Groups[4].Captures[0].Value.Count(c => 
                    c == char.Parse(match.Groups[3].Captures[0].Value))))
            .Count(v => v.from <= v.count && v.count <= v.to);

        [ExpectedResult("294")]
        public object Part2() => File.ReadLines("input2.txt")
            .Select(line => new Regex("^(\\d*)-(\\d*) (\\w): (\\w*)$").Match(line))
            .Select(match => (
                from: int.Parse(match.Groups[1].Captures[0].Value),
                to: int.Parse(match.Groups[2].Captures[0].Value),
                ch: char.Parse(match.Groups[3].Captures[0].Value),
                str: match.Groups[4].Captures[0].Value))
            .Count(v => v.str[v.from - 1] == v.ch ^ v.str[v.to - 1] == v.ch);
    }
}