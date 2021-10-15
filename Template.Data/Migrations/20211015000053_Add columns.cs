using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class Addcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TestePassword",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TesteTemplate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 14, 21, 0, 52, 516, DateTimeKind.Local).AddTicks(3105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 14, 20, 38, 52, 218, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "17982310203");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12345678910");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TesteTemplate",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TestePassword");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 14, 20, 38, 52, 218, DateTimeKind.Local).AddTicks(3020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 14, 21, 0, 52, 516, DateTimeKind.Local).AddTicks(3105));
        }
    }
}
