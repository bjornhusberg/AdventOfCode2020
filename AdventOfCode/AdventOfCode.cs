
using System;
using System.Linq;
using System.Reflection;

namespace AdventOfCode
{
    public interface IDay
    {
        public object Part1();
        public object Part2();
    }
    
    public static class AdventOfCode
    {
        public static void Main()
        {
            var days = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type != typeof(IDay) && typeof(IDay).IsAssignableFrom(type))
                .OrderBy(type => type.Name);

            foreach (var day in days)
            {
                var dayObject = (IDay) day.GetConstructor(new Type[0])?.Invoke(new object[0]);
                Console.WriteLine(day.Name + " part 1: " + dayObject.Part1());
                Console.WriteLine(day.Name + " part 2: " + dayObject.Part2());
            }
        }
    }
}