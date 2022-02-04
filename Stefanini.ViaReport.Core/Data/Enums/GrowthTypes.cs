using System.ComponentModel;

namespace Stefanini.ViaReport.Core.Data.Enums
{
    public enum GrowthTypes : uint
    {
        [Description("Growth To Do")]
        ToDo = 1,
        [Description("Growth In Progress")]
        InProgress = 2,
    }
}