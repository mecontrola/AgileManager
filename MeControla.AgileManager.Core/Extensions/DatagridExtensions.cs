using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.AgileManager.Core.Extensions
{
    public static class DatagridExtensions
    {
        public static IList<T> GetSelectedItems<T>(this IEnumerable enumerable, Func<T, bool> predicate)
            => enumerable?.Cast<T>()
                          .Where(predicate)
                          .ToList()
            ?? new List<T>();
    }
}
