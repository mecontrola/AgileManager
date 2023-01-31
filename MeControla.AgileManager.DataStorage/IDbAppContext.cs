using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeControla.AgileManager.DataStorage
{
    public interface IDbAppContext : IDbContext
    {
        DbSet<ClassOfService> ClasseOfServices { get; }
        DbSet<CustomField> CustomFields { get; }
        DbSet<Deploy> Deploys { get; }
        DbSet<Issue> Issues { get; }
        DbSet<IssueCustomfieldData> IssueCustomfieldDatas { get; }
        DbSet<IssueEpic> IssueEpics { get; }
        DbSet<IssueExtraData> IssueExtraDatas { get; }
        DbSet<IssueImpediment> IssueImpediments { get; }
        DbSet<IssueStatusHistory> IssueStatusHistories { get; }
        DbSet<IssueType> IssueTypes { get; }
        DbSet<PreferenceClassOfService> PreferenceClasseOfServices { get; }
        DbSet<PreferenceCustomField> PreferenceCustomFields { get; }
        DbSet<PreferenceIssueType> PreferenceIssueTypes { get; }
        DbSet<PreferenceStatus> PreferenceStatuses { get; }
        DbSet<PreferenceStatusCategory> PreferenceStatusCategories { get; }
        DbSet<Project> Projects { get; }
        DbSet<ProjectCategory> ProjectCategories { get; }
        DbSet<Quarter> Quarters { get; }
        DbSet<Status> Statuses { get; }
        DbSet<StatusCategory> StatusCategories { get; }
    }
}