using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graphics_Asp_MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFileUploadToIndexOfForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "IndexOfForms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UploadedBy",
                table: "IndexOfForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "IndexOfForms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "IndexOfForms");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "IndexOfForms");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "IndexOfForms");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "IndexOfForms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "IndexOfForms");

            migrationBuilder.DropColumn(
                name: "UploadedBy",
                table: "IndexOfForms");
        }
    }
}
