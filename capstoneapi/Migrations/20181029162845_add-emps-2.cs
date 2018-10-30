using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneapi.Migrations
{
    public partial class addemps2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "29a1f871-d380-49db-9d42-2766c2200851", "74a113f9-5d0f-4125-ac5a-1600944b1df2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2bd5c099-5e3e-423d-90d8-6d4d69b8c802", "dd0019d9-d870-481b-b91c-e5c3ad545081" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8d66abb1-1021-4a39-a7f6-0592ce2ba26b", "ce52c22a-5850-423a-a11d-aa250742101f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f19abf08-3074-45bf-9cfb-5c0aff9a22d6", "a000fae1-d14e-483a-aea3-78354d0848ef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "06bd1516-2457-4f2c-b2f6-98637f946401", 0, "78cfd654-9588-48d8-a4e2-f2f5d24185cf", "Employee", "r@leedy.com", true, false, null, "R@LEEDY.COM", "RLEEDY", "AQAAAAEAACcQAAAAELwejCjlli2NCTcbfz6tPa8x6rpNFUDrImE67UkqTPbOubdm+PZw9fRGDRLgjtPLWA==", null, false, "7f9a8046-ab3d-49cb-b204-1c82a62941e3", false, "rleedy", 1, "Robert", "Leedy" },
                    { "7b72a9ff-d7f0-4f8a-9aca-5f7edd0cae98", 0, "a8c7e0e4-a339-4686-8a75-1a567a79640e", "Employee", "w@kimball.com", true, false, null, "W@KIMBALL.COM", "WKIMBALL", "AQAAAAEAACcQAAAAEHuPmYknduWdr5u28t2LxX/du85/+jyNjVMbTbMCldVFEEcXxxN+rGEznSWtRUEw8Q==", null, false, "f8287642-ce9c-4049-a488-04c62ec7b303", false, "wkimball", 2, "William", "Kimball" },
                    { "8dbda5e5-4f99-4142-b7e8-57c1c1632b49", 0, "7dda8e85-2ae6-43fe-a643-167dc0d2d6a9", "Employee", "n@cox.com", true, false, null, "N@COX.COM", "NCOX", "AQAAAAEAACcQAAAAEMnB8ygCofcgF5qgQM3jou9E4koMOK2FdTPLHMC43J3580d1c+A8wbXql/6oRwlfXA==", null, false, "944df322-996a-4cdd-a823-380270751d17", false, "ncox", 3, "Natasha", "Cox" },
                    { "2c4573a3-49d3-4df9-9be3-8effbf58e2f1", 0, "46509479-ad19-40c2-9628-9f78520271a7", "Employee", "l@gwin.com", true, false, null, "L@GWIN.COM", "LGWIN", "AQAAAAEAACcQAAAAEOXhEZC/hDD23CTQFxivxCuQXPVEzn7kZNLNk/Vdc4opeb3JnqQkwVODtNQ2e6Yzhw==", null, false, "70735862-aa5c-4958-85a3-40e618a2b448", false, "lgwin", 4, "Leah", "Gwin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "06bd1516-2457-4f2c-b2f6-98637f946401", "78cfd654-9588-48d8-a4e2-f2f5d24185cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2c4573a3-49d3-4df9-9be3-8effbf58e2f1", "46509479-ad19-40c2-9628-9f78520271a7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7b72a9ff-d7f0-4f8a-9aca-5f7edd0cae98", "a8c7e0e4-a339-4686-8a75-1a567a79640e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8dbda5e5-4f99-4142-b7e8-57c1c1632b49", "7dda8e85-2ae6-43fe-a643-167dc0d2d6a9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { "f19abf08-3074-45bf-9cfb-5c0aff9a22d6", 0, "a000fae1-d14e-483a-aea3-78354d0848ef", "Employee", "r@leedy.com", true, false, null, "R@LEEDY.COM", "RLEEDY", "AQAAAAEAACcQAAAAEOBZgGeLj1XQnQNPCIFsYxZ8tjoCgVL9eG7WtdBUW2tZgq5Kz+fCc/lxhnSGnBkhJA==", null, false, "4e45504e-1520-481f-a91d-4735850a437f", false, "rleedy", 1, "Robert", "Leedy" },
                    { "29a1f871-d380-49db-9d42-2766c2200851", 0, "74a113f9-5d0f-4125-ac5a-1600944b1df2", "Employee", "w@kimball.com", true, false, null, "W@KIMBALL.COM", "WKIMBALL", "AQAAAAEAACcQAAAAEDbixHwlhkoc4H3Qm7e1H4R2mjCFS5axXokV88Nmy+UDVhezaexwSLgsDiATU0hMBA==", null, false, "50c50d51-2931-4753-938d-203b75295146", false, "wkimball", 2, "William", "Kimball" },
                    { "2bd5c099-5e3e-423d-90d8-6d4d69b8c802", 0, "dd0019d9-d870-481b-b91c-e5c3ad545081", "Employee", "n@cox.com", true, false, null, "N@COX.COM", "NCOX", null, null, false, "d14ffc4f-7dfb-4976-87f1-3aecb557682c", false, "ncox", 3, "Natasha", "Cox" },
                    { "8d66abb1-1021-4a39-a7f6-0592ce2ba26b", 0, "ce52c22a-5850-423a-a11d-aa250742101f", "Employee", "l@gwin.com", true, false, null, "L@GWIN.COM", "LGWIN", null, null, false, "2ce3e129-26b2-4f4b-bc4d-2f79bf3bd078", false, "lgwin", 4, "Leah", "Gwin" }
                });
        }
    }
}
