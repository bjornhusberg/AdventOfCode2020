using System;
using System.Reflection;

namespace AdventOfCode
{
    public class ExpectedResult : Attribute
    {
        private readonly string _result;

        public ExpectedResult(string result)
        {
            _result = result;
        }

        public static string GetExpectedResult(object o, string methodName) =>
            ((ExpectedResult) o.GetType().GetMethod(methodName)?
                .GetCustomAttribute(typeof(ExpectedResult)))?._result;
    }
}