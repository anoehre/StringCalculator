#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace StringCalculator
{
    public class StringClac
    {
        public int Add(string line)
        {
            if (string.IsNullOrEmpty(line)) return 0;

            var separator = new List<string> {",", "\n"};
            if (line.StartsWith("//"))
            {
                separator.AddRange(line.Substring(2, line.IndexOf("\n", StringComparison.Ordinal) - 2).Split(','));
                line = line.Substring(line.IndexOf("\n", StringComparison.Ordinal) + 1);
            }

            var numbers = line.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            if (numbers.Any(x => int.Parse(x) < 0)) throw new Exception("Negatives not allowed");

            return numbers.Where(x => int.Parse(x) <= 1000).Sum(number => int.Parse(number));
        }
    }
}