using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class MapFretista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "TestePassword");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(8623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 871, DateTimeKind.Local).AddTicks(5241));

            migrationBuilder.AddColumn<Guid>(
                name: "FretistaId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(7621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 870, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.CreateTable(
                name: "Fretista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rntrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 852, DateTimeKind.Local).AddTicks(3819)),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fretista", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FretistaId",
                table: "Users",
                column: "FretistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Fretista_FretistaId",
                table: "Users",
                column: "FretistaId",
                principalTable: "Fretista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Fretista_FretistaId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Fretista");

            migrationBuilder.DropIndex(
                name: "IX_Users_FretistaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FretistaId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "TestePassword",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 871, DateTimeKind.Local).AddTicks(5241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(8623));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 21, 39, 1, 870, DateTimeKind.Local).AddTicks(263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 17, 8, 25, 56, 869, DateTimeKind.Local).AddTicks(7621));
        }
    }
}
