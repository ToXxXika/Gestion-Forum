using System.Security.Cryptography;
using System.Text;
using BL.Models;
using DAL.DataBaseContext;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers;

public class SignUpController : Controller
{
    public  readonly  ForumDbContext _context;
    // GET
    public IActionResult Index()
    {
        return View("Signup");
    }

    public SignUpController(ForumDbContext context)
    {
        _context = context;
    }

    public String HashPassword(String password)
    {
        byte[] passwordByte = Encoding.UTF8.GetBytes(password);
        HashAlgorithm algorithm = new SHA256Managed();
        byte[] hash = algorithm.ComputeHash(passwordByte);
        return hash.ToString();
    }
    [HttpPost]
    public async Task<IActionResult> AddUser([Bind("nom,prenom,mail,pwd,adresse,username,phone")] Utilisateur utilisateur)
    {
        utilisateur.Country = Request.Form["Country"].ToString();
        utilisateur.roles = "R123";
        utilisateur.about = "DEFINE ME LATER";
        await _context.AddAsync(utilisateur);
        Login user = new Login();
        user.mail=utilisateur.mail;
        user.pwd=utilisateur.pwd;
        await _context.login.AddAsync(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Login");
    }

 
}