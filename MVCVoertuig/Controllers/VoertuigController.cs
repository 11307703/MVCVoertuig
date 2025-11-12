using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;
using MVCVoertuig.Models;

namespace MVCVoertuig.Controllers
{
    public class VoertuigController : Controller
    {
        private VoertuigDbContext _context;
        public VoertuigController(VoertuigDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.Voertuigen;
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Voertuig v)
        {
            _context.Voertuigen.Add(v);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Merk(string merk)
        {
            ViewBag.Merk = merk;
            return View(_context.Voertuigen.Where(x => x.Merk == merk));
        }
    }
}
