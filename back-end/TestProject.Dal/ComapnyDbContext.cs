using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Dal.Entitites;

namespace TestProject.Dal
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Project> Project { get; set; }

        public DbSet<Developer> Developer { get; set; }
        public DbSet<ProjectDeveloper> ProjectDeveloper { get; set; }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }

        public static CompanyDbContext Create()
        {
            string connectionString = @"Server=.\sqlexpress;Database=TestProject;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new CompanyDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(item => item.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Developer>().Property(item => item.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProjectDeveloper>().HasKey(pd => new { pd.ProjectId, pd.DeveloperId });

            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne<Project>(pd => pd.Project)
                .WithMany(p => p.ProjectDevelopers)
                .HasForeignKey(pd => pd.ProjectId);


            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne<Developer>(pd => pd.Developer)
                .WithMany(d => d.ProjectDevelopers)
                .HasForeignKey(pd => pd.DeveloperId);
        }
    }
}
