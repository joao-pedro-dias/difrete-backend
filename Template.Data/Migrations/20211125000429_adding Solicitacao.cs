using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class addingSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 4, 28, 675, DateTimeKind.Local).AddTicks(246),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 41, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 4, 28, 674, DateTimeKind.Local).AddTicks(9367),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 40, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 4, 28, 673, DateTimeKind.Local).AddTicks(7195),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 39, DateTimeKind.Local).AddTicks(5750));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 41, DateTimeKind.Local).AddTicks(196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 4, 28, 675, DateTimeKind.Local).AddTicks(246));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 40, DateTimeKind.Local).AddTicks(9733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 4, 28, 674, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 20, 58, 34, 39, DateTimeKind.Local).AddTicks(5750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 4, 28, 673, DateTimeKind.Local).AddTicks(7195));
        }
    }
}
