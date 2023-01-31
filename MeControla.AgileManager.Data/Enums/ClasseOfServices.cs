using System.ComponentModel;

namespace MeControla.AgileManager.Data.Enums
{
    public enum ClasseOfServices : uint
    {
        [Description("Standard")]
        Standard = 1,
        [Description("Expedite")]
        Expedite = 2,
        [Description("Fixed Date")]
        FixedDate = 3,
        [Description("Intangible")]
        Intangible = 4
    }
}