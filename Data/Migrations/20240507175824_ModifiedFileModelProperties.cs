using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graphics_Asp_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedFileModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "IndexOfForms");

            migrationBuilder.AlterColumn<string>(
                name: "UploadedBy",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UploadedBy",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
