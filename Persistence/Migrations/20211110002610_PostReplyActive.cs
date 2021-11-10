using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PostReplyActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PostReplies",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TargetPostReplyId",
                table: "PostReplies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_TargetPostReplyId",
                table: "PostReplies",
                column: "TargetPostReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_PostReplies_TargetPostReplyId",
                table: "PostReplies",
                column: "TargetPostReplyId",
                principalTable: "PostReplies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_PostReplies_TargetPostReplyId",
                table: "PostReplies");

            migrationBuilder.DropIndex(
                name: "IX_PostReplies_TargetPostReplyId",
                table: "PostReplies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PostReplies");

            migrationBuilder.DropColumn(
                name: "TargetPostReplyId",
                table: "PostReplies");
        }
    }
}
