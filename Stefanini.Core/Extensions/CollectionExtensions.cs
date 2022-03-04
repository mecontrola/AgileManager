using System.Collections.Generic;
using System.Diagnostics;

namespace Stefanini.Core.Extensions
{
    public static class CollectionExtensions
    {
        [DebuggerStepThrough]
        public static void AddList<T>(this ICollection<T> obj, IEnumerable<T> list)
        {
            obj.Clear();

            foreach (var item in list)
                obj.Add(item);
        }
    }
}