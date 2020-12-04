
namespace AdventOfCode
{
    public abstract class Day
    {
        public abstract void Part1();
        public abstract void Part2();
        
        protected void PrintResult(object result)
        {
            System.Console.WriteLine(GetType().Name + ": " + result);
        }
    }
    
    public static class AdventOfCode
    {
        public static void Main()
        {
            foreach (var day in new Day[]
            {
                new Day1(), 
                new Day2(),
                new Day3(),
                new Day4()
            })
            {
                day.Part1();
                day.Part2();
            }
        }
    }
}