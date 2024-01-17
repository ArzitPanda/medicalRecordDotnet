using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordMedical.Migrations
{
    /// <inheritdoc />
    public partial class addAttendeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendeeId",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_AttendeeId",
                table: "Patient",
                column: "AttendeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Attendees_AttendeeId",
                table: "Patient",
                column: "AttendeeId",
                principalTable: "Attendees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Attendees_AttendeeId",
                table: "Patient");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropIndex(
                name: "IX_Patient_AttendeeId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AttendeeId",
                table: "Patient");
        }
    }
}
