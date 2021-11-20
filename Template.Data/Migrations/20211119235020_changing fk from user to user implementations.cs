using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Data.Migrations
{
    public partial class changingfkfromusertouserimplementations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Fretistas_FretistaId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FretistaId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FretistaId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 18, 12, 29, 55, 694, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1420),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 18, 12, 29, 55, 694, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 637, DateTimeKind.Local).AddTicks(9950),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 18, 12, 29, 55, 692, DateTimeKind.Local).AddTicks(2463));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Fretistas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserId",
                table: "Persons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fretistas_UserId",
                table: "Fretistas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fretistas_Users_UserId",
                table: "Fretistas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_UserId",
                table: "Persons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fretistas_Users_UserId",
                table: "Fretistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_UserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_UserId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Fretistas_UserId",
                table: "Fretistas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fretistas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 18, 12, 29, 55, 694, DateTimeKind.Local).AddTicks(5199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.AddColumn<Guid>(
                name: "FretistaId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 18, 12, 29, 55, 694, DateTimeKind.Local).AddTicks(4150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 639, DateTimeKind.Local).AddTicks(1420));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Fretistas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 11, 18, 12, 29, 55, 692, DateTimeKind.Local).AddTicks(2463),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 11, 19, 20, 50, 19, 637, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.CreateIndex(
                name: "IX_Users_FretistaId",
                table: "Users",
                column: "FretistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Fretistas_FretistaId",
                table: "Users",
                column: "FretistaId",
                principalTable: "Fretistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
