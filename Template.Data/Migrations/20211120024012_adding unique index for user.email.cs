using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class addinguniqueindexforuseremail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_UserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Fretistas_UserId",
                table: "Fretistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6341),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1420));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 408, DateTimeKind.Local).AddTicks(2230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 637, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fretistas_UserId",
                table: "Fretistas",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_UserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Fretistas_UserId",
                table: "Fretistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1420),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 637, DateTimeKind.Local).AddTicks(9950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 408, DateTimeKind.Local).AddTicks(2230));

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fretistas_UserId",
                table: "Fretistas",
                column: "UserId");
        }
    }
}
