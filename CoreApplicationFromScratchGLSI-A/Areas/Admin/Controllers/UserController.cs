using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CoreApplicationFromScratchGLSI_A.Models;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        public UserController(UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> _rolemanager)
        {
            this._usermanager = usermanager;
            this._rolemanager = _rolemanager;
        }
        //Lister tous les utilisateurs
        public IActionResult UserManagement()
        {
            var users = _usermanager.Users;
            return View(users);
        }
        //Lister tous les roles des utilisateurs
        public IActionResult RoleManagement()
        {
            var roles = _rolemanager.Roles;
            return View(roles);
        }
    }
}
