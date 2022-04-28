using System.Collections.Generic;
using System.Linq;

namespace Stefanini.Core.Tests.Mocks.Primitives
{
    public class IEnumerableMock
    {
        public static IEnumerable<string> CreateFill()
            => new[] { 4, 5, 6 }.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}");
    }
}