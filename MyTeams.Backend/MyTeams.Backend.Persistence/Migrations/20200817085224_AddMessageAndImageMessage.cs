using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTeams.Backend.Persistence.Migrations
{
    public partial class AddMessageAndImageMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Channels_ChannelId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_FromId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message_FromId",
                table: "Messages",
                newName: "IX_Messages_FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ChannelId",
                table: "Messages",
                newName: "IX_Messages_ChannelId");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Messages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Channels_ChannelId",
                table: "Messages",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Channels_ChannelId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromId",
                table: "Message",
                newName: "IX_Message_FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ChannelId",
                table: "Message",
                newName: "IX_Message_ChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Channels_ChannelId",
                table: "Message",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_FromId",
                table: "Message",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
