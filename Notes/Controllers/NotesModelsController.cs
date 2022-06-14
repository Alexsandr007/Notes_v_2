using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Models;

namespace Notes.Controllers
{
    public class NotesModelsController : Controller
    {
        private readonly MvcNotesContext _context;

        public NotesModelsController(MvcNotesContext context)
        {
            _context = context;
        }

        // GET: NotesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: NotesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notesModel = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notesModel == null)
            {
                return NotFound();
            }

            return View(notesModel);
        }

        // GET: NotesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotesModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Text")] NotesModel notesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notesModel);
        }

        // GET: NotesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notesModel = await _context.Movie.FindAsync(id);
            if (notesModel == null)
            {
                return NotFound();
            }
            return View(notesModel);
        }

        // POST: NotesModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Text")] NotesModel notesModel)
        {
            if (id != notesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotesModelExists(notesModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notesModel);
        }

        // GET: NotesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notesModel = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notesModel == null)
            {
                return NotFound();
            }

            return View(notesModel);
        }

        // POST: NotesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notesModel = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(notesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotesModelExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
