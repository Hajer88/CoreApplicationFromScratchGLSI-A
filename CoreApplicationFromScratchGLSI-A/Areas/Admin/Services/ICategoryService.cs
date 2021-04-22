using CoreApplicationFromScratchGLSI_A.Models;
using CoreApplicationFromScratchGLSI_A.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<CategoryDTO> CreateCategory(Category category);
        Task<CategoryDTO> EditCategory(int id, Category category);
        Task<Category> DeleteCategory(int id, Category category);


    }
}
