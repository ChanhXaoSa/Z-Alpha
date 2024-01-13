using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInteractComments");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ReplyCommentId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAccountId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AnonymousStatus", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "NumberOfDisLikes", "NumberOfLikes", "PostBody", "PostImagesUrl", "PostTitle" },
                values: new object[,]
                {
                    { new Guid("55b7d164-ebb7-466e-a7d8-d2c1cbed3d30"), 1, new DateTime(2024, 1, 13, 19, 6, 59, 218, DateTimeKind.Local).AddTicks(1047), null, false, null, null, 10, 100, "Nội dung bài đăng test thử ", "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C", "Nội dung bài đăng test 1" },
                    { new Guid("75da058c-13cf-4027-9962-8e4c00ec297c"), 1, new DateTime(2024, 1, 13, 19, 6, 59, 218, DateTimeKind.Local).AddTicks(1032), null, false, null, null, 10, 100, "Nội dung bài đăng test thử ", "https://scontent.fsgn5-10.fna.fbcdn.net/v/t39.30808-6/387798154_632107352457871_5690110333313757656_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=3635dc&_nc_ohc=OpZIs7vdMK8AX9Hgjkq&_nc_ht=scontent.fsgn5-10.fna&oh=00_AfAvpIg3y_s3UEGS0ilM8J6x6spEamFSC3sjhVn3V7G5-A&oe=65A6DF8C", "Nội dung bài đăng test 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyCommentId",
                table: "Comments",
                column: "ReplyCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserAccountId",
                table: "Comments",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserAccountId",
                table: "Comments",
                column: "UserAccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ReplyCommentId",
                table: "Comments",
                column: "ReplyCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserAccountId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ReplyCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ReplyCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserAccountId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("55b7d164-ebb7-466e-a7d8-d2c1cbed3d30"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("75da058c-13cf-4027-9962-8e4c00ec297c"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ReplyCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "UserInteractComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteractComment = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInteractComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInteractComments_AspNetUsers_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInteractComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractComments_CommentId",
                table: "UserInteractComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInteractComments_UserAccountId",
                table: "UserInteractComments",
                column: "UserAccountId");
        }
    }
}
