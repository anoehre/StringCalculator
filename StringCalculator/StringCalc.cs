using System;
using System.Collections.Generic;
using System.Linq;
using dff.Extensions;

namespace StringCalculator
{
    public class StringCalc
    {
        public int Add(string line)
        {
            if (string.IsNullOrEmpty(line)) return 0;
            var result = 0;

            var separator = new List<string> { ",", "\n" };
            if (line.StartsWith("//"))
            {
                var speratorLine=line.Substring(2, line.IndexOf("\n", StringComparison.Ordinal)-2);
                separator.AddRange(speratorLine.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
                line = line.Substring(line.IndexOf("\n", StringComparison.Ordinal) + 1);
            }
            
            var items = line.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var errorItems = new List<string>();
            foreach (var item in items)
            {
                int parsedInteger = item.TryToInt();
                if (parsedInteger<0) errorItems.Add(item);
                if (parsedInteger > 1000) parsedInteger = 0;
                result += parsedInteger;    
            }

            if (errorItems.Any())
                throw new Exception("Negative Value detected!: " + errorItems.Aggregate( (s,e) => s+","+e));

            return result;
        }
    }
}