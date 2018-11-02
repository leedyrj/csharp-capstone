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
                    { "e7764f71-70a8-4a3b-8824-cc95ee7d685c", 0, "a158b83b-0492-45c0-902f-bd96f3a6b86a", "Employee", "r@leedy.com", true, false, null, "R@LEEDY.COM", "RLEEDY", "AQAAAAEAACcQAAAAENkH7u356RckNu5IJoWSA/p82u8/DpPf4ntpVUfM3qQdgseEp4VcihdeCbFEl1NVSg==", null, false, "37fdc376-fa1a-4a78-a6b9-9d5678036b1a", false, "rleedy", 1, "Robert", "Leedy" },
                    { "eb24187b-5fd4-42ea-8a28-af083e113e7d", 0, "4cae8288-e394-41a0-bc96-dbd2ef56e959", "Employee", "w@kimball.com", true, false, null, "W@KIMBALL.COM", "WKIMBALL", "AQAAAAEAACcQAAAAEDhzlQ3tyx7272X6AM5bn8ujrcBx5NGTmscpfRENR0PjJZ5pjFJR/RINYhPxEJIOuQ==", null, false, "b0266ee0-17b9-431e-8612-9657a1598754", false, "wkimball", 2, "William", "Kimball" },
                    { "0e81f73e-9b67-4100-b8fc-c337c4c5b506", 0, "d21734f4-a729-40a0-be0e-a39eba2579d1", "Employee", "n@cox.com", true, false, null, "N@COX.COM", "NCOX", "AQAAAAEAACcQAAAAEE2diVRqZn00p3JWZ30L66ktJLHogKZWkKsiNV8TerZWA2eStllldMYVBJ4b14AEcA==", null, false, "eb9b0bb8-a2c5-4588-ab96-433a9810ee7b", false, "ncox", 3, "Natasha", "Cox" },
                    { "551bfd87-df1a-4b40-b464-ea4a11572109", 0, "47f30172-63b6-4f7a-9445-8196c655d1b8", "Employee", "l@gwin.com", true, false, null, "L@GWIN.COM", "LGWIN", "AQAAAAEAACcQAAAAEC+e0/7wlpM8XQmoziYv5/yhGkBY7I8UhLgntvY4dR3PIYuFzCl8M3iGWiiJjzWRLQ==", null, false, "21e8ef78-e48d-4d55-b47d-607623c77005", false, "lgwin", 4, "Leah", "Gwin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0e81f73e-9b67-4100-b8fc-c337c4c5b506", "d21734f4-a729-40a0-be0e-a39eba2579d1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "551bfd87-df1a-4b40-b464-ea4a11572109", "47f30172-63b6-4f7a-9445-8196c655d1b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e7764f71-70a8-4a3b-8824-cc95ee7d685c", "a158b83b-0492-45c0-902f-bd96f3a6b86a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "eb24187b-5fd4-42ea-8a28-af083e113e7d", "4cae8288-e394-41a0-bc96-dbd2ef56e959" });
        }
    }
}
