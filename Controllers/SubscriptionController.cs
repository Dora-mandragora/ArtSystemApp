using ArtSystemApp.Models;
using ArtSystemApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(AddSubscriptionModel model)
        {
            return View(model);
        }
    }
}
