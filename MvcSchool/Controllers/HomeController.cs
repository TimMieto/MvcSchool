using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcSchool.Models;
using Microsoft.AspNetCore.Identity;
using MvcSchool.Areas.Identity.Data;

namespace MvcSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolUserContext _schoolUserContext;
        private readonly UserManager<MvcSchoolUser> _userManager;

        public HomeController(SchoolUserContext schoolUserContext, UserManager<MvcSchoolUser> userManager)
        {
            _schoolUserContext = schoolUserContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            //var users = _schoolUserContext.Users.ToList();
            //var user = users.First();
            //var aaf =await _userManager.GetRolesAsync(user);
            //return View(users);

            List<UserRoleViewModel> roleUser = new List<UserRoleViewModel>();
            List<MvcSchoolUser> users = _schoolUserContext.Users.ToList();
            foreach (var item in users)
            {
                roleUser.Add(new UserRoleViewModel { UserId = item.Id, UserEmail = item.Email, UserName = item.UserName, Roles = await _userManager.GetRolesAsync(item) });
            }
            return View(roleUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
