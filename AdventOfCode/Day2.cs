
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day2 : Day
    {
        public override void Part1()
        {
            PrintResult(File
                .ReadLines("input2.txt")
                .Select(ParseLine)
                .Where(line =>
                {
                    var count = line.str.Count(c => c == line.ch);
                    return line.from <= count && count <= line.to;
                })
                .Count());
        }

        public override void Part2()
        {
            PrintResult(File
                .ReadLines("input2.txt")
                .Select(ParseLine)
                .Count(line => line.str[line.from - 1] == line.ch ^ line.str[line.to - 1] == line.ch));
        }

        private (int from, int to, char ch, string str) ParseLine(string line)
        {
            var match = new Regex("^(\\d*)-(\\d*) (\\w): (\\w*)$").Match(line);
            return (
                from: int.Parse(GetCapture(match, 1)), 
                to: int.Parse(GetCapture(match, 2)),
                ch: char.Parse(GetCapture(match, 3)), 
                str: GetCapture(match, 4));
        }

        private static string GetCapture(Match match, int index) => match.Groups[index].Captures[0].Value;
    }
}