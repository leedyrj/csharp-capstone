﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using capstoneapi.Data;

namespace capstoneapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("capstoneapi.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget");

                    b.Property<string>("DepartmentName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new { Id = 1, Budget = 50000, DepartmentName = "Human Resources" },
                        new { Id = 2, Budget = 50000, DepartmentName = "Sales" },
                        new { Id = 3, Budget = 50000, DepartmentName = "Information Technology" },
                        new { Id = 4, Budget = 50000, DepartmentName = "Marketing" }
                    );
                });

            modelBuilder.Entity("capstoneapi.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("ExpenseDate");

                    b.Property<int>("ExpenseTypeId");

                    b.Property<string>("Location")
                        .IsRequired();

                    b.Property<int>("ReportId");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseTypeId");

                    b.HasIndex("ReportId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("capstoneapi.Models.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExpenseTypeName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ExpenseTypes");

                    b.HasData(
                        new { Id = 1, ExpenseTypeName = "Mileage" },
                        new { Id = 2, ExpenseTypeName = "Lodging" },
                        new { Id = 3, ExpenseTypeName = "Meals - Employees Only" },
                        new { Id = 4, ExpenseTypeName = "Meals - Client/Guest" },
                        new { Id = 5, ExpenseTypeName = "Fuel" },
                        new { Id = 6, ExpenseTypeName = "Travel - Transportation" },
                        new { Id = 7, ExpenseTypeName = "Supplies" },
                        new { Id = 8, ExpenseTypeName = "Travel - Misc" },
                        new { Id = 9, ExpenseTypeName = "Registration Fees" },
                        new { Id = 10, ExpenseTypeName = "Postage/Shipping" },
                        new { Id = 11, ExpenseTypeName = "Dry Cleaning" }
                    );
                });

            modelBuilder.Entity("capstoneapi.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExpenseId");

                    b.Property<string>("PhotoName");

                    b.Property<string>("PhotoPath");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("capstoneapi.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeId");

                    b.Property<string>("Purpose")
                        .IsRequired();

                    b.Property<bool>("Submitted");

                    b.Property<DateTime>("SubmittedDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("capstoneapi.Models.Employee", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");

                    b.HasDiscriminator().HasValue("Employee");

                    b.HasData(
                        new { Id = "7dad6c5e-bbae-4fe0-b53b-dc949751b41b", AccessFailedCount = 0, ConcurrencyStamp = "bac79b82-b152-4d51-a284-08aa47915f7b", Email = "r@leedy.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "R@LEEDY.COM", NormalizedUserName = "RLEEDY", PasswordHash = "AQAAAAEAACcQAAAAECYiyVgRWNY+5tKpnYKScqKZyz5/OTYemgBNRbxWJSO++q0BwgMQ1FbOwcp3EV/Pvg==", PhoneNumberConfirmed = false, SecurityStamp = "9666b447-100c-4df2-b45c-eacfd3eb2b21", TwoFactorEnabled = false, UserName = "rleedy", DepartmentId = 1, FirstName = "Robert", LastName = "Leedy" },
                        new { Id = "a7bfbba7-233a-40fc-81dc-99b0aa64fbc7", AccessFailedCount = 0, ConcurrencyStamp = "29da0ab3-47b9-4646-b291-26f28a7c35e6", Email = "w@kimball.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "W@KIMBALL.COM", NormalizedUserName = "WKIMBALL", PasswordHash = "AQAAAAEAACcQAAAAEI311Nd2fktfyfSO1Xp8snXZqaaR2I/KsZzytHoceN1pOsH4zTBV1QQgxZ27NMkHnw==", PhoneNumberConfirmed = false, SecurityStamp = "5ee3e979-46e2-4d82-9f9a-c9d4beddebfc", TwoFactorEnabled = false, UserName = "wkimball", DepartmentId = 2, FirstName = "William", LastName = "Kimball" },
                        new { Id = "a0c40966-38d2-4c81-ac13-d42634920cde", AccessFailedCount = 0, ConcurrencyStamp = "7f459445-692e-4d7e-abed-40694cac439b", Email = "n@cox.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "N@COX.COM", NormalizedUserName = "NCOX", PasswordHash = "AQAAAAEAACcQAAAAENVZNJWqBE6n6+NA2h/6lmy0hLRwx1txw6XHeTSHNbxeuzBmb6jP6Pvb4X2QmNgNKg==", PhoneNumberConfirmed = false, SecurityStamp = "8e4ff1bc-715d-4943-80af-111a4e36f4fb", TwoFactorEnabled = false, UserName = "ncox", DepartmentId = 3, FirstName = "Natasha", LastName = "Cox" },
                        new { Id = "62819b67-8343-470f-b61d-620b77abc420", AccessFailedCount = 0, ConcurrencyStamp = "c3dcef5d-50aa-4a82-9100-1e947070f2a8", Email = "l@gwin.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "L@GWIN.COM", NormalizedUserName = "LGWIN", PasswordHash = "AQAAAAEAACcQAAAAEMVhARy2gt165AoFHtymB1I+IP5b8ZaFsvLOGzQ2JVdU4gJD6i3R4uhdt3bSrrnsWg==", PhoneNumberConfirmed = false, SecurityStamp = "2e729c6c-dd15-434a-a443-7c2a7e2e5904", TwoFactorEnabled = false, UserName = "lgwin", DepartmentId = 4, FirstName = "Leah", LastName = "Gwin" }
                    );
                });

            modelBuilder.Entity("capstoneapi.Models.Expense", b =>
                {
                    b.HasOne("capstoneapi.Models.ExpenseType", "ExpenseTypes")
                        .WithMany()
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("capstoneapi.Models.Report", "Report")
                        .WithMany("Expenses")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capstoneapi.Models.Photo", b =>
                {
                    b.HasOne("capstoneapi.Models.Expense", "Expense")
                        .WithMany("Photos")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capstoneapi.Models.Report", b =>
                {
                    b.HasOne("capstoneapi.Models.Employee", "Employee")
                        .WithMany("Reports")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("capstoneapi.Models.Employee", b =>
                {
                    b.HasOne("capstoneapi.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
