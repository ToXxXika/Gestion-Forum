using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class PostCommentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "post_commments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_post = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_utilisateur = table.Column<int>(type: "int", nullable: false),
                    post_ref = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    utilisateur_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_commments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_post_commments_post_post_ref",
                        column: x => x.post_ref,
                        principalTable: "post",
                        principalColumn: "post_ref");
                    table.ForeignKey(
                        name: "FK_post_commments_utilisateur_utilisateur_id",
                        column: x => x.utilisateur_id,
                        principalTable: "utilisateur",
                        principalColumn: "utilisateur_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_post_commments_post_ref",
                table: "post_commments",
                column: "post_ref");

            migrationBuilder.CreateIndex(
                name: "IX_post_commments_utilisateur_id",
                table: "post_commments",
                column: "utilisateur_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post_commments");
        }
    }
}
