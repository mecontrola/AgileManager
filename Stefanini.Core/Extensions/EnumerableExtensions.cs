using System;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.Core.Extensions
{
    public static class EnumerableExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
            => source.Select(selector)
                     .Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);

#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static TimeSpan Average<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
            => source.Sum(selector) / source.Count();
    }
}