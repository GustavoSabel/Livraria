using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookstore.Infra.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthdate", "FirstName", "LastName" },
                values: new object[] { new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd1"), null, "Douglas", "Adams" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthdate", "FirstName", "LastName" },
                values: new object[] { new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd2"), new DateTime(1945, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric", "Evans" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Synopsis", "Title" },
                values: new object[] { new Guid("90660dd0-bfe6-4424-a5fe-13d5a301984e"), new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd1"), "", "The Hitchhiker's Guide to the Galaxy" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Synopsis", "Title" },
                values: new object[] { new Guid("6ffa55c1-2c17-4d39-93d4-2362b42c433c"), new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd1"), "", "Dirk Gently's Holistic Detective Agency" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Synopsis", "Title" },
                values: new object[] { new Guid("9fff44e9-727c-4d86-91ba-593c01fc116d"), new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd2"), "", "Domain Driven Design" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6ffa55c1-2c17-4d39-93d4-2362b42c433c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("90660dd0-bfe6-4424-a5fe-13d5a301984e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9fff44e9-727c-4d86-91ba-593c01fc116d"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd1"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd2"));
        }
    }
}
