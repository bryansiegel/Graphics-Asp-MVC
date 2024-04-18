using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graphics_Asp_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class CurrentEvaluationChangeActiveToBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "active",
                table: "CurrentEvaluations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "active",
                table: "CurrentEvaluations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
