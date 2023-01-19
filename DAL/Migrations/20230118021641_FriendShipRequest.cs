using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class FriendShipRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "about",
                table: "utilisateur",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "FriendshipRequest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sender_id = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    receiver_id = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendshipRequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_FriendshipRequest_utilisateur_receiver_id",
                        column: x => x.receiver_id,
                        principalTable: "utilisateur",
                        principalColumn: "utilisateur_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FriendshipRequest_utilisateur_sender_id",
                        column: x => x.sender_id,
                        principalTable: "utilisateur",
                        principalColumn: "utilisateur_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendshipRequest_receiver_id",
                table: "FriendshipRequest",
                column: "receiver_id");

            migrationBuilder.CreateIndex(
                name: "IX_FriendshipRequest_sender_id",
                table: "FriendshipRequest",
                column: "sender_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendshipRequest");

            migrationBuilder.AlterColumn<string>(
                name: "about",
                table: "utilisateur",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
