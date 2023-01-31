using MeControla.AgileManager.Data.Entities;
using MeControla.AgileManager.Data.Enums;
using MeControla.AgileManager.DataStorage;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeControla.AgileManager.Core.Tests.Mocks.Repositories
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
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("6D430F8B-8048-44F0-82BA-2B63F6DEDDCD"), Key = (int)IssueTypes.Bug, Name = "Bug" },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("816A24D3-0EC8-4DDF-8AE6-90040A94A1F9"), Key = (int)IssueTypes.Task, Name = "Task" },
                new() { Id = DataMock.INT_ID_3, Uuid = Guid.Parse("4B2CA961-6CF0-47F6-B829-2B6DBA08B756"), Key = (int)IssueTypes.Improvement, Name = "Technical Improvement" },
                new() { Id = DataMock.INT_ID_4, Uuid = Guid.Parse("E9BF1468-D088-4217-B81D-1A1C2A995EE3"), Key = (int)IssueTypes.SubTask, Name = "Sub-task" },
                new() { Id = DataMock.INT_ID_5, Uuid = Guid.Parse("14E94EAE-D997-4E2F-9C21-0F6B3A0CD00D"), Key = (int)IssueTypes.Epic, Name = "Epic" },
                new() { Id = DataMock.INT_ID_6, Uuid = Guid.Parse("5F10718D-29E5-49BD-879C-8517EBCEA345"), Key = (int)IssueTypes.Story, Name = "Story" },
            };

            var projects = new Project[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("FC4298AB-47B8-43F0-BE9D-4F0E4E3EEC71"), Key = 21018, Name = "Search", ProjectCategoryId = DataMock.INT_ID_2, Selected = true, },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("380C1025-881A-49BF-813A-025C71E7D11D"), Key = 21021, Name = "Loyalty", ProjectCategoryId = DataMock.INT_ID_5, Selected = true },
                new() { Id = DataMock.INT_ID_3, Uuid = Guid.Parse("4FA18144-78F8-40D2-8DDE-BA8129DE31FE"), Key = 16313, Name = "Core Apps", ProjectCategoryId = DataMock.INT_ID_2, Selected = false },
                new() { Id = DataMock.INT_ID_4, Uuid = Guid.Parse("CCE656A3-BFE7-4C1D-8C6F-3478BFCD73FB"), Key = 20209, Name = "Choose", ProjectCategoryId = DataMock.INT_ID_2, Selected = false },
            };

            var quarters = new Quarter[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("9B4858AB-0F94-476D-BE7F-BC0A01456753"), Name = DataMock.TEXT_QUARTER_3_1999 },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("AFE641A1-5447-45CF-9B21-09402E301037"), Name = DataMock.TEXT_QUARTER_4_1999 },
                new() { Id = DataMock.INT_ID_3, Uuid = Guid.Parse("C9AC28DB-1B89-4D7C-BEAB-12A39C3304A3"), Name = DataMock.TEXT_QUARTER_1_2000 },
                new() { Id = DataMock.INT_ID_4, Uuid = Guid.Parse("C6E9B8F7-3137-4B6A-8DDE-A431D5B3A3EE"), Name = DataMock.TEXT_QUARTER_2_2000 },
                new() { Id = DataMock.INT_ID_5, Uuid = Guid.Parse("CB71694D-B23D-4A95-B9A1-89BA454E2820"), Name = DataMock.TEXT_QUARTER_3_2000 },
                new() { Id = DataMock.INT_ID_6, Uuid = Guid.Parse("C48AD8A0-3F4E-4292-96C1-A7920E8A9821"), Name = DataMock.TEXT_QUARTER_4_2000 },
            };

            var statusCategories = new StatusCategory[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("2A36DD15-F66F-4B23-A825-8020F0BE130E"), Key = (int)StatusCategories.NoCategory, Name = "No Category" },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("EA1F5CFB-FF4E-442B-927F-178540D1C1FC"), Key = (int)StatusCategories.ToDo, Name = "To Do" },
                new() { Id = DataMock.INT_ID_3, Uuid = Guid.Parse("6E90BC59-7314-496B-98BD-236D17406521"), Key = (int)StatusCategories.InProgress, Name = "In Progress" },
                new() { Id = DataMock.INT_ID_4, Uuid = Guid.Parse("3FA0D74C-6C56-4127-A47F-75D41A6B32E1"), Key = (int)StatusCategories.Done, Name = "Done" },
            };

            var statuses = new Status[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("57894093-08E5-4D2A-B153-ADBB653211CD"), Key = DataMock.INT_ID_1, Name = "Aberto", StatusCategoryId = DataMock.INT_ID_2 },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("0CB70F4C-BDD4-44B1-A6EA-7B8B6913E6DF"), Key = DataMock.INT_ID_3, Name = "Doing", StatusCategoryId = DataMock.INT_ID_3 },
                new() { Id = DataMock.INT_ID_3, Uuid = Guid.Parse("B47FB708-052D-4577-89BA-EA1D8840EB83"), Key = DataMock.INT_ID_4, Name = "Reaberto", StatusCategoryId = DataMock.INT_ID_2 },
                new() { Id = DataMock.INT_ID_4, Uuid = Guid.Parse("A8C3F00D-39B9-4EC9-9EF7-871BF3BDABF7"), Key = DataMock.INT_ID_5, Name = "Resolvido", StatusCategoryId = DataMock.INT_ID_4 },
                new() { Id = DataMock.INT_ID_5, Uuid = Guid.Parse("0A4C6FC3-498F-40E1-9CCA-56D0838C28C8"), Key = DataMock.INT_ID_6, Name = "Done", StatusCategoryId = DataMock.INT_ID_4 },
            };

            var issues = new Issue[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("97D319F3-E03C-4A3D-8F74-EBB81B259BA8"), Key = DataMock.ISSUE_KEY_1, Summary = DataMock.ISSUE_SUMMARY_1, Incident = false, Updated = DateTime.Parse("2021-08-26 14:24:28.367"), ProjectId = DataMock.INT_ID_1, StatusId = DataMock.INT_ID_5, IssueTypeId = DataMock.INT_ID_3, Link = DataMock.ISSUE_LINK_1, Created = DateTime.Parse("2021-08-23 10:09:47.936"), Resolved = DateTime.Parse("2021-09-29 10:09:47.936") },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("882DF254-8915-4B19-A372-217CB10A4D21"), Key = DataMock.ISSUE_KEY_2, Summary = DataMock.ISSUE_SUMMARY_2, Incident = false, Updated = DateTime.Parse("2021-08-26 16:28:28.367"), ProjectId = DataMock.INT_ID_1, StatusId = DataMock.INT_ID_5, IssueTypeId = DataMock.INT_ID_1, Link = DataMock.ISSUE_LINK_2, Created = DateTime.Parse("2021-07-20 15:23:52.745"), Resolved = DateTime.Parse("2021-09-29 15:23:52.745") },
                new() { Id = DataMock.INT_ID_3, Uuid = Guid.Parse("40637157-767A-41EA-B718-6EC372B120D2"), Key = DataMock.ISSUE_KEY_3, Summary = DataMock.ISSUE_SUMMARY_3, Incident = false, Updated = DateTime.Parse("2021-08-26 14:24:28.367"), ProjectId = DataMock.INT_ID_1, StatusId = DataMock.INT_ID_5, IssueTypeId = DataMock.INT_ID_5, Link = DataMock.ISSUE_LINK_3, Created = DateTime.Parse("2021-08-23 09:34:35.538"), Resolved = DateTime.Parse("2021-09-29 09:34:35.538") },
            };

            var issueStatusHistories = new IssueStatusHistory[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("9A4962CE-802C-48BC-BB22-41EFA94E4809"), DateTime = DateTime.Parse("2021-08-23 10:09:47.936"), IssueId = DataMock.INT_ID_1, FromStatusId = DataMock.INT_ID_1 },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("8D946486-87C0-4578-8121-96057DE489A8"), DateTime = DateTime.Parse("2021-08-23 09:51:45.826"), IssueId = DataMock.INT_ID_1, FromStatusId = DataMock.INT_ID_2 },
                new() { Id = DataMock.INT_ID_3, Uuid = Guid.Parse("216CC531-A6BC-4BF3-A98C-33650C7C55BF"), DateTime = DateTime.Parse("2021-08-24 16:53:16.348"), IssueId = DataMock.INT_ID_1, FromStatusId = DataMock.INT_ID_3 },
                new() { Id = DataMock.INT_ID_4, Uuid = Guid.Parse("8D38C898-BE22-4D7A-A801-59E7ECBB2E5B"), DateTime = DataMock.DATETIME_FIRST_HISTORY_FINDED, IssueId = DataMock.INT_ID_1, FromStatusId = DataMock.INT_ID_4 },
                new() { Id = DataMock.INT_ID_5, Uuid = Guid.Parse("54E15017-E03D-4BAE-8746-EFE0D3AF4971"), DateTime = DateTime.Parse("2021-08-26 14:24:28.367"), IssueId = DataMock.INT_ID_1, FromStatusId = DataMock.INT_ID_5 },
                new() { Id = DataMock.INT_ID_6, Uuid = Guid.Parse("EAB43272-599C-471F-AE77-1CFA480F027D"), DateTime = DateTime.Parse("2021-08-23 10:09:47.936"), IssueId = DataMock.INT_ID_3, FromStatusId = DataMock.INT_ID_1 },
                new() { Id = DataMock.INT_ID_7, Uuid = Guid.Parse("AEC7380A-1F68-4FFE-9BCB-90C11BA3FDDA"), DateTime = DateTime.Parse("2021-08-23 09:51:45.826"), IssueId = DataMock.INT_ID_3, FromStatusId = DataMock.INT_ID_2 },
                new() { Id = 8, Uuid = Guid.Parse("3087011D-B710-4AAC-8302-28D1D5DC05EF"), DateTime = DateTime.Parse("2021-08-24 16:53:16.348"), IssueId = DataMock.INT_ID_3, FromStatusId = DataMock.INT_ID_3 },
                new() { Id = 9, Uuid = Guid.Parse("CB9D1186-E319-4D5A-9171-E8AAD18B6A7F"), DateTime = DateTime.Parse("2021-08-25 11:18:57.876"), IssueId = DataMock.INT_ID_3, FromStatusId = DataMock.INT_ID_4 },
                new() { Id = 10, Uuid = Guid.Parse("2236EBB3-41FF-4588-A567-AACD155EFFDC"), DateTime = DateTime.Parse("2021-08-26 14:24:28.367"), IssueId = DataMock.INT_ID_3, FromStatusId = DataMock.INT_ID_5 },
            };

            var issueImpediments = new IssueImpediment[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("BF0B986D-7C96-46FA-9DFD-403C468E0C10"), Start = DateTime.Parse("2021-08-30 10:36:18.762"), End = DateTime.Parse("2021-08-31 09:42:24.384"), IssueId = DataMock.INT_ID_1 },
                new() { Id = DataMock.INT_ID_2, Uuid = Guid.Parse("B5B68AE0-60C3-4E82-B19D-39ED408018BA"), Start = DateTime.Parse("2021-09-06 16:52:49.375"), End = null, IssueId = DataMock.INT_ID_1 },
            };

            var issueEpics = new IssueEpic[]
            {
                new() { Id = DataMock.INT_ID_1, Uuid = Guid.Parse("A535A8E6-0587-4BDA-BAB7-8F243A73AD26"), QuarterId = DataMock.INT_ID_3, Progress = DataMock.VALUE_DEFAULT_50, IssueId = DataMock.INT_ID_3 }
            };

            context.IssueTypes.AddRange(issueTypes);
            context.Projects.AddRange(projects);
            context.Quarters.AddRange(quarters);
            context.StatusCategories.AddRange(statusCategories);
            context.Statuses.AddRange(statuses);
            context.Issues.AddRange(issues);
            context.IssueStatusHistories.AddRange(issueStatusHistories);
            context.IssueImpediments.AddRange(issueImpediments);
            context.IssueEpics.AddRange(issueEpics);
            context.SaveChanges();
        }
    }
}