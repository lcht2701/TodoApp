using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class change_field_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubItems_TodoItems_TaskId",
                table: "SubItems");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "SubItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_SubItems_TaskId",
                table: "SubItems",
                newName: "IX_SubItems_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubItems_TodoItems_ItemId",
                table: "SubItems",
                column: "ItemId",
                principalTable: "TodoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubItems_TodoItems_ItemId",
                table: "SubItems");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "SubItems",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_SubItems_ItemId",
                table: "SubItems",
                newName: "IX_SubItems_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubItems_TodoItems_TaskId",
                table: "SubItems",
                column: "TaskId",
                principalTable: "TodoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
