using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class removingSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 41, DateTimeKind.Local).AddTicks(196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 40, DateTimeKind.Local).AddTicks(9733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 39, DateTimeKind.Local).AddTicks(5750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 408, DateTimeKind.Local).AddTicks(2230));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "Fretistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6746),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 41, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 409, DateTimeKind.Local).AddTicks(6341),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 40, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 23, 40, 12, 408, DateTimeKind.Local).AddTicks(2230),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 39, DateTimeKind.Local).AddTicks(5750));
        }
    }
}
