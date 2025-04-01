using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DeleteClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Enrollmen__class__4D94879B",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_class_id",
                table: "Enrollments");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Projects",
                type: "varchar(20)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "Projects",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    lecturer_id = table.Column<int>(type: "int", nullable: false),
                    class_name = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Classes__FDF479868DEADBFA", x => x.class_id);
                    table.ForeignKey(
                        name: "FK__Classes__course___45F365D3",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK__Classes__lecture__46E78A0C",
                        column: x => x.lecturer_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_class_id",
                table: "Enrollments",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_course_id",
                table: "Classes",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_lecturer_id",
                table: "Classes",
                column: "lecturer_id");

            migrationBuilder.AddForeignKey(
                name: "FK__Enrollmen__class__4D94879B",
                table: "Enrollments",
                column: "class_id",
                principalTable: "Classes",
                principalColumn: "class_id");
        }
    }
}
