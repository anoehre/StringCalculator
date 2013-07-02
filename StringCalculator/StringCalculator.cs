#region

using System;
using System.Collections.Generic;
using System.Linq;
using dff.Extensions;

#endregion

namespace StringCalculator2013_07_02
{
    public class StringCalculator
    {
        public int Add(string line)
        {
            if (string.IsNullOrEmpty(line))
                return 0;

            var customSperator = new List<string>();
            if (line.StartsWith("//"))
            {
                var seperatorLine = line.Substring(2, line.IndexOf("\n", StringComparison.Ordinal) - 2);
                customSperator = seperatorLine.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                line = line.Substring(line.IndexOf("\n", StringComparison.Ordinal) + 1);
            }
            var itemsToAdd = line.Split(",\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var extendedItemsToAdd = new List<string>();
            if (customSperator.Any())
            {
                foreach (var item in itemsToAdd)
                {
                    var customSplit = item.Split(customSperator.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    extendedItemsToAdd.AddRange(customSplit);
                }
            }
            else extendedItemsToAdd = itemsToAdd.ToList();

            return extendedItemsToAdd.Where(x => x.TryToInt() <= 1000).Sum(s => s.TryToInt());
        }
    }
}