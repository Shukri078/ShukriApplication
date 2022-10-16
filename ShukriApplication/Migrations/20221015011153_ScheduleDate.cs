using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShukriApplication.Migrations
{
    public partial class ScheduleDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(nullable: true),
                    ClassDescription = table.Column<string>(nullable: true),
                    LectureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoomId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleDate_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDate_ClassRoomId",
                table: "ScheduleDate",
                column: "ClassRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectRole");

            migrationBuilder.DropTable(
                name: "ScheduleDate");

            migrationBuilder.DropTable(
                name: "ClassRoom");
        }
    }
}
