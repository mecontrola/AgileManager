using System.ComponentModel;

namespace MeControla.AgileManager.Data.Enums
{
    public enum StatusTypes : uint
    {
        [Description("Cancelled")]
        Cancelled = 10717,
        [Description("Removed")]
        Removed = 11709,
        [Description("Done")]
        Done = 10214
    }
}