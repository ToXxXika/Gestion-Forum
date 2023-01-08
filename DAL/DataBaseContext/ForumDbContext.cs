using BL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataBaseContext;

public class ForumDbContext:DbContext
{

    public ForumDbContext(DbContextOptions<ForumDbContext> options):base(options)
    {
        
    }
 
    
    public DbSet<Utilisateur> utilisateur{get;set;}
    public DbSet<Login> login{get;set;}
    public DbSet<Role> role{get;set;}
    public DbSet<Comments> comments{get;set;}
    public DbSet<Post> post{get;set;}
    public DbSet<Permission> permission{get;set;}
    public DbSet<Reaction> reaction{get;set;}
    public DbSet<Reaction_Post> reaction_Post{get;set;}
    public DbSet<ReactionComment> reaction_Comment{get;set;}
    public DbSet<UtilisateurPost> utilisateur_Post{get;set;}
    public DbSet<Blog> blog{get;set;}
}