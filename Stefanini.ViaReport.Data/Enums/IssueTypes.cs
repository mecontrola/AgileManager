using System.ComponentModel;

namespace Stefanini.ViaReport.Data.Enums
{
    public enum IssueTypes
    {
        [Description("Bug")]
        Bug = 1,
        [Description("Task")]
        Task = 3,
        [Description("Technical Improvement")]
        Improvement = 4,
        [Description("Sub-task")]
        SubTask = 5,
        [Description("Epic")]
        Epic = 6,
        [Description("Story")]
        Story = 7,
        [Description("Technical Debt")]
        TechnicalDebt = 12200
    }
}