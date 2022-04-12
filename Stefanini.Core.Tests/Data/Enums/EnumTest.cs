using System.ComponentModel;

namespace Stefanini.Core.Tests.Data.Enums
{
    public enum EnumTest : uint
    {
        [Description("Test")]
        Element1 = 1,
        Element2 = 2
    }
}