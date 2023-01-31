using System.ComponentModel;

namespace MeControla.AgileManager.Data.Enums
{
    public enum StatusCategories : uint
    {
        [Description("No Category")]
        NoCategory = 1,
        [Description("To Do")]
        ToDo = 2,
        [Description("In Progress")]
        InProgress = 3,
        [Description("Done")]
        Done = 4
    }
}