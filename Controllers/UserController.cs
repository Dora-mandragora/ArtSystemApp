using ArtSystemApp.Models;
using ArtSystemApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSystemApp.Controllers
{
    public class UserController : Controller
    {
        private UserContext _context;
        public UserController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> UserTable()
        {
            var users = _context.Users.ToList();
            foreach(var user in users)
            {
                user.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Users.Contains(user));
                user.Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Users.Contains(user));
                user.Confirmation = await _context.Confirmations.FirstOrDefaultAsync(c => c.Users.Contains(user));
            }
            return View(users);
        }

        [HttpPost]
        public async Task<ActionResult> Define(int[] ids, string button)
        {
            if (button == "block_button") await Block(ids);
            if (button == "unblock_button") await Unblock(ids);
            if (button == "delete_button") await Delete(ids);
            if (button == "confirm_button") await Confirm(ids);
            if (button == "unconfirm_button") await Unconfirm(ids);

            return RedirectToAction("UserTable", "User");
        }

        async Task<ActionResult> Block(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                var s = await _context.Roles.FirstOrDefaultAsync(u => u.Users.Contains(el));
                if (s.Name != "admin")
                    el.Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Name == "block");
            }

            await _context.SaveChangesAsync();

            return Content("Ok");
        }

        async Task<ActionResult> Unblock(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                el.Status = await _context.Statuses.FirstOrDefaultAsync(s => s.Name == "active");
            }

            await _context.SaveChangesAsync();

            return Content("Ok");
        }

        async Task<ActionResult> Delete(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                _context.Remove(el);
            }

            await _context.SaveChangesAsync();

            return Content("Ok");
        }

        async Task<ActionResult> Confirm(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                el.Confirmation = await _context.Confirmations.FirstOrDefaultAsync(s => s.Name == "paid");
            }

            await _context.SaveChangesAsync();

            return Content("Ok");
        }

        async Task<ActionResult> Unconfirm(int[] ids)
        {
            foreach (var id in ids)
            {
                User el = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                el.Confirmation = await _context.Confirmations.FirstOrDefaultAsync(s => s.Name == "free");
            }

            await _context.SaveChangesAsync();

            return Content("Ok");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            ViewBag.User = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                Picture picture = null;
                if (model.Image != null)
                {
                    using (var binaryReader = new BinaryReader(model.Image.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Image.Length);
                    }
                    picture = new()
                    {
                        Format = new Format { Type = "png" },
                        Img = imageData
                    };
                    _context.Pictures.Remove(user.Image);
                    user.Image = picture;
                    _context.Pictures.Add(picture);
                }
                else ModelState.AddModelError("", "Email не правильного формата");
                if (model.Login != null) user.Login = model.Login;
                if (model.Email != null) user.Email = model.Email;
                if (model.Description != null) user.Description = model.Description;


                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Home");

            }
            return View(model);
        }
    }
}
