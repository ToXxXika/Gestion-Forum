
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BL.Models;
using DAL.DataBaseContext;
using Hanssens.Net;
using Newtonsoft.Json;
using Blazored.LocalStorage;


namespace PL.Controllers
{
    public class LoginController : Controller
    {
        public readonly ForumDbContext _context;

        public LoginController(ForumDbContext context)
        {
            _context = context;
        }


        // GET: Login
        public async Task<IActionResult> Index()
        {
            return _context.login != null ? View() : Problem("Entity set 'ForumDbContext.login'  is null.");
        }


        [HttpPost]
        public async Task<IActionResult> VerifyLogs([Bind("mail", "pwd")] Login _Login)
        {
            //verify if the user exists
            var user = await _context.login.FirstOrDefaultAsync(m => m.mail == _Login.mail && m.pwd == _Login.pwd);
            if (user != null)
            {
                Console.WriteLine("User found");
                var user2 = await _context.utilisateur.FirstOrDefaultAsync(x => x.mail == _Login.mail);
                TempData["LocalNom"] = user2?.nom;
                TempData["LocalPrenom"] = user2?.prenom;
                TempData["LocalMail"] = user2?.mail;
                TempData["LocalPhone"] = user2?.phone;
                TempData["LocalUserName"] = user2?.username;
                TempData["adresse"] = user2?.adresse;
                TempData["LocalId"] = user2?.utilisateur_id;
                ViewBag.userName = user2.username;
                await System.IO.File.WriteAllTextAsync(
                    @"C:\Users\mabro\RiderProjects\\Gestion-Forum\\PL\\JsonDeserializer\\user.json",
                    JsonConvert.SerializeObject(user2));
   

                HttpContext.Session.SetString("username", user2.username);
             
                

                return RedirectToAction("Index", "Home",new {data = user2.username});
            }
            Console.WriteLine("USER NOT FOUND ");
            return RedirectToAction("Index", "Login");
        }


        private bool LoginExists(int id)
        {
            return (_context.login?.Any(e => e.idlog == id)).GetValueOrDefault();
        }
    }
}

    
   
