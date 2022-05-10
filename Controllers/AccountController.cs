using ArtSystemApp.Models;
using ArtSystemApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArtSystemApp.Controllers
{
    public class AccountController : Controller
    {
        private UserContext _context;
        public AccountController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == Hash.GetHashString(model.Password));
                if (user != null)
                {
                    user.Role = await _context.Roles.FirstOrDefaultAsync(r => r.Users.Contains(user));
                    user.Status = await _context.Statuses.FirstOrDefaultAsync(r => r.Users.Contains(user));
                    await Authenticate(user);                   
                    
                    if (user.Status.Id == 2)
                        ModelState.AddModelError("", "Пользователь заблокирован");
                    else
                        return RedirectToAction("Home", "Home");
                }
                else ModelState.AddModelError("", "Неверный логин или пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
                if(user == null)
                {
                    user = new User
                    {
                        Login = model.Login,
                        Email = model.Email,
                        Password = Hash.GetHashString(model.Password),
                        Confirmation = _context.Confirmations.FirstOrDefault(c => c.Name == "free"),
                        Status = _context.Statuses.FirstOrDefault(s => s.Name == "active"),
                        Role = _context.Roles.FirstOrDefault(r => r.Name == "user")
                    };

                    Access freeAccess = new() {Name = "Бесплатно", Price = 0, User = user, Description = "Доступ к работам по бесплатной подписке" };

                    _context.Users.Add(user);
                    _context.Accesses.Add(freeAccess);

                    await _context.SaveChangesAsync();
                    await Authenticate(user);
                    return RedirectToAction("Home", "Home");
                }
                ModelState.AddModelError("", "Пользователь с таким логином уже существует");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
