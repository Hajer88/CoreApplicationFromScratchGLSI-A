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
        public UserController(UserManager<ApplicationUser> usermanager)
        {
            this._usermanager = usermanager;
        }
        //Lister tous les utilisateurs
        public IActionResult UserManagement()
        {
            var users = _usermanager.Users;
            return View(users);
        }
    }
}
