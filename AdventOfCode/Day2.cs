
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day2 : Day
    {
        public object Part1()
        {
            return File.ReadLines("input2.txt")
                .Count(line =>
                    {
                        var match = new Regex("^(\\d*)-(\\d*) (\\w): (\\w*)$").Match(line);
                        var from = int.Parse(match.Groups[1].Captures[0].Value);
                        var to = int.Parse(match.Groups[2].Captures[0].Value);
                        var ch = char.Parse(match.Groups[3].Captures[0].Value);
                        var str = match.Groups[4].Captures[0].Value;
                        var count = str.Count(c => c == ch);
                        return from <= count && count <= to;
                    });
        }

        public object Part2()
        {
            return File.ReadLines("input2.txt")
                .Count(line =>
                {
                    var match = new Regex("^(\\d*)-(\\d*) (\\w): (\\w*)$").Match(line);
                    var from = int.Parse(match.Groups[1].Captures[0].Value);
                    var to = int.Parse(match.Groups[2].Captures[0].Value);
                    var ch = char.Parse(match.Groups[3].Captures[0].Value);
                    var str = match.Groups[4].Captures[0].Value;
                    return str[from - 1] == ch ^ str[to - 1] == ch;
                });
        }
    }
}