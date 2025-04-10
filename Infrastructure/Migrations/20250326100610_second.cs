using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatuses_DefaultStatusId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DefaultStatusId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "MaxAttendeeNo",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "DefaultStatusId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AccessCode",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_DefaultStatusId",
                table: "Events",
                column: "DefaultStatusId",
                unique: true,
                filter: "[DefaultStatusId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatuses_DefaultStatusId",
                table: "Events",
                column: "DefaultStatusId",
                principalTable: "EventStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventStatuses_DefaultStatusId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DefaultStatusId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "MaxAttendeeNo",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DefaultStatusId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccessCode",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DefaultStatusId",
                table: "Events",
                column: "DefaultStatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventStatuses_DefaultStatusId",
                table: "Events",
                column: "DefaultStatusId",
                principalTable: "EventStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
