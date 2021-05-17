using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApplicationFromScratchGLSI_A.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize (Roles ="Admin")]
    [Authorize(Roles ="Customer")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        
        public async Task<IActionResult> Index()
        {
            return View(await _db.categories.ToListAsync());
        }
    }
}
