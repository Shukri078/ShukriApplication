using Microsoft.EntityFrameworkCore.Migrations;

namespace ShukriApplication.Migrations
{
    public partial class ClassCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDate_ClassRoom_ClassRoomId",
                table: "ScheduleDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleDate",
                table: "ScheduleDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ScheduleDate");

            migrationBuilder.RenameTable(
                name: "ClassRoom",
                newName: "ClassRooms");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleDateId",
                table: "ScheduleDate",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleDate",
                table: "ScheduleDate",
                column: "ScheduleDateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRooms",
                table: "ClassRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDate_ClassRooms_ClassRoomId",
                table: "ScheduleDate",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDate_ClassRooms_ClassRoomId",
                table: "ScheduleDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleDate",
                table: "ScheduleDate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRooms",
                table: "ClassRooms");

            migrationBuilder.DropColumn(
                name: "ScheduleDateId",
                table: "ScheduleDate");

            migrationBuilder.RenameTable(
                name: "ClassRooms",
                newName: "ClassRoom");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ScheduleDate",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleDate",
                table: "ScheduleDate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDate_ClassRoom_ClassRoomId",
                table: "ScheduleDate",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
