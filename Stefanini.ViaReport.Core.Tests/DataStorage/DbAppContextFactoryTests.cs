using FluentAssertions;
using Stefanini.ViaReport.DataStorage;
using System;
using System.IO;
using Xunit;

namespace Stefanini.ViaReport.Core.Tests.DataStorage
{
    public class DbAppContextFactoryTests
    {
        private const string DATABASE_FILENAME = "storage.db";

        [Fact(DisplayName = "[DbAppContextFactory.CreateDbContext] Deve criar o banco de dados SQLite.")]
        public async void DeveCriarBancoSQLite()
        {
            if (File.Exists(DATABASE_FILENAME))
                File.Delete(DATABASE_FILENAME);

            using (var dbContextFactory = new DbAppContextFactory())
            {
                var dbContext = dbContextFactory.CreateDbContext(Array.Empty<string>());

                await dbContext.Database.EnsureCreatedAsync();
                await dbContext.DisposeAsync();
            }

            File.Exists(DATABASE_FILENAME).Should().BeTrue();
        }
    }
}