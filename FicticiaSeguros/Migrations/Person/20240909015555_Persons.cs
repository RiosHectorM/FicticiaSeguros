using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FicticiaSeguros.Migrations.Person
{
    /// <inheritdoc />
    public partial class Persons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dni = table.Column<long>(type: "bigint", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDriver = table.Column<bool>(type: "bit", nullable: false),
                    UsesGlasses = table.Column<bool>(type: "bit", nullable: false),
                    IsDiabetic = table.Column<bool>(type: "bit", nullable: false),
                    OtherDiseases = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Dni",
                table: "Persons",
                column: "Dni",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
