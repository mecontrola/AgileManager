using System.ComponentModel;

namespace MeControla.AgileManager.Data.Enums
{
    public enum CustomFields : uint
    {
        [Description("Story Points")]
        StoryPoints = 1,
        [Description("Sprint")]
        Sprint,
        [Description("Impediment")]
        Impediment,
        [Description("Class of Service")]
        ClassOfService
    }
}