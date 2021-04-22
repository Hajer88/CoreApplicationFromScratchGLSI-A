using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApplicationFromScratchGLSI_A.Areas.Admin.Services;
using CoreApplicationFromScratchGLSI_A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _Icategoryservice;
        public CategoryController(ICategoryService _Icategoryservice)
        {
            this._Icategoryservice = _Icategoryservice;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> getCategories()
        {
            var categories = await _Icategoryservice.GetAllCategories();
            return Ok(categories);
        }
        [HttpPost("create")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var categorie = await _Icategoryservice.CreateCategory(category);
            return Ok(category);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> updateCategroy(int id, Category category)
        {
            var cat = await _Icategoryservice.EditCategory(id, category);
            return Ok(cat);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteConfirmedCategroy(int id, Category category)
        {
            var cat = await _Icategoryservice.DeleteCategory(id, category);
            return Ok(cat);
        }
    }
}
