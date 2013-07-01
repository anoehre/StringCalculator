using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using dff.Extensions;

namespace StringCalculator
{
    public class StringCal
    {
        public int Add(string lineOfText)
        {
            if (string.IsNullOrEmpty(lineOfText)) return 0;

            var singleCharSeperators = new List<char> {',', '\n'};
            
            var customSeperator = StringSpereratorGet(lineOfText);
            if (customSeperator!=null && customSeperator.Any()) 
                lineOfText = RemoveStringSeperatorLine(lineOfText);

            var extendedList = new List<string>();
            var listSplittedOnDefaultSeperators = lineOfText.Split(singleCharSeperators.ToArray()).ToList();

            if (customSeperator != null && customSeperator.Any())
            {
                foreach (var item in listSplittedOnDefaultSeperators)
                {
                    var stringSeparators = customSeperator.ToArray();
                    extendedList.AddRange(item.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList());
                }
            }
            else extendedList = listSplittedOnDefaultSeperators;

            return extendedList.Where(x=>x.TryToInt()<1000).Sum(s => s.TryToInt());
        }

        private static string RemoveStringSeperatorLine(string line)
        {
            line = line.Substring(line.IndexOf("\n", System.StringComparison.Ordinal) + 1);
            return line;
        }

        private static List<string> StringSpereratorGet(string line)
        {
            var seperators= new List<string>();
            if (line.StartsWith("//"))
            {
                var x = line.Substring(2, line.IndexOf("\n", System.StringComparison.Ordinal) - 2);
                seperators = x.Split(',').ToList();
            }
            return seperators;
        }
    }
}