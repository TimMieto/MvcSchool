using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSchool.Models;
using MvcSchool.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MvcSchool.Areas.Identity.Data;

namespace MvcSchool.Controllers
{
    public class StudentsController : Controller
    {
        //private readonly MvcSchoolContext _context;
        //private readonly SchoolUserContext _contextUser;

        //public StudentsController(MvcSchoolContext context, SchoolUserContext contextUser)
        //{
        //    _context = context;
        //    _contextUser = contextUser;
        //}

        private readonly MvcSchoolContext _context;
        //private readonly SchoolUserContext _contextUser;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<MvcSchoolUser> _userManager;

        public StudentsController(
            MvcSchoolContext context,
        //    SchoolUserContext contextUser,
            IAuthorizationService authorizationService,
            UserManager<MvcSchoolUser> userManager)
        {
            _context = context;
        //    _contextUser = contextUser;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Title,StuFamilyName,StuGivenName,StuGender,StuBirth,MajorName,StuCredit")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                //绑定OwnerID
                student.OwnerID = _userManager.GetUserId(User);

                //用控制器
                var isAuthorized = await _authorizationService.AuthorizeAsync(User, student, ContactOperations.Create);
                if (!isAuthorized.Succeeded)
                {
                    return new ChallengeResult();
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName", student.MajorName);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            //Only if the OwnerId matches, user has the authorization to edit.
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, student,
                                                    ContactOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName", student.MajorName);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Title,StuFamilyName,StuGivenName,StuGender,StuBirth,MajorName,StuCredit")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    student.OwnerID = _userManager.GetUserId(User);
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, student,
                                                ContactOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            //　//submitted 機能
            //if (student.Status == ContactStatus.Approved)
            //{
            //    // If the contact is updated after approval, 
            //    // and the user cannot approve set the status back to submitted
            //    var canApprove = await _authorizationService.AuthorizeAsync(User, student,
            //                            ContactOperations.Approve);

            //    if (!canApprove.Succeeded) student.Status = ContactStatus.Submitted;
            //}

            ViewData["MajorName"] = new SelectList(_context.Major, "MajorName", "MajorName", student.MajorName);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentId == id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, student,
                            ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, student,
                                        ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
