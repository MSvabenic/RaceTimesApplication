using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaceTimesApplication.Models;
using System;

namespace RaceTimesApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserTimeModel> UserTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserTimeModel>().Property(p => p.CreationTime).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
        }
    }
}
