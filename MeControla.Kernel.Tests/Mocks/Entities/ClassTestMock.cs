using MeControla.Kernel.Tests.Data.Entities;

namespace MeControla.Kernel.Tests.Mocks.Entities
{
    public class ClassTestMock
    {
        public static ClassTest Create()
            => new()
            {
                FieldInClass1 = DataMock.VALUE_DEFAULT_5,
                FieldInClass2 = DataMock.VALUE_DEFAULT_9,
                FieldDateTime = DataMock.DATETIME_QUARTER_2_2000
            };

        public static ClassTest CreateNoDateTime()
            => new()
            {
                FieldInClass1 = DataMock.VALUE_DEFAULT_5,
                FieldInClass2 = DataMock.VALUE_DEFAULT_9
            };
    }
}