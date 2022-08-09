using MeControla.AgileManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeControla.AgileManager.DataStorage.DataSeeding
{
    public static class MigrationData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectCategory>().HasData(
                new ProjectCategory { Id = 1, Uuid = Guid.Parse("042B72F2-0848-47A1-BB11-8ED69B0CAF7E"), Key = 0, Name = "No Category" },
                new ProjectCategory { Id = 2, Uuid = Guid.Parse("15792637-4496-4E0F-8848-E3EE2B077711"), Key = 12904, Name = "Aplicativos" },
                new ProjectCategory { Id = 3, Uuid = Guid.Parse("975A10E5-74FA-4529-BAF7-C08D79D62C9A"), Key = 11404, Name = "Decisão" },
                new ProjectCategory { Id = 4, Uuid = Guid.Parse("B1C8348F-AA66-46FD-97BD-2FFE97D681BB"), Key = 11104, Name = "Descoberta" },
                new ProjectCategory { Id = 5, Uuid = Guid.Parse("DC5E09D1-610D-4CED-9C06-E014FC2B2BEB"), Key = 12905, Name = "Fidelização" }
            );
        }
    }
}