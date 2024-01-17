using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecordMedical.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationMedicalReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Relation",
                table: "MedicalReport");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Relation",
                table: "MedicalReport",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
