using System.ComponentModel;

namespace Stefanini.ViaReport.Data.Enums
{
    public enum LeadTimes : uint
    {
        [Description("Customer Lead Time")]
        Customer = 1,
        [Description("Discovery Lead Time")]
        Discovery,
        [Description("System Lead Time")]
        System
    }
}