using Stefanini.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(IDbAppContext context)
            : base(context, context.Projects)
        { }
    }
}