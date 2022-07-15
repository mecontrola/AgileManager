using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Data.Enums;

namespace Stefanini.ViaReport.Core.Services
{
    public class StatusInProgressService : BaseStatusService, IStatusInProgressService
    {
        public StatusInProgressService(IStatusGetAll statusGetAll)
            : base(statusGetAll)
        { }

        protected override StatusCategories GetStatusCategory()
            => StatusCategories.InProgress;
    }
}