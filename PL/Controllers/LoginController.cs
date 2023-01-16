using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BL.Models;
using DAL.DataBaseContext;

using Newtonsoft.Json;
using SQLitePCL;

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
              return _context.login != null ? 
                          View() :
                          Problem("Entity set 'ForumDbContext.login'  is null.");
        }


        [HttpPost]
        public async Task<IActionResult> VerifyLogs([Bind("mail","pwd")] Login _Login)
        {
            //check if context is initialized 
            //display Login
            Console.WriteLine(_Login.mail+" "+_Login.pwd);
            //verify if the user exists
            var user = await _context.login.FirstOrDefaultAsync(m => m.mail == _Login.mail && m.pwd == _Login.pwd);
            if (user != null)
            {
                Console.WriteLine("User found");
               var user2 =  await _context.utilisateur.FirstOrDefaultAsync(x=>x.mail == _Login.mail);
               TempData["LocalNom"] = user2.nom;
               TempData["LocalPrenom"] = user2.prenom;
               TempData["LocalMail"] = user2.mail;
               TempData["LocalPhone"]= user2.phone;
               TempData["LocalUserName"] = user2.username;
               TempData["adresse"] = user2.adresse;
               TempData["LocalId"] = user2.utilisateur_id;
               await System.IO.File.WriteAllTextAsync(@"C:\Users\MSI\RiderProjects\Gestion-Forum\PL\JsonDeserializer\user.json",JsonConvert.SerializeObject(user2));


               return RedirectToAction("Index", "Home");
            }
            else
            {
                Console.WriteLine("USER NOT FOUND ");
                return RedirectToAction("Index", "Login");
            }
            
        }



        private bool LoginExists(int id)
        {
          return (_context.login?.Any(e => e.idlog == id)).GetValueOrDefault();
        }
        
    }
}
