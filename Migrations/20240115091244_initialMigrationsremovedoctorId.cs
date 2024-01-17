using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordMedical.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrationsremovedoctorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctors_DoctorId1",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoctorId1",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Patient",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorId",
                table: "Patient",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctors_DoctorId",
                table: "Patient",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctors_DoctorId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoctorId",
                table: "Patient");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "Patient",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorId1",
                table: "Patient",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctors_DoctorId1",
                table: "Patient",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
