using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShkollaA1.Data;
using ShkollaA1.Models;

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


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Weeks,Hours")] Curriculum curriculum)
        {
            _context.Add(curriculum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curriculums == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculums.FindAsync(id);
            return View(curriculum);
        }

        // POST: Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Weeks,Hours")] Curriculum curriculum)
        {
            if (id != curriculum.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(curriculum);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var curriculumToDelete = _context.Curriculums.Where(x => x.Id == id).FirstOrDefault();
             _context.Remove(curriculumToDelete);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
