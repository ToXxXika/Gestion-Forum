﻿// <auto-generated />
using System;
using DAL.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    partial class ForumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BL.Models.Blog", b =>
                {
                    b.Property<string>("blog_reference")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("blog_reference");

                    b.Property<string>("blog_title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("blog_title");

                    b.HasKey("blog_reference");

                    b.ToTable("blog");
                });

            modelBuilder.Entity("BL.Models.Comments", b =>
                {
                    b.Property<string>("comment_reference")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("comment_reference");

                    b.Property<string>("comment_content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("comment_content");

                    b.Property<int>("comment_user")
                        .HasColumnType("int");

                    b.HasKey("comment_reference");

                    b.HasIndex("comment_user");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("BL.Models.Login", b =>
                {
                    b.Property<int>("idlog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idlog"), 1L, 1);

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("pwd")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("idlog");

                    b.ToTable("login");
                });

            modelBuilder.Entity("BL.Models.Permission", b =>
                {
                    b.Property<int>("idpermission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idpermission"), 1L, 1);

                    b.Property<string>("permission_code")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("permission_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permission_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_ref")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("idpermission");

                    b.HasIndex("role_ref");

                    b.ToTable("permission");
                });

            modelBuilder.Entity("BL.Models.Post", b =>
                {
                    b.Property<string>("post_ref")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("blog_ref")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("post_content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("post_subtitle")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("post_title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("utilisateur_id")
                        .HasColumnType("int");

                    b.HasKey("post_ref");

                    b.HasIndex("blog_ref");

                    b.HasIndex("utilisateur_id");

                    b.ToTable("post");
                });

            modelBuilder.Entity("BL.Models.Reaction", b =>
                {
                    b.Property<string>("reaction_ref")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("reaction_ref");

                    b.Property<string>("reaction_description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reaction_description");

                    b.Property<string>("reaction_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reaction_type");

                    b.HasKey("reaction_ref");

                    b.ToTable("reaction");
                });

            modelBuilder.Entity("BL.Models.Reaction_Post", b =>
                {
                    b.Property<int>("idpostref")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idpostref");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idpostref"), 1L, 1);

                    b.Property<string>("post_ref_pk")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("post_ref_pk");

                    b.Property<int>("reaction_count")
                        .HasColumnType("int")
                        .HasColumnName("reaction_count");

                    b.Property<string>("reaction_ref_pk")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("reaction_ref_pk");

                    b.HasKey("idpostref");

                    b.HasIndex("post_ref_pk");

                    b.HasIndex("reaction_ref_pk");

                    b.ToTable("reaction_post");
                });

            modelBuilder.Entity("BL.Models.ReactionComment", b =>
                {
                    b.Property<int>("reaction_ref")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reaction_ref");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("reaction_ref"), 1L, 1);

                    b.Property<string>("comment_ref_pk")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("comment_ref_pk");

                    b.Property<int>("reaction_count")
                        .HasColumnType("int")
                        .HasColumnName("reaction_count");

                    b.Property<string>("reaction_ref_pk")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("reaction_ref_pk");

                    b.HasKey("reaction_ref");

                    b.HasIndex("comment_ref_pk");

                    b.HasIndex("reaction_ref_pk");

                    b.ToTable("reaction_comment");
                });

            modelBuilder.Entity("BL.Models.Role", b =>
                {
                    b.Property<string>("role_ref")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("role_ref");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_ref");

                    b.ToTable("role");
                });

            modelBuilder.Entity("BL.Models.Utilisateur", b =>
                {
                    b.Property<int>("utilisateur_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("utilisateur_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("utilisateur_id"), 1L, 1);

                    b.Property<string>("adresse")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("adresse");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("mail");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nom");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("prenom");

                    b.Property<string>("pwd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("pwd");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.Property<string>("rolesrole_ref")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("username");

                    b.HasKey("utilisateur_id");

                    b.HasIndex("rolesrole_ref");

                    b.ToTable("utilisateur");
                });

            modelBuilder.Entity("BL.Models.UtilisateurPost", b =>
                {
                    b.Property<int>("id_post_utilisateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_post_utilisateur");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_post_utilisateur"), 1L, 1);

                    b.Property<string>("post_ref_fk")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("post_ref_fk");

                    b.Property<int>("utilisateur_id_fk")
                        .HasColumnType("int")
                        .HasColumnName("utilisateur_id_fk");

                    b.HasKey("id_post_utilisateur");

                    b.HasIndex("post_ref_fk");

                    b.HasIndex("utilisateur_id_fk");

                    b.ToTable("utilisateur_Post");
                });

            modelBuilder.Entity("BL.Models.Comments", b =>
                {
                    b.HasOne("BL.Models.Utilisateur", "utilisateur")
                        .WithMany("Comments")
                        .HasForeignKey("comment_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("utilisateur");
                });

            modelBuilder.Entity("BL.Models.Permission", b =>
                {
                    b.HasOne("BL.Models.Role", "role")
                        .WithMany()
                        .HasForeignKey("role_ref")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("BL.Models.Post", b =>
                {
                    b.HasOne("BL.Models.Blog", "blog")
                        .WithMany("Posts")
                        .HasForeignKey("blog_ref")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BL.Models.Utilisateur", null)
                        .WithMany("Posts")
                        .HasForeignKey("utilisateur_id");

                    b.Navigation("blog");
                });

            modelBuilder.Entity("BL.Models.Reaction_Post", b =>
                {
                    b.HasOne("BL.Models.Post", "post")
                        .WithMany()
                        .HasForeignKey("post_ref_pk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BL.Models.Reaction", "reaction")
                        .WithMany()
                        .HasForeignKey("reaction_ref_pk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("reaction");
                });

            modelBuilder.Entity("BL.Models.ReactionComment", b =>
                {
                    b.HasOne("BL.Models.Comments", "comment")
                        .WithMany()
                        .HasForeignKey("comment_ref_pk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BL.Models.Reaction", "reaction")
                        .WithMany()
                        .HasForeignKey("reaction_ref_pk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comment");

                    b.Navigation("reaction");
                });

            modelBuilder.Entity("BL.Models.Utilisateur", b =>
                {
                    b.HasOne("BL.Models.Role", "roles")
                        .WithMany()
                        .HasForeignKey("rolesrole_ref")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });

            modelBuilder.Entity("BL.Models.UtilisateurPost", b =>
                {
                    b.HasOne("BL.Models.Post", "post")
                        .WithMany()
                        .HasForeignKey("post_ref_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BL.Models.Utilisateur", "utilisateur")
                        .WithMany()
                        .HasForeignKey("utilisateur_id_fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("post");

                    b.Navigation("utilisateur");
                });

            modelBuilder.Entity("BL.Models.Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BL.Models.Utilisateur", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
