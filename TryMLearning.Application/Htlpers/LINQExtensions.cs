using System.Collections.Generic;
using System.Linq;

namespace TryMLearning.Application.Htlpers
{
    public static class LINQExtensions
    {
        public static IEnumerable<T[]> SplitOnBlocks<T>(this IEnumerable<T> source, int parts)
        {
            int i = 0;
            var splits = from item in source
                         group item by i++ % parts into part
                         select part.ToArray();

            return splits;
        }
    }
}