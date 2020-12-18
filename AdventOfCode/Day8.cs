using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day8 : IDay
    {
        [ExpectedResult(1709)]
        public object Part1()
        {
            var opcodes = File.ReadLines("input8.txt")
                .Select(s => s.Split(" "))
                .Select(s => (instr:s[0], value:int.Parse(s[1])))
                .ToList();

            var visited = new List<int>();
            var index = 0;
            var acc = 0;

            while (!visited.Contains(index))
            {
                visited.Add(index);
                switch (opcodes[index].instr)
                {
                    case "acc":
                        acc += opcodes[index].value;
                        index++;
                        break;
                    case "jmp":
                        index += opcodes[index].value;
                        break;
                    case "nop":
                        index++;
                        break;
                }
            }

            return acc;
        }

        public object Part2()
        {
            return null;
        }
    }
}