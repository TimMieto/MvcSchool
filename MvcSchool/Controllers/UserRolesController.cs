using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSchool.Areas.Identity.Data;
using MvcSchool.Models;

namespace MvcSchool.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly SchoolUserContext _schoolUserContext;
        private readonly UserManager<MvcSchoolUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(
            SchoolUserContext schoolUserContext, 
            UserManager<MvcSchoolUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _schoolUserContext = schoolUserContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<UserRoleViewModel> roleUser = new List<UserRoleViewModel>();
            List<MvcSchoolUser> users = _schoolUserContext.Users.ToList();
            foreach (var item in users)
            {
                roleUser.Add(new UserRoleViewModel
                {
                    UserId = item.Id,
                    UserEmail = item.Email,
                    UserName = item.UserName,
                    Roles = await _userManager.GetRolesAsync(item)
                });
            }
            return View(roleUser);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string email)
        {
            var user = new MvcSchoolUser
            {
                UserName = email,
                Email = email
            };

            await _userManager.CreateAsync(user, "Password.123");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateUserToRole(string userName, string roleName, bool delete)
        //{
        //    var user = await _userManager.FindByNameAsync(userName);

        //    if (delete)
        //        await _userManager.RemoveFromRoleAsync(user, roleName);
        //    else
        //        await _userManager.AddToRoleAsync(user, roleName);


        //    IQueryable<string> roleNameQuery = from r in _schoolUserContext.Roles
        //                                       select r.Name;
        //    IQueryable<string> userNameQuery = from u in _schoolUserContext.Users
        //                                       select u.UserName;

        //    ViewBag.RoleNameList = new SelectList(await roleNameQuery.Distinct().ToListAsync());
        //    ViewBag.UserNameList = new SelectList(await userNameQuery.Distinct().ToListAsync());

        //    return RedirectToAction("Index");
        //}
    }


}