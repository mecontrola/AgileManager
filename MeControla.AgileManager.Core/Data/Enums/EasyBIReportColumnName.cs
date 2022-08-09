using System.ComponentModel;

namespace MeControla.AgileManager.Core.Data.Enums
{
    public enum EasyBIReportColumnName : uint
    {
        [Description("In Progress")]
        InProgress = 1,
        [Description("To Do")]
        ToDo = 2,
        [Description("Done")]
        Done = 3
    }
}