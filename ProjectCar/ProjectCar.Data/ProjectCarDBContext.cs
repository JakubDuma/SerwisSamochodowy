using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectCar.Data.Models;

namespace ProjectCar.Data
{
    public class ProjectCarDBContext : DbContext
    {
        public DbSet<Part> Parts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<WW> WW { get; set; }
        public DbSet<WZ> WZ { get; set; }

        // Pozostałe modele/tabele dla DB

        public ProjectCarDBContext()
        {
        }

        public ProjectCarDBContext(DbContextOptions<ProjectCarDBContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;

            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienia modeli
        }
    }
}