using Microsoft.EntityFrameworkCore;
using Stefanini.Core.Repositories;
using Stefanini.ViaReport.Data.Entities;

namespace Stefanini.ViaReport.DataStorage
{
    public interface IDbAppContext : IDbContext
    {
        DbSet<Project> Projects { get; }
        DbSet<ProjectCategory> ProjectCategories { get; }
    }
}