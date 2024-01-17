using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordMedical.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordManagers_Users_UserId",
                table: "PasswordManagers");

            migrationBuilder.DropIndex(
                name: "IX_PasswordManagers_UserId",
                table: "PasswordManagers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PasswordManagers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoiningDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<long>(
                name: "PasswordManagerId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PasswordManagerId",
                table: "Users",
                column: "PasswordManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PasswordManagers_PasswordManagerId",
                table: "Users",
                column: "PasswordManagerId",
                principalTable: "PasswordManagers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PasswordManagers_PasswordManagerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PasswordManagerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordManagerId",
                table: "Users");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoiningDate",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "PasswordManagers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordManagers_UserId",
                table: "PasswordManagers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordManagers_Users_UserId",
                table: "PasswordManagers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
