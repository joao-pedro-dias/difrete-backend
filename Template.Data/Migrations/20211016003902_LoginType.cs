using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class LoginType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 871, DateTimeKind.Local).AddTicks(5241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 21, 26, 33, 574, DateTimeKind.Local).AddTicks(1639));

            migrationBuilder.AddColumn<int>(
                name: "LoginType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 870, DateTimeKind.Local).AddTicks(263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 21, 26, 33, 572, DateTimeKind.Local).AddTicks(326));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginType",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 21, 26, 33, 574, DateTimeKind.Local).AddTicks(1639),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 871, DateTimeKind.Local).AddTicks(5241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 21, 26, 33, 572, DateTimeKind.Local).AddTicks(326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 870, DateTimeKind.Local).AddTicks(263));
        }
    }
}
