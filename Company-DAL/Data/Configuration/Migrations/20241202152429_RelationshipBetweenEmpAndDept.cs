using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_DAL.Data.Configuration.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipBetweenEmpAndDept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepartmentId",
                table: "employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_DepartmentId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "employee");
        }
    }
}
