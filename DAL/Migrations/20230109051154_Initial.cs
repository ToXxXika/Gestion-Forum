using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    blog_reference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    blog_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.blog_reference);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    idlog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    pwd = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.idlog);
                });

            migrationBuilder.CreateTable(
                name: "reaction",
                columns: table => new
                {
                    reaction_ref = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    reaction_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    reaction_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reaction", x => x.reaction_ref);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_ref = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_ref);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    post_ref = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    post_title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    post_content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    post_subtitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    blog_ref = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.post_ref);
                    table.ForeignKey(
                        name: "FK_post_blog_blog_ref",
                        column: x => x.blog_ref,
                        principalTable: "blog",
                        principalColumn: "blog_reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    idpermission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    permission_description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    permission_code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    role_ref = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.idpermission);
                    table.ForeignKey(
                        name: "FK_permission_role_role_ref",
                        column: x => x.role_ref,
                        principalTable: "role",
                        principalColumn: "role_ref",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur",
                columns: table => new
                {
                    utilisateur_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pwd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    roles = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateur", x => x.utilisateur_id);
                    table.ForeignKey(
                        name: "FK_utilisateur_role_roles",
                        column: x => x.roles,
                        principalTable: "role",
                        principalColumn: "role_ref",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reaction_post",
                columns: table => new
                {
                    idpostref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reaction_ref_pk = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    post_ref_pk = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    reaction_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reaction_post", x => x.idpostref);
                    table.ForeignKey(
                        name: "FK_reaction_post_post_post_ref_pk",
                        column: x => x.post_ref_pk,
                        principalTable: "post",
                        principalColumn: "post_ref",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reaction_post_reaction_reaction_ref_pk",
                        column: x => x.reaction_ref_pk,
                        principalTable: "reaction",
                        principalColumn: "reaction_ref",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_reference = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    comment_content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    comment_user = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_reference);
                    table.ForeignKey(
                        name: "FK_comments_utilisateur_comment_user",
                        column: x => x.comment_user,
                        principalTable: "utilisateur",
                        principalColumn: "utilisateur_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "utilisateur_Post",
                columns: table => new
                {
                    id_post_utilisateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    utilisateur_id_fk = table.Column<int>(type: "int", nullable: false),
                    post_ref_fk = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utilisateur_Post", x => x.id_post_utilisateur);
                    table.ForeignKey(
                        name: "FK_utilisateur_Post_post_post_ref_fk",
                        column: x => x.post_ref_fk,
                        principalTable: "post",
                        principalColumn: "post_ref",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_utilisateur_Post_utilisateur_utilisateur_id_fk",
                        column: x => x.utilisateur_id_fk,
                        principalTable: "utilisateur",
                        principalColumn: "utilisateur_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reaction_comment",
                columns: table => new
                {
                    reaction_ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment_ref_pk = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    reaction_ref_pk = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    reaction_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reaction_comment", x => x.reaction_ref);
                    table.ForeignKey(
                        name: "FK_reaction_comment_comments_comment_ref_pk",
                        column: x => x.comment_ref_pk,
                        principalTable: "comments",
                        principalColumn: "comment_reference",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reaction_comment_reaction_reaction_ref_pk",
                        column: x => x.reaction_ref_pk,
                        principalTable: "reaction",
                        principalColumn: "reaction_ref",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_comment_user",
                table: "comments",
                column: "comment_user");

            migrationBuilder.CreateIndex(
                name: "IX_permission_role_ref",
                table: "permission",
                column: "role_ref");

            migrationBuilder.CreateIndex(
                name: "IX_post_blog_ref",
                table: "post",
                column: "blog_ref");

            migrationBuilder.CreateIndex(
                name: "IX_reaction_comment_comment_ref_pk",
                table: "reaction_comment",
                column: "comment_ref_pk");

            migrationBuilder.CreateIndex(
                name: "IX_reaction_comment_reaction_ref_pk",
                table: "reaction_comment",
                column: "reaction_ref_pk");

            migrationBuilder.CreateIndex(
                name: "IX_reaction_post_post_ref_pk",
                table: "reaction_post",
                column: "post_ref_pk");

            migrationBuilder.CreateIndex(
                name: "IX_reaction_post_reaction_ref_pk",
                table: "reaction_post",
                column: "reaction_ref_pk");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_roles",
                table: "utilisateur",
                column: "roles");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_Post_post_ref_fk",
                table: "utilisateur_Post",
                column: "post_ref_fk");

            migrationBuilder.CreateIndex(
                name: "IX_utilisateur_Post_utilisateur_id_fk",
                table: "utilisateur_Post",
                column: "utilisateur_id_fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "reaction_comment");

            migrationBuilder.DropTable(
                name: "reaction_post");

            migrationBuilder.DropTable(
                name: "utilisateur_Post");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "reaction");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "utilisateur");

            migrationBuilder.DropTable(
                name: "blog");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
