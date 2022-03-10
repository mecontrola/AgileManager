using Stefanini.ViaReport.Core.Data.Dto.Jira;
using Stefanini.ViaReport.Core.Data.Enums;
using Stefanini.ViaReport.Core.Integrations.Jira.V2.Statuses;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public abstract class BaseStatusService : IBaseStatusService
    {
        private readonly IStatusGetAll statusGetAll;

        protected BaseStatusService(IStatusGetAll statusGetAll)
        {
            this.statusGetAll = statusGetAll;
        }

        protected abstract StatusCategories GetStatusCategory();

        public async Task<IDictionary<string, string>> GetList(string username, string password, CancellationToken cancellationToken)
        {
            var data = await statusGetAll.Execute(username, password, cancellationToken);

            return data.Where(x => IsStatusCategory(x))
                       .ToDictionary(x => x.Id,
                                     x => x.Name);
        }

        private bool IsStatusCategory(StatusDto status)
            => status.StatusCategory.Id == (int)GetStatusCategory();
    }
}