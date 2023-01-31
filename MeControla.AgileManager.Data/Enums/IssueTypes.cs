using System.ComponentModel;

namespace MeControla.AgileManager.Data.Enums
{
    public enum IssueTypes : uint
    {
        [Description("Bug")]
        Bug = 1,
        [Description("Task")]
        Task = 2,
        [Description("Sub-task")]
        SubTask = 3,
        [Description("Epic")]
        Epic = 4,
        [Description("Story")]
        Story = 5,
        [Description("Poc")]
        Poc = 6,
        [Description("Spike")]
        Spike = 7,
        [Description("Technical Debt")]
        TechnicalDebt = 8,
        [Description("Technical Improvement")]
        Improvement = 9,
    }
}