using System.ComponentModel;

namespace MeControla.AgileManager.Data.Enums
{
    public enum PeriodTypes : uint
    {
        [Description("Sprint")]
        Sprint = 1,
        [Description("Cycle")]
        Cycle = 2,
    }
}