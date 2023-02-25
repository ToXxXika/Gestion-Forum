using System.Diagnostics;
using BL.Models;
using DAL.DataBaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Models;
using Hanssens.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Newtonsoft.Json;

namespace PL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ForumDbContext _context;
    

    public HomeController(ILogger<HomeController> logger, ForumDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public List<Utilisateur> getUsers()
    {
        var users = _context.utilisateur.ToList();
        return users;
    }

    public List<UtilisateurPost> FindUsersPost()
    {
        var userPost = _context.utilisateur_Post
            .Include(x => x.utilisateur).ThenInclude(u => u.role).Include(x => x.post).ToList();
        return userPost;
    }

    public List<Reaction_Post> FindReaction_Post()
    {
        var ReactionPost = _context.reaction_Post.Include(x => x.post)
            .Include(x => x.reaction).ToList();
        return ReactionPost;
    }
    public List<FriendshipRequest> FindFriendshipRequest()
    {
        var friendshipRequest = _context.friendshipRequest.Include(x=>x.receiver).Include(x=>x.sender).ToList();
        return friendshipRequest;
    }


    [HttpGet]
    public List<Blog> GetBlogs()
    {
        return _context.blog.ToList();
    }


    public IActionResult Index()
    {
        var  data = HttpContext.Session.GetString("username");
        
        
        var blogsList = GetBlogs();
        var userPost = FindUsersPost();
        var ReactionList = FindReaction_Post();
        var users = getUsers();
        var viewModel2 = new ArrayViewModel()
        {
            userPost = userPost
        };
        var viewModel = new ArrayViewModel
        {
            BlogArray = blogsList
        };
        var viewModel3 = new ArrayViewModel
        {
            ReactionPost = ReactionList
        };
        var viewModel4 = new ArrayViewModel()
        {
            FriendshipRequests = FindFriendshipRequest()
        };
        var viewModel5 = new ArrayViewModel()
        {
            Users = users
        };
        //receive the data from LoginController
        var localNom = TempData["LocalNom"];
        var localPrenom = TempData["LocalPrenom"];
        ViewData["BlogList"] = viewModel;
        ViewData["PostList"] = viewModel2;
        ViewData["ReactionPost"] = viewModel3;
        ViewData["FriendshipRequest"]= viewModel4;
        ViewData["Users"] = viewModel5;
        ViewData["Nom"] = localNom;
        ViewData["Prenom"] = localPrenom;
        ViewData["blog"] = new SelectList(_context.blog, "blog_reference", "blog_title");
        Utilisateur u = JsonConvert.DeserializeObject<Utilisateur>(
            System.IO.File.ReadAllText(@"C:\Users\mabro\RiderProjects\Gestion-Forum\PL\JsonDeserializer\user.json"));
        Console.WriteLine(viewModel3.ReactionPost.Count);
        ViewBag.user = u;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public String GenrateRandomReference()
    {
        //TODO: Generate Random Reference if u want to change it and test if it's not found
        return "REF" + new Random().Next(1, 999999).ToString();
    }

    
    public IActionResult UpdateReaction(string reactionref,string postref)
    {
   
        Console.WriteLine("reaction ref : "+reactionref);
        Console.WriteLine("post ref : "+postref);
         
        var reaction = _context.reaction_Post.FirstOrDefault(x => x.post_ref_pk == postref && x.reaction_ref_pk == reactionref);
        reaction.reaction_count  += 1;
        _context.reaction_Post.Update(reaction);
        if (_context.SaveChanges() < 0)
        {
            Console.WriteLine("Error while updating reaction");
        }else
        {
            Console.WriteLine("Reaction updated successfully");
        }
        return RedirectToAction("Index");
        
    }
    [HttpPost]
    public IActionResult AddFriend(int sender,int receiver)
    {
        Console.WriteLine("sender : "+sender);
        Console.WriteLine("receiver : "+receiver);
        var friendshipRequest = new FriendshipRequest()
        {
            senderId = sender,
            receiverId= receiver,
            status = "pending"
        };
        _context.friendshipRequest.Add(friendshipRequest);
        if (_context.SaveChanges() < 0)
        {
            Console.WriteLine("Error while adding friend");
        }else
        {
            Console.WriteLine("Friend added successfully");
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPost([Bind("post_title,post_content,post_subtitle,blog_ref")] Post post)
    {
     
        post.post_ref = GenrateRandomReference();
        Utilisateur u = JsonConvert.DeserializeObject<Utilisateur>(
            System.IO.File.ReadAllText(@"C:\Users\mabro\RiderProjects\Gestion-Forum\PL\JsonDeserializer\user.json"));
       
        UtilisateurPost UP = new UtilisateurPost()
        {
            utilisateur_id_fk = u.utilisateur_id,
            post_ref_fk = post.post_ref
        };
        await _context.post.AddAsync(post);
        await _context.SaveChangesAsync();
        await _context.utilisateur_Post.AddAsync(UP);
        await _context.SaveChangesAsync();
            
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class ArrayViewModel
{
    public List<Blog> BlogArray { get; set; }
    public List<UtilisateurPost> userPost { get; set; }
    public List<Reaction_Post> ReactionPost { get; set; }
    public List<FriendshipRequest> FriendshipRequests { get; set; }
    public List<Utilisateur> Users { get; set; }
}