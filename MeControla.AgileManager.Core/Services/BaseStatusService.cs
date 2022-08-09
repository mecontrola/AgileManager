using MeControla.AgileManager.Core.Integrations.Jira.V2.Statuses;
using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
{
    public abstract class BaseStatusService : IBaseStatusService
    {
        private readonly IStatusGetAll statusGetAll;

        protected BaseStatusService(IStatusGetAll statusGetAll)
        {
            this.statusGetAll = statusGetAll;
        }

        protected abstract StatusCategories GetStatusCategory();

        public async Task<IDictionary<string, string>> GetList(CancellationToken cancellationToken)
        {
            var data = await statusGetAll.Execute(cancellationToken);

            return data.Where(x => IsStatusCategory(x))
                       .ToDictionary(x => x.Id,
                                     x => x.Name);
        }

        private bool IsStatusCategory(StatusDto status)
            => status.StatusCategory.Id == (int)GetStatusCategory();
    }
}