using CoreApplicationFromScratchGLSI_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Services
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategory>> GetSubCatByCategory(Category category);
    }
}
