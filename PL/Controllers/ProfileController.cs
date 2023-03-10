using BL.Models;
using DAL.DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Identity;

namespace PL.Controllers;

public class ProfileController : Controller
{
    
    private readonly ForumDbContext _context;
    
    public ProfileController(ForumDbContext context)
    {
        _context = context;
    }
    public List<UtilisateurPost> FindUsersPost()
    {
        var userPost = _context.utilisateur_Post
            .Include(x => x.utilisateur).ThenInclude(u => u.role).Include(x => x.post).ToList();
        Console.WriteLine(userPost.Count);
        return userPost;
    }
    public List<FriendshipRequest> FindFriendshipRequest()
    {
        var friendshipRequest = _context.friendshipRequest.Include(x=>x.receiver).Include(x=>x.sender).ToList();
        return friendshipRequest;
    }

    public List<UtilisateurPost> FindLatestUsersPost()
    {
        return _context.utilisateur_Post.OrderByDescending(x => x.utilisateur).Take(3).ToList();
    }

    public List<Reaction_Post> FindReaction_Post()
    {
        var ReactionPost = _context.reaction_Post.Include(x => x.post)
            .Include(x => x.reaction).ToList();
        return ReactionPost;
    }
    [HttpDelete]
    public IActionResult Delete([Bind("post_ref") ] string id)
    {
        var userPost = _context.utilisateur_Post.Find(id);
        var post = _context.post.Find(id);
        var postcomments=  _context.PostComments.Find(id);
        var reactionPost = _context.reaction_Post.Find(id);
        if (post == null || userPost == null   || reactionPost == null)
        {
            return NotFound();
        }
      
        _context.utilisateur_Post.Remove(userPost);
        _context.PostComments.Remove(postcomments);
        _context.reaction_Post.Remove(reactionPost);
        _context.post.Remove(post);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    // GET
    public  IActionResult Index()
    {
        var viewModel2 = new ArrayViewModel2()
        {
            userPost = FindUsersPost()
        };
     
        var viewModel3 = new ArrayViewModel2
        {
            ReactionPost = FindReaction_Post()
        };
        var viewModel4 = new ArrayViewModel2()
        {
           LatestUserPost = FindLatestUsersPost()
        };
        var ViewModel5 = new ArrayViewModel2()
        {
            FriendshipRequest = FindFriendshipRequest()
        };

        var username = HttpContext.Session.GetString("username");
         
        
        Utilisateur u = JsonConvert.DeserializeObject<Utilisateur>(
            System.IO.File.ReadAllText(@"C:\Users\mabro\RiderProjects\Gestion-Forum\PL\JsonDeserializer\user.json"));
  
        ViewBag.user = u;
        ViewBag.userPost = viewModel2;
        ViewBag.ReactionPost = viewModel3;
        ViewBag.userLatestPost = viewModel4;
        ViewBag.FriendshipRequest = ViewModel5;
       return   View("Profile");
    }

   
}
public class ArrayViewModel2
{
    public List<Blog> BlogArray { get; set; }
    public List<UtilisateurPost> userPost { get; set; }
    public List<UtilisateurPost> LatestUserPost { get; set; }
    public List<Reaction_Post> ReactionPost { get; set; }
    public List<FriendshipRequest> FriendshipRequest { get; set; }
}