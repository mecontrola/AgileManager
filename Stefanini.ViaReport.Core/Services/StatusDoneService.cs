using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;

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