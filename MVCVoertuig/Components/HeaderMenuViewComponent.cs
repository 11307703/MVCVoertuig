using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;
using MVCVoertuig.Models;

namespace MVCVoertuig.Components
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        private VoertuigDbContext _context;
        public HeaderMenuViewComponent(VoertuigDbContext context)
        {
            _context = context;
        }


        public IViewComponentResult Invoke()
        {
            var list = _context.Voertuigen
                .Select(x => x.Merk)
                .Distinct()
                .OrderBy(x => x);

            return View(list);
        }

    }
}
