using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessengerApp.Data.DbContext.Migrations
{
    public partial class UserFriendsCompletedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserFriendId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserId1",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserFriendId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserFriendId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_UserFriendId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_UserId1",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "UserFriendId",
                table: "Friends");

            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "UserFriendId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "FriendRequests");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Friends",
                newName: "FriendsId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserId1",
                table: "Friends",
                newName: "IX_Friends_FriendsId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FriendRequests",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Friends",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "FriendId",
                table: "Friends",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverUserId",
                table: "FriendRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "FriendRequests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverUserId",
                table: "FriendRequests",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_ReceiverUserId",
                table: "FriendRequests",
                column: "ReceiverUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_SenderId",
                table: "FriendRequests",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_FriendsId",
                table: "Friends",
                column: "FriendsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_ReceiverUserId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendRequests_AspNetUsers_SenderId",
                table: "FriendRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_FriendsId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_Friends_UserId",
                table: "Friends");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_ReceiverUserId",
                table: "FriendRequests");

            migrationBuilder.DropIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "FriendRequests");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FriendsId",
                table: "Friends",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_FriendsId",
                table: "Friends",
                newName: "IX_Friends_UserId1");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "FriendRequests",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Friends",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "FriendId",
                table: "Friends",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserFriendId",
                table: "Friends",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FriendId",
                table: "FriendRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserFriendId",
                table: "FriendRequests",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "FriendRequests",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserFriendId",
                table: "Friends",
                column: "UserFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_UserFriendId",
                table: "FriendRequests",
                column: "UserFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_UserId1",
                table: "FriendRequests",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserFriendId",
                table: "FriendRequests",
                column: "UserFriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendRequests_AspNetUsers_UserId1",
                table: "FriendRequests",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserFriendId",
                table: "Friends",
                column: "UserFriendId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId1",
                table: "Friends",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
