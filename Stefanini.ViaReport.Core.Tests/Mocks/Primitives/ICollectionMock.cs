using System;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Primitives
{
    public class ICollectionMock
    {
        public static ICollection<string> CreateEmpty()
            => Array.Empty<string>().ToList();

        public static ICollection<string> CreateFill()
            => new[] { 1, 2, 3 }.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToList();

        public static ICollection<string> CreateFill2()
            => new[] { 4, 5, 6 }.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}").ToList();
    }
}