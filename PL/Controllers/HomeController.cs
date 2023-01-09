using System.Diagnostics;
using BL.Models;
using DAL.DataBaseContext;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Models;
using PL.Repositories;

namespace PL.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ForumDbContext _context;
    private readonly  PostRepository _postRepository;
    private readonly  BlogRepository _blogRepository;

    public HomeController(ILogger<HomeController> logger,ForumDbContext context)
    {
        _logger = logger;
        _context = context;
    }
  

    [HttpGet]
    public List<Blog> GetBlogs()
    {
        return  _context.blog.ToList();
    }
    public List<Post> GetPosts()
    {
        return _context.post.ToList();
    }
    public IActionResult Index()
    {
        var blogsList = GetBlogs();
        var postlist = GetPosts();
        var viewModel2 = new ArrayViewModel()
        {
            PostArray  = postlist
        };
        var viewModel = new ArrayViewModel
        {
            BlogArray = blogsList
        };
        //receive the data from LoginController
        var localNom = TempData["LocalNom"];
        var localPrenom = TempData["LocalPrenom"];
        ViewData["BlogList"] = viewModel;
        ViewData["PostList"] = viewModel2;
        ViewData["Nom"] = localNom;
        ViewData["Prenom"] = localPrenom;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPost([Bind("post_title,post_content,post_subtitle,blog_ref,utilisateur_id")] Post post, int userId)
    {
        post.post_ref = _postRepository.GenrateRandomReference();
        post.utilisateur_id = userId;
        await _context.post.AddAsync(post);
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
    public List<Post> PostArray { get; set; }
}