using Microsoft.EntityFrameworkCore;
using Stefanini.ViaReport.Data.Entities;
using Stefanini.ViaReport.DataStorage;
using System;

namespace Stefanini.ViaReport.Core.Tests.Mocks.Repositories
{
    public abstract class BaseRepository
    {
        public static IDbAppContext GetDbInstance()
        {
            var context = new DbAppContext(CreateDbOptions());

            Seed(context);

            return context;
        }

        private static DbContextOptions<DbAppContext> CreateDbOptions()
            => new DbContextOptionsBuilder<DbAppContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        private static void Seed(DbAppContext context)
        {
            var issueTypes = new IssueType[]
            {
                new() { Id = 1, Uuid = Guid.Parse("6D430F8B-8048-44F0-82BA-2B63F6DEDDCD"), Key = 1, Name = "Bug" },
                new() { Id = 2, Uuid = Guid.Parse("816A24D3-0EC8-4DDF-8AE6-90040A94A1F9"), Key = 3, Name = "Task" },
                new() { Id = 3, Uuid = Guid.Parse("4B2CA961-6CF0-47F6-B829-2B6DBA08B756"), Key = 4, Name = "Technical Improvement" },
                new() { Id = 4, Uuid = Guid.Parse("E9BF1468-D088-4217-B81D-1A1C2A995EE3"), Key = 5, Name = "Sub-task" },
                new() { Id = 5, Uuid = Guid.Parse("14E94EAE-D997-4E2F-9C21-0F6B3A0CD00D"), Key = 6, Name = "Epic" },
                new() { Id = 6, Uuid = Guid.Parse("5F10718D-29E5-49BD-879C-8517EBCEA345"), Key = 7, Name = "Story" },
            };

            var projects = new Project[]
            {
                new() { Id = 1, Uuid = Guid.Parse("FC4298AB-47B8-43F0-BE9D-4F0E4E3EEC71"), Key = 21018, Name = "Search", ProjectCategoryId = 1, Selected = true },
                new() { Id = 2, Uuid = Guid.Parse("380C1025-881A-49BF-813A-025C71E7D11D"), Key = 21021, Name = "Loyalty", ProjectCategoryId = 4, Selected = true },
                new() { Id = 3, Uuid = Guid.Parse("4FA18144-78F8-40D2-8DDE-BA8129DE31FE"), Key = 16313, Name = "Core Apps", ProjectCategoryId = 1, Selected = false },
                new() { Id = 4, Uuid = Guid.Parse("CCE656A3-BFE7-4C1D-8C6F-3478BFCD73FB"), Key = 20209, Name = "Choose", ProjectCategoryId = 1, Selected = false },
            }; 

            var statusCategories = new StatusCategory[]
            {
                new() { Id = 1, Uuid = Guid.Parse("2A36DD15-F66F-4B23-A825-8020F0BE130E"), Key = 1, Name = "No Category" },
                new() { Id = 2, Uuid = Guid.Parse("EA1F5CFB-FF4E-442B-927F-178540D1C1FC"), Key = 2, Name = "To Do" },
                new() { Id = 3, Uuid = Guid.Parse("6E90BC59-7314-496B-98BD-236D17406521"), Key = 4, Name = "In Progress" },
                new() { Id = 4, Uuid = Guid.Parse("3FA0D74C-6C56-4127-A47F-75D41A6B32E1"), Key = 3, Name = "Done" },
            };

            var statuses = new Status[]
            {
                new() { Id = 1, Uuid = Guid.Parse("57894093-08E5-4D2A-B153-ADBB653211CD"), Key = 1, Name = "Aberto", StatusCategoryId = 2 },
                new() { Id = 2, Uuid = Guid.Parse("0CB70F4C-BDD4-44B1-A6EA-7B8B6913E6DF"), Key = 3, Name = "Doing", StatusCategoryId = 3 },
                new() { Id = 3, Uuid = Guid.Parse("B47FB708-052D-4577-89BA-EA1D8840EB83"), Key = 4, Name = "Reaberto", StatusCategoryId = 2 },
                new() { Id = 4, Uuid = Guid.Parse("A8C3F00D-39B9-4EC9-9EF7-871BF3BDABF7"), Key = 5, Name = "Resolvido", StatusCategoryId = 4 },
                new() { Id = 5, Uuid = Guid.Parse("0A4C6FC3-498F-40E1-9CCA-56D0838C28C8"), Key = 6, Name = "Fechado", StatusCategoryId = 4 },
            };

            var issues = new Issue[]
            {
                new() { Id = 1, Uuid = Guid.Parse("97D319F3-E03C-4A3D-8F74-EBB81B259BA8"), Key = "SEA-1", Summary = "Teste de permissão", Incident = false, Updated = DateTime.Parse("2021-08-26 14:24:28.367"), ProjectId = 2, StatusId = 5, IssueTypeId = 3 },
                new() { Id = 2, Uuid = Guid.Parse("882DF254-8915-4B19-A372-217CB10A4D21"), Key = "SEA-2", Summary = "Teste de permissão 2", Incident = false, Updated = DateTime.Parse("2021-08-26 16:28:28.367"), ProjectId = 2, StatusId = 5, IssueTypeId = 1 },
            };

            context.IssueTypes.AddRange(issueTypes);
            context.Projects.AddRange(projects);
            context.StatusCategories.AddRange(statusCategories);
            context.Statuses.AddRange(statuses);
            context.Issues.AddRange(issues);
            context.SaveChanges();
        }
    }
}