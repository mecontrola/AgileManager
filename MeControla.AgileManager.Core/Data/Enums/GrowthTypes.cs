using System.ComponentModel;

namespace MeControla.AgileManager.Core.Data.Enums
{
    public enum GrowthTypes : uint
    {
        [Description("Growth To Do")]
        ToDo = 1,
        [Description("Growth In Progress")]
        InProgress = 2,
    }
}