using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Stefanini.ViaReport.DataStorage
{
    public class DbAppContextFactory : IDesignTimeDbContextFactory<DbAppContext>, IDisposable
    {
        private const string CONNECTION_STRING = "Data Source=storage.db";

        private DbAppContext context;

        public DbAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbAppContext>();
            optionsBuilder.UseSqlite(CONNECTION_STRING);

            context = new DbAppContext(optionsBuilder.Options);
            return context;
        }

        public void Dispose()
        {
            if(context != null)
                context.Dispose();
        }
    }
}