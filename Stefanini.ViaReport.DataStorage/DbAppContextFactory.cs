using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Stefanini.ViaReport.DataStorage
{
    public class DbAppContextFactory : IDesignTimeDbContextFactory<DbAppContext>
    {
        private const string CONNECTION_STRING = "Data Source=storage.db";

        public DbAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbAppContext>();
            optionsBuilder.UseSqlite(CONNECTION_STRING);

            return new DbAppContext(optionsBuilder.Options);
        }
    }
}