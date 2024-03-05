using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetanqueProSuite.Domain;
using PetanqueProSuite.Domain.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetanqueProSuite.Infrastructure
{
    public class PetanqueProSuiteDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public PetanqueProSuiteDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("db"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(p => p.Name).IsUnique(true);
            modelBuilder.Entity<League>().HasIndex(p => new { p.Name, p.CategoryId}).IsUnique();
            modelBuilder.Entity<Division>().HasIndex(p => new {p.Name, p.LeagueId}).IsUnique();
            modelBuilder.Entity<Club>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Club>().HasIndex(p => p.Number).IsUnique();
            modelBuilder.Entity<CompetitionTeam>().HasIndex(p => new { p.Identifyer, p.ClubId }).HasFilter("[Identifyer] IS NOT NULL").IsUnique();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<CompetitionTeam> CompetitionTeams { get; set; }
        public DbSet<License> Licenses { get; set; }
    }
}
