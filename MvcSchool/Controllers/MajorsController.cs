using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSchool.Models;
using Microsoft.AspNetCore.Authorization;

namespace MvcSchool.Controllers
{
    public class MajorsController : Controller
    {
        private readonly MvcSchoolContext _context;

        public MajorsController(MvcSchoolContext context)
        {
            _context = context;
        }

        // GET: Majors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Major.ToListAsync());
        }

        // GET: Majors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var major = await _context.Major
                .FirstOrDefaultAsync(m => m.MajorId == id);
            if (major == null)
            {
                return NotFound();
            }

            return View(major);
        }

        // GET: Majors/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Majors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MajorId,MajorName")] Major major)
        {
            if (ModelState.IsValid)
            {
                _context.Add(major);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(major);
        }

        // GET: Majors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var major = await _context.Major.FindAsync(id);
            if (major == null)
            {
                return NotFound();
            }
            return View(major);
        }

        // POST: Majors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MajorId,MajorName")] Major major)
        {
            if (id != major.MajorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(major);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MajorExists(major.MajorId))
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
            return View(major);
        }

        // GET: Majors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var major = await _context.Major
                .FirstOrDefaultAsync(m => m.MajorId == id);
            if (major == null)
            {
                return NotFound();
            }

            return View(major);
        }

        // POST: Majors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var major = await _context.Major.FindAsync(id);
            _context.Major.Remove(major);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MajorExists(int id)
        {
            return _context.Major.Any(e => e.MajorId == id);
        }
    }
}
