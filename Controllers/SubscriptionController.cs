using ArtSystemApp.Models;
using ArtSystemApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArtSystemApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private UserContext _context;
        public SubscriptionController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSubscriptionModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            if (ModelState.IsValid)
            {
                Access acc = null;
                if(model.Name != null)
                {
                    acc = new()
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        User = user
                    };
                }

                if(acc != null)
                {
                    _context.Accesses.Add(acc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Home", "Home");

                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Action(int? acc_id, string action_button)
        {
            if (acc_id == null) return NotFound();
            else
            {
                if (action_button == "edit") return await Edit(acc_id);
                if (action_button == "delete") return await Delete(acc_id);
            }
            return Content("And?");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            ViewBag.Access = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == id);
            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddSubscriptionModel model, int? acc_id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            var acc = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == acc_id);
            ViewBag.Access = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == acc_id);

            if (ModelState.IsValid)
            {
                if (model.Name != null) acc.Name = model.Name;
                acc.Description = model.Description;
                if (model.Price != acc.Price) acc.Price = model.Price;
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var acc = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == id);
            _context.Accesses.Remove(acc);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home", "Home");
        }
    }
}
