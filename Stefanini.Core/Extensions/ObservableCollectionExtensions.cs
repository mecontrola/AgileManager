using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Stefanini.Core.Extensions
{
    public static class ObservableCollectionExtensions
    {
#if !DEBUG
        [System.Diagnostics.DebuggerStepThrough]
#endif
        public static void AddList<T>(this ObservableCollection<T> obj, IEnumerable<T> list)
        {
            obj.Clear();

            foreach (var item in list)
                obj.Add(item);
        }
    }
}