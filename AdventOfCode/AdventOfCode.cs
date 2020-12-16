
using System;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public static class AdventOfCode
    {
        public static void Main() =>
            Console.Write(string.Join("\n",
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => type != typeof(IDay) && typeof(IDay).IsAssignableFrom(type))
                    .OrderBy(type => type.Name)
                    .Select(day => (IDay) day.GetConstructor(new Type[0])?.Invoke(new object[0]))
                    .SelectMany(day => new []
                    {
                        PrintResult(day, nameof(day.Part1), day.Part1()),
                        PrintResult(day, nameof(day.Part2), day.Part2())
                    })));

        private static string PrintResult(IDay day, string method, object result) =>
            $"{day.GetType().Name}.{method}: {result} ({ExpectedResult.GetExpectedResult(day, method) == result.ToString()})";
    }
}