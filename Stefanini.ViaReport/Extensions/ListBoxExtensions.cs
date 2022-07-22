using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Stefanini.ViaReport.Extensions
{
    public static class ListBoxExtensions
    {
        public static IList<T> ToListData<T>(this ListBox obj)
            => obj.ItemsSource
                  .Cast<T>()
                  .ToList();

        public static void Fill<T>(this ListBox obj, IList<T> items)
            => Fill(obj, items, Array.Empty<string>());

        public static void Fill<T>(this ListBox obj, IList<T> items, IList<string> propertyGroupDescriptions)
        {
            var lcv = new ListCollectionView((System.Collections.IList)items);

            foreach (var propertyGroupDescription in propertyGroupDescriptions)
                lcv.GroupDescriptions.Add(new PropertyGroupDescription(propertyGroupDescription));

            obj.ItemsSource = lcv;
        }

        public static object GetData(this ListBox source, Point point)
        {
            var element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }

            return null;
        }
    }
}