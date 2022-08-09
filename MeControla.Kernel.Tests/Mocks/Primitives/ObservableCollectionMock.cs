using System.Collections.ObjectModel;
using System.Linq;

namespace MeControla.Kernel.Tests.Mocks.Primitives
{
    public class ObservableCollectionMock
    {
        public static ObservableCollection<string> CreateEmpty()
            => new();

        public static ObservableCollection<string> CreateFill()
            => FillObservableCollection(new[] { 1, 2, 3 }.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToArray());

        public static ObservableCollection<string> CreateFill2()
            => FillObservableCollection(new[] { 4, 5, 6 }.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToArray());

        private static ObservableCollection<T> FillObservableCollection<T>(T[] values)
        {
            var obj = new ObservableCollection<T>();

            foreach (var value in values)
                obj.Add(value);

            return obj;
        }
    }
}