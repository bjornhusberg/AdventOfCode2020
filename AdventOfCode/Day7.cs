using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day7 : IDay
    {
        [ExpectedResult(101)]
        public object Part1() =>
            Expand("shiny gold", new string[0], 
                File.ReadAllLines("input7.txt")
                    .Select(line => new Regex("^(.*) bags contain (?:no other bags|(?:\\d* ([^,]*) bags?(?:, )?)*)\\.$").Match(line))
                    .SelectMany(match => match.Groups[2].Captures.Select(c => (c.Value, match.Groups[1].Captures[0].Value)))
                    .GroupBy(v => v.Item1, v=> v.Item2)
                    .ToDictionary(g => g.Key, g => g.ToArray())).Count() - 1;

        private static IEnumerable<string> Expand(string bag, IEnumerable<string> bags, Dictionary<string, string[]> dict) =>
            bags.Concat(new [] {bag})
                .Concat((dict.GetValueOrDefault(bag) ?? new string[0]).Except(bags)
                    .SelectMany(b => Expand(b, bags.Concat(new[] {bag}), dict)))
                .Distinct();


        [ExpectedResult(108636)]
        public object Part2() => Count("shiny gold", File.ReadAllLines("input7.txt")
            .Select(line => new Regex("^(.*) bags contain (?:no other bags|(?:(\\d*) ([^,]*) bags?(?:, )?)*)\\.$").Match(line))
            .ToDictionary(match => match.Groups[1].Captures[0].Value,
                match => match.Groups[3].Captures
                    .Zip(match.Groups[2].Captures, (a, b) => (a.Value, int.Parse(b.Value)))
                    .ToDictionary(v => v.Item1, v => v.Item2))) - 1;

        private static int Count(string bag, Dictionary<string, Dictionary<string, int>> dict) => 
            1 + dict.GetValueOrDefault(bag)?.Select(bags => bags.Value * Count(bags.Key, dict)).Sum() ?? 1;
    }
}