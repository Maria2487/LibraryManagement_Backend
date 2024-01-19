using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Infrastructure.Migrations
{
    public partial class addauthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("979b637c-e574-446e-b528-134a028f1a91"));

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Biography", "DateOfBirth", "DateOfDeath", "FirstName", "IsDeleted", "LastName", "Nationality", "Photo" },
                values: new object[] { new Guid("2f5da9ca-9401-41b5-ad1c-d87c6cbc5287"), "Mihai Eminescu a fost un poet, prozator și jurnalist român, considerat, în general, ca fiind cea mai cunoscută și influentă personalitate din literatura română.", new DateTime(1850, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1889, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai", false, "Eminescu", "Romanian", "" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6976fe0d-f926-4c30-a38c-8f440a1e11ce"),
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 12, 13, 17, 963, DateTimeKind.Utc).AddTicks(6254), "$2a$11$y3qWX7HxTowsZ4hsacAjGeEDj1TTTHbI4A3RWJDVRonaMCzxORXjy", new DateTime(2024, 1, 18, 12, 13, 17, 963, DateTimeKind.Utc).AddTicks(6255) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "MemberPhoto", "MembershipId", "Password", "Phone", "Role", "UpdatedAt" },
                values: new object[] { new Guid("1aff78cb-91ad-4346-9b49-9752f8a7a220"), "Universitatii 13, Suceava, Romania", new DateTime(2024, 1, 18, 12, 13, 17, 963, DateTimeKind.Utc).AddTicks(6045), new DateTime(2000, 1, 24, 22, 0, 0, 0, DateTimeKind.Utc), "librarymanager0125@gmail.com", "Library", 0, false, "Administrator", null, null, "$2a$11$y3qWX7HxTowsZ4hsacAjGeEDj1TTTHbI4A3RWJDVRonaMCzxORXjy", "+40740535564", 0, new DateTime(2024, 1, 18, 12, 13, 17, 963, DateTimeKind.Utc).AddTicks(6045) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("2f5da9ca-9401-41b5-ad1c-d87c6cbc5287"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1aff78cb-91ad-4346-9b49-9752f8a7a220"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6976fe0d-f926-4c30-a38c-8f440a1e11ce"),
                columns: new[] { "CreatedAt", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 42, 8, 902, DateTimeKind.Utc).AddTicks(3836), "$2a$11$xDsf65HuAFOrWBSi1XlQeubnI9GRqbMYa1n4VuSO8hNsqHch6xroW", new DateTime(2024, 1, 18, 11, 42, 8, 902, DateTimeKind.Utc).AddTicks(3837) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "MemberPhoto", "MembershipId", "Password", "Phone", "Role", "UpdatedAt" },
                values: new object[] { new Guid("979b637c-e574-446e-b528-134a028f1a91"), "Universitatii 13, Suceava, Romania", new DateTime(2024, 1, 18, 11, 42, 8, 902, DateTimeKind.Utc).AddTicks(3816), new DateTime(2000, 1, 24, 22, 0, 0, 0, DateTimeKind.Utc), "librarymanager0125@gmail.com", "Library", 0, false, "Administrator", null, null, "$2a$11$xDsf65HuAFOrWBSi1XlQeubnI9GRqbMYa1n4VuSO8hNsqHch6xroW", "+40740535564", 0, new DateTime(2024, 1, 18, 11, 42, 8, 902, DateTimeKind.Utc).AddTicks(3816) });
        }
    }
}
