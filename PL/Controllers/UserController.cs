using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BL.Models;
using DAL.DataBaseContext;

namespace PL.Controllers
{
    public class UserController : Controller
    {
        private readonly ForumDbContext _context;

        public UserController(ForumDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var forumDbContext = _context.utilisateur.Include(u => u.role);
            return View(await forumDbContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.utilisateur == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur
                .Include(u => u.role)
                .FirstOrDefaultAsync(m => m.utilisateur_id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            ViewData["roles"] = new SelectList(_context.role, "role_ref", "role_name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("utilisateur_id,nom,prenom,mail,pwd,roles,adresse,username,phone")] Utilisateur utilisateur)
        {
             Console.WriteLine(utilisateur.adresse+" "+utilisateur.mail+" "+utilisateur.nom+" "+utilisateur.prenom+" "+utilisateur.pwd+" "+utilisateur.roles+" "+utilisateur.username+" "+utilisateur.phone);;

             
             utilisateur.pwd = HashPassword(utilisateur.pwd);
                await _context.AddAsync(utilisateur);
                await _context.SaveChangesAsync();
                Login user = new Login();
                user.mail=utilisateur.mail;
                user.pwd=utilisateur.pwd;
                await _context.login.AddAsync(user);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            
           
        }

        public String HashPassword(String password)
        {
            byte[] passwordByte = Encoding.UTF8.GetBytes(password);
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(passwordByte);
            return hash.ToString();
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.utilisateur == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }
            ViewData["roles"] = new SelectList(_context.role, "role_ref", "role_name", utilisateur.roles);
            return View(utilisateur);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("utilisateur_id,nom,prenom,mail,pwd,roles,adresse,username,phone")] Utilisateur utilisateur)
        {
            if (id != utilisateur.utilisateur_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilisateurExists(utilisateur.utilisateur_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["roles"] = new SelectList(_context.role, "role_ref", "role_ref", utilisateur.roles);
            return View(utilisateur);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.utilisateur == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.utilisateur
                .Include(u => u.role)
                .FirstOrDefaultAsync(m => m.utilisateur_id == id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            return View(utilisateur);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.utilisateur == null)
            {
                return Problem("Entity set 'ForumDbContext.utilisateur'  is null.");
            }
            var utilisateur = await _context.utilisateur.FindAsync(id);
            if (utilisateur != null)
            {
                _context.utilisateur.Remove(utilisateur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilisateurExists(int id)
        {
          return (_context.utilisateur?.Any(e => e.utilisateur_id == id)).GetValueOrDefault();
        }
        
      
    }
    
}
