using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class changingdescriptionpropertytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(3625),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "StatusSolicitacoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StatusSolicitacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(3289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(2022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Solicitacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(2820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(1634));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(2418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 392, DateTimeKind.Local).AddTicks(1232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 529, DateTimeKind.Local).AddTicks(873));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(2411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.AlterColumn<int>(
                name: "Descricao",
                table: "StatusSolicitacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "StatusSolicitacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(2022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Solicitacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(1634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 530, DateTimeKind.Local).AddTicks(1188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 393, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 24, 21, 28, 44, 529, DateTimeKind.Local).AddTicks(873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 24, 21, 36, 16, 392, DateTimeKind.Local).AddTicks(1232));
        }
    }
}
