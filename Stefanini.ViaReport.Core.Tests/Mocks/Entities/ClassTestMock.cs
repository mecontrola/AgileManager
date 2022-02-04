using Stefanini.ViaReport.Core.Tests.Data.Entities;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Entities
{
    public class ClassTestMock
    {
        public static ClassTest Create()
            => new()
            {
                FieldInClass1 = DataMock.VALUE_DEFAULT_5,
                FieldInClass2 = DataMock.VALUE_DEFAULT_9,
                FieldDateTime = DataMock.DATETIME_DEFAULT
            };

        public static ClassTest CreateNoDateTime()
            => new()
            {
                FieldInClass1 = DataMock.VALUE_DEFAULT_5,
                FieldInClass2 = DataMock.VALUE_DEFAULT_9
            };
    }
}