using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.Integrations.Jira.Rest.V3.Statuses;

namespace MeControla.AgileManager.Core.Services
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