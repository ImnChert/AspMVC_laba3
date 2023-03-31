using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class messagedefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumMessages_Forums_ForumId",
                table: "ForumMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumMessages_Users_UserId",
                table: "ForumMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForumMessages",
                table: "ForumMessages");

            migrationBuilder.RenameTable(
                name: "ForumMessages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_ForumMessages_UserId",
                table: "Message",
                newName: "IX_Message_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumMessages_ForumId",
                table: "Message",
                newName: "IX_Message_ForumId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEditing",
                table: "Message",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfDispath",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 31, 9, 23, 33, 597, DateTimeKind.Local).AddTicks(66),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Forums_ForumId",
                table: "Message",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Forums_ForumId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_UserId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "ForumMessages");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserId",
                table: "ForumMessages",
                newName: "IX_ForumMessages_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ForumId",
                table: "ForumMessages",
                newName: "IX_ForumMessages_ForumId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsEditing",
                table: "ForumMessages",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfDispath",
                table: "ForumMessages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 31, 9, 23, 33, 597, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForumMessages",
                table: "ForumMessages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumMessages_Forums_ForumId",
                table: "ForumMessages",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumMessages_Users_UserId",
                table: "ForumMessages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
