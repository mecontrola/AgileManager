using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Stefanini.ViaReport.Extensions
{
    public static class ComboBoxExtensions
    {
        public static bool IsItemsSourceNull(this ComboBox obj)
            => obj != null
            && obj.ItemsSource == null;

        public static IList<T> GetSourceCollection<T>(this ComboBox obj)
        {
            var list = obj.ItemsSource as ListCollectionView;

            return list.SourceCollection as IList<T>;
        }

        public static T GetSelectedValue<T>(this ComboBox obj)
            where T : class
            => obj.SelectedIndex == 0
             ? null
             : (T)obj.SelectedItem;

        public static int GetItemIndexOf<T>(this ComboBox obj, Func<T, bool> predicate)
            where T : class
        {
            if (obj == null || obj.IsItemsSourceNull())
                return 0;

            return GetItemIndexInList(obj.GetSourceCollection<T>(), predicate);
        }

        private static int GetItemIndexInList<T>(IList<T> list, Func<T, bool> predicate)
            where T : class
            => list.Select((value, index) => new { value, index })
                   .FirstOrDefault(x => predicate(x.value))
                  ?.index
            ?? 0;
    }
}