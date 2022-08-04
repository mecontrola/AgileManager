using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using Stefanini.ViaReport.Data.Enums;

namespace Stefanini.ViaReport.Core.Services
{
    public class StatusDoneService : BaseStatusService, IStatusDoneService
    {
        public StatusDoneService(IStatusGetAll statusGetAll)
            : base(statusGetAll)
        { }

        protected override StatusCategories GetStatusCategory()
            => StatusCategories.Done;
    }
}