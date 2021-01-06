using Microsoft.AspNetCore.Identity;
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

            //For testing purpose only
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "F8BED3E7-1263-4705-B713-76965DE0EDFE",
                    UserName = "AdminUser1@gmail.com",
                    NormalizedUserName = "ADMINUSER1@gmail.com",
                    Email = "AdminUser1@gmail.com",
                    NormalizedEmail = "ADMINUSER1@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "AdminUser1@gmail.com")
                });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "DDB8F0FD-B8A2-4582-B513-99605CA8B7F0",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "F8BED3E7-1263-4705-B713-76965DE0EDFE",
                    RoleId = "DDB8F0FD-B8A2-4582-B513-99605CA8B7F0"
                });
        }
    }
}
