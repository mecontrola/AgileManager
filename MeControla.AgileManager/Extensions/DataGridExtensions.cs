using MeControla.Core.Extensions;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MeControla.AgileManager.Extensions
{
    public static class DataGridExtensions
    {
        public static void Fill<TSource>(this DataGrid grid, ICollection<TSource> collection, IList<TSource> items)
        {
            collection.Clear();
            collection.AddList(items);

            grid.ItemsSource = collection;
        }
    }
}