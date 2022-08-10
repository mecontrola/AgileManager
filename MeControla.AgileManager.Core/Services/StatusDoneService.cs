using MeControla.AgileManager.Core.Integrations.Jira.V2.Statuses;
using MeControla.AgileManager.Data.Enums;

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