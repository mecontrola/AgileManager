using System.Collections.Generic;

namespace MeControla.Kernel.Extensions
{
    public static class CollectionExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static void AddList<T>(this ICollection<T> obj, IEnumerable<T> list)
        {
            obj.Clear();

            foreach (var item in list)
                obj.Add(item);
        }
    }
}