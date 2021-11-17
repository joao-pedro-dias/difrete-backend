using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class FretistaRepository : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(8733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(7664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(7621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretista",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 72, DateTimeKind.Local).AddTicks(6825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 852, DateTimeKind.Local).AddTicks(3819));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(8623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(7621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 89, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretista",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 852, DateTimeKind.Local).AddTicks(3819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 48, 16, 72, DateTimeKind.Local).AddTicks(6825));
        }
    }
}
