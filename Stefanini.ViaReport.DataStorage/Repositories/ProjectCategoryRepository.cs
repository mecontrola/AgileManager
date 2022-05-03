using Stefanini.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class ProjectCategoryRepository : BaseRepository<ProjectCategory>, IProjectCategoryRepository
    {
        public ProjectCategoryRepository(IDbAppContext context)
            : base(context, context.ProjectCategories)
        { }
    }
}