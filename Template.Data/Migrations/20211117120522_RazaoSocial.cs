using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class RazaoSocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginType",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 9, 5, 22, 49, DateTimeKind.Local).AddTicks(1653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 9, 5, 22, 49, DateTimeKind.Local).AddTicks(685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretista",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 9, 5, 22, 33, DateTimeKind.Local).AddTicks(2487),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 72, DateTimeKind.Local).AddTicks(6825));

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Fretista",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Fretista");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(8733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 9, 5, 22, 49, DateTimeKind.Local).AddTicks(1653));

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
                defaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(7664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 9, 5, 22, 49, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretista",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 72, DateTimeKind.Local).AddTicks(6825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 9, 5, 22, 33, DateTimeKind.Local).AddTicks(2487));
        }
    }
}
