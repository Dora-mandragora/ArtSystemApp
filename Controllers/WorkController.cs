using ArtSystemApp.Models;
using ArtSystemApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSystemApp.Controllers
{
    public class WorkController : Controller
    {
        private UserContext _context;
        public WorkController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return NotFound();
            else
            {
                var item = await _context.Works.FirstOrDefaultAsync(i => i.Id == id);
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
                if (user.Role.Name == "admin") ViewBag.IsAdmin = true;
                else ViewBag.IsAdmin = false;
                return View(item);
            }
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            if (user.Confirmation.Name == "paid") ViewBag.IsConfirm = true;
            else ViewBag.IsConfirm = false;
            ViewBag.Accesses = _context.Accesses.Where(a => a.User.Id == user.Id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddWorkModel model, int? acc)
        {
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            ViewBag.Accesses = _context.Accesses.Where(a => a.User.Id == user.Id);
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                Theme theme = null;
                Picture picture = null;
                Work work = null;
                Access access = null;
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
                    if (model.Theme != null)
                    {
                        theme = new()
                        {
                            Name = model.Theme
                        };
                    }

                    if (acc == null) access = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == 1);
                    else access = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == acc);
                    work = new()
                    {
                        User = user,
                        Name = model.Name,
                        Description = model.Description,
                        Theme = theme,
                        Image = picture,
                        Access = access
                    };
                }
                else ModelState.AddModelError("", "Изображение обязательно");           
                
               
                if (work != null)
                {
                    _context.Works.Add(work);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Home", "Home");
                }
            }            
            return View(model);
        }         

        [HttpGet]
        public async Task<IActionResult> Action(int? img_id, string action_button)
        {
            if (img_id == null) return NotFound();
            else
            {
                if(action_button == "edit") return await Edit(img_id);
                if(action_button == "delete") return await Delete(img_id);
            }
            return Content("And?");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            ViewBag.Accesses = _context.Accesses.Where(a => a.User.Id == user.Id);
            ViewBag.Work = await _context.Works.FirstOrDefaultAsync(w => w.Id == id);
            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddWorkModel model, int? acc, int? img_id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == User.Identity.Name);
            ViewBag.Accesses = _context.Accesses.Where(a => a.User.Id == user.Id);
            var work = await _context.Works.FirstOrDefaultAsync(w => w.Id == img_id);
            if (ModelState.IsValid)
            {
                Theme theme = null;

                if (model.Theme != null)
                {
                    theme = new()
                    {
                        Name = model.Theme
                    };
                    work.Theme = theme;
                }
                if (model.Name != null) work.Name = model.Name;
                work.Description = model.Description;

                if (acc != null) work.Access = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == acc);
                //work.Access = await _context.Accesses.FirstOrDefaultAsync(a => a.Id == 1);
                await _context.SaveChangesAsync();
                return RedirectToAction("Home", "Home");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var work = await _context.Works.FirstOrDefaultAsync(a => a.Id == id);
            _context.Works.Remove(work);
            _context.Pictures.Remove(work.Image);
            _context.Formats.Remove(work.Image.Format);
            await _context.SaveChangesAsync();
            return RedirectToAction("Home", "Home");
        }

        public async Task<ActionResult> GetImage(int id)
        {
            var image = await _context.Pictures.FirstOrDefaultAsync(c => c.Id == id);
            var format = image.Format;
            byte[] bytes = image.Img;
            if (bytes == null) return null;
            else return File(bytes, "image/" + format);
        }
    }
}
