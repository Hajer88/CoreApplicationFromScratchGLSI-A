using CoreApplicationFromScratchGLSI_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category> EditCategory(int id, Category category);
        Task<Category> DeleteCategory(int id, Category category);


    }
}
