using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShkollaA1.Data;

namespace ShkollaA1.Controllers
{
    public class CurriculumController : Controller
    {

        private readonly ShkollaA1Context _context;

        public CurriculumController(ShkollaA1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (_context.Curriculums != null)
            {
                return View(await _context.Curriculums.ToListAsync());
            }
            else
            {
                return Problem("There are no curriculums!");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curriculums == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculums.FirstOrDefaultAsync(m => m.Id == id);
            return View(curriculum);
        }
    }
}
