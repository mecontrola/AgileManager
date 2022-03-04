using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Stefanini.Core.Extensions
{
    public static class ObservableCollectionExtensions
    {
        [DebuggerStepThrough]
        public static void AddList<T>(this ObservableCollection<T> obj, IEnumerable<T> list)
        {
            obj.Clear();

            foreach (var item in list)
                obj.Add(item);
        }
    }
}