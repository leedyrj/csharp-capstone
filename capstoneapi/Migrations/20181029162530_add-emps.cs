using Microsoft.EntityFrameworkCore.Migrations;

namespace capstoneapi.Migrations
{
    public partial class addemps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
