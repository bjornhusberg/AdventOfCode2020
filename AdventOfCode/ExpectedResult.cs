using System;
using System.Reflection;

namespace AdventOfCode
{
    public class ExpectedResult : Attribute
    {
        private readonly object _result;

        public ExpectedResult(object result)
        {
            _result = result;
        }

        public static object GetExpectedResult(object o, string methodName) =>
            ((ExpectedResult) o.GetType().GetMethod(methodName)?
                .GetCustomAttribute(typeof(ExpectedResult)))?._result;
    }
}