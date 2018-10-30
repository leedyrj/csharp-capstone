using System;
using System.Collections.Generic;
using System.Text;
using capstoneapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace capstoneapi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            Employee user = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Robert",
                LastName = "Leedy",
                UserName = "rleedy",
                NormalizedUserName = "RLEEDY",
                Email = "r@leedy.com",
                NormalizedEmail = "R@LEEDY.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                DepartmentId = 1
            };

            Employee user2 = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "William",
                LastName = "Kimball",
                UserName = "wkimball",
                NormalizedUserName = "WKIMBALL",
                Email = "w@kimball.com",
                NormalizedEmail = "W@KIMBALL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                DepartmentId = 2
            };

            Employee user3 = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Natasha",
                LastName = "Cox",
                UserName = "ncox",
                NormalizedUserName = "NCOX",
                Email = "n@cox.com",
                NormalizedEmail = "N@COX.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                DepartmentId = 3
            };

            Employee user4 = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Leah",
                LastName = "Gwin",
                UserName = "lgwin",
                NormalizedUserName = "LGWIN",
                Email = "l@gwin.com",
                NormalizedEmail = "L@GWIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                DepartmentId = 4
            };

            var passwordHash = new PasswordHasher<Employee>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<Employee>().HasData(user);

            var passwordHash2 = new PasswordHasher<Employee>();
            user2.PasswordHash = passwordHash2.HashPassword(user2, "Admin8*");
            modelBuilder.Entity<Employee>().HasData(user2);

            var passwordHash3 = new PasswordHasher<Employee>();
            user3.PasswordHash = passwordHash2.HashPassword(user2, "Admin8*");
            modelBuilder.Entity<Employee>().HasData(user3);

            var passwordHash4 = new PasswordHasher<Employee>();
            user4.PasswordHash = passwordHash2.HashPassword(user2, "Admin8*");
            modelBuilder.Entity<Employee>().HasData(user4);
        }
    }
}