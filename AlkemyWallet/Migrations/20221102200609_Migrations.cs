using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlkemyWallet.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Catalogue",
                columns: new[] { "Id", "Image", "Points", "Product_description" },
                values: new object[] { 1, "", 300, "cocina" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Admin", "vice presidente junior" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "usuario", "usuario standard" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "First_name", "Last_name", "Password", "Points", "Rol_id" },
                values: new object[] { 1, "clint@eastwood.com ", "Clint", "Eastwood", "Clint", 30, 2 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "First_name", "Last_name", "Password", "Points", "Rol_id" },
                values: new object[] { 2, "ArnoldSG@Skynet.com ", "Arnold", "Schwarzenegger", "Arnold", 2000, 1 });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreationDate", "IsBlocked", "Money", "User_id" },
                values: new object[] { 1, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 150000f, 1 });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "CreationDate", "IsBlocked", "Money", "User_id" },
                values: new object[] { 2, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 50f, 1 });

            migrationBuilder.InsertData(
                table: "FixedTermDeposit",
                columns: new[] { "Id", "Account_id", "Amount", "Closing_date", "Creation_date", "User_id" },
                values: new object[] { 1, 1, 23000f, new DateTime(2021, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Transaction_id", "Account_id", "Amount", "Concept", "Date", "Type", "User_id" },
                values: new object[] { 1, 1, 2000, "crédito", new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Efectivo", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Catalogue",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FixedTermDeposit",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Transaction_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
