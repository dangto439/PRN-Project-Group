using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contacts__024E7A863D6C3367", x => x.contact_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 100, nullable: false),
                    role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__B9BE370F554A8750", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    course_name = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__8F1EF7AE1E59BE38", x => x.course_id);
                    table.ForeignKey(
                        name: "FK__Courses__created__412EB0B6",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    enrollment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    enrollment_date = table.Column<DateTime>(type: "date", nullable: false),
                    payment_status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__6D24AA7A2F897312", x => x.enrollment_id);
                    table.ForeignKey(
                        name: "FK__Enrollmen__stude__4CA06362",
                        column: x => x.student_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "News_Events",
                columns: table => new
                {
                    news_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    event_date = table.Column<DateTime>(type: "date", nullable: true),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News_Eve__4C27CCD8E040FEE0", x => x.news_id);
                    table.ForeignKey(
                        name: "FK__News_Even__creat__5FB337D6",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_name = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    end_date = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 10, nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Projects__BC799E1F4A6E4FC0", x => x.project_id);
                    table.ForeignKey(
                        name: "FK__Projects__create__59FA5E80",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    resource_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    resource_name = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 100, nullable: false),
                    resource_type = table.Column<string>(type: "nvarchar(255)", maxLength: 10, nullable: false),
                    file_url = table.Column<string>(type: "nvarchar(255)", unicode: false, maxLength: 255, nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Resource__4985FC73535F25D2", x => x.resource_id);
                    table.ForeignKey(
                        name: "FK__Resources__cours__534D60F1",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK__Resources__creat__5441852A",
                        column: x => x.created_by,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_created_by",
                table: "Courses",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_student_id",
                table: "Enrollments",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_Events_created_by",
                table: "News_Events",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_created_by",
                table: "Projects",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_course_id",
                table: "Resources",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_created_by",
                table: "Resources",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E616403F36D9A",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__F3DBC572D40FC304",
                table: "Users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "News_Events");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
