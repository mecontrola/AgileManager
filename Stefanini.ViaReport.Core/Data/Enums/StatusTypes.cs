using System.ComponentModel;

namespace Stefanini.ViaReport.Core.Data.Enums
{
    public enum StatusTypes : uint
    {
        [Description("Cancelled")]
        Cancelled = 1,
        [Description("Removed")]
        Removed,
        [Description("Done")]
        Done
    }
}