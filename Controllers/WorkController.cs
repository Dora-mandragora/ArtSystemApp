using ArtSystemApp.Models;
using ArtSystemApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                //потом подрузить, что необходимо
                return View(item);
            }
        }

        [HttpPost]
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
        public IActionResult Add(AddWorkModel model)
        {
            return View(model);
        }
    }
}
