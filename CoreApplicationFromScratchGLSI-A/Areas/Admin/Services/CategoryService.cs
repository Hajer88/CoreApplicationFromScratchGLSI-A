using CoreApplicationFromScratchGLSI_A.Data;
using CoreApplicationFromScratchGLSI_A.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            //_db=new ApplicationDbContext();
            _db = db;
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.categories.ToListAsync();
        }
        public async Task<Category> CreateCategory(Category category)
        {
            _db.categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }
        public async Task<Category> EditCategory(int id, Category category)
        {
            var CatInDb = await _db.categories.FindAsync(id);
            CatInDb.Name = category.Name;
            await _db.SaveChangesAsync();
            return CatInDb;
        }
        public async Task<Category> DeleteCategory(int id, Category category)
        {
            var CatInDb = await _db.categories.FindAsync(id);
            _db.Remove(CatInDb);
            await _db.SaveChangesAsync();
            return CatInDb;
        }
    }
}
