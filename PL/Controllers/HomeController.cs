﻿using System.Diagnostics;
using BL.Models;
using DAL.DataBaseContext;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PL.Models;
using BL.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public List<UtilisateurPost> FindUsersPost()
    {
        var userPost = _context.utilisateur_Post
            .Include(x=>x.utilisateur).ThenInclude(u=>u.role).Include(x=>x.post).ToList();
        return userPost;
    }

    public List<Reaction_Post> FindReaction_Post()
    {
        var ReactionPost = _context.reaction_Post.Include(x => x.post)
            .Include(x => x.reaction).ToList();
        return ReactionPost;
    }

    
    [HttpGet]
    public List<Blog> GetBlogs()
    {
        return  _context.blog.ToList();
    }
   
    public IActionResult Index()
    {
        var blogsList = GetBlogs();
        var userPost = FindUsersPost();
     
        Console.WriteLine(userPost.Count);
        var viewModel2 = new ArrayViewModel()
        {
            userPost  = userPost
        };
        var viewModel = new ArrayViewModel
        {
            BlogArray = blogsList
        };
        var viewModel3 = new ArrayViewModel
        {
            ReactionPost = FindReaction_Post()
        };
        //receive the data from LoginController
        var localNom = TempData["LocalNom"];
        var localPrenom = TempData["LocalPrenom"];
        ViewData["BlogList"] = viewModel;
        ViewData["PostList"] = viewModel2;
        ViewData["ReactionPost"] = viewModel3;
        ViewData["Nom"] = localNom;
        ViewData["Prenom"] = localPrenom;
        ViewData["blog"] = new SelectList(_context.blog, "blog_reference", "blog_title");
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
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPost([Bind("post_title,post_content,post_subtitle,blog_ref")] Post post)
    {
        Console.WriteLine("Hello i'm here ");
        post.post_ref = GenrateRandomReference();
        await _context.post.AddAsync(post);
        await _context.SaveChangesAsync();
        UtilisateurPost UP = new UtilisateurPost();
        
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
}