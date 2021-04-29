using AutoMapper;
using CoreApplicationFromScratchGLSI_A.Data;
using CoreApplicationFromScratchGLSI_A.Models;
using CoreApplicationFromScratchGLSI_A.Models.DTO;
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
        private readonly IMapper _imapper;
        public CategoryService(ApplicationDbContext db,IMapper _mapper)
        {
            //_db=new ApplicationDbContext();
            _db = db;
            _imapper = _mapper;
        }
        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var cat = _db.categories.ToList();
            var catDTO = _imapper.Map<List<CategoryDTO>>(cat);
            //var categories =  from c in _db.categories
            //                 select new CategoryDTO()
            //                 {
            //                     Id = c.Id,
            //                     Name = c.Name
            //                 };
            return catDTO;
        }
        public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            var cat = _imapper.Map<Category>(categoryDTO);
            _db.categories.Add(cat);
            await _db.SaveChangesAsync();
            return categoryDTO;
        }
        public async Task<CategoryDTO> EditCategory(int id, Category category)
        {

            var CatInDb = await _db.categories.FindAsync(id);
            CatInDb.Name = category.Name;
            await _db.SaveChangesAsync();
            return _imapper.Map<Category,CategoryDTO>(category);
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
