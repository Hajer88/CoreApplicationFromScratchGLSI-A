using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreApplicationFromScratchGLSI_A.Areas.Admin.Services;
using CoreApplicationFromScratchGLSI_A.Models;
using CoreApplicationFromScratchGLSI_A.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _Icategoryservice;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService _Icategoryservice, IMapper _mapper)
        {
            this._Icategoryservice = _Icategoryservice;
            this._mapper = _mapper;
        }

        [HttpGet("categories")]
        public IActionResult getCategories()
        {
            var categories = _Icategoryservice.GetAllCategories();
            return Ok(categories);
        }
        [HttpPost("create")]
        public async Task<IActionResult> AddCategory(CategoryDTO categorydto)
        {
            var cat = _mapper.Map<Category>(categorydto);
            if (!ModelState.IsValid) return BadRequest();
            var categorie = await _Icategoryservice.CreateCategory(categorydto);
            return Ok(categorydto);
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
