using System.ComponentModel;

namespace MeControla.Kernel.Tests.Data.Enums
{
    public enum EnumTest : uint
    {
        [Description("Test")]
        Element1 = 1,
        Element2 = 2
    }
}