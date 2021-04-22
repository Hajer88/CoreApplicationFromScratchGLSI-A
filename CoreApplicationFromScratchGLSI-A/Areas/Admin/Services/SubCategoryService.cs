using CoreApplicationFromScratchGLSI_A.Data;
using CoreApplicationFromScratchGLSI_A.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Services
{
    public class SubCategoryService :ISubCategoryService
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
       public async Task<IEnumerable<SubCategory>> GetSubCatByCategory(Category category)
        {
            var subcat = await _db.subcategories.Include(c => c.category)
            .Where(c => c.category.Name == category.Name)
            .ToListAsync();
            return subcat;
        }
    }
}
