using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSchool.Models;

namespace MvcSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly MvcSchoolContext _context;

        public CoursesController(MvcSchoolContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index(string searchLevel, string searchName, coursedate? searchDate, int searchTime)
        {
            //Use LINQ to get list of levels.
            IQueryable<string> levelQuery = from m in _context.Course
                                            orderby m.CourseLevel
                                            select m.CourseLevel;

            IQueryable<coursedate?> dateQuery = from m in _context.Course
                                           orderby m.CourseDate
                                           select m.CourseDate;

            IQueryable<int> timeQuery = from m in _context.Course
                                        orderby m.CourseTime
                                        select m.CourseTime;

            var courses = from c in _context.Course
                          select c;

            if(!String.IsNullOrEmpty(searchName))
            {
                courses = courses.Where(s => s.CourseName.Contains(searchName));
            }

            if(!String.IsNullOrEmpty(searchLevel))
            {
                courses = courses.Where(x => x.CourseLevel == searchLevel);
            }

            if (searchDate != null)
            {
                courses = courses.Where(x => x.CourseDate == searchDate);
            }

            if (searchTime != 0)
            {
                courses = courses.Where(x => x.CourseTime == searchTime);
            }

            var courseSearchVM = new CourseSearchViewModel
            {
                Levels = new SelectList(await levelQuery.Distinct().ToListAsync()),
                Dates = new SelectList(await dateQuery.Distinct().ToListAsync()),
                Times = new SelectList(await timeQuery.Distinct().ToListAsync()),
                Courses = await courses.ToListAsync()
            };

            return View(courseSearchVM);
        }
        
        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,CourseCredit,CourseLevel,MajorName,CourseDate,CourseTime")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName", course.MajorName);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName", course.MajorName);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName,CourseCredit,CourseLevel,MajorName,CourseDate,CourseTime")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
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
            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName", course.MajorName);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.CourseId == id);
        }
    }
}
