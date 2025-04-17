using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_DAL.Data.Configuration.Migrations
{
    /// <inheritdoc />
    public partial class ImageColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "employee");
        }
    }
}
