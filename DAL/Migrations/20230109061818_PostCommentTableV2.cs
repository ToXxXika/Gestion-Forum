using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class PostCommentTableV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_commments_post_post_ref",
                table: "post_commments");

            migrationBuilder.DropForeignKey(
                name: "FK_post_commments_utilisateur_utilisateur_id",
                table: "post_commments");

            migrationBuilder.DropIndex(
                name: "IX_post_commments_post_ref",
                table: "post_commments");

            migrationBuilder.DropIndex(
                name: "IX_post_commments_utilisateur_id",
                table: "post_commments");

            migrationBuilder.DropColumn(
                name: "post_ref",
                table: "post_commments");

            migrationBuilder.DropColumn(
                name: "utilisateur_id",
                table: "post_commments");

            migrationBuilder.AlterColumn<string>(
                name: "id_post",
                table: "post_commments",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_post_commments_id_post",
                table: "post_commments",
                column: "id_post");

            migrationBuilder.CreateIndex(
                name: "IX_post_commments_id_utilisateur",
                table: "post_commments",
                column: "id_utilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_post_commments_post_id_post",
                table: "post_commments",
                column: "id_post",
                principalTable: "post",
                principalColumn: "post_ref",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_commments_utilisateur_id_utilisateur",
                table: "post_commments",
                column: "id_utilisateur",
                principalTable: "utilisateur",
                principalColumn: "utilisateur_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_commments_post_id_post",
                table: "post_commments");

            migrationBuilder.DropForeignKey(
                name: "FK_post_commments_utilisateur_id_utilisateur",
                table: "post_commments");

            migrationBuilder.DropIndex(
                name: "IX_post_commments_id_post",
                table: "post_commments");

            migrationBuilder.DropIndex(
                name: "IX_post_commments_id_utilisateur",
                table: "post_commments");

            migrationBuilder.AlterColumn<string>(
                name: "id_post",
                table: "post_commments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "post_ref",
                table: "post_commments",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "utilisateur_id",
                table: "post_commments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_post_commments_post_ref",
                table: "post_commments",
                column: "post_ref");

            migrationBuilder.CreateIndex(
                name: "IX_post_commments_utilisateur_id",
                table: "post_commments",
                column: "utilisateur_id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_commments_post_post_ref",
                table: "post_commments",
                column: "post_ref",
                principalTable: "post",
                principalColumn: "post_ref");

            migrationBuilder.AddForeignKey(
                name: "FK_post_commments_utilisateur_utilisateur_id",
                table: "post_commments",
                column: "utilisateur_id",
                principalTable: "utilisateur",
                principalColumn: "utilisateur_id");
        }
    }
}
