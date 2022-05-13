using ArtSystemApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSystemApp.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null) return NotFound();
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                user.Accesses = await _context.Accesses.Where(a => a.User.Id == user.Id).ToListAsync();
                user.Works = await _context.Works.Where(w => w.User.Id == user.Id).ToListAsync();
                user.Confirmation = await _context.Confirmations.FirstOrDefaultAsync(c => c.Users.Contains(user));
                user.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Users.Contains(user));
                return View(user);
            }           
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            user.Accesses = await _context.Accesses.Where(a => a.User == user).ToListAsync();
            user.Works = await _context.Works.Where(w => w.User == user).ToListAsync();            
            user.Confirmation= await _context.Confirmations.FirstOrDefaultAsync(c => c.Users.Contains(user));
            user.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Users.Contains(user));
            return View(user);
        }

        public async Task<IActionResult> SendRequest()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            user.Confirmation = await _context.Confirmations.FirstOrDefaultAsync(c => c.Name == "await");
            await _context.SaveChangesAsync();
            return RedirectToAction("Home");
        }

        public IActionResult Privacy()
        {
            return RedirectToAction("Home", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
