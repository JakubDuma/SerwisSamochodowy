﻿using Microsoft.EntityFrameworkCore;
using ProjectCar.Data.Models;

namespace ProjectCar.Data
{
    public class ProjectCarDBContext : DbContext
    {
        public DbSet<Part> Parts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<WW> WW { get; set; }

        // Pozostałe modele/tabele dla DB

        public ProjectCarDBContext()
        {
        }

        public ProjectCarDBContext(DbContextOptions<ProjectCarDBContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ustawienia modeli
        }
    }
}