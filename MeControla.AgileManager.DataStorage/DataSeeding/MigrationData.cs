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
                new ProjectCategory { Id = 1, Uuid = Guid.Parse("042B72F2-0848-47A1-BB11-8ED69B0CAF7E"), Key = 0, Name = "No Category" }
            );
        }
    }
}