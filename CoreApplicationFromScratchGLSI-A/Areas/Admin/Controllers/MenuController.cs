using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApplicationFromScratchGLSI_A.Data;
using CoreApplicationFromScratchGLSI_A.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> userManager;
        public MenuController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            this.userManager = userManager;

        }
        public IActionResult MenuListByUser()
        {
            var currentuser = userManager.GetUserId(User);
            
            var menus = _db.menus.Where(x => x.UserId == currentuser)
                .ToList();
            return View(menus);
        }
    }
}
