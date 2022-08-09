using MeControla.Kernel.Tests.Data.Entities;

namespace MeControla.Kernel.Tests.Mocks.Entities
{
    public class ClassTestConfigurationMock
    {
        public static ClassTestConfiguration CreateEmpty()
            => new();

        public static ClassTestConfiguration Create()
            => new()
            {
                FieldInClass1 = DataMock.VALUE_DEFAULT_5,
                FieldInClass2 = DataMock.VALUE_DEFAULT_9,
            };
    }
}